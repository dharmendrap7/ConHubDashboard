using Conquerorhub.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquerorhub.DAL.DTO
{
   public class CommentDTO
    {
        public System.Guid Id { get; set; }
        public string UserId { get; set; }
        public System.Guid PostId { get; set; }
        public string CommentMessage { get; set; }
        public Nullable<System.DateTime> CommentedDate { get; set; }

        public AspnetUserDTO AspNetUser { get; set; }
    }
    public class CommentModelDTO
    {
        public string CommentDate { set; get; }
        public string UserName { set; get; }
        public string CommentId { set; get; }
        public bool result { set; get; }
        public string CommentMsg { set; get; }
    }

}
