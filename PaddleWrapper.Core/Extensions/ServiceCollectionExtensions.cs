using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PaddleWrapper.Core.Configuration;
using PaddleWrapper.Core.Http;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models.Bulk;
using PaddleWrapper.Core.Services;
using PaddleWrapper.Core.Services.Bulk;
using PaddleWrapper.Core.Services.Cache;
using PaddleWrapper.Core.Services.Discounts;
using PaddleWrapper.Core.Services.Customers;
using PaddleWrapper.Core.Services.Adjustments;
using PaddleWrapper.Core.Services.Events;
using PaddleWrapper.Core.Services.Notifications;
using PaddleWrapper.Core.Services.Prices;
using PaddleWrapper.Core.Services.Transactions;
using PaddleWrapper.Core.Services.Reports;

namespace PaddleWrapper.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPaddleServices(
            this IServiceCollection services,
            Action<PaddleOptions> configureOptions)
        {
            services.Configure(configureOptions);
            services.AddScoped<IPaddleLogger, DefaultPaddleLogger>();
            services.AddMemoryCache();
            services.AddScoped<IPaddleCache, MemoryPaddleCache>();

            var sp = services.BuildServiceProvider();
            var logger = sp.GetRequiredService<IPaddleLogger>();
            var options = sp.GetRequiredService<IOptions<PaddleOptions>>();

            services.AddHttpClient<PaddleHttpClient>()
                .AddHttpMessageHandler(() => new CompressionHandler(logger, options))
                .AddPaddleRetryPolicies(logger);

            // Temel servisler
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<WebhookHandler>();

            // Yeni eklenen servisler
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IAdjustmentService, AdjustmentService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IPriceService, PriceService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IReportService, ReportService>();

            // Bulk işlem servisleri
            services.AddScoped(typeof(IBulkOperationHandler<,>), typeof(BulkOperationHandler<,>));
            
            return services;
        }
    }
} 