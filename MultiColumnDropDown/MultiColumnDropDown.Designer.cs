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
            this.txtMCD = new System.Windows.Forms.TextBox();
            this.btnMCD = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtMCD
            // 
            this.txtMCD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMCD.Location = new System.Drawing.Point(0, 0);
            this.txtMCD.Margin = new System.Windows.Forms.Padding(0);
            this.txtMCD.Name = "txtMCD";
            this.txtMCD.Size = new System.Drawing.Size(215, 23);
            this.txtMCD.TabIndex = 4;
            // 
            // btnMCD
            // 
            this.btnMCD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMCD.FlatAppearance.BorderSize = 0;
            this.btnMCD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMCD.Image = ((System.Drawing.Image)(resources.GetObject("btnMCD.Image")));
            this.btnMCD.Location = new System.Drawing.Point(216, 0);
            this.btnMCD.Margin = new System.Windows.Forms.Padding(0);
            this.btnMCD.Name = "btnMCD";
            this.btnMCD.Size = new System.Drawing.Size(22, 23);
            this.btnMCD.TabIndex = 3;
            this.btnMCD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMCD.UseVisualStyleBackColor = false;
            // 
            // MultiColumnDropDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtMCD);
            this.Controls.Add(this.btnMCD);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MultiColumnDropDown";
            this.Size = new System.Drawing.Size(238, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMCD;
        private System.Windows.Forms.Button btnMCD;
    }
}
