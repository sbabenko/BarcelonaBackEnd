namespace BarcelonaBackEnd.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    namespace YourNamespace.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class ChatController : ControllerBase
        {
            // Endpoint for sending read receipt via HTTP
            [HttpPost("sendReadReceipt")]
            public IActionResult SendReadReceipt([FromBody] ReadReceiptDto receipt)
            {
                // Handle the logic to mark the message as read in the database or perform other actions
                // Example: Mark the message as read for the given user
                Console.WriteLine($"Read receipt received for message {receipt.MessageId} by {receipt.Username}");

                // Return a success response
                return Ok(new { success = true });
            }
        }
    }

}
