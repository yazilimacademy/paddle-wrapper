using Microsoft.AspNetCore.Mvc;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Event;

namespace PaddleWrapper.Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly ILogger<EventsController> _logger;

        public EventsController(IEventService eventService, ILogger<EventsController> logger)
        {
            _eventService = eventService;
            _logger = logger;
        }

        /// <summary>
        /// Lists all events
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<PaddleResponse<Event[]>>> ListEvents()
        {
            return await _eventService.ListEventsAsync();
        }

        /// <summary>
        /// Gets a specific event by ID
        /// </summary>
        [HttpGet("{eventId}")]
        public async Task<ActionResult<PaddleResponse<Event>>> GetEvent(string eventId)
        {
            return await _eventService.GetEventAsync(eventId);
        }

        /// <summary>
        /// Lists event types
        /// </summary>
        [HttpGet("types")]
        public async Task<ActionResult<PaddleResponse<EventType[]>>> ListEventTypes()
        {
            return await _eventService.GetEventTypesAsync();
        }
    }
}