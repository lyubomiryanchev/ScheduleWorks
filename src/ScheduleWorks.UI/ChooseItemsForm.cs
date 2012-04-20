using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using ScheduleWorks.Utility;

namespace ScheduleWorks.UI
{
    public partial class ChooseItemsForm : Telerik.WinControls.UI.RadForm
    {
        public ChooseItemsForm(ChooseItems.Mode selectionMode, string formTitle, List<ChooseItemsParameters> items)
        {
            InitializeComponent();

            this.Text = formTitle;

            addItemsToGridviewForFirstTime(items);
            
            if (selectionMode == ChooseItems.Mode.MultipleItems)
            {
                gridviewItems.MultiSelect = true;
                gridviewSelectedItems.MultiSelect = true;
            }
            else if(selectionMode == ChooseItems.Mode.SingleItem)
            {
                gridviewItems.MultiSelect = false;
                gridviewSelectedItems.MultiSelect = false;
            }

            setGridviewLayout();
        }

        public ChooseItemsForm(ChooseItems.Mode selectionMode, string formTitle, List<ChooseItemsParameters> items, List<ChooseItemsParameters> selectedItems)
        {
            InitializeComponent();

            this.Text = formTitle;

            addItemsToGridviewForFirstTime(items, selectedItems);

            if (selectionMode == ChooseItems.Mode.MultipleItems)
            {
                gridviewItems.MultiSelect = true;
                gridviewSelectedItems.MultiSelect = true;
            }
            else if (selectionMode == ChooseItems.Mode.SingleItem)
            {
                gridviewItems.MultiSelect = false;
                gridviewSelectedItems.MultiSelect = false;
            };

            setGridviewLayout();

        }

        void addItemsToGridviewForFirstTime(List<ChooseItemsParameters> items)
        {
            gridviewItems.Rows.Clear();
            foreach (var k in items)
            {
                gridviewItems.Rows.Add(k.Name, k.ShortName, k.Tag);
            }
        }

        void addItemsToGridviewForFirstTime(List <ChooseItemsParameters> items, List<ChooseItemsParameters> selectedItems)
        {
            if (selectedItems.Count > 0)
            {
                foreach (var k in items)
                {
                    bool isAlreadySelected = false;
                    foreach (var sI in selectedItems)
                    {
                        if (k.Tag.ToString() == sI.Tag.ToString())
                        {
                            isAlreadySelected = true;
                        }
                    }
                    if (!isAlreadySelected)
                    {
                        gridviewItems.Rows.Add(k.Name, k.ShortName, k.Tag);
                    }
                }
                foreach (var sI in selectedItems)
                {
                    gridviewSelectedItems.Rows.Add(sI.Name, sI.ShortName, sI.Tag);
                }
            }
            else
            {
                foreach (var k in items)
                {
                    gridviewItems.Rows.Add(k.Name, k.ShortName, k.Tag);
                }
            }
        }

        void setGridviewLayout()
        {
            gridviewItems.Columns["Съкращение"].Width = 22;
            gridviewSelectedItems.Columns["Съкращение"].Width = 22;

            gridviewItems.AllowAddNewRow = false;
            gridviewItems.AllowEditRow = false;
            gridviewItems.AllowDeleteRow = false;
            gridviewItems.AllowDragToGroup = false;
            gridviewItems.AllowRowReorder = false;
            gridviewItems.AllowRowResize = false;
            gridviewItems.EnableSorting = false;
            gridviewItems.ShowGroupPanel = false;
            gridviewItems.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridviewItems.ShowColumnHeaders = true;
            gridviewItems.AllowColumnHeaderContextMenu = true;
            gridviewItems.ShowRowHeaderColumn = false;

            gridviewSelectedItems.AllowAddNewRow = false;
            gridviewSelectedItems.AllowEditRow = false;
            gridviewSelectedItems.AllowDeleteRow = false;
            gridviewSelectedItems.AllowDragToGroup = false;
            gridviewSelectedItems.AllowRowReorder = false;
            gridviewSelectedItems.AllowRowResize = false;
            gridviewSelectedItems.EnableSorting = false;
            gridviewSelectedItems.ShowGroupPanel = false;
            gridviewSelectedItems.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridviewSelectedItems.ShowColumnHeaders = true;
            gridviewSelectedItems.AllowColumnHeaderContextMenu = true;
            gridviewSelectedItems.ShowRowHeaderColumn = false;

            buttonBack.IsAccessible = false;
            buttonBack.Enabled = false;

            gridviewItems.Columns["Tag"].IsVisible = false;
            gridviewSelectedItems.Columns["Tag"].IsVisible = false;

            if (!gridviewSelectedItems.MultiSelect)
            {
                if (gridviewSelectedItems.Rows.Count >= 1)
                {
                    buttonForward.Enabled = false;
                    buttonBack.Enabled = true;
                }
            }

            if (gridviewSelectedItems.MultiSelect){
                buttonForward.Enabled = true;
            }
            if (gridviewSelectedItems.Rows.Count > 0)
            {
                buttonBack.Enabled = true;
            }

            if (gridviewItems.Rows.Count == 0)
            {
                buttonForward.Enabled = false;
            }
            if (gridviewSelectedItems.Rows.Count == 0)
            {
                buttonForward.Enabled = true;
                buttonBack.Enabled = false;
            }

        }

