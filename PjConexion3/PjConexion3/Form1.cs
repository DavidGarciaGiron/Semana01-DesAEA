using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace PjConexion3
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["neptuno"].ConnectionString);

        public void ListaProductos()
        {
            using (SqlDataAdapter df = new SqlDataAdapter("Usp_ListaProductos_Neptuno", cn))
            {
                df.SelectCommand.CommandType = CommandType.StoredProcedure;
                using (DataSet Da = new DataSet())
                {
                    df.Fill(Da, "Productos");
                    DgProductos.DataSource = Da.Tables["Productos"];
                    lblTotal.Text = Da.Tables["Productos"].Rows.Count.ToString();
                }
            }
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            ListaProductos();
        }
    }
}
