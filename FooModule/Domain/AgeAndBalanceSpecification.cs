using System;
using System.Linq.Expressions;
using Volo.Abp.Specifications;

namespace FooModule.Domain
{
    public class AgeAndBalanceSpecification : AndSpecification<Student>
    {
        public AgeAndBalanceSpecification() : base(new AgeSpecification(), new BalanceSpecification())
        {

        }

        public override Expression<Func<Student, bool>> ToExpression()
        {
            return base.ToExpression().And(s => s.Age > 0);
        }
    }
}
