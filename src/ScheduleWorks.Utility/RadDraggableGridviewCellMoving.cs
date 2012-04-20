using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace ScheduleWorks.Utility
{
    public class RadDraggableGridViewCellMoving : RadGridView
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RadDraggableGridViewCellMoving"/> class.
        /// </summary>
        public RadDraggableGridViewCellMoving()
        {
            // comment this line to disable multi selection
            this.MultiSelect = false;

            var dragDropService = this.GridViewElement.GetService<RadGridViewDragDropService>();
            dragDropService.PreviewDragStart += this.dragDropService_PreviewDragStart;
            dragDropService.PreviewDragDrop += this.dragDropService_PreviewDragDrop;
            dragDropService.PreviewDragOver += this.dragDropService_PreviewDragOver;
            dragDropService.PreviewDragHint += this.dragDropService_PreviewDragHint;

            this.CellFormatting += this.DraggableGridView_CellFormatting;

            var gridBehavior = this.GridBehavior as BaseGridBehavior;
            gridBehavior.UnregisterBehavior(typeof(GridViewDataRowInfo));
            gridBehavior.RegisterBehavior(typeof(GridViewDataRowInfo), new MyGridDataRowBehavior());
        }

        #endregion Constructors and Destructors

        #region Properties

        /// <summary>
        /// Gets ThemeClassName.
        /// </summary>
        public override string ThemeClassName
        {
            get
            {
                return typeof(RadGridView).FullName;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// The draggable grid view_ row formatting.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void DraggableGridView_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            e.CellElement.AllowDrag = true;
            e.CellElement.AllowDrop = true;
        }

        /// <summary>
        /// The get target row index.
        /// </summary>
        /// <param name="cell">
        /// The row.
        /// </param>
        /// <param name="dropLocation">
        /// The drop location.
        /// </param>
        /// <returns>
        /// The get target row index.
        /// </returns>
        private int GetTargetCellIndex(GridDataCellElement cell, Point dropLocation)
        {
            int halfHeight = cell.Size.Height / 2;
            int index = cell.RowInfo.Index;
            if (dropLocation.Y > halfHeight)
            {
                index++;
            }

            return index;
        }

        private int GetTargetRowIndex(GridDataRowElement row, Point dropLocation)
        {
            int halfHeight = row.Size.Height / 2;
            int index = row.RowInfo.Index;
            if (dropLocation.Y > halfHeight)
            {
                index++;
            }

            return index;
        }

        /// <summary>
        /// The move rows.
        /// </summary>
        /// <param name="targetGrid">
        /// The target grid.
        /// </param>
        /// <param name="dragGrid">
        /// The drag grid.
        /// </param>
        /// <param name="dragRows">
        /// The drag rows.
        /// </param>
        /// <param name="index">
        /// The index.
        /// </param>
        private void MoveCell(RadGridView targetGrid, RadGridView dragGrid, GridCellElement cellElement, int index, int indexRow, int indexColumn)
        {
            dragGrid.BeginUpdate();
            targetGrid.BeginUpdate();

            if (targetGrid != null)
            {
                targetGrid.Rows[indexRow].Cells[indexColumn].Value = cellElement.Value;
                targetGrid.Rows[indexRow].Cells[indexColumn].Tag = cellElement.Tag;

                dragGrid.Rows[cellElement.RowIndex].Cells[cellElement.ColumnIndex].Value = "";
                dragGrid.Rows[cellElement.RowIndex].Cells[cellElement.ColumnIndex].Tag = null;
            }

            dragGrid.EndUpdate(true);
            targetGrid.EndUpdate(true);
        }

        /// <summary>
        /// The drag drop service_ preview drag drop.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void dragDropService_PreviewDragDrop(object sender, RadDropEventArgs e)
        {
            e.Handled = true;

            var cellElement = e.DragInstance as GridDataCellElement;
            if (cellElement == null)
            {
                return;
            }

            var dropTarget = e.HitTarget as RadItem;
            var targetGrid = dropTarget.ElementTree.Control as RadGridView;
            if (targetGrid == null)
            {
                return;
            }

            var dragGrid = cellElement.ElementTree.Control as RadGridView;

            e.Handled = true;
            var dropTargetCell = dropTarget as GridDataCellElement;
            int index = this.GetTargetCellIndex(dropTargetCell, e.DropLocation);
            this.MoveCell(targetGrid, dragGrid, cellElement, index, dropTargetCell.RowIndex, dropTargetCell.ColumnIndex);
        }

        /// <summary>
        /// The drag drop service_ preview drag hint.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void dragDropService_PreviewDragHint(object sender, PreviewDragHintEventArgs e)
        {
            var dataRElement = e.DragInstance as GridDataCellElement;
            if (dataRElement != null && dataRElement.ViewTemplate.MasterTemplate.SelectedCells.Count > 1)
            {
                // set custom drag hint for multiple rows here
                //e.DragHint = new Bitmap(this.imageList1.Images[6]);
                //e.UseDefaultHint = false;
            }
        }

        /// <summary>
        /// The drag drop service_ preview drag over.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void dragDropService_PreviewDragOver(object sender, RadDragOverEventArgs e)
        {
            if (e.DragInstance is GridDataCellElement)
            {
                e.CanDrop = e.HitTarget is GridDataCellElement || e.HitTarget is GridTableElement ||
                            e.HitTarget is GridSummaryRowElement;
            }
        }

        /// <summary>
        /// The drag drop service_ preview drag start.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void dragDropService_PreviewDragStart(object sender, PreviewDragStartEventArgs e)
        {
            e.CanStart = true;
        }

        #endregion Methods

        /// <summary>
        /// The my grid data row behavior.
        /// </summary>
        private class MyGridDataRowBehavior : GridDataRowBehavior
        {
            #region Methods

            /// <summary>
            /// The on mouse down left.
            /// </summary>
            /// <param name="e">
            /// The e.
            /// </param>
            /// <returns>
            /// The on mouse down left.
            /// </returns>
            protected override bool OnMouseDownLeft(MouseEventArgs e)
            {
                var dataCellElement = this.GetCellAtPoint(e.Location) as GridDataCellElement;

                if (dataCellElement != null)
                {
                    var dragDropService = this.GridViewElement.GetService<RadGridViewDragDropService>();
                    dragDropService.Start(dataCellElement);
                }

                return base.OnMouseDownLeft(e);
            }

            #endregion Methods
        }
    }
}
