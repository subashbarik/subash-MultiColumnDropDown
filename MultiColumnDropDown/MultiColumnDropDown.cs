using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiColumnDropDown
{
    public partial class MultiColumnDropDown: UserControl
    {
        public DataGridView gridMCD { get; set; }
        public bool bGridCreated { get; set; } = false;
        public GridViewMCD objGVM = null;
        public MultiColumnDropDown()
        {
            InitializeComponent();
        }

        private void MultiColumnDropDown_Load(object sender, EventArgs e)
        {
            if(!this.bGridCreated)
            {
                objGVM = new GridViewMCD();
                this.gridMCD = objGVM.gridMCD;
                this.bGridCreated = objGVM.bGridCreated;
                this.Controls.Add(this.gridMCD); // add the grid view control to the form
            }
            
        }
        // default code to create a gridview can be modified in the form level
        public virtual void CreateGV()
        {
            // Create a Grid View in the constructor
            if (!this.bGridCreated)
            {
                gridMCD = new DataGridView();
                gridMCD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridMCD.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                //Header column cell style
                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
                dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
                dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
                dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
                dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
                dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
                gridMCD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
                gridMCD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
                dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                gridMCD.RowsDefaultCellStyle = dataGridViewCellStyle2;

                // Grid events should be assiged once , hence code is here
                // This should be handled at the form level where it will be used
                /* gridMCD.Leave += new EventHandler(dgvProduct_Leave);
                 gridMCD.KeyDown += new KeyEventHandler(dgvProduct_KeyDown);
                 gridMCD.CellClick += new DataGridViewCellEventHandler(dgvProduct_CellClick);*/

                gridMCD.ReadOnly = true;
                //groupBox2.Controls.Add(dgvProduct);
                //this.Controls.Add(dgvProduct);
                gridMCD.Visible = false;

                this.bGridCreated = true;
                // Below code should be handled at the form level where it will be used
                /*
                dgvProduct.DataSource = this.dtAvailableProducts;
                hideColumnsProductGrid();
                //setProductGridHeader();
                setProductGridColumnWidthProduct();
                dgvProduct.Refresh();
                dgvProduct.Update();
                dgvProduct.ClearSelection();
                reloadGrid("");
                */
            }
        }
        // Default code to draw an area where gird view will be displayed
        // should be implemented in the form level
        public virtual void ShowGV()
        {
            this.gridMCD.Visible = true;
            this.gridMCD.AllowUserToAddRows = false;
            this.gridMCD.ClearSelection();
        }

        // Default code to hide gridview
        // should be implemented in the form level
        public virtual void HideGV()
        {
            this.gridMCD.Visible = false;
        }

    }
}
