﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWepAPI.Model
{
    public class SMSApplication
    {
        public string UserName { get; set; } = "ACdb6c8eb26449187c76afe22fc845631d";

        public string Password { get; set; } = "616af29b7ea8a863ada5cf1c0cf8fb02";

        public string FromNumber { get; set; } = "+13342319024";

        public long ToNumber { get; set; }
        [TempData]
        public string OTPNumber { get; set; } = "0";

        public string SendOTP { get; set; } 

    }
}
