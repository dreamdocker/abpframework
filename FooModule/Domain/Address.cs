using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Values;

namespace FooModule.Domain
{
    public class Address : ValueObject
    {
        public string Province { get; private set; }

        public string City { get; private set; }

        public string County { get; private set; }

        public string Street { get; private set; }

        public string ZipCode { get; private set; }

        public Address() { }

        public Address(string province, string city, string country, string street, string zipcode)
        {
            Province = province;
            City = city;
            County = country;
            Street = street;
            ZipCode = zipcode;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            // Using a yield return statement to return each element one at a time
            yield return Province;
            yield return City;
            yield return County;
            yield return Street;
            yield return ZipCode;
        }
    }
}
