using Cibertec.Models;
using Cibertec.Repositories.Northwind;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace Cibertec.Repositories.EntityFramework.Northwind
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DbContext context) : base(context)
        {
        }

        public int Count()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Customer> PagedList(int startRow, int endRow)
        {
            throw new System.NotImplementedException();
        }

        public Customer SearchByNames(string firstName, string lastName)
        {
            return _context.Set<Customer>().FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
