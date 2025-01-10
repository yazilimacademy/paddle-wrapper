# Paddle API Wrapper Demo

This is a demonstration project showcasing the usage of the Paddle API Wrapper library. It provides a complete example of how to integrate and use the Paddle API in your .NET applications.

## Features

- Subscription Management
  - List all subscriptions
  - Create new subscriptions
  - Update existing subscriptions
  - Cancel subscriptions

- Notification Management (Webhooks)
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
    "Environment": "sandbox",
    "TimeoutSeconds": 30,
    "MaxRetryAttempts": 3
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

## API Endpoints

### Subscriptions

- `GET /api/subscriptions` - List all subscriptions
- `POST /api/subscriptions` - Create a new subscription
- `PATCH /api/subscriptions/{id}` - Update a subscription
- `DELETE /api/subscriptions/{id}` - Cancel a subscription

### Webhooks

- `GET /api/webhooks` - List notification settings
- `POST /api/webhooks` - Create a notification endpoint
- `PATCH /api/webhooks/{id}` - Update notification settings
- `DELETE /api/webhooks/{id}` - Delete a notification endpoint
- `POST /api/webhooks/receive` - Webhook receiver endpoint

## Example Requests

### Create a Notification Endpoint

```json
{
  "data": {
    "type": "webhook",
    "description": "My webhook endpoint for subscription events",
    "destination": "https://your-domain.com/api/webhooks/receive",
    "active": true,
    "api_version": "1.0",
    "subscribed_events": [
      "subscription.created",
      "subscription.updated",
      "subscription.canceled"
    ]
  }
}
```

### Create a Subscription

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
- Webhook signature verification (recommended for production)

## Additional Resources

- [Paddle API Documentation](https://developer.paddle.com)
- [PaddleWrapper Library Documentation](../README.md)
- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core) 