namespace Tibia.Util
{
    partial class ClientChooser
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
            this.uxClients = new System.Windows.Forms.ComboBox();
            this.uxChoose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uxClients
            // 
            this.uxClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxClients.FormattingEnabled = true;
            this.uxClients.Location = new System.Drawing.Point(12, 12);
            this.uxClients.Name = "uxClients";
            this.uxClients.Size = new System.Drawing.Size(211, 21);
            this.uxClients.TabIndex = 0;
            this.uxClients.KeyUp += new System.Windows.Forms.KeyEventHandler(this.CommonKeyUp);
            // 
            // uxChoose
            // 
            this.uxChoose.Location = new System.Drawing.Point(229, 12);
            this.uxChoose.Name = "uxChoose";
            this.uxChoose.Size = new System.Drawing.Size(62, 23);
            this.uxChoose.TabIndex = 1;
            this.uxChoose.Text = "Choose";
            this.uxChoose.UseVisualStyleBackColor = true;
            this.uxChoose.Click += new System.EventHandler(this.uxChoose_Click);
            // 
            // ClientChooser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 48);
            this.Controls.Add(this.uxChoose);
            this.Controls.Add(this.uxClients);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ClientChooser";
            this.Text = "ClientChooser";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox uxClients;
        private System.Windows.Forms.Button uxChoose;
    }
}