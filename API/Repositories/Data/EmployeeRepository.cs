using API.Context;
using API.Models;
using API.Repositories.Interface;
using API.ViewModel;
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

            //EmployeeViewModel employeeView = new EmployeeViewModel();
            //foreach (Employee employee in data)
            //{
            //    employeeView.Employees.Add();
            //}


            //data.FirstName = employeeView.FirstName;
            //data.JobsId = employeeView.JobsId;
            //data.DepartmentId = employeeView.DepartmentId;
            return data;

            //var data = mycontext.Employees.ToList();

            //List<EmployeeViewModel> dataList = new List<EmployeeViewModel>();
            //foreach (Employee employee in data)
            //{
            //    dataList.Add(new EmployeeViewModel()
            //    {
            //        EmployeeId = employee.EmployeeId,
            //        FirstName = employee.FirstName,
            //        DepartmentId = employee.DepartmentId,
            //        JobsId = employee.JobsId
            //    });
            //}
            //return dataList;

        }

        public Employee Get(int id)
        {
            var data = mycontext.Employees.Find(id);
            return data;
        }

        public int Post(Employee employee)
        {
            mycontext.Employees.Add(employee);
            var result = mycontext.SaveChanges();
            return result;
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

    }
}
