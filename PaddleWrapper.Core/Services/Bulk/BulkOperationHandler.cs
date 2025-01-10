using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models.Bulk;

namespace PaddleWrapper.Core.Services.Bulk
{
    /// <summary>
    /// Genel bulk işlem handler'ı.
    /// </summary>
    public class BulkOperationHandler<TInput, TOutput> : IBulkOperationHandler<TInput, TOutput>
    {
        private readonly Func<TInput, Task<TOutput>> _processor;
        private readonly IPaddleLogger _logger;
        private BulkOperationStatus _status = BulkOperationStatus.Pending;
        private double _progress;
        private int _totalItems;
        private int _processedItems;

        public BulkOperationHandler(
            Func<TInput, Task<TOutput>> processor,
            IPaddleLogger logger)
        {
            _processor = processor;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<BulkOperationResult<TOutput>> ProcessAsync(
            IEnumerable<TInput> items,
            BulkOperationOptions options = null)
        {
            options ??= new BulkOperationOptions();
            var result = new BulkOperationResult<TOutput>();
            var itemsList = items.ToList();
            _totalItems = itemsList.Count;
            _processedItems = 0;
            _status = BulkOperationStatus.InProgress;

            try
            {
                _logger.LogInformation($"Starting bulk operation with {_totalItems} items");

                // Öğeleri batch'lere böl
                var batches = itemsList
                    .Select((item, index) => new { Item = item, Index = index })
                    .GroupBy(x => x.Index / options.BatchSize)
                    .Select(g => g.ToList())
                    .ToList();

                foreach (var batch in batches)
                {
                    var batchTasks = batch.Select(async item =>
                    {
                        try
                        {
                            var output = await _processor(item.Item);
                            return new { Success = true, Result = output, Error = default(BulkOperationError), Index = item.Index };
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError($"Error processing item at index {item.Index}", ex);
                            return new
                            {
                                Success = false,
                                Result = default(TOutput),
                                Error = new BulkOperationError
                                {
                                    Index = item.Index,
                                    Message = ex.Message,
                                    Details = ex.ToString()
                                },
                                Index = item.Index
                            };
                        }
                    });

                    // Paralel işleme
                    var batchResults = await Task.WhenAll(
                        batchTasks.ToList().InParallel(options.MaxDegreeOfParallelism));

                    // Sonuçları topla
                    foreach (var batchResult in batchResults)
                    {
                        if (batchResult.Success)
                        {
                            result.SuccessfulResults.Add(batchResult.Result);
                            result.SuccessCount++;
                        }
                        else
                        {
                            result.Errors.Add(batchResult.Error);
                            result.FailureCount++;

                            if (!options.ContinueOnError)
                            {
                                _status = BulkOperationStatus.Failed;
                                return result;
                            }
                        }

                        _processedItems++;
                        _progress = (double)_processedItems / _totalItems * 100;
                    }

                    if (options.DelayBetweenBatches > 0)
                    {
                        await Task.Delay(options.DelayBetweenBatches);
                    }
                }

                result.Success = result.FailureCount == 0;
                _status = result.Success ? BulkOperationStatus.Completed : BulkOperationStatus.PartiallyCompleted;
                _logger.LogInformation($"Bulk operation completed. Success: {result.SuccessCount}, Failures: {result.FailureCount}");
            }
            catch (Exception ex)
            {
                _status = BulkOperationStatus.Failed;
                _logger.LogError("Bulk operation failed", ex);
                throw;
            }

            return result;
        }

        /// <inheritdoc/>
        public BulkOperationStatus GetStatus() => _status;

        /// <inheritdoc/>
        public double GetProgress() => _progress;
    }

    /// <summary>
    /// Paralel işlem için extension method.
    /// </summary>
    internal static class ParallelExtensions
    {
        public static IEnumerable<Task<T>> InParallel<T>(
            this IEnumerable<Task<T>> tasks,
            int maxDegreeOfParallelism)
        {
            return tasks
                .Select((task, index) => new { Task = task, Index = index })
                .GroupBy(x => x.Index % maxDegreeOfParallelism)
                .SelectMany(group => group.Select(x => x.Task));
        }
    }
} 