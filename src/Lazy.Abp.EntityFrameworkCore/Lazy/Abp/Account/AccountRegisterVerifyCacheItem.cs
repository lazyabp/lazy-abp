﻿namespace Lazy.Abp.Account
{
    public class AccountRegisterVerifyCacheItem
    {
        public string PhoneNumber { get; set; }
        public string VerifyCode { get; set; }
        public string VerifyToken { get; set; }
    }
}
