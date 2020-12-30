using System;
using System.Linq.Expressions;
using Volo.Abp.Specifications;

namespace FooModule.Domain
{
    public class BalanceSpecification : Specification<Student>
    {
        public override Expression<Func<Student, bool>> ToExpression()
        {
            return student => student.Balance < 1000;
        }
    }
}
