using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquerorhub.SDK.ViewModels
{
   public class BlockViewModel
    {

        public int Id { get; set; }
        public string BlockingUser { get; set; }
        public string BlockedUser { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }



    }
}
