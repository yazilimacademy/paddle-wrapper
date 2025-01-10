using System;
using System.Collections.Generic;

namespace PaddleWrapper.Core.Models.Report
{
    /// <summary>
    /// Rapor bilgilerini temsil eden sınıf.
    /// </summary>
    public class Report
    {
        /// <summary>
        /// Rapor ID'si
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Rapor tipi
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Rapor durumu
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Rapor parametreleri
        /// </summary>
        public ReportParameters Parameters { get; set; }

        /// <summary>
        /// Rapor sonuçları
        /// </summary>
        public ReportResults Results { get; set; }

        /// <summary>
        /// Raporun oluşturulma tarihi
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Raporun tamamlanma tarihi
        /// </summary>
        public DateTime? CompletedAt { get; set; }

        /// <summary>
        /// Rapor meta verileri
        /// </summary>
        public Dictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();
    }

    /// <summary>
    /// Rapor parametrelerini temsil eden sınıf.
    /// </summary>
    public class ReportParameters
    {
        /// <summary>
        /// Başlangıç tarihi
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Bitiş tarihi
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gruplandırma (günlük, aylık, yıllık)
        /// </summary>
        public string GroupBy { get; set; }

        /// <summary>
        /// Filtreler
        /// </summary>
        public Dictionary<string, string> Filters { get; set; } = new Dictionary<string, string>();
    }

    /// <summary>
    /// Rapor sonuçlarını temsil eden sınıf.
    /// </summary>
    public class ReportResults
    {
        /// <summary>
        /// Rapor verileri
        /// </summary>
        public List<Dictionary<string, object>> Data { get; set; } = new List<Dictionary<string, object>>();

        /// <summary>
        /// Toplam kayıt sayısı
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// Rapor özeti
        /// </summary>
        public Dictionary<string, object> Summary { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// İndirilebilir dosya URL'i
        /// </summary>
        public string DownloadUrl { get; set; }

        /// <summary>
        /// Dosya formatı (CSV, Excel vb.)
        /// </summary>
        public string FileFormat { get; set; }
    }
} 