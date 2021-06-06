using Lazy.Abp.Localization;
using Volo.Abp.Application.Services;

namespace Lazy.Abp
{
    public abstract class LazyAbpAppService : ApplicationService
    {
        protected LazyAbpAppService()
        {
            LocalizationResource = typeof(LazyAbpResource);
            ObjectMapperContext = typeof(LazyAbpApplicationModule);
        }
    }
}
