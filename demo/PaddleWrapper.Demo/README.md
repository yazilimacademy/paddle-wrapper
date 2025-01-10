# Paddle API Wrapper Demo

This is a demonstration project showcasing the usage of the Paddle API Wrapper library. It provides a complete example of how to integrate and use the Paddle API in your .NET applications.

## Features

### Product Management
- List all products
- Get product details
- Create new products
- Update existing products
- Delete products

### Price Management
- List all prices
- Get price details
- Create new prices
- Update existing prices
- Delete prices

### Customer Management
- List all customers
- Get customer details
- Create new customers
- Update existing customers
- Manage credit balances

### Discount Management
- List all discounts
- Get discount details
- Create new discounts
- Update existing discounts
- Delete discounts

### Transaction Management
- List all transactions
- Get transaction details
- Create new transactions
- Update existing transactions
- Preview transactions
- Get transaction invoices

### Report Management
- List all reports
- Get report details
- Create new reports
- Download reports

### Event Management
- List all events
- Get event details
- List event types

### Adjustment Management
- List all adjustments
- Get adjustment details
- Create new adjustments
- Preview adjustments

### Bulk Operations
- Create bulk operations
- Get bulk operation details
- List bulk operations
- Update bulk operations

### Notification Management (Webhooks)
- Configure notification endpoints
- Handle webhook events
- Process subscription-related notifications

## Getting Started

### Prerequisites

- .NET 9.0 or later
- A Paddle account with API credentials

### Configuration

1. Clone the repository
2. Update `appsettings.json` with your Paddle API credentials:
```json
{
  "Paddle": {
    "ApiKey": "YOUR_API_KEY_HERE",
    "VendorId": "YOUR_VENDOR_ID",
    "WebhookSecret": "YOUR_WEBHOOK_SECRET",
    "TimeoutSeconds": 30,
    "BaseUrl": "https://vendors.paddle.com/api/2.0",
    "RetryOptions": {
      "MaxRetries": 3,
      "CircuitBreakerThreshold": 5,
      "EnableCircuitBreaker": true,
      "CircuitBreakerDurationSeconds": 30
    },
    "CompressionOptions": {
      "EnableRequestCompression": true,
      "EnableResponseCompression": true,
      "MinimumSizeToCompress": 1024,
      "SupportedEncodings": ["gzip", "deflate"]
    }
  }
}
```

### Running the Demo

1. Build the project:
```bash
dotnet build
```

2. Run the application:
```bash
dotnet run
```

3. Open your browser and navigate to `https://localhost:7240` to access the Swagger UI.

## Example Requests

### Create a Product
```json
{
  "data": {
    "name": "Premium Plan",
    "description": "Premium subscription plan with advanced features",
    "type": "subscription",
    "tax_category": "digital-goods",
    "custom_data": {
      "features": ["feature1", "feature2"]
    }
  }
}
```

### Create a Price
```json
{
  "data": {
    "description": "Monthly subscription",
    "product_id": "pro_123",
    "billing_cycle": {
      "interval": "month",
      "frequency": 1
    },
    "unit_price": {
      "amount": "29.99",
      "currency_code": "USD"
    }
  }
}
```

### Create a Customer
```json
{
  "data": {
    "email": "customer@example.com",
    "name": "John Doe",
    "locale": "en",
    "custom_data": {
      "company": "Example Corp"
    }
  }
}
```

### Create a Transaction
```json
{
  "data": {
    "customer_id": "ctm_123",
    "address_id": "add_123",
    "business_id": "biz_123",
    "currency_code": "USD",
    "collection_mode": "automatic",
    "items": [
      {
        "price_id": "pri_123",
        "quantity": 1
      }
    ]
  }
}
```

### Create a Report
```json
{
  "data": {
    "type": "subscriptions",
    "filters": {
      "status": ["active", "past_due"],
      "date_from": "2024-01-01",
      "date_to": "2024-12-31"
    }
  }
}
```

### Create a Bulk Operation
```json
{
  "data": {
    "type": "price_update",
    "items": [
      {
        "price_id": "pri_123",
        "unit_price": {
          "amount": "39.99",
          "currency_code": "USD"
        }
      },
      {
        "price_id": "pri_456",
        "unit_price": {
          "amount": "49.99",
          "currency_code": "USD"
        }
      }
    ]
  }
}
```

## Testing Webhooks Locally

To test webhooks locally, you can use tools like ngrok:

1. Install ngrok
2. Run ngrok to create a tunnel:
```bash
ngrok http https://localhost:7240
```
3. Use the ngrok URL as your webhook destination

## Error Handling

The demo includes comprehensive error handling:
- Validation errors
- API errors
- Webhook processing errors

All errors are logged and appropriate HTTP status codes are returned.

## Logging

The application uses structured logging:
- Console output
- Debug output
- Configurable log levels

## Security

- HTTPS enforcement
- API key authentication
- Webhook signature verification
- Circuit breaker pattern
- Request/Response compression

## Additional Resources

- [Paddle API Documentation](https://developer.paddle.com)
- [PaddleWrapper Library Documentation](../README.md)
- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core) 