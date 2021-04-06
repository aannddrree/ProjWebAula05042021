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

        protected void GVEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GVEmployee.Rows[index];

            Employee a = new Employee();
            a.Id = Convert.ToInt32(row.Cells[0].Text);

            if (e.CommandName == "EXCLUIR")
            {
                string teste = "";
            }
            else if (e.CommandName == "ALTERAR")
            {
                string teste1 = "";
            }
        }
    }
}