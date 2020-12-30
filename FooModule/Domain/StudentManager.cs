using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Specifications;

namespace FooModule.Domain
{
    public class StudentManager : DomainService
    {
        public async Task ApplyingCredit(Student student)
        {
            if (!new AgeSpecification().IsSatisfiedBy(student))
            {
                throw new Exception("This student doesn't satisfy the Age specification!");
            }

            await Task.CompletedTask;
        }

        private readonly IRepository<Student, Guid> _repository;

        public StudentManager(IRepository<Student, Guid> studentRepository)
        {
            _repository = studentRepository;
        }

        public async Task<IEnumerable<Student>> Example0()
        {
            var query = _repository.Where(s => s.Age >= 18 && s.Balance < 1000);

            return await AsyncExecuter.ToListAsync(query);
        }

        public async Task<IEnumerable<Student>> Example1()
        {
            var query = _repository.Where(new AgeSpecification());

            return await AsyncExecuter.ToListAsync(query);
        }

        public async Task<IEnumerable<Student>> Example2()
        {
            var spec = new AgeSpecification().And(new BalanceSpecification());

            var query = _repository.Where(spec.ToExpression());

            return await AsyncExecuter.ToListAsync(query);
        }

        public async Task<IEnumerable<Student>> Example3()
        {
            var query = _repository.Where(new AgeAndBalanceSpecification());

            return await AsyncExecuter.ToListAsync(query);
        }
    }
}
