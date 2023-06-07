using DAL.Contexts;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository;

public class UnitOfWork : IUnitOfWork
{
    private TestCurdContext context;
    public UnitOfWork(TestCurdContext context)
    {
        this.context = context;
        Employee = new EmployeeRepository(this.context);
    }
    
    public IEmployeeRepository Employee
    {
        get;
        private set;
    }
    public void Dispose()
    {
        context.Dispose();
    }
    public int Save()
    {
        return context.SaveChanges();
    }
}
