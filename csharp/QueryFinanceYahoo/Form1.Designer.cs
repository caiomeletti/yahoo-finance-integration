namespace QueryFinanceYahoo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            cmdAtualizar = new Button();
            txtFilename = new TextBox();
            cmdCarregar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Top;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1081, 529);
            dataGridView1.TabIndex = 1;
            // 
            // cmdAtualizar
            // 
            cmdAtualizar.Enabled = false;
            cmdAtualizar.Location = new Point(193, 572);
            cmdAtualizar.Name = "cmdAtualizar";
            cmdAtualizar.Size = new Size(175, 26);
            cmdAtualizar.TabIndex = 5;
            cmdAtualizar.Text = "&Atualizar";
            cmdAtualizar.UseVisualStyleBackColor = true;
            cmdAtualizar.Click += cmdAtualizar_Click;
            // 
            // txtFilename
            // 
            txtFilename.Location = new Point(12, 543);
            txtFilename.Name = "txtFilename";
            txtFilename.Size = new Size(1057, 23);
            txtFilename.TabIndex = 3;
            // 
            // cmdCarregar
            // 
            cmdCarregar.Location = new Point(12, 572);
            cmdCarregar.Name = "cmdCarregar";
            cmdCarregar.Size = new Size(175, 26);
            cmdCarregar.TabIndex = 4;
            cmdCarregar.Text = "&Carregar";
            cmdCarregar.UseVisualStyleBackColor = true;
            cmdCarregar.Click += cmdCarregar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1081, 606);
            Controls.Add(cmdCarregar);
            Controls.Add(txtFilename);
            Controls.Add(cmdAtualizar);
            Controls.Add(dataGridView1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Yahoo Finance Query";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridView1;
        private Button cmdAtualizar;
        private TextBox txtFilename;
        private Button cmdCarregar;
    }
}
