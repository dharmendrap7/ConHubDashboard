using Conquerorhub.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquerorhub.SDK.ViewModels
{
   public class SubCommentsViewModel
    {
        public System.Guid SubCommentId { get; set; }
        public string UserId { get; set; }
        public Nullable<System.Guid> PostId { get; set; }
        public System.Guid CommentId { get; set; }
        public Nullable<System.DateTime> SubCommentDatetime { get; set; }
        public string SubCommentmsg { get; set; }
        public AspnetuserViewModel AspNetUser { get; set; }
    }
}
