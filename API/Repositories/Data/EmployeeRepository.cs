using API.Context;
using API.Models;
using API.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;

namespace API.Repositories.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        MyContext mycontext;

        public EmployeeRepository(MyContext myContext)
        {
            this.mycontext = myContext;
        }

        public int Delete(int id)
        {
            var data = Get(id);
            mycontext.Employees.Remove(data);
            var result = mycontext.SaveChanges();
            return result;
        }

        public List<Employee> Get()
        {
            var data = mycontext.Employees.ToList();
            return data;
        }

        public Employee Get(int id)
        {
            var data = mycontext.Employees.Find(id);
            return data;
        }

        public int Put(Employee employee)
        {
            var data = Get(employee.EmployeeId);
            data.FirstName = employee.FirstName;
            data.DepartmentId = employee.DepartmentId;
            data.JobsId = employee.JobsId;
            mycontext.Employees.Update(data);
            var result = mycontext.SaveChanges();
            return result;
        }

        public int Post(Employee employee)
        {
            mycontext.Employees.Add(employee);
            var result = mycontext.SaveChanges();
            return result;
        }
    }
}
