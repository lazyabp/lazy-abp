using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Lazy.Abp.EntityFrameworkCore
{
    public class LazyAbpModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public LazyAbpModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}