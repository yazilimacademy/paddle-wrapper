namespace PaddleWrapper.Core.Models.Bulk
{
    /// <summary>
    /// Bulk işlem durumlarını temsil eden enum.
    /// </summary>
    public enum BulkOperationStatus
    {
        Pending,
        InProgress,
        Completed,
        Failed,
        PartiallyCompleted
    }

    /// <summary>
    /// Bulk işlem sonuçlarını temsil eden sınıf.
    /// </summary>
    /// <typeparam name="T">İşlem sonucu dönen veri tipi.</typeparam>
    public class BulkOperationResult<T>
    {
        /// <summary>
        /// İşlem başarılı oldu mu?
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Başarılı işlem sayısı.
        /// </summary>
        public int SuccessCount { get; set; }

        /// <summary>
        /// Başarısız işlem sayısı.
        /// </summary>
        public int FailureCount { get; set; }

        /// <summary>
        /// Başarılı işlemlerin sonuçları.
        /// </summary>
        public List<T> SuccessfulResults { get; set; } = new List<T>();

        /// <summary>
        /// Başarısız işlemlerin hataları.
        /// </summary>
        public List<BulkOperationError> Errors { get; set; } = new List<BulkOperationError>();
    }

    /// <summary>
    /// Bulk işlem hata detaylarını temsil eden sınıf.
    /// </summary>
    public class BulkOperationError
    {
        /// <summary>
        /// Hatanın oluştuğu işlem indeksi.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Hata mesajı.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Hata detayları.
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Hatanın oluştuğu zaman.
        /// </summary>
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }

    /// <summary>
    /// Bulk işlem yapılandırma seçenekleri.
    /// </summary>
    public class BulkOperationOptions
    {
        /// <summary>
        /// Paralel işlenecek maksimum işlem sayısı.
        /// </summary>
        public int MaxDegreeOfParallelism { get; set; } = 5;

        /// <summary>
        /// Her bir batch'te işlenecek maksimum öğe sayısı.
        /// </summary>
        public int BatchSize { get; set; } = 100;

        /// <summary>
        /// İşlemler arası bekleme süresi (ms).
        /// </summary>
        public int DelayBetweenBatches { get; set; } = 1000;

        /// <summary>
        /// Hata durumunda işleme devam edilsin mi?
        /// </summary>
        public bool ContinueOnError { get; set; } = true;
    }

    /// <summary>
    /// Bulk işlem yöneticisi için interface.
    /// </summary>
    /// <typeparam name="TInput">Giriş veri tipi.</typeparam>
    /// <typeparam name="TOutput">Çıkış veri tipi.</typeparam>
    public interface IBulkOperationHandler<TInput, TOutput>
    {
        /// <summary>
        /// Bulk işlemi başlatır.
        /// </summary>
        Task<BulkOperationResult<TOutput>> ProcessAsync(
            IEnumerable<TInput> items,
            BulkOperationOptions options = null);

        /// <summary>
        /// İşlem durumunu kontrol eder.
        /// </summary>
        BulkOperationStatus GetStatus();

        /// <summary>
        /// İşlem ilerlemesini yüzde olarak döner.
        /// </summary>
        double GetProgress();
    }
}