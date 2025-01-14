using PaddleWrapper;
using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using PaddleWrapper.Resources.Customers;
using Environment = PaddleWrapper.Environment;

class Program
{
    static async Task Main(string[] args)
    {
        // Paddle API anahtarını ayarlayın
        Options options = new(Environment.Sandbox);
        Client client = new("MY_BEAUTIFUL_SECRET_KEY", options);

        // Customers client örneği oluşturun
        CustomersClient customersClient = new(client);
        //CustomersClient customersClient = client.Customers;

        try
        {
            // Müşteri listesini alın
            CustomerCollection customers = await customersClient.ListAsync();
            Console.WriteLine($"Toplam müşteri sayısı: {customers.Count()}");

            // Her müşterinin bilgilerini yazdırın
            foreach (Customer customer in customers)
            {
                Console.WriteLine($"Müşteri ID: {customer.Id}");
                Console.WriteLine($"E-posta: {customer.Email}");
                Console.WriteLine($"Ad: {customer.Name}");
                Console.WriteLine("------------------------");
            }
        }
        catch (CustomerApiError ex)
        {
            Console.WriteLine($"Müşteri API Hatası:");
            Console.WriteLine($"Tip: {ex.Type}");
            Console.WriteLine($"Kod: {ex.Code}");
            Console.WriteLine($"Detay: {ex.Detail}");
            Console.WriteLine($"Dokümantasyon: {ex.DocumentationUrl}");

            if (ex.FieldErrors?.Any() == true)
            {
                Console.WriteLine("Alan Hataları:");
                foreach (FieldError fieldError in ex.FieldErrors)
                {
                    Console.WriteLine($"- Alan: {fieldError.Field}");
                    Console.WriteLine($"  Kod: {fieldError.Code}");
                    Console.WriteLine($"  Mesaj: {fieldError.Message}");
                }
            }
        }
        catch (ApiError ex)
        {
            Console.WriteLine($"API Hatası:");
            Console.WriteLine($"Tip: {ex.Type}");
            Console.WriteLine($"Kod: {ex.Code}");
            Console.WriteLine($"Detay: {ex.Detail}");
            Console.WriteLine($"Dokümantasyon: {ex.DocumentationUrl}");
        }
        catch (MalformedResponse ex)
        {
            Console.WriteLine($"Hatalı Yanıt Hatası: {ex.Message}");
            if (ex.InnerException != null)
            {
                Console.WriteLine($"İç Hata: {ex.InnerException.Message}");
            }
        }
        catch (SdkException ex)
        {
            Console.WriteLine($"SDK Hatası: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Beklenmeyen Hata: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
        }

        Console.WriteLine("İşlem tamamlandı. Çıkmak için bir tuşa basın...");
        Console.ReadKey();
    }
}
