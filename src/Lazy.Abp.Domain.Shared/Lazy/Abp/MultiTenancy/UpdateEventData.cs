﻿using System;

namespace Lazy.Abp.MultiTenancy
{
    public class UpdateEventData
    {
        public Guid Id { get; set; }

        public string OriginName { get; set; }

        public string Name { get; set; }
    }
}
