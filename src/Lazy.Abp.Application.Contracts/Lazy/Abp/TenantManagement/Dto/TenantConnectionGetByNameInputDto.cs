﻿using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.TenantManagement;
using Volo.Abp.Validation;

namespace Lazy.Abp.TenantManagement
{
    public class TenantConnectionGetByNameInputDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [DynamicStringLength(typeof(TenantConnectionStringConsts), nameof(TenantConnectionStringConsts.MaxNameLength))]
        public string Name { get; set; }
    }
}
