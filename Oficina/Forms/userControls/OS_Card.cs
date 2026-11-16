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

namespace Oficina.Forms.userControls
{
    public partial class OS_Card : UserControl
    {
        HistoricoOSTableAdapter Historico = new HistoricoOSTableAdapter();
        int id, id_historico;
        public OS_Card(int id, int id_historico)
        {
            InitializeComponent();
            this.id = id;
            this.id_historico = id_historico;
        }

        private void OS_Card_Load(object sender, EventArgs e)
        {
            DataTable historico = Historico.ver_historico(id, id_historico);
            if (historico.Rows.Count > 0)
            {
                try
                {
                    ID_Historico.Text = historico.Rows[0]["ID_Historico"].ToString();
                    ID_OS.Text = historico.Rows[0]["ID_OS"].ToString();
                    Status_Antigo.Text = historico.Rows[0]["Status_Anterior"].ToString();
                    Status_Posterior.Text = historico.Rows[0]["Status_Novo"].ToString();
                    Data_realizada.Text = historico.Rows[0]["Data_Alteracao"].ToString();
                    Observacao.Text = historico.Rows[0]["Observacao"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
