using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Media;
using CustomErrorValidationDemo.DataModel;
using System.ComponentModel;
using Syncfusion.Windows.GridCommon;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Controls;
using Syncfusion.Windows.Data;

namespace CustomErrorValidationDemo
{
	class CustomValidationBehavior : Behavior<GridDataControl>
	{
        const string ErrorMessageforRowValidation = "Some fields in this record are having invalid data";
        GridDataControl Grid;
        RadioButton CellvalidationRadioButton;
        RadioButton RowValidationRadioButton;		
        int errorRowIndex = -1;
        string ErrorMsg = ""; 

        #region Overrides
        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            Grid = this.AssociatedObject;
            Grid.Model.QueryCellInfo += new GridQueryCellInfoEventHandler(OnQueryCellInfo);
            Grid.CurrentCellValidating += new CurrentCellValidatingEventHandler(OnCurrentCellValidating);
            Grid.RowValidating += new GridDataRowValidatingEventHandler(OnRowValidating);
            Grid.ModelLoaded += new EventHandler(OnModelLoaded);
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            Grid.Model.QueryCellInfo -= new GridQueryCellInfoEventHandler(OnQueryCellInfo);
            Grid.CurrentCellValidating -= new CurrentCellValidatingEventHandler(OnCurrentCellValidating);
            Grid.RowValidating -= new GridDataRowValidatingEventHandler(OnRowValidating);
            CellvalidationRadioButton.Click -= new RoutedEventHandler(OnCellValidationRadioButtonClick);
            RowValidationRadioButton.Click -= new RoutedEventHandler(OnRowValidationRadioButtonClick);

        }

        #endregion  

        #region Events

        /// <summary>
        /// Called when [model loaded].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void OnModelLoaded(object sender, EventArgs e)
        {
            var window = Grid.FindParentElementOfType<Window>();
            this.CellvalidationRadioButton = window.FindName("CellValidation") as RadioButton;
            this.RowValidationRadioButton = window.FindName("RowValidation") as RadioButton;
            CellvalidationRadioButton.Click += new RoutedEventHandler(OnCellValidationRadioButtonClick);
            RowValidationRadioButton.Click += new RoutedEventHandler(OnRowValidationRadioButtonClick);
        }

        /// <summary>
        /// Called when [row validation radio button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void OnRowValidationRadioButtonClick(object sender, RoutedEventArgs e)
        {
            if (Grid.Model.Grid.CurrentCell.IsEditing)
            {
                Grid.Model.Grid.CurrentCell.Deactivate();
            }
            ErrorMsg = "";
            errorRowIndex = -1;
            Grid.Model.Grid.InvalidateCells();
        }

        /// <summary>
        /// Called when [cell validation radio button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void OnCellValidationRadioButtonClick(object sender, RoutedEventArgs e)
        {
            if (Grid.Model.Grid.CurrentCell.IsEditing)
            {
                Grid.Model.Grid.CurrentCell.Deactivate();
            }
            ErrorMsg = "";
            errorRowIndex = -1;
            Grid.Model.Grid.InvalidateCells();
        }

        void OnRowValidating(object sender, GridDataRowValidatingEventArgs args)
        {
            if (IsCellValidating)
                return;
            Products p;
            if (args.Record is RecordEntry)
                p = (args.Record as RecordEntry).Data as Products;
            else
                p = args.Record as Products;
            if (this.Validate("", null, null, p))
            {
                this.SetErrorInformation(args.RowIndex, ErrorMessageforRowValidation);
                //To Change the Background and set the error tooltip.
                this.Grid.Model.RowStyles[args.RowIndex].Background = new SolidColorBrush(GridUtil.GetXamlConvertedValue<Color>("#FFFFD0D0"));
                this.Grid.Model.RowStyles[args.RowIndex].CellValue2 = "Error";
                this.Grid.Model.RowStyles[args.RowIndex].Tag = ErrorMessageforRowValidation;
                this.Grid.Model.RowStyles[args.RowIndex].ShowTooltip = true;
                this.Grid.Model.RowStyles[args.RowIndex].TooltipTemplateKey = "myTooltipTemplate";
                this.Grid.Model.InvalidateCell(GridRangeInfo.Row(args.RowIndex));
                errorRowIndex = args.RowIndex;
                args.IsValid = false;
            }
            else
            {
                errorRowIndex = -1;
                ErrorMsg = "";
                args.IsValid = true;
                //Need to revert the color once error cleared in the row.
                this.AssociatedObject.Model.RowStyles[args.RowIndex].ShowTooltip = false;
                this.AssociatedObject.Model.RowStyles[args.RowIndex].Background = Brushes.Transparent;
                this.AssociatedObject.Model.InvalidateCell(GridRangeInfo.Row(args.RowIndex));
            }
        }

