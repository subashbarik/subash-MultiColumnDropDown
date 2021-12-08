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
        //+ Grid related properties
        public DataGridView gridMCD { get; set; }
        public TextBox txtCtrl { get; set; }
        public Button btnCtrl { get; set; }
        public int GridWidth { get; set; }
        public int GridHeight { get; set; }
        public int GridXPOS { get; set; }
        public int GridYPOS { get; set; }
        public bool bGridCreated { get; set; } = false;
        public GridViewMCD objGVM = null;
        public List<GridViewData> lstGVD = null;
        // - Grid related properties

        public MultiColumnDropDown()
        {
            InitializeComponent();
            this.txtCtrl = this.txtMCD;
            this.btnCtrl = this.btnMCD;
            CreateGV();
        }

        private void MultiColumnDropDown_Load(object sender, EventArgs e)
        {
            /*if(!this.bGridCreated)
            {
                objGVM = new GridViewMCD();
                this.gridMCD = objGVM.gridMCD;
                this.bGridCreated = objGVM.bGridCreated;
                this.Controls.Add(this.gridMCD); // add the grid view control to the form
            }*/
          
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
        public virtual void ShowHideGV()
        {
            if(this.gridMCD.Visible == false)
            {
                LoadGV();
                this.gridMCD.AllowUserToAddRows = false;
                this.gridMCD.ClearSelection();

                //this.Controls.Add(this.gridMCD);

                //Create a rectangle to display the grid
                Rectangle rectMCD = new Rectangle();
                rectMCD.X = txtMCD.Location.X;
                rectMCD.Y = txtMCD.Location.Y + txtMCD.Height;
                rectMCD.Height = 95;
                rectMCD.Width = 199;

                this.gridMCD.Size = new Size(200, 100);
                this.gridMCD.Location = new Point(rectMCD.X, rectMCD.Y);
                this.gridMCD.BringToFront();

                this.gridMCD.Visible = true;

            }
            else
            {
                this.gridMCD.Visible = false;
            }
            
        }

        // Default code to hide gridview
        // should be implemented in the form level
        public virtual void HideGV()
        {
            this.gridMCD.Visible = false;
        }

        // Default code to load data into the gridview
        // should be implemented in the form level
        public virtual void LoadGV()
        {
            // Prepare Sample data
            lstGVD = new List<GridViewData>();
            lstGVD.Add(new GridViewData { ID = 1, Name = "Test Name1" });
            lstGVD.Add(new GridViewData { ID = 2, Name = "Test Name2" });
            lstGVD.Add(new GridViewData { ID = 3, Name = "Test Name3" });
            lstGVD.Add(new GridViewData { ID = 4, Name = "Test Name4" });

            this.gridMCD.DataSource = lstGVD;
        }

    }
}
