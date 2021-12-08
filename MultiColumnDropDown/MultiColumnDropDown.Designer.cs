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
            this.btnMCD = new System.Windows.Forms.Button();
            this.txtMCD = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnMCD
            // 
            this.btnMCD.Location = new System.Drawing.Point(199, 15);
            this.btnMCD.Name = "btnMCD";
            this.btnMCD.Size = new System.Drawing.Size(29, 22);
            this.btnMCD.TabIndex = 1;
            this.btnMCD.UseVisualStyleBackColor = true;
            // 
            // txtMCD
            // 
            this.txtMCD.Location = new System.Drawing.Point(36, 15);
            this.txtMCD.Name = "txtMCD";
            this.txtMCD.Size = new System.Drawing.Size(166, 22);
            this.txtMCD.TabIndex = 2;
            // 
            // MultiColumnDropDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtMCD);
            this.Controls.Add(this.btnMCD);
            this.Name = "MultiColumnDropDown";
            this.Size = new System.Drawing.Size(256, 55);
            this.Load += new System.EventHandler(this.MultiColumnDropDown_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMCD;
        private System.Windows.Forms.TextBox txtMCD;
    }
}
