//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Conquerorhub.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class CH_SubComment
    {
        public System.Guid SubCommentId { get; set; }
        public string UserId { get; set; }
        public Nullable<System.Guid> PostId { get; set; }
        public System.Guid CommentId { get; set; }
        public Nullable<System.DateTime> SubCommentDatetime { get; set; }
        public string SubCommentmsg { get; set; }
    }
}
