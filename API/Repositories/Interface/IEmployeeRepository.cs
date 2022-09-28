using API.Models;
using System.Collections.Generic;

namespace API.Repositories.Interface
{
    public interface IEmployeeRepository
    {
        List<Employee> Get();
        Employee Get(int id);

        int Post(Employee employee);
        
        int Put(Employee employee);
        int Delete(int id);
    }
}
