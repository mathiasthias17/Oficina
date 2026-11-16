
namespace Oficina.Forms.userControls
{
    partial class OS_Card
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.ID_Historico = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ID_OS = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Status_Antigo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Status_Posterior = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Data_realizada = new System.Windows.Forms.Label();
            this.Observacao = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Número da alteração:";
            // 
            // ID_Historico
            // 
            this.ID_Historico.AutoSize = true;
            this.ID_Historico.Location = new System.Drawing.Point(115, 7);
            this.ID_Historico.Name = "ID_Historico";
            this.ID_Historico.Size = new System.Drawing.Size(0, 13);
            this.ID_Historico.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID da OS:";
            // 
            // ID_OS
            // 
            this.ID_OS.AutoSize = true;
            this.ID_OS.Location = new System.Drawing.Point(200, 7);
            this.ID_OS.Name = "ID_OS";
            this.ID_OS.Size = new System.Drawing.Size(0, 13);
            this.ID_OS.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Status anterior:";
            // 
            // Status_Antigo
            // 
            this.Status_Antigo.AutoSize = true;
            this.Status_Antigo.Location = new System.Drawing.Point(321, 7);
            this.Status_Antigo.Name = "Status_Antigo";
            this.Status_Antigo.Size = new System.Drawing.Size(0, 13);
            this.Status_Antigo.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Status posterior:";
            // 
            // Status_Posterior
            // 
            this.Status_Posterior.AutoSize = true;
            this.Status_Posterior.Location = new System.Drawing.Point(89, 26);
            this.Status_Posterior.Name = "Status_Posterior";
            this.Status_Posterior.Size = new System.Drawing.Size(0, 13);
            this.Status_Posterior.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Realizada em:";
            // 
            // Data_realizada
            // 
            this.Data_realizada.AutoSize = true;
            this.Data_realizada.Location = new System.Drawing.Point(317, 26);
            this.Data_realizada.Name = "Data_realizada";
            this.Data_realizada.Size = new System.Drawing.Size(0, 13);
            this.Data_realizada.TabIndex = 10;
            // 
            // Observacao
            // 
            this.Observacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Observacao.Location = new System.Drawing.Point(6, 46);
            this.Observacao.Name = "Observacao";
            this.Observacao.Size = new System.Drawing.Size(430, 56);
            this.Observacao.TabIndex = 11;
            // 
            // OS_Card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Observacao);
            this.Controls.Add(this.Data_realizada);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Status_Posterior);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Status_Antigo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ID_OS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ID_Historico);
            this.Controls.Add(this.label2);
            this.Name = "OS_Card";
            this.Size = new System.Drawing.Size(443, 108);
            this.Load += new System.EventHandler(this.OS_Card_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ID_Historico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ID_OS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Status_Antigo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Status_Posterior;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Data_realizada;
        private System.Windows.Forms.Label Observacao;
    }
}
