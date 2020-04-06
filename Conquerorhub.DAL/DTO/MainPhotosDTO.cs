using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquerorhub.DAL.DTO
{
   public class MainPhotosDTO
    {

        public System.Guid Id { get; set; }
        public string UserId { get; set; }
        public Nullable<System.Guid> PhotosId { get; set; }
        public byte[] BannerPicData { get; set; }
        public byte[] ProfilePicData { get; set; }
    }
}
