﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conquerorhub.DAL.DTO
{
   public class OtpVerificationDTO
    {
        public System.Guid Id { get; set; }
        public Nullable<System.Guid> EventId { get; set; }
        public string UserId { get; set; }
        public Nullable<int> OTP { get; set; }
    }
}
