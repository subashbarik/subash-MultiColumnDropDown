
/*                      Auther : Subash Chandra Barik 
 *                      Date   : 11-12-2021
 *                      Purpose: Purpose of the UserControl is to show multi column grid. It consists of a TextBox Control,
 *                               a Button Control and a DataGridView Control. It display the DataGridView Control when the
 *                               Button Control is Clicked. MultiColumnDropDown class serves as a Base Class hence it exposes
 *                               many functionality and events which can be extended in the Child class. The main usage of this
 *                               UserControl is to display only few records in the  DataGridView Control (which can be configured)
 *                               and fetch more records when scroll event of the DataGridView is fired ,it is helpful when we have
 *                               huges number of records in the table.
 *                               
 * 
 */
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
        public string WhereVal { get; set; } // If we type a value in the textbox control such text will be searched and match records will be displayed in the grid
        public string Sql { get; set; }
        public bool bFirstFetch { get; set; } = true;
        // - Grid related properties
        //+ TextBox Control Properties
        public string txtCtrlText { get; set; }
        public string txtCtrlValue { get; set; }
        //- TextBox Control Properties

        public MultiColumnDropDown()
        {
            InitializeComponent();
            //Initialize the button,textbox and gridview controls of MCD
            this.btnCtrl = this.btnMCD;
            this.txtCtrl = this.txtMCD;
            
        }
        #region CoreCode
        public virtual void SetUpGrid()
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
            //GridView Event Handlers
            this.gridCtrl.Scroll += new System.Windows.Forms.ScrollEventHandler(this.PopUpGrid_Scroll);
            this.gridCtrl.SelectionChanged += new System.EventHandler(this.PopUpGrid_SelectionChanged);
            this.gridCtrl.Leave += new EventHandler(this.PopUpGrid_Leave);
            this.gridCtrl.KeyDown += new KeyEventHandler(this.PopUpGrid_KeyDown);
            this.gridCtrl.CellClick += new DataGridViewCellEventHandler(this.PopUpGrid_CellClick);
            /*this.gridCtrl.Click += new System.EventHandler(this.PopUpGrid_Click);
            this.gridCtrl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PopUpGrid_MouseMove);*/
            this.gridCtrl.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridCtrl_DataBindingComplete);
            //TextBox Event Handlers
            this.txtCtrl.KeyUp += new KeyEventHandler(this.txtCtrl_KeyUp);
            this.txtCtrl.TextChanged += new EventHandler(this.txtCtrl_TextChanged);
            //Button Event Handlers
            this.btnCtrl.Click += new EventHandler(this.btnCtrl_Click);
            // By Default grid should be invisible
            this.gridCtrl.Visible = false;

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
            lstGVD.Add(new GridViewData { ID = 10, Name = "Test Name10" });

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
                this.gridCtrl.Visible = true;
            }
            else
            {
                this.gridCtrl.Visible = false;
            }

        }

        public virtual void btnCtrl_Click(object sender, EventArgs e)
        {
            TogglePopUpGrid();
        }
        #endregion
        #region Virtual Implementation of GridView Event handlers
        // + Virtual Implementation of GridView Events handlers
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
            //this.gridCtrl.ClearSelection();
        }
        /*public virtual void PopUpGrid_Click(object sender, EventArgs e)
        {

        }
        public virtual void PopUpGrid_MouseMove(object sender, MouseEventArgs e)
        {

        }*/
        public virtual void PopUpGrid_CellClick(object sender, EventArgs e)
        {
            this.SelectRecordFromGrid();
        }
        public virtual void PopUpGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                hideGridView();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                this.SelectRecordFromGrid();
            }
        }
        public virtual void PopUpGrid_Leave(object sender, EventArgs e)
        {
        }
        public virtual void gridCtrl_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.gridCtrl.ClearSelection();
        }
        private void MultiColumnDropDown_Load(object sender, EventArgs e)
        {
          
        }
        public virtual void hideGridView()
        {
            this.gridCtrl.Visible = false;
        }
        public virtual void SelectRecordFromGrid()
        {
            this.txtCtrlText = this.gridCtrl.CurrentRow.Cells["Name"].Value.ToString();
            this.txtCtrlValue = this.gridCtrl.CurrentRow.Cells["ID"].Value.ToString();
            this.txtCtrl.Text = this.gridCtrl.CurrentRow.Cells["Name"].Value.ToString();
            this.gridCtrl.Visible = false;
        }
        public virtual void focusPopupGrid(string keyCode)
        {
            // Put the focus in the popup grid and select the first record
            if ((keyCode.ToUpper() == "DOWN") || (keyCode.ToUpper() == "UP"))
            {
                if (this.gridCtrl.Visible == true)
                {
                    if (this.gridCtrl.Rows.Count != 0)
                    {
                        this.gridCtrl.Focus();
                        this.gridCtrl.Rows[0].Selected = true;
                    }
                }
            }
        }
        // - Virtual Implementation of GridView Events handlers
        #endregion

        #region Virtual implementation of TextBox Event handlers
        public virtual void txtCtrl_KeyUp(object sender, KeyEventArgs e)
        {

        }
        public virtual void txtCtrl_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

    }
}
