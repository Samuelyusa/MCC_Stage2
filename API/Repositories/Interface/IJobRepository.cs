using API.Models;
using System.Collections.Generic;

namespace API.Repositories.Interface
{
    public interface IJobRepository
    {
        List<Jobs> Get();
        Jobs Get(int id);

        int Post(Jobs jobs);
        int Put(Jobs jobs);
        int Delete(int id);
    }
}
