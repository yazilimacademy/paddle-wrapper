using Microsoft.Extensions.DependencyInjection;
using PaddleWrapper.Configuration;
using PaddleWrapper.Interfaces;
using PaddleWrapper.Services;
using System;

namespace PaddleWrapper.Extensions
{
    /// <summary>
    /// Extension methods for IServiceCollection to add Paddle services
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds Paddle services to the service collection
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="configure">Action to configure Paddle options</param>
        public static IServiceCollection AddPaddleServices(
            this IServiceCollection services,
            Action<PaddleOptions> configure)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            services.Configure(configure);

            services.AddSingleton<PaddleOptions>(sp =>
            {
                PaddleOptions options = new PaddleOptions();
                configure(options);
                return options;
            });

            services.AddHttpClient();
            services.AddScoped<IPaddleClient, PaddleClient>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPriceService, PriceService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<INotificationService, NotificationService>();

            return services;
        }
    }
}