using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Employee : Person
    {
        public const string INSERT =  "INSERT INTO TB_EMPLOYEE (name, telephone) VALUES ('{0}', '{1}')";
        public const string GETALL =  "SELECT id, name, telephone FROM TB_EMPLOYEE";
        public const string GETBYID = "SELECT id, name, telephone FROM TB_EMPLOYEE WHERE id = {0}";
        public const string DELETE =  "DELETE FROM TB_EMPLOYEE WHERE id = {0}";
        public const string UPDATE =  "UPDATE TB_EMPLOYEE SET name = '{0}', telephone = '{1}' WHERE id = {2}";
    }
}
