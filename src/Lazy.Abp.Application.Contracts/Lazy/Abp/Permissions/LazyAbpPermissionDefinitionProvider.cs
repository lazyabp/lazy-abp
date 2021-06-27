using Lazy.Abp.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Lazy.Abp.Permissions
{
    public class LazyAbpPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var group = context.AddGroup(LazyAbpPermissions.GroupName, L("Permission:LazyAbp"));

            var noticeGroup = group.AddPermission(LazyAbpPermissions.Notification.Default, L("Permission:Notification"));
            noticeGroup.AddChild(LazyAbpPermissions.Notification.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<LazyAbpResource>(name);
        }
    }
}
