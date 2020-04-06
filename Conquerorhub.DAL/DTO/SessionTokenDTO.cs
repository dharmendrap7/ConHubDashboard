using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquerorhub.DAL.DTO
{
   public class SessionTokenDTO
    {
        public Guid id { get; set; }
        public string UserId { get; set; }
        public string SessionToken1{ get; set; }
        public Nullable<System.DateTime> CreatedDateandTime { get; set; }
        public Nullable<System.DateTime> ExpiryDateandTime { get; set; }
    }
}
