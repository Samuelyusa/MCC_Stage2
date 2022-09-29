using API.Models;
using API.ViewModel;
using System.Collections.Generic;

namespace API.Repositories.Interface
{
    public interface IEmployeeRepository
    {
        List<EmployeeViewModel> Get();
        Employee Get(int id);

        int Post(Employee employee);
        
        int Put(Employee employee);
        int Delete(int id);
    }
}
