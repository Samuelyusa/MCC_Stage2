using API.Models;
using System.Collections.Generic;

namespace API.Repositories.Interface
{
    public interface IDepartmentRepository
    {
        List<Department> Get();
        Department Get(int id);

        int Post(Department department);
        int Put(Department department);
        int Delete(int id);
    }
}
