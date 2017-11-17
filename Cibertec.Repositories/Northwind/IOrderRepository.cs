using Cibertec.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cibertec.Repositories.Northwind
{
    public interface IOrderRepository:IRepository<Order>
    {
        IEnumerable<Order> PagedList(int startRow, int endRow);

        int Count();
    }
}
