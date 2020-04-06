using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquerorhub.SDK.ViewModels
{
  public  class SubscriptionViewmodel
    {
        public System.Guid Id { get; set; }
        public string SubscriberUserId { get; set; }
        public string ProfileUserId { get; set; }
        public Nullable<bool> SubscriptionStatus { get; set; }
        public Nullable<System.DateTime> Datetime { get; set; }
    }
}
