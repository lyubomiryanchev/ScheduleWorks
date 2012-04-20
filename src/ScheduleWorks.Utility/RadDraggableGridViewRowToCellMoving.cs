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
    public class RadDraggableGridViewRowToCellMoving : RadGridView
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RadDraggableGridViewRowToMoving"/> class.
        /// </summary>
        public RadDraggableGridViewRowToCellMoving()
        {

            var dragDropService = this.GridViewElement.GetService<RadGridViewDragDropService>();
            dragDropService.PreviewDragStart += this.dragDropService_PreviewDragStart;
            dragDropService.PreviewDragDrop += this.dragDropService_PreviewDragDrop;
            dragDropService.PreviewDragOver += this.dragDropService_PreviewDragOver;
            dragDropService.PreviewDragHint += this.dragDropService_PreviewDragHint;

            this.RowFormatting += this.DraggableGridView_RowFormatting;

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
        private void DraggableGridView_RowFormatting(object sender, RowFormattingEventArgs e)
        {
            e.RowElement.AllowDrag = true;
            e.RowElement.AllowDrop = true;
        }

        /// <summary>
        /// The get target row index.
        /// </summary>
        /// <param name="row">
        /// The row.
        /// </param>
        /// <param name="dropLocation">
        /// The drop location.
        /// </param>
        /// <returns>
        /// The get target row index.
        /// </returns>
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
        private void MoveRows(RadGridView targetGrid, RadGridView dragGrid, GridCellElement cellElement)//, GridRowElement rowElement)
        {
            dragGrid.BeginUpdate();
            targetGrid.BeginUpdate();

            Console.WriteLine("HERE!");
            targetGrid.Rows[cellElement.RowIndex].Cells[cellElement.ColumnIndex].Value = "blq";

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

            var rowElement = e.DragInstance as GridDataRowElement;
            if (rowElement == null)
            {
                return;
            }

            var dropTarget = e.HitTarget as RadItem;
            var targetGrid = dropTarget.ElementTree.Control as RadGridView;
            if (targetGrid == null)
            {
                return;
            }

            var dragGrid = rowElement.ElementTree.Control as RadGridView;

            if (targetGrid != dragGrid)
            {
                
                e.Handled = true;
                var dropTargetCell = dropTarget as GridDataCellElement;
                int index = this.GetTargetCellIndex(dropTargetCell, e.DropLocation);
                this.MoveRows(targetGrid, dragGrid, dropTargetCell);
            }
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
            var dataCellElement = e.DragInstance as GridDataCellElement;
            if (dataCellElement != null && dataCellElement.ViewTemplate.MasterTemplate.SelectedRows.Count > 1)
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
            if (e.DragInstance is GridDataRowElement)
            {
                e.CanDrop = e.HitTarget is GridDataCellElement || e.HitTarget is GridTableElement ||
                            e.HitTarget is GridSummaryCellElement;
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
                var dataRowElement = this.GetRowAtPoint(e.Location) as GridDataRowElement;

                if (dataCellElement != null)
                {
                    var dragDropService = this.GridViewElement.GetService<RadGridViewDragDropService>();
                    dragDropService.Start(dataRowElement);
                }

                return base.OnMouseDownLeft(e);
            }

            #endregion Methods
        }
    }
}
