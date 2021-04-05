using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class Person
    {

        #region Propriedades

        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }

        #endregion

    }
}
