using System;

namespace Gunnsoft.Common.Caching
{
    public class CacheSettings
    {
        static CacheSettings()
        {
            Default = new CacheSettings
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1)
            };
        }

        public TimeSpan AbsoluteExpirationRelativeToNow { get; set; }
        public static CacheSettings Default { get; set; }
        public TimeSpan? SlidingExpiration { get; set; }
    }
}