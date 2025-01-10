using Microsoft.AspNetCore.Mvc;
using PaddleWrapper.Interfaces;

namespace PaddleWrapperDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotifications()
        {
            PaddleWrapper.Models.Common.PaddleResponse<List<PaddleWrapper.Models.Notifications.Notification>> result = await _notificationService.ListNotificationsAsync();
            return Ok(result);
        }

        [HttpGet("{notificationId}")]
        public async Task<IActionResult> GetNotification(string notificationId)
        {
            PaddleWrapper.Models.Common.PaddleResponse<PaddleWrapper.Models.Notifications.Notification> result = await _notificationService.GetNotificationAsync(notificationId);
            return Ok(result);
        }

        [HttpGet("entities/{entityType}")]
        public async Task<IActionResult> GetEntityNotifications(string entityType)
        {
            PaddleWrapper.Models.Common.PaddleResponse<List<PaddleWrapper.Models.Notifications.Notification>> result = await _notificationService.ListEntityNotificationsAsync(entityType);
            return Ok(result);
        }

        [HttpGet("unread")]
        public async Task<IActionResult> GetUnreadNotifications()
        {
            PaddleWrapper.Models.Common.PaddleResponse<List<PaddleWrapper.Models.Notifications.Notification>> result = await _notificationService.ListUnreadNotificationsAsync();
            return Ok(result);
        }

        [HttpPost("{notificationId}/mark-as-read")]
        public async Task<IActionResult> MarkAsRead(string notificationId)
        {
            PaddleWrapper.Models.Common.PaddleResponse<PaddleWrapper.Models.Notifications.Notification> result = await _notificationService.MarkAsReadAsync(notificationId);
            return Ok(result);
        }

        [HttpPost("mark-all-as-read")]
        public async Task<IActionResult> MarkAllAsRead()
        {
            PaddleWrapper.Models.Common.PaddleResponse<List<PaddleWrapper.Models.Notifications.Notification>> result = await _notificationService.MarkAllAsReadAsync();
            return Ok(result);
        }
    }
}
