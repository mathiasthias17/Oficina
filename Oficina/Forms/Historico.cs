using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oficina.Dados.MecanicaDBTableAdapters;
using Oficina.Forms.userControls;

namespace Oficina.Forms
{
    public partial class Historico : Form
    {
        HistoricoOS1TableAdapter Historicos = new HistoricoOS1TableAdapter();
        int id;
        public Historico(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void Historico_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable ID = Historicos.pegar_id_historico(id);
                if (ID.Rows.Count > 0)
                {
                    for (int i = 0; i < ID.Rows.Count; i++)
                    {
                        OS_Card card = new OS_Card(id, Convert.ToInt32(ID.Rows[i]["ID_Historico"]));
                        flowLayoutPanel1.Controls.Add(card);
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
