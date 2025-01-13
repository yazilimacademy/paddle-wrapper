using PaddleWrapper;
using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Resources.Customers;
using Environment = PaddleWrapper.Environment;

class Program
{
    static async Task Main(string[] args)
    {
        // Paddle API anahtarını ayarlayın
        Options options = new(Environment.Sandbox);
        Client client = new("b9847347b603864b3ac8a5c3bd2b05a40b4fc591dc225e4fd2", options);

        // Customers client örneği oluşturun
        CustomersClient customersClient = new(client);

        Console.WriteLine((await customersClient.GetAsync("ctm_01jh8973bvkf4q66za2n0dvnvf")).Name);

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
        catch (Exception ex)
        {
            Console.WriteLine($"Hata oluştu: {ex.Message}");
            Console.WriteLine($"Stack Trace: {ex.StackTrace}");
        }

        Console.WriteLine("İşlem tamamlandı. Çıkmak için bir tuşa basın...");
        Console.ReadKey();
    }
}
