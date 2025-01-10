using System.Threading.Tasks;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Customer;

namespace PaddleWrapper.Core.Interfaces
{
    /// <summary>
    /// Müşteri işlemleri için servis arayüzü.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Müşteri detaylarını getirir.
        /// </summary>
        Task<PaddleResponse<Customer>> GetCustomerAsync(string customerId);

        /// <summary>
        /// Yeni bir müşteri oluşturur.
        /// </summary>
        Task<PaddleResponse<Customer>> CreateCustomerAsync(Customer customer);

        /// <summary>
        /// Mevcut bir müşteriyi günceller.
        /// </summary>
        Task<PaddleResponse<Customer>> UpdateCustomerAsync(string customerId, Customer customer);

        /// <summary>
        /// Müşteri listesini getirir.
        /// </summary>
        Task<PaddleResponse<Customer[]>> ListCustomersAsync();

        /// <summary>
        /// Müşterinin adreslerini getirir.
        /// </summary>
        Task<PaddleResponse<Address[]>> GetCustomerAddressesAsync(string customerId);

        /// <summary>
        /// Müşteriye yeni bir adres ekler.
        /// </summary>
        Task<PaddleResponse<Address>> AddCustomerAddressAsync(string customerId, Address address);

        /// <summary>
        /// Müşterinin adresini günceller.
        /// </summary>
        Task<PaddleResponse<Address>> UpdateCustomerAddressAsync(string customerId, string addressId, Address address);

        /// <summary>
        /// Müşterinin adresini siler.
        /// </summary>
        Task<PaddleResponse<bool>> DeleteCustomerAddressAsync(string customerId, string addressId);

        /// <summary>
        /// Müşterinin işletme bilgilerini getirir.
        /// </summary>
        Task<PaddleResponse<Business>> GetCustomerBusinessAsync(string customerId);

        /// <summary>
        /// Müşterinin işletme bilgilerini günceller.
        /// </summary>
        Task<PaddleResponse<Business>> UpdateCustomerBusinessAsync(string customerId, Business business);
    }
} 