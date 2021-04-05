using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class EmployeeDB : IEmployeeDB
    {
        
        public List<Employee> GetAll()
        {
            string sql = Employee.GETALL;
            List<Employee> lst;

            using (var connection = new DB())
            {
                lst = TransformSQLReaderToList(connection.ExecQueryReturn(sql));
            }
            return lst;
        }

        private List<Employee> TransformSQLReaderToList(SqlDataReader returnData)
        {
            var lst = new List<Employee>();

            while (returnData.Read())
            {
                var item = new Employee()
                {
                    Id = int.Parse(returnData["id"].ToString()),
                    Name = returnData["name"].ToString(),
                    Telephone = returnData["telephone"].ToString()

                };
                lst.Add(item);
            }
            return lst;
        }

        public bool Insert(Employee employee)
        {
            bool status =  false;
            string sql = string.Format(Employee.INSERT, employee.Name, employee.Telephone);

            using (var connection = new DB())
            {
                status =  connection.ExecQuery(sql);
            }
            return status;
        }

        //Segundo momento:

        public Employee SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Employee funcionario)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
