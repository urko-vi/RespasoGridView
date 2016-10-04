using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestion.beans
{
    public class Trabajador
    {
        private int id;
        private string nombre;
        public Trabajador()
        {
            this.id = -1;
            this.nombre = "";
        }
        public int ID { get { return id; } set { id = value; } }
        public string NOMBRE { get { return nombre; } set { nombre = value; } }
    }
}