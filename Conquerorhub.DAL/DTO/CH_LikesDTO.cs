﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquerorhub.DAL.DTO
{
   public class CH_LikesDTO
    {

        public System.Guid Id { get; set; }
        public Nullable<bool> LikeStatus { get; set; }
        public Nullable<System.Guid> Imageid { get; set; }
        public string SourceUserId { get; set; }
        public string DestinationUserId { get; set; }
        public Nullable<System.DateTime> DateandTime { get; set; }
    }
}