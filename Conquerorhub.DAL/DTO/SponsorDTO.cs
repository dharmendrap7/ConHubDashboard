using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Conquerorhub.DAL.DTO
{
    public class SponsorDTO
    {
        public System.Guid Id { get; set; }
        public string UserId { get; set; }
        public byte[] Image { get; set; }
        public string Caption { get; set; }
        public Nullable<int> Like { get; set; }
        public string Comment { get; set; }
        public Nullable<bool> Private { get; set; }
        public Nullable<bool> Public { get; set; }
        public Nullable<System.DateTime> DateandTime { get; set; }
        public Nullable<System.Guid> ImageId { get; set; }

        public HttpPostedFileBase UploadedImage { get; set; }
    }
   
}
