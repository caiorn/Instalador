namespace InstaladorMapsCS
{
    partial class frm1Inicial
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

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm1Inicial));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAvancar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnSearchFolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(599, 337);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(83, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(437, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pack 20 Melhores Mapas CS 1.6";
            // 
            // btnAvancar
            // 
            this.btnAvancar.Enabled = false;
            this.btnAvancar.Location = new System.Drawing.Point(261, 443);
            this.btnAvancar.Name = "btnAvancar";
            this.btnAvancar.Size = new System.Drawing.Size(75, 23);
            this.btnAvancar.TabIndex = 3;
            this.btnAvancar.Text = "Avançar";
            this.btnAvancar.UseVisualStyleBackColor = true;
            this.btnAvancar.Click += new System.EventHandler(this.btnAvancar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 401);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Selecione a pasta cstrike do seu cs 1.6";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(15, 417);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(472, 20);
            this.txtPath.TabIndex = 6;
            this.txtPath.TextChanged += new System.EventHandler(this.txtPath_TextChanged);
            // 
            // btnSearchFolder
            // 
            this.btnSearchFolder.Location = new System.Drawing.Point(508, 417);
            this.btnSearchFolder.Name = "btnSearchFolder";
            this.btnSearchFolder.Size = new System.Drawing.Size(54, 20);
            this.btnSearchFolder.TabIndex = 5;
            this.btnSearchFolder.Text = "...";
            this.btnSearchFolder.UseVisualStyleBackColor = true;
            this.btnSearchFolder.Click += new System.EventHandler(this.bntSearchFolder_Click);
            // 
            // frm1Inicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 473);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnSearchFolder);
            this.Controls.Add(this.btnAvancar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm1Inicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mapas Cs 1.6";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAvancar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearchFolder;
        public System.Windows.Forms.TextBox txtPath;
    }
}

