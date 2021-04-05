using Dal;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjWebAula05042021
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            Employee employee = getData();
            var db = new EmployeeDB();

            if (db.Insert(employee))
            {
                LblMsg.Text = "Registro inserido!";
                LoadGrid();
            }
            else
                LblMsg.Text = "Erro ao inserir registro";
        }

        private Employee getData()
        {
            return new Employee()
            {
                Name = TxtNome.Text,
                Telephone = TxtTelefone.Text
            };
        }

        private void LoadGrid()
        {
            GVEmployee.DataSource = new EmployeeDB().GetAll();
            GVEmployee.DataBind();
        }
    }
}