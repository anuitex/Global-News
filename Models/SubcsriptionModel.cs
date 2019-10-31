using NewsAPI.Constants;

namespace Models
{
    public class SubcsriptionModel
    {
        public string Email { get; set; }
        public Categories Category { get; set; }
        public bool SubscribeAll { get; set; }
    }
}
