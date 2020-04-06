using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquerorhub.DAL.DTO
{
  public  class BlockDTO
    {

        public int Id { get; set; }
        public string BlockingUser { get; set; }
        public string BlockedUser { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
    }
}