        public delegate void OnReadyButtonClickedDelegate(object sender, EventArgs e);
        public event OnReadyButtonClickedDelegate OnReadyButtonClicked;

        private void buttonForward_Click(object sender, EventArgs e)
        {
            try
            {
                List<Telerik.WinControls.UI.GridViewRowInfo> toRemove = new List<Telerik.WinControls.UI.GridViewRowInfo>();
                foreach (var i in gridviewItems.SelectedRows)
                {
                    string name = gridviewItems.Rows[i.Index].Cells[0].Value.ToString();
                    string shortName;
                    try
                    {
                        shortName = gridviewItems.Rows[i.Index].Cells[1].Value.ToString();
                    }
                    catch
                    {
                        shortName = " ";
                    }
                    string tag = gridviewItems.Rows[i.Index].Cells[2].Value.ToString();
                    gridviewSelectedItems.Rows.Add(name, shortName, tag);
                    toRemove.Add(i);
                }
                for (int i = 0; i <= toRemove.Count; ++i)
                {
                    gridviewItems.Rows.Remove(toRemove[i]);
                }
                toRemove.Clear();
            }
            catch
            {

            }

            buttonBack.Enabled = true;

            if(!gridviewSelectedItems.MultiSelect)
            {
                if (gridviewSelectedItems.Rows.Count >= 1)
                {
                    buttonForward.Enabled = false;
                    buttonBack.Enabled = true;
                }
            }
            if (gridviewItems.Rows.Count == 0)
            {
                buttonForward.Enabled = false;
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            try
            {
                List<Telerik.WinControls.UI.GridViewRowInfo> toRemove = new List<Telerik.WinControls.UI.GridViewRowInfo>();
                foreach(var row in gridviewSelectedItems.SelectedRows)
                {
                    string name = gridviewSelectedItems.Rows[row.Index].Cells[0].Value.ToString();
                    string shortName;
                    try
                    {
                        shortName = gridviewSelectedItems.Rows[row.Index].Cells[1].Value.ToString();
                    }
                    catch
                    {
                        shortName = " ";
                    }
                    string tag = gridviewSelectedItems.Rows[row.Index].Cells[2].Value.ToString();
                    gridviewItems.Rows.Add(name, shortName, tag);
                    toRemove.Add(row);
                }
                for (int i = 0; i <= toRemove.Count; ++i)
                {
                    gridviewSelectedItems.Rows.Remove(toRemove[i]);
                }
                toRemove.Clear();
            }
            catch
            {
                
            }

            buttonForward.Enabled = true;

            if (gridviewSelectedItems.Rows.Count == 0)
            {
                buttonForward.Enabled = true;
                buttonBack.Enabled = false;
            }
        }

        /// <summary>
        /// Get a list of selected elements
        /// </summary>
        /// <returns>Returns whatever is setted for "Tag"</returns>

        public List<object> GetSelectedItems()
        {
            List<object> toReturn = new List<object>();
            foreach (var row in gridviewSelectedItems.Rows)
            {
                toReturn.Add(row.Cells[2].Value.ToString());
                Console.WriteLine("\t ID = {0}", row.Cells[2].Value);
            }
            return toReturn;
        }

        private void buttonReady_Click(object sender, EventArgs e)
        {
            if (gridviewSelectedItems.Rows.Count >= 1)
            {
                OnReadyButtonClicked(sender, e);
                this.Close();
            }
            else
            {
                RadMessageBox.Show("Моля, изберете елемент/и от списъка!", "Грешка");
            }
        }
    }
}
