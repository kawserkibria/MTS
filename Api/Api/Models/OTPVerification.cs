using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class OTPVerification
    {
        public string MobileNo { get; set; }
        public string Otpcode { get; set; }
    }
}