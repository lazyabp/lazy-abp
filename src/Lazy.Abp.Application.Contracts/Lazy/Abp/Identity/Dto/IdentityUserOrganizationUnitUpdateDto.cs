using System;
using System.ComponentModel.DataAnnotations;

namespace Lazy.Abp.Identity
{
    public class IdentityUserOrganizationUnitUpdateDto
    {
        [Required]
        public Guid[] OrganizationUnitIds { get; set; }
    }
}
