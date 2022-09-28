using API.Context;
using API.Models;
using API.Repositories.Interface;
using System.Collections.Generic;
using System.Linq;

namespace API.Repositories.Data
{
    public class DepartmentRepository : IDepartmentRepository
    {
        MyContext mycontext;

        public DepartmentRepository(MyContext myContext)
        {
            this.mycontext = myContext;
        }

        public int Delete(int id)
        {
            var data = Get(id);
            mycontext.Departments.Remove(data);
            var result = mycontext.SaveChanges();
            return result;
        }

        public List<Department> Get()
        {
            var data = mycontext.Departments.ToList();
            return data;
        }

        public Department Get(int id)
        {
            var data = mycontext.Departments.Find(id);
            return data;
        }

        public int Post(Department department)
        {
            mycontext.Departments.Add(department);
            var result = mycontext.SaveChanges();
            return result;
        }

        public int Put(Department department)
        {
            var data = Get(department.DepartmentId);
            data.Name = department.Name;
            mycontext.Departments.Update(data);
            var result = mycontext.SaveChanges();
            return result;
        }
    }
}
