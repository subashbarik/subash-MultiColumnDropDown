namespace MultiColumnDropDown
{
    partial class MultiColumnDropDown
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiColumnDropDown));
            this.btnMCD = new System.Windows.Forms.Button();
            this.txtMCD = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnMCD
            // 
            this.btnMCD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMCD.Image = ((System.Drawing.Image)(resources.GetObject("btnMCD.Image")));
            this.btnMCD.Location = new System.Drawing.Point(145, 2);
            this.btnMCD.Margin = new System.Windows.Forms.Padding(2);
            this.btnMCD.Name = "btnMCD";
            this.btnMCD.Size = new System.Drawing.Size(15, 20);
            this.btnMCD.TabIndex = 1;
            this.btnMCD.UseVisualStyleBackColor = true;
            // 
            // txtMCD
            // 
            this.txtMCD.Location = new System.Drawing.Point(2, 2);
            this.txtMCD.Margin = new System.Windows.Forms.Padding(2);
            this.txtMCD.Name = "txtMCD";
            this.txtMCD.Size = new System.Drawing.Size(143, 20);
            this.txtMCD.TabIndex = 2;
            // 
            // MultiColumnDropDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtMCD);
            this.Controls.Add(this.btnMCD);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MultiColumnDropDown";
            this.Size = new System.Drawing.Size(161, 25);
            this.Load += new System.EventHandler(this.MultiColumnDropDown_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMCD;
        private System.Windows.Forms.TextBox txtMCD;
    }
}
