using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Ejemplo_Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            try
            {

                // crear una conexion
                SqlConnection mi_conexion = new SqlConnection(@"Data Source=LAPTOP-RHMTR2G9\SQLEXPRESS; Initial Catalog=probd; Integrated Security=True");
                // abrir una conexion
                mi_conexion.Open();
                //comando de consulta a la tabla de usuarios
                SqlCommand consulta = new SqlCommand("select nombre, clave, rol from usuario where nombre = '" + txt_usuario.Text + "' And clave = '" + txt_clave.Text + "' ", mi_conexion);

                // se ejecuta el comando de consulta

                consulta.ExecuteNonQuery();

                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter(consulta);

                da.Fill(ds, "usuario");

                DataRow dr;
                dr = ds.Tables["usuario"].Rows[0];

                if (txt_usuario.Text == dr["nombre"].ToString() || txt_clave.Text == dr["clave"].ToString())
                {

                    //instanciando el formulario principal
                    Principal frmPrincipal = new Principal();
                    frmPrincipal.Show();//abriendo el formulario principal
                    Hide();//esto sirve para ocultar el formulario de login

                }
                else
                {
                     MessageBox.Show("el usuario " + txt_usuario.Text +"---> " + dr["nombre"].ToString()+ " -- " +  txt_clave.Text + " --> "+ dr["clave"].ToString());
                }

                mi_conexion.Close();
            }
            catch
            {
                //en caso que la contraseña sea erronea mostrara un mensaje
                //dentro de los parentesis va: "Mensaje a mostrar","Titulo de la ventana",botones a mostrar en ste caso OK, icono a mostrar en este caso uno de error
                //MessageBox.Show("select nombre, clave, rol from usuarios where nombre = '" + txt_usuario.Text + "' And contraseña = '" + txt_clave.Text + "' ");

                MessageBox.Show("Error! Su contraseña y/o usuario son invalidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            //Salir de la aplicacion
            Application.Exit();
        }


        private void txt_usuario_TextChanged(object sender, EventArgs e)
        {
            btn_ingresar.Enabled = true;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            txt_clave.PasswordChar = '\0';
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            txt_clave.PasswordChar = '*';
        }

        private void lbl_intentos_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        protected void Listarpersonas()
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
