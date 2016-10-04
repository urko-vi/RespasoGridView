using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
namespace gestion
{
    public partial class persona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string codigo = Request.QueryString["codigo"];
            if (codigo!=null & codigo != "")//update
            {
                string connectionString = ConfigurationManager.ConnectionStrings["GESTPERSONALDesarrollo"].ConnectionString;
                string SQL = "SELECT idTrabajador, nombre FROM trabajadores WHERE trabajadorId = @id";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand(SQL, connection);
                cmd.Parameters.AddWithValue("@id", codigo);
                //recoger los paarametros de la select
                SqlDataReader dr = cmd.ExecuteReader();
                connection.Close();
                //capturar los datos del empleado para rellanar el formulario
                string nombre = "";
                txtNombreEmpleado.Text = nombre;
                codigoEmpleado.Value = codigo;
            }
            else//insert
            {
                //se resetea el formulario (se pone en blanco)
                codigoEmpleado.Value = "-1";
                txtNombreEmpleado.Text = "";
            }
        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            beans.Trabajador trabajador = new beans.Trabajador();
            trabajador.ID = Convert.ToInt32(codigoEmpleado.Value);
            trabajador.NOMBRE = txtNombreEmpleado.Text;
            string connectionString = ConfigurationManager.ConnectionStrings["GESTPERSONALDesarrollo"].ConnectionString;

            if (trabajador.ID > -1)//es una update
            {
                //se actualizarían todos los datos del registro de BBDD
                string SQL = "UPDATE trabajador SET nombre = '"+trabajador.NOMBRE+"' WHERE codigoTrabajador =@id" ;
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand(SQL, connection);
                cmd.Parameters.AddWithValue("@id", trabajador.ID);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            else//es una insert
            {
                string SQL = "INSERT trabajador(nombre) VALUES('@nombre')";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand(SQL, connection);
                cmd.Parameters.AddWithValue("@nombre", trabajador.NOMBRE);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            //EJECUTAR EL COMANDO
            Server.Transfer("index.aspx?msgcode=1", true);
        }

        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Server.Transfer("index.aspx", true);
        }
    }
}