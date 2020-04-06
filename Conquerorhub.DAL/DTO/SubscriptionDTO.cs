using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquerorhub.DAL.DTO
{
   public class SubscriptionDTO
    {
        public System.Guid Id { get; set; }
        public string SubscriberUserId { get; set; }
        public string ProfileUserId { get; set; }
        public Nullable<bool> SubscriptionStatus { get; set; }
        public Nullable<System.DateTime> Datetime { get; set; }
    }
}
