using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Usar el espacio de nombre para la conexcion a SQL Server
using System.Data.SqlClient;
namespace pjConexion2
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }
        //realizar la cadena de conexion a la base de datos
        SqlConnection cn = new SqlConnection("Data Source=DESKTOP-0CFPOQB\\SQLEXPRESS;Initial Catalog=Neptuno;Integrated Security=True");

        public void ListaClientes()
        {
            using (SqlDataAdapter Df = new SqlDataAdapter("Select * from Clientes", cn))
            {
                using (DataSet Da= new DataSet())
                {
                    //llenar el dataset mediante el metodo fill del SqlDataAdapter
                    Df.Fill(Da, "Clientes");
                    //Mostrar los datos en el control DataGridView
                    dgClientes.DataSource = Da.Tables["Clientes"];
                    //mostrar el numero de clientes, pero en este ejemplo utilizar el DataSet
                    lblTotal.Text = Da.Tables["Clientes"].Rows.Count.ToString();
                }
            }
        }

        private void FrmClientes_Load_1(object sender, EventArgs e)
        {
            ListaClientes();

        }
    }
}
