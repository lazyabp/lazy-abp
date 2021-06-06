using System;

namespace Lazy.Abp.Permissions
{
    public class AbpSettingManagementPermissions
    {
        public const string GroupName = "AbpSettingManagement";

        public class Settings
        {
            public const string Default = GroupName + ".Settings";

            [Obsolete("The best way to do this is to enable the configuration administrator privileges", true)]
            public const string Update = GroupName + ".Update";

            public const string Manager = GroupName + ".Manager";
        }
    }
}
