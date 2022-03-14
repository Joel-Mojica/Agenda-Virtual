using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidad
{
    public class E_agenda
    {
        private int id;
        private string nombre;
        private string apellido;
        private string correo;
        private int telefono;
        private string  fechaDeNacimiento;
        private string dirección;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo { get => correo; set => correo = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string FechaDeNacimiento { get => fechaDeNacimiento; set => fechaDeNacimiento = value; }
        public string Dirección { get => dirección; set => dirección = value; }
    }
}
