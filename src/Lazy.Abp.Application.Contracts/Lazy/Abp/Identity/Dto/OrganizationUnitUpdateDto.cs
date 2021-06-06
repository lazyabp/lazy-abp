using Volo.Abp.ObjectExtending;

namespace Lazy.Abp.Identity
{
    public class OrganizationUnitUpdateDto : ExtensibleObject
    {
        public string DisplayName { get; set; }
    }
}
