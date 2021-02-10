namespace Designer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnShowfrm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShowfrm
            // 
            this.btnShowfrm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowfrm.Font = new System.Drawing.Font("IRANSansWeb(FaNum)", 14F);
            this.btnShowfrm.Location = new System.Drawing.Point(50, 39);
            this.btnShowfrm.Name = "btnShowfrm";
            this.btnShowfrm.Size = new System.Drawing.Size(142, 54);
            this.btnShowfrm.TabIndex = 0;
            this.btnShowfrm.Text = "طراحی فاکتور";
            this.btnShowfrm.UseVisualStyleBackColor = true;
            this.btnShowfrm.Click += new System.EventHandler(this.btnShowfrm_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 134);
            this.Controls.Add(this.btnShowfrm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "طراحی فاکتور";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowfrm;
    }
}