        /// <summary>
        /// Handles the CurrentCellValidating event of the grid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Controls.Grid.CurrentCellValidatingEventArgs"/> instance containing the event data.</param>
        void OnCurrentCellValidating(object sender, CurrentCellValidatingEventArgs e)
        {
            if (!IsCellValidating)
                return;
            int colidx = this.AssociatedObject.Model.ResolvePositionToVisibleColumnIndex(e.Style.ColumnIndex);
            string column = this.Grid.VisibleColumns[colidx].MappingName;
            Products product = null;
            if (this.AssociatedObject.GroupedColumns.Count > 0)
            {
                var record = Grid.Model.Table.GetRecordFromRow(e.Style.RowIndex) as GridDataRecord;
                if (record != null)                
                    product = (Products)record.Data;
            }
            else
                product = (Products)Grid.Model.Table.GetRecordFromRow(e.Style.RowIndex);
            e.Cancel = Validate(column, e.NewValue, e.Style, product);
        }

        /// <summary>
        /// Handles the QueryCellInfo event of the Model control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventArgs"/> instance containing the event data.</param>
        void OnQueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            if (IsCellValidating)
            {
                //For CellLevel Validating
                if (e.Cell.ColumnIndex == 0 && e.Cell.RowIndex > 0)
                {
                    if (e.Style.ErrorInfo != null)
                    {
                        e.Style.ErrorInfo = null;
                    }
                }
                if (e.Cell.RowIndex <= 0 || e.Cell.ColumnIndex <= 0)
                    return;
                //Once we Swith from RowValidation from cellValidation property which are set RowLevelValidation should clear.
                this.AssociatedObject.Model.RowStyles[e.Style.RowIndex].ShowTooltip = false;
                this.AssociatedObject.Model.RowStyles[e.Style.RowIndex].Background = Brushes.Transparent;

                int colidx = this.AssociatedObject.Model.ResolvePositionToVisibleColumnIndex(e.Style.ColumnIndex);
                if (colidx > -1 && colidx < this.AssociatedObject.VisibleColumns.Count)
                {
                    string column = this.Grid.VisibleColumns[colidx].MappingName;
                    Products product = null;
                    if (this.AssociatedObject.GroupedColumns.Count > 0)
                    {
                        var record = Grid.Model.Table.GetRecordFromRow(e.Style.RowIndex) as GridDataRecord;
                        if (record != null)
                            product = (Products)record.Data;
                    }
                    else
                    {
                        product = (Products)Grid.Model.Table.GetRecordFromRow(e.Style.RowIndex);
                    }

                    if (Validate(column, e.Style.CellValue, e.Style, product))
                    {
                        e.Style.ErrorInfo.ErrorMessage = ErrorMsg;
                    }
                }
            }
            else
            {
                //For RowLevelValidating
                if (e.Style.RowIndex > 0 && e.Style.RowIndex != errorRowIndex)
                {
                    GridDataRecord record = null;
                    if (this.AssociatedObject.GroupedColumns.Count > 0)
                    {
                        var groupindex = this.AssociatedObject.Model.ResolveIndexToGroupPosition(e.Style.RowIndex);
                        record = this.AssociatedObject.Model.View.TopLevelGroup.DisplayElements[groupindex] as GridDataRecord;
                    }
                    else
                    {
                        var recordIdx = this.AssociatedObject.Model.ResolveIndexToRecordPosition(e.Style.RowIndex);
                        record = this.AssociatedObject.Model.View.Records[recordIdx] as GridDataRecord;
                    }
                    if (record != null)
                    {
                        Products currentRecord = (Products)record.Data;
                        if (Validate("", null, e.Style, currentRecord))
                        {
                            e.Style.ShowTooltip = true;
                            e.Style.CellValue2 = "Information";
                            e.Style.Tag = ErrorMessageforRowValidation;
                            e.Style.TooltipTemplateKey = "myTooltipTemplate";
                            if (e.Style.ColumnIndex > 0)
                                e.Style.Background = new SolidColorBrush(GridUtil.GetXamlConvertedValue<Color>("#FFCDD3F1"));
                            this.AssociatedObject.Model[e.Style.RowIndex, 0].ErrorInfo = new GridErrorStyleInfo
                            {

                                ErrorMessage = ErrorMessageforRowValidation,
                                ErrorTooltipTemplateKey = "myTooltipTemplate",
                                ErrorType = ErrorType.Custom,
                                CustomImage = new BitmapImage(new Uri(@"..\..\Images\InformationIcon.png", UriKind.RelativeOrAbsolute)),
                                ImageMargins = new Syncfusion.Windows.Controls.Cells.CellMarginsInfo(0, 3, 2, 0),
                                ImageHeight = new GridLength(0.7, GridUnitType.Star),

                            };
                        }
                    }
                }
            }
        }

        #endregion

        #region PrivateProperties

        /// <summary>
        /// Gets a value indicating whether this instance is cell validating.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is cell validating; otherwise, <c>false</c>.
        /// </value>
        private bool IsCellValidating
        {
            get
            {
                return (bool)this.CellvalidationRadioButton.IsChecked;
            }
        }

        #endregion       

        #region Supporting Methods

        /// <summary>
        /// Validates the specified column.
        /// </summary>
        /// <param name="column">The column.</param>
        /// <param name="CellValue">The cell value.</param>
        /// <param name="style">The style.</param>
        /// <param name="product">The product.</param>
        /// <returns></returns>
        public bool Validate(String column, object CellValue, GridStyleInfo style, Products product)
        { 
            bool isInError = false;

            if (column == "UnitPrice" || (!IsCellValidating))
            {
                object checkValue = IsCellValidating ? CellValue : product.UnitPrice;
                if (checkValue is DBNull || checkValue == null || (double.Parse(checkValue.ToString()) < 10))
                {
                    ErrorMsg = "Unit price cannot be less than 10.";
                    isInError = true;
                }
            }

            if (column == "UnitsInStock" || (!IsCellValidating))
            {
                object checkValue = IsCellValidating ? CellValue : product.UnitsInStock;
                short checkvalue = Convert.ToInt16(checkValue);
                /// Inventory control validation.
                if (checkValue is DBNull || checkValue == null || double.Parse(checkValue.ToString()) < 0)
                {
                    ErrorMsg= "Units cannot be less than 0.";
                    isInError = true;
                }

                else if ( checkValue is DBNull || checkValue == null || short.Parse(checkValue.ToString()) < product.ReorderLevel)
                {
                    if (IsCellValidating)
                    {
                        style.ErrorInfo.CustomImage = new System.Windows.Media.Imaging.BitmapImage(new Uri("pack://application:,,/Images/Information.png"));
                        style.ErrorInfo.ErrorTooltipTemplateKey = "ReorderLevelIndicator";
                        style.ErrorInfo.ErrorMessage = "Reorder level reached";
                        style.ErrorInfo.ErrorType = ErrorType.Custom;
                        style.ErrorInfo.ImageMargins = new Syncfusion.Windows.Controls.Cells.CellMarginsInfo() { Top = 4, Bottom = 4, Left = 0, Right = 0 };
                        
                    }
                    isInError = true;
                }

                if (checkValue is DBNull || checkValue == null || short.Parse(checkValue.ToString()) < product.ReorderLevel && product.UnitsOnOrder <= 0)
                {
                    if (IsCellValidating)
                    {

                        style.ErrorInfo = new GridErrorStyleInfo { ErrorMessage = "Reorder level reached, and no units are ordered." };
                    }
                    isInError = true;
                }
            }

            if (column == "UnitsOnOrder" || (!IsCellValidating))
            {

                object checkValue = IsCellValidating ? CellValue : product.UnitsOnOrder;
                if (checkValue is DBNull || checkValue == null || short.Parse(checkValue.ToString()) > 100)
                {
                   ErrorMsg = "Units in order cannot be more than 100.";
                    isInError = true;
                }
            }

            if (column == "ReorderLevel" || (!IsCellValidating))
            {
                object checkValue = IsCellValidating ? CellValue : product.ReorderLevel;
                
                if (checkValue is DBNull || checkValue == null || short.Parse(checkValue.ToString()) > 50)
                {
                    ErrorMsg= "Reorder level cannot cannot be more than 50.";
                    isInError = true;
                }
            }

            if (column == "Discontinued" || (!IsCellValidating))
            {
                object checkValue = IsCellValidating ? CellValue : product.Discontinued;
                if (checkValue != null)
                {
                    if ((bool)checkValue)
                    {
                        if (product.ReorderLevel > 0 || product.UnitsOnOrder > 0)
                        {
                            ErrorMsg = " A product cannot be discontinued, when reorder level or units on order is greater than 0.";
                            isInError = true;
                        }
                    }
                }
            }
            return isInError;
        }

        /// <summary>
        /// Sets the error information.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="message">The message.</param>
        private void SetErrorInformation(int rowIndex, string message)
        {
            this.AssociatedObject.Model[rowIndex, 0].ErrorInfo = new GridErrorStyleInfo
            {
                ErrorMessage = message,
                ErrorType = ErrorType.Custom,
                CustomImage = new BitmapImage(new Uri(@"..\..\Images\ErrorIcon.png", UriKind.RelativeOrAbsolute)),
                ImageMargins = new Syncfusion.Windows.Controls.Cells.CellMarginsInfo(0, 3, 2, 0),
                ImageHeight = new GridLength(0.7, GridUnitType.Star),
            };
        }

        #endregion
		
	}
}
