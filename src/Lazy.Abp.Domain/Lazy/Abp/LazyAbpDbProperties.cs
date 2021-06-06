namespace Lazy.Abp
{
    public static class LazyAbpDbProperties
    {
        public static string DbTablePrefix { get; set; } = "LazyAbp";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "LazyAbp";
    }
}
