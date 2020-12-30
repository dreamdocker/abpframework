using System;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace FooModule.Domain
{
    public class Mouse1 : Entity<Guid>
    {
        public string Brand { get; set; }

        public float Price { get; set; }
    }

    public class Mouse2 : Entity<Guid>
    {
        protected Mouse2()
        {
        }

        public Mouse2(Guid id) : base(id)
        {
        }

        public string Brand { get; set; }

        public float Price { get; set; }
    }

    public class Mouse3 : Entity
    {
        public int MouseId { get; set; }

        public string BrandId { get; set; }

        public float Price { get; set; }

        public override object[] GetKeys()
        {
            return new object[] { MouseId, BrandId };
        }
    }


    public class Mouse4 : IEntity
    {
        public virtual int MouseId { get; set; }

        public virtual string BrandId { get; set; }

        public virtual float Price { get; set; }

        public virtual object[] GetKeys()
        {
            return new object[] { MouseId, BrandId };
        }
    }

    public class Mouse5 : Entity<int>, IFullAuditedObject
    {
        public string Brand { get; set; }

        public float Price { get; set; }

        public DateTime CreationTime { get; set; }

        public Guid? CreatorId { get; set; }

        public Guid? LastModifierId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public Guid? DeleterId { get; set; }

        public DateTime? DeletionTime { get; set; }

        public bool IsDeleted { get; set; }
    }

    public class Mouse6 : FullAuditedEntity<int>
    {
        public string Brand { get; set; }

        public float Price { get; set; }
    }


    public class Mouse7 : CreationAuditedEntity<Guid>
    {
        public string Brand { get; set; }

        public float Price { get; set; }
    }

    public class MyUser : Entity<Guid> { };

    public class Mouse8 : FullAuditedEntityWithUser<Guid, MyUser>
    {
        public string Brand { get; set; }

        public float Price { get; set; }
    }
}