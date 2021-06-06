using Lazy.Abp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Lazy.Abp
{
    public abstract class LazyAbpController : AbpController
    {
        protected LazyAbpController()
        {
            LocalizationResource = typeof(LazyAbpResource);
        }
    }
}
