using Conquerorhub.DAL;
using Conquerorhub.SDK.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquerorhub.SDK.ViewModels
{
   public class CommentViewModel
    {
        public System.Guid Id { get; set; }
        public string UserId { get; set; }
        public System.Guid PostId { get; set; }
        public string CommentMessage { get; set; }
        public Nullable<System.DateTime> CommentedDate { get; set; }

        public AspnetuserViewModel AspNetUser { get; set; }
    }
    public class CommentModel
    {
        public string CommentDate { set; get; }
        public string UserName { set; get; }
        public string CommentId { set; get; }
        public bool result { set; get; }
        public string CommentMsg { set; get; }
    }
}
