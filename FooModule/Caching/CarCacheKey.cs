using System;

namespace FooModule.Caching
{
    public class CarCacheKey
    {
        public Guid Id { get; set; }

        public string CarType { get; set; }

        public override string ToString()
        {
            return $"{Id}{CarType}";
        }
    }
}
