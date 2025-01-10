namespace PaddleWrapper.Core.Models.Customer
{
    /// <summary>
    /// İşletme bilgilerini temsil eden sınıf.
    /// </summary>
    public class Business
    {
        /// <summary>
        /// İşletme ID'si
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// İşletme adı
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Vergi numarası
        /// </summary>
        public string TaxNumber { get; set; }

        /// <summary>
        /// KDV numarası
        /// </summary>
        public string VatNumber { get; set; }

        /// <summary>
        /// İşletme numarası
        /// </summary>
        public string CompanyNumber { get; set; }

        /// <summary>
        /// İşletme adresi
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// İşletmenin kontakları
        /// </summary>
        public Contact[] Contacts { get; set; }

        /// <summary>
        /// İşletmenin oluşturulma tarihi
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// İşletmenin son güncelleme tarihi
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }

    /// <summary>
    /// İşletme kontağını temsil eden sınıf.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Kontak adı
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Kontak e-posta adresi
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Kontak telefon numarası
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Kontak rolü
        /// </summary>
        public string Role { get; set; }
    }
}