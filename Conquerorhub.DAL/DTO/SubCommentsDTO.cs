using Conquerorhub.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquerorhub.DAL.DTO
{
  public  class SubCommentsDTO
    {
        public System.Guid SubCommentId { get; set; }
        public string UserId { get; set; }
        public Nullable<System.Guid> PostId { get; set; }
        public System.Guid CommentId { get; set; }
        public Nullable<System.DateTime> SubCommentDatetime { get; set; }
        public string SubCommentmsg { get; set; }
        public  AspnetUserDTO AspNetUser { get; set; }
    }
}
