using CapaDatos;
using capaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaNegocios
{
    public class N_agenda
    {
        E_agenda objEntida = new E_agenda();
        D_agenda objDatos = new D_agenda();



        public List<E_agenda> buscarRegistroContacto(string buscar)
        {
            return objDatos.buscarContacto(buscar);
        }

        public void agregarRegistroContacto(E_agenda Contacto)
        {
            objDatos.agregarContacto(Contacto);
        }

        public void editarRegistroContacto(E_agenda Contacto)
        {
            objDatos.editarContacto(Contacto);
        }

        public void eliminarRegistroContacto(E_agenda Contacto)
        {
            objDatos.eliminarContacto(Contacto);
        }

    }
}
