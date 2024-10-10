namespace BarcelonaBackEnd.Models
{
    public class Message
    {
        public string Id { get; set; }
        public string User { get; set; }
        public string Text { get; set; }
        public List<string> ReadBy { get; set; } = new List<string>(); // List to track users who read the message
    }

}
