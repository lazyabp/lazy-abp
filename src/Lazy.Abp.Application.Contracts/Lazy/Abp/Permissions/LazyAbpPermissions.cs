using System;
using System.Collections.Generic;
using System.Text;

namespace Lazy.Abp.Permissions
{
    public static class LazyAbpPermissions
    {
        public const string GroupName = "LazyAbp";

        public class Notification
        {
            public const string Default = GroupName + ".Notification";

            public const string Delete = Default + ".Delete";
        }
    }
}
