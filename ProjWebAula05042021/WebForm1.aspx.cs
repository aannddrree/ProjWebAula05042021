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

            if (employee.Id == 0)
            {
                if (db.Insert(employee))
                {
                    LblMsg.Text = "Registro inserido!";
                }
                else
                    LblMsg.Text = "Erro ao inserir registro";
            }
            else
            {

                if (db.Update(employee))
                {
                    LblMsg.Text = "Registro atualizado!";
                }
                else
                    LblMsg.Text = "Erro ao atualizar registro";
            }

            LoadGrid();
        }

        private Employee getData()
        {
            return new Employee()
            {
                Name = TxtNome.Text,
                Telephone = TxtTelefone.Text,
                Id = string.IsNullOrEmpty(IdH.Value) ? 0 : int.Parse(IdH.Value)
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

            int id = Convert.ToInt32(row.Cells[0].Text);

            var db = new EmployeeDB();

            if (e.CommandName == "EXCLUIR")
            {
                db.Delete(id);
                LoadGrid();

            }
            else if (e.CommandName == "ALTERAR")
            {
                Employee employee = db.SelectById(id);

                TxtNome.Text = employee.Name;
                TxtTelefone.Text = employee.Telephone;
                IdH.Value = employee.Id.ToString();
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            TxtNome.Text = "";
            TxtTelefone.Text = "";
            IdH.Value = "0";
            TxtNome.Focus();
        }
    }
}