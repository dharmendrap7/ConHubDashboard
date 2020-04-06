﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquerorhub.DAL.DTO
{
   public class LastLoginDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string SessionToken { get; set; }
        public Nullable<System.DateTime> CreatedDateandTime { get; set; }
        public Nullable<System.DateTime> ExpiryDateTime { get; set; }
    }
}
