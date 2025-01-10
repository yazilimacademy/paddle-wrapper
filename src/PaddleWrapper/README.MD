# PaddleWrapper

A .NET SDK for the Paddle API. This wrapper provides a simple and intuitive way to interact with Paddle's API services.

## Installation

You can install the package via NuGet:

```bash
dotnet add package PaddleWrapper
```

## Usage

First, initialize the PaddleClient with your API key:

```csharp
var client = new PaddleClient("your-api-key");
```

### Working with Products

```csharp
// List all products
var products = await client.Products.ListAsync();

// Get a specific product
var product = await client.Products.GetAsync("prod_123");

// Create a new product
var newProduct = await client.Products.CreateAsync(new Product 
{
    Name = "My Product",
    Description = "Product description"
});

// Update a product
var updatedProduct = await client.Products.UpdateAsync("prod_123", product);
```

### Working with Prices

```csharp
// List all prices
var prices = await client.Prices.ListAsync();

// Get a specific price
var price = await client.Prices.GetAsync("pri_123");

// Create a new price
var newPrice = await client.Prices.CreateAsync(new Price 
{
    ProductId = "prod_123",
    Description = "Monthly subscription",
    UnitPrice = new PriceAmount 
    {
        Amount = 9.99m,
        CurrencyCode = "USD"
    }
});

// Update a price
await client.Prices.UpdateAsync("pri_123", price);
```

### Working with Discounts

```csharp
// List all discounts
var discounts = await client.Discounts.ListAsync();

// Get a specific discount
var discount = await client.Discounts.GetAsync("dsc_123");

// Create a new discount
var newDiscount = await client.Discounts.CreateAsync(new Discount 
{
    Code = "SUMMER2023",
    Type = "percentage",
    Description = "Summer Sale",
    Amount = new DiscountAmount 
    {
        Value = 20,
        Type = "percentage"
    }
});

// Update a discount
await client.Discounts.UpdateAsync("dsc_123", discount);
```

### Working with Addresses

```csharp
// List all addresses
var addresses = await client.Addresses.ListAsync();

// Get a specific address
var address = await client.Addresses.GetAsync("add_123");

// Create a new address
var newAddress = await client.Addresses.CreateAsync(new Address 
{
    CountryCode = "US",
    PostalCode = "94105",
    City = "San Francisco",
    FirstLine = "123 Main St",
    Description = "Main Office"
});

// Update an address
await client.Addresses.UpdateAsync("add_123", address);
```

### Working with Businesses

```csharp
// List all businesses
var businesses = await client.Businesses.ListAsync();

// Get a specific business
var business = await client.Businesses.GetAsync("biz_123");

// Create a new business
var newBusiness = await client.Businesses.CreateAsync(new Business 
{
    Name = "Acme Corp",
    CompanyNumber = "12345678",
    Contacts = new[] 
    {
        new BusinessContact 
        {
            IsPrimary = true,
            Name = "John Doe",
            Email = "john@acme.com"
        }
    }
});

// Update a business
await client.Businesses.UpdateAsync("biz_123", business);
```

### Working with Customers

```csharp
// List all customers
var customers = await client.Customers.ListAsync();

// Get a specific customer
var customer = await client.Customers.GetAsync("ctm_123");

// Create a new customer
var newCustomer = await client.Customers.CreateAsync(new Customer 
{
    Name = "John Doe",
    Email = "customer@example.com"
});
```

### Working with Transactions

```csharp
// List all transactions
var transactions = await client.Transactions.ListAsync();

// Get a specific transaction
var transaction = await client.Transactions.GetAsync("txn_123");

// Create a new transaction
var newTransaction = await client.Transactions.CreateAsync(new Transaction 
{
    CustomerId = "ctm_123",
    Items = new[] 
    {
        new TransactionItem 
        {
            Quantity = 1,
            PriceId = "pri_123"
        }
    }
});

// Preview a transaction
var preview = await client.Transactions.PreviewAsync(transaction);
```

### Working with Subscriptions

```csharp
// List all subscriptions
var subscriptions = await client.Subscriptions.ListAsync();

// Get a specific subscription
var subscription = await client.Subscriptions.GetAsync("sub_123");

// Create a new subscription
var newSubscription = await client.Subscriptions.CreateAsync(new Subscription 
{
    CustomerId = "ctm_123",
    Items = new[] 
    {
        new SubscriptionItem 
        {
            Quantity = 1,
            PriceId = "pri_123"
        }
    }
});

// Pause a subscription
await client.Subscriptions.PauseAsync("sub_123");

// Resume a subscription
await client.Subscriptions.ResumeAsync("sub_123");

// Cancel a subscription
await client.Subscriptions.CancelAsync("sub_123");
```

### Working with Webhooks

```csharp
// List all webhooks
var webhooks = await client.Webhooks.ListAsync();

// Get a specific webhook
var webhook = await client.Webhooks.GetAsync("whk_123");

// Create a new webhook
var newWebhook = await client.Webhooks.CreateAsync(new Webhook 
{
    Description = "My webhook",
    EndpointUrl = "https://your-domain.com/webhook",
    SubscribedEvents = new[] { "subscription.created", "subscription.updated" }
});

// Update a webhook
await client.Webhooks.UpdateAsync("whk_123", webhook);

// Delete a webhook
await client.Webhooks.DeleteAsync("whk_123");

// List webhook events
var events = await client.Webhooks.ListEventsAsync();

// Get a specific webhook event
var webhookEvent = await client.Webhooks.GetEventAsync("evt_123");
```

### Working with Notifications

```csharp
// List all notifications
var notifications = await client.Notifications.ListAsync();

// Get a specific notification
var notification = await client.Notifications.GetAsync("ntf_123");

// List notification attempts
var attempts = await client.Notifications.ListAttemptsAsync("ntf_123");

// Get a specific notification attempt
var attempt = await client.Notifications.GetAttemptAsync("ntf_123", "att_123");

// Replay a notification
await client.Notifications.ReplayAsync("ntf_123");
```

## Error Handling

The SDK uses standard HTTP status codes and throws exceptions when API calls fail. You should wrap API calls in try-catch blocks:

```csharp
try 
{
    var product = await client.Products.GetAsync("prod_123");
} 
catch (HttpRequestException ex) 
{
    // Handle API errors
    Console.WriteLine($"API error: {ex.Message}");
}
```

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is licensed under the GPL-3.0 License - see the LICENSE file for details.