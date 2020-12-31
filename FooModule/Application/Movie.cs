using System;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace FooModule.Application
{
    public class Movie : AggregateRoot<Guid>, IEntityDto<Guid>
    {
        public virtual string Name { get; protected set; }

        public virtual float? Price { get; set; }

        public new Guid Id { get => base.Id; set => base.Id = value; }

        protected Movie() { }

        public Movie(Guid id, [NotNull] string name, float? price = 0)
        {
            Id = id;
            ChangeName(name);
            Price = price;
        }

        public virtual void ChangeName([NotNull] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"name can not be empty or white space!");
            }

            if (name.Length > 20)
            {
                throw new ArgumentException($"name can not be longer than 10 chars!");
            }

            Name = name;
        }
    }
}
