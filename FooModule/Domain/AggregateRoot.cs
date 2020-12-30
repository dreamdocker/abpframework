using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace FooModule.Domain
{
    public class OrderAggregateRoot : FullAuditedAggregateRoot<Guid>
    {
        public virtual int TotalItemCount { get; protected set; }

        public virtual List<OrderItem> OrderItems { get; protected set; }

        public virtual Address StreetAddress { get; protected set; }

        protected OrderAggregateRoot()
        {
        }

        public OrderAggregateRoot(Guid id) : base(id)
        {
            OrderItems = new List<OrderItem>();
        }

        public void AddProduct(Guid productId, int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException("You can not add zero or negative count of products!", nameof(count));
            }

            var existingItems = OrderItems.FirstOrDefault(ol => ol.ProductId == productId);

            if (existingItems == null)
            {
                OrderItems.Add(new OrderItem(Id, productId, count));
            }
            else
            {
                existingItems.ChangeCount(existingItems.Count + count);
            }

            TotalItemCount += count;
        }
    }

    public class OrderItem : Entity
    {
        public virtual Guid OrderId { get; protected set; }

        public virtual Guid ProductId { get; protected set; }

        public virtual int Count { get; protected set; }

        protected OrderItem()
        {
        }

        internal OrderItem(Guid orderId, Guid productId, int count)
        {
            OrderId = orderId;
            ProductId = productId;
            Count = count;
        }

        internal void ChangeCount(int newCount)
        {
            Count = newCount;
        }

        public override object[] GetKeys()
        {
            return new object[] { OrderId, ProductId };
        }
    }
}
