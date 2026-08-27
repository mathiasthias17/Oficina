using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oficina
{
    public partial class SplashScreen : Form
    {
        Timer timer;
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            try { 
                timer = new Timer();
                timer.Interval = 100; // 100 milliseconds
                timer.Tick += Timer_Tick;
                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao iniciar o splash screen: " + ex.Message);
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {

            if (this.Opacity != 0)
            {
                this.Opacity -= 0.05;
            }
            else
            {
                timer.Stop();
                inicio form = new inicio();
                form.Show();
                this.Hide();
            }
        }
    }
}
