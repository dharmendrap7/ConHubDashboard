using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Conquerorhub.DAL.DTO
{
  public  class GalleryDTO
    {
        public List<string> Images { get; set; }
        //public List<LikesModel> LikeList { get; set; }
        public System.Guid Id { get; set; }
        public string UserId { get; set; }
        public Nullable<System.Guid> PostId { get; set; }
        public byte[] ImageData { get; set; }
        public string Caption { get; set; }
        public byte[] VideoData { get; set; }
        public string ContentType { get; set; }
        public HttpPostedFileBase UploadedPost { get; set; }
        public Nullable<System.DateTime> DateAndTime { get; set; }
    }
}
