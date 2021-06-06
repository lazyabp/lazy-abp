using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lazy.Abp.Identity
{
    public class OrganizationUnitAddUserDto
    {
        [Required]
        public List<Guid> UserIds { get; set; }
    }
}
