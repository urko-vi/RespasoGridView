using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace gestion
{
    public partial class index : System.Web.UI.Page
    {
        private DataTable dt;
             
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }


        public void cargarDatos()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GESTPERSONALDesarrollo"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string SQL = "SELECT * FROM trabajadores";
            SqlDataAdapter dAdapter = new SqlDataAdapter(SQL, connection);
            dAdapter.Fill(dt);
            gridEmpleados.DataSource = dt;
            gridEmpleados.DataBind();
            connection.Close();
        }

        protected void gridEmpleados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //para saber que fila has pulsado
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow gvrow = gridEmpleados.Rows[index];
            string comando = e.CommandName;
            int trabajadorId = Convert.ToInt32(gvrow.Cells[0].Text);
            if (comando == "editEmpleado")
            {
                Server.Transfer("persona.aspx?codigo="+trabajadorId,true);
                //GetById ---> te redirige
            }
            else//borrado
            {
             
                borrarRegistro(trabajadorId);
                cargarDatos();
            }
        }
        private void borrarRegistro(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["GESTPERSONALDesarrollo"].ConnectionString;
            string SQL = "DELETE FROM trabajadores WHERE trabajadorId = @id";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(SQL, connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        protected void crearEmpleado(object sender, EventArgs e)
        {
            Server.Transfer("persona.aspx", true);
        }
    }
}