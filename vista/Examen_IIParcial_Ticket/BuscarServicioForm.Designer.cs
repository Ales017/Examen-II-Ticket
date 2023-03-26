namespace Examen_IIParcial_Ticket
{
    partial class BuscarServicioForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ServicioDataGridView = new System.Windows.Forms.DataGridView();
            this.AceptarButton = new System.Windows.Forms.Button();
            this.DescripcionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CancelarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ServicioDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ServicioDataGridView
            // 
            this.ServicioDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServicioDataGridView.Location = new System.Drawing.Point(0, 157);
            this.ServicioDataGridView.Name = "ServicioDataGridView";
            this.ServicioDataGridView.RowHeadersWidth = 51;
            this.ServicioDataGridView.Size = new System.Drawing.Size(832, 248);
            this.ServicioDataGridView.TabIndex = 8;
            
            // 
            // AceptarButton
            // 
            this.AceptarButton.Location = new System.Drawing.Point(468, 82);
            this.AceptarButton.Name = "AceptarButton";
            this.AceptarButton.Size = new System.Drawing.Size(99, 46);
            this.AceptarButton.TabIndex = 7;
            this.AceptarButton.Text = "Aceptar";
            this.AceptarButton.UseVisualStyleBackColor = true;
            this.AceptarButton.Click += new System.EventHandler(this.AceptarButton_Click);
            // 
            // DescripcionTextBox
            // 
            this.DescripcionTextBox.Location = new System.Drawing.Point(93, 51);
            this.DescripcionTextBox.Name = "DescripcionTextBox";
            this.DescripcionTextBox.Size = new System.Drawing.Size(562, 22);
            this.DescripcionTextBox.TabIndex = 6;
            this.DescripcionTextBox.TextChanged += new System.EventHandler(this.DescripcionTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Descripción:";
            // 
            // CancelarButton
            // 
            this.CancelarButton.Location = new System.Drawing.Point(573, 82);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(99, 46);
            this.CancelarButton.TabIndex = 9;
            this.CancelarButton.Text = "Cancelar";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click_1);
            // 
            // BuscarServicioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 405);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.ServicioDataGridView);
            this.Controls.Add(this.AceptarButton);
            this.Controls.Add(this.DescripcionTextBox);
            this.Controls.Add(this.label1);
            this.Name = "BuscarServicioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BuscarServicioForm";
            this.Load += new System.EventHandler(this.BuscarServicioForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ServicioDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ServicioDataGridView;
        private System.Windows.Forms.Button AceptarButton;
        private System.Windows.Forms.TextBox DescripcionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CancelarButton;
    }
}