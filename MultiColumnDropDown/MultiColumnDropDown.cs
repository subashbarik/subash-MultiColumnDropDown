using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MultiColumnDropDown
{
    public partial class MultiColumnDropDown: UserControl
    {
        //+ Grid related properties
        public DataGridView gridCtrl { get; set; }
        public TextBox txtCtrl { get; set; }
        public Button btnCtrl { get; set; }
        public int GridWidth { get; set; }
        public int GridHeight { get; set; }
        public int GridXPOS { get; set; }
        public int GridYPOS { get; set; }
        public int OffSetYPOS { get; set; }
        public bool bGridCreated { get; set; } = false;
        public bool bReadOnly { get; set; } = true;
        public bool bAllowUserToAddRows { get; set; } = false;
        public GridViewMCD objGVM = null;
        public List<GridViewData> lstGVD = null;

        public bool bGridSetup { get; set; } = false;
        public DataTable DtData { get; set; }
        public DataSet DsDataSet { get; set; }
        public SqlDataAdapter DA { get; set; }
        public BindingSource Source { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Sql { get; set; }
        public bool bFirstFetch { get; set; } = true;

        // - Grid related properties

        public MultiColumnDropDown()
        {
            InitializeComponent();
            //Initialize the button,textbox and gridview controls of MCD
            this.btnCtrl = this.btnMCD;
            this.txtCtrl = this.txtMCD;
            
        }

        public void SetUpGrid()
        {
            // Data fetching related property Initialization
            this.DtData = new DataTable();
            this.DsDataSet = new DataSet();
            this.DA = new SqlDataAdapter();
            this.Source = new BindingSource();
            this.gridCtrl = new DataGridView();

            // Setup Side and Position of the Grid
            Rectangle rectMCD = new Rectangle();
            rectMCD.X = this.GridXPOS;
            rectMCD.Y = this.GridYPOS + this.OffSetYPOS;
            rectMCD.Height = this.GridHeight;
            rectMCD.Width = this.GridWidth;

            this.gridCtrl.Size = new System.Drawing.Size(this.GridWidth, this.GridHeight);
            this.gridCtrl.Location = new Point(rectMCD.X, rectMCD.Y);

            //Setup Style - It can be modified to be customizable to be assigned value from out side 
            this.gridCtrl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.gridCtrl.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            //Header column cell style
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridCtrl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridCtrl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridCtrl.RowsDefaultCellStyle = dataGridViewCellStyle2;

            // Set read only property
            this.gridCtrl.ReadOnly = this.bReadOnly;
            this.gridCtrl.AllowUserToAddRows = this.bAllowUserToAddRows;

            //Assign events
            this.gridCtrl.Scroll += new System.Windows.Forms.ScrollEventHandler(this.PopUpGrid_Scroll);
            this.gridCtrl.SelectionChanged += new System.EventHandler(this.PopUpGrid_SelectionChanged);
            //this.PopUpGrid.Leave += new EventHandler(dgvProduct_Leave);
            //this.PopUpGrid.KeyDown += new KeyEventHandler(dgvProduct_KeyDown);
            this.gridCtrl.CellClick += new DataGridViewCellEventHandler(this.PopUpGrid_CellClick);


            // By Default grid should be invisible
            this.gridCtrl.Visible = false;

        }
        public virtual int GetDisplayedRowsCount()
        {
            int count = this.gridCtrl.Rows[this.gridCtrl.FirstDisplayedScrollingRowIndex].Height;
            count = this.gridCtrl.Height / count;
            return count;
        }

        public virtual void PopUpGrid_Scroll(object sender, ScrollEventArgs e)
        {  
            int display = this.gridCtrl.Rows.Count - this.gridCtrl.DisplayedRowCount(false);
            if (e.Type == ScrollEventType.SmallIncrement || e.Type == ScrollEventType.LargeIncrement)
            {
                if (e.NewValue >= this.gridCtrl.Rows.Count - GetDisplayedRowsCount())
                {
                    this.PageIndex = this.PageIndex + 1;
                    FetchDataAndMerge();
                    this.gridCtrl.FirstDisplayedScrollingRowIndex = display;
                }
            }
        }
        public virtual void PopUpGrid_SelectionChanged(object sender, EventArgs e)
        {
            this.gridCtrl.ClearSelection();
        }
        public virtual void PopUpGrid_CellClick(object sender, EventArgs e)
        {

        }

        private void MultiColumnDropDown_Load(object sender, EventArgs e)
        {
          
        }
        
       
        // Default code to load data into the gridview
        // should be implemented in the form level
        public virtual void FetchData()
        {
            // Prepare Sample data
            lstGVD = new List<GridViewData>();
            lstGVD.Add(new GridViewData { ID = 1, Name = "Test Name1" });
            lstGVD.Add(new GridViewData { ID = 2, Name = "Test Name2" });
            lstGVD.Add(new GridViewData { ID = 3, Name = "Test Name3" });
            lstGVD.Add(new GridViewData { ID = 4, Name = "Test Name4" });
            lstGVD.Add(new GridViewData { ID = 5, Name = "Test Name5" });
            this.gridCtrl.DataSource = lstGVD;
        }

        public virtual void FetchDataAndMerge()
        {
            lstGVD = new List<GridViewData>();
            lstGVD.Add(new GridViewData { ID = 1, Name = "Test Name1" });
            lstGVD.Add(new GridViewData { ID = 2, Name = "Test Name2" });
            lstGVD.Add(new GridViewData { ID = 3, Name = "Test Name3" });
            lstGVD.Add(new GridViewData { ID = 4, Name = "Test Name4" });
            lstGVD.Add(new GridViewData { ID = 5, Name = "Test Name5" });
            lstGVD.Add(new GridViewData { ID = 6, Name = "Test Name6" });
            lstGVD.Add(new GridViewData { ID = 7, Name = "Test Name7" });
            lstGVD.Add(new GridViewData { ID = 8, Name = "Test Name8" });
            lstGVD.Add(new GridViewData { ID = 9, Name = "Test Name9" });
            lstGVD.Add(new GridViewData { ID = 10, Name = "Test Name10"});

            this.gridCtrl.DataSource = lstGVD;
        }

        public virtual void TogglePopUpGrid()
        {
            if (this.gridCtrl.Visible == false)
            {
                if (this.bFirstFetch)
                {
                    FetchData();
                    this.bFirstFetch = false;
                }
                this.gridCtrl.ClearSelection();
                //this.Controls.Add(this.gridMCD);
                this.gridCtrl.Visible = true;
            }
            else
            {
                this.gridCtrl.Visible = false;
            }

        }

        public virtual void btnMCD_Click(object sender, EventArgs e)
        {
            TogglePopUpGrid();
        }
    }
}
