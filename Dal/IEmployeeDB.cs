using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public interface IEmployeeDB
    {
        bool Insert(Employee funcionario);
        bool Update(Employee funcionario);
        bool Delete(int id);
        Employee SelectById(int id);
        List<Employee> GetAll();
    }
}
