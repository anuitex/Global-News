using System;
using System.Collections.Generic;
using NewsAPI.Constants;

namespace Entities
{
    public class Subscription : BaseEntity
    {
        public string Email { get; set; }
        public Categories Category { get; set; }
        public bool SubscribeAll { get; set; }
    }
}
