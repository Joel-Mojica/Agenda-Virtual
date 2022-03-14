using CapaDatos;
using capaEntidad;
using capaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaVirtual
{

    public partial class index : Form
    {
        E_agenda objEnti = new E_agenda();
        D_agenda objDato = new D_agenda();
        N_agenda objNego = new N_agenda();

        private string idContacto;
        private bool editarse = false;
        public index()
        {
            InitializeComponent();
        }

        private void index_Load(object sender, EventArgs e)
        {
            mostrarContactosAgenda("");
            dataGridViewAgenda.ClearSelection();
        }

        public void mostrarContactosAgenda(string buscar)
        {
            dataGridViewAgenda.DataSource = objNego.buscarRegistroContacto(buscar);
        }

        private void txtBuscar_OnTextChange(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            mostrarContactosAgenda(txtBuscar.Text);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
      
                         
                           try
                           {
                               objEnti.Id = Convert.ToInt32(idContacto);
                               objEnti.Nombre = txtNombre.Text;
                                objEnti.Apellido = txtApellido.Text;
                                objEnti.Correo = txtCorreo.Text;
                                objEnti.Telefono = Convert.ToInt32(txtTelefono.Text);
                                objEnti.FechaDeNacimiento = txtFecha.Text;
                                objEnti.Dirección = txtDireccion.Text;
                                objNego.editarRegistroContacto(objEnti);

                               MessageBox.Show("Se modifico el contacto");
                               // para que actualize despues de dar ok
                               mostrarContactosAgenda("");
                                limpiar();
                           }
                           catch (Exception Error)
                           {
                               MessageBox.Show("no se pudo editar" + Error);
                           }  


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        public void limpiar()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtFecha.Text = "";
            txtDireccion.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                objEnti.Nombre = txtNombre.Text;
                objEnti.Apellido = txtApellido.Text;
                objEnti.Correo = txtCorreo.Text;
                objEnti.Telefono = Convert.ToInt32(txtTelefono.Text);
                objEnti.FechaDeNacimiento = txtFecha.Text;
                objEnti.Dirección = txtDireccion.Text;

                objNego.agregarRegistroContacto(objEnti);

                MessageBox.Show("Se guardo el contacto");
                // para que actualize despues de dar ok
                mostrarContactosAgenda("");
                limpiar();
            }
            catch (Exception Error)
            {
                MessageBox.Show("no se pudo guardar" + Error);
            }
        }

        private void btnTraer_Click(object sender, EventArgs e)
        {
            if (dataGridViewAgenda.SelectedRows.Count > 0)
            {
                idContacto = dataGridViewAgenda.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dataGridViewAgenda.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = dataGridViewAgenda.CurrentRow.Cells[2].Value.ToString();
                txtCorreo.Text = dataGridViewAgenda.CurrentRow.Cells[3].Value.ToString();
                txtTelefono.Text = dataGridViewAgenda.CurrentRow.Cells[4].Value.ToString();
                txtFecha.Text = dataGridViewAgenda.CurrentRow.Cells[5].Value.ToString();
                txtDireccion.Text = dataGridViewAgenda.CurrentRow.Cells[6].Value.ToString();
                
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewAgenda.SelectedRows.Count > 0)
            {
                objEnti.Id = Convert.ToInt32(dataGridViewAgenda.CurrentRow.Cells[0].Value);
                objNego.eliminarRegistroContacto(objEnti);

                MessageBox.Show("Se ha eliminado el contacto correctamente");
                mostrarContactosAgenda("");

            }
        }
    }
}
