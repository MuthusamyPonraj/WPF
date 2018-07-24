using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Controls;
using System.Windows.Media;

namespace UnBoundRowDemo
{
    class SummaryCalculationBehavior: Behavior<GridDataControl>
    {
        #region InternalVariables
        /// <summary>
        /// Dictionary to maintain the UnBoundColumnValues based on the Product name for dataGrid1
        /// </summary>
        Dictionary<string, bool> UnboundColumnDictionary_dataGrid1 = new Dictionary<string, bool>();


        /// <summary>
        /// Gets or sets the price1 summary for dataGrid1
        /// </summary>
        /// <value>The price1 summary.</value>
        public double PopulationSummary { get; set; }

        /// <summary>
        /// Gets or sets the price2 summary for dataGrid1
        /// </summary>
        /// <value>The price2 summary.</value>
        public double AreaSummary { get; set; }

        /// <summary>
        /// Gets or sets the price3 summary for dataGrid1
        /// </summary>
        /// <value>The price3 summary.</value>
        public double PopulationDensitySummary { get; set; }

        /// <summary>
        /// Gets or sets the totoal count  for dataGrid1
        /// </summary>
        /// <value>The totoal count.</value>
        public double TotoalCount_dataGrid1 { get; set; }      

        #endregion

        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {
            ViewModel Model = this.AssociatedObject.DataContext as ViewModel;            
            this.AssociatedObject.Model.UnboundRowsCount = 1;
            this.AssociatedObject.ModelLoaded += new EventHandler(AssociatedObject_ModelLoaded);
            for (int i = 0; i < Model.CountryInfo.Count; i++)
            {
                UnboundColumnDictionary_dataGrid1.Add(Model.CountryInfo[i].CountryName, false);
            }
            this.AssociatedObject.Model.QueryCellInfo += Model_QueryCellInfo;
            this.AssociatedObject.CurrentCellChanged += AssociatedObject_CurrentCellChanged;
            this.AssociatedObject.ModelLoaded += new EventHandler(AssociatedObject_ModelLoaded);
        }

        void AssociatedObject_ModelLoaded(object sender, EventArgs e)
        {
            this.AssociatedObject.Model.RowHeights.DefaultLineSize = 40;
        }

        /// <summary>
        /// Handles the CurrentCellChanged event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="Syncfusion.Windows.ComponentModel.SyncfusionRoutedEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_CurrentCellChanged(object sender, Syncfusion.Windows.ComponentModel.SyncfusionRoutedEventArgs args)
        {
            GridDataControl _dataGrid = this.AssociatedObject;
            //Getting the index of VisibleColumn from ColumnIndex of Grid
            var columnIndex = _dataGrid.Model.ResolvePositionToVisibleColumnIndex(_dataGrid.Model.CurrencyManager.CurrentCell.ColumnIndex);
            if (columnIndex >= 0)
            {
                var column = _dataGrid.Model.TableProperties.VisibleColumns[columnIndex];
                var recordIndex = _dataGrid.Model.CurrencyManager.CurrentRecordIndex;
                //Adding condition check to handle Unbound column values alone
                if (column.MappingName == "Status")
                {
                    var checkbx = _dataGrid.Model.CurrencyManager.CurrentCell.Renderer.CurrentCellUIElement;
                    var key = (_dataGrid.Model.View.Records[recordIndex].Data as CountryDetails).CountryName;

                    bool _containsValue = false;
                    _containsValue = UnboundColumnDictionary_dataGrid1.ContainsKey(key);
                    //Updation the checkbox value in dictionary and calculation the summary value based on the check box state
                    if (_containsValue)
                    {
                        UnboundColumnDictionary_dataGrid1[key] = (bool)(checkbx as CheckBox).IsChecked;
                        if ((bool)(checkbx as CheckBox).IsChecked)
                        {
                            PopulationSummary += (_dataGrid.Model.View.Records[recordIndex].Data as CountryDetails).Population;
                            AreaSummary += (_dataGrid.Model.View.Records[recordIndex].Data as CountryDetails).Area;
                            PopulationDensitySummary += (_dataGrid.Model.View.Records[recordIndex].Data as CountryDetails).PopulationDensity;
                            if (PopulationDensitySummary < 0)
                                PopulationDensitySummary = 0;
                            TotoalCount_dataGrid1 = TotoalCount_dataGrid1 + 1;
                        }
                        else
                        {
                            PopulationSummary -= (_dataGrid.Model.View.Records[recordIndex].Data as CountryDetails).Population;
                            AreaSummary -= (_dataGrid.Model.View.Records[recordIndex].Data as CountryDetails).Area;
                            PopulationDensitySummary -= (_dataGrid.Model.View.Records[recordIndex].Data as CountryDetails).PopulationDensity;
                            if (PopulationDensitySummary < 0)
                                PopulationDensitySummary = 0;
                            TotoalCount_dataGrid1 = TotoalCount_dataGrid1 - 1;
                        }

                        //Invalidation the last Unbound row to refresh with  new summary values
                        _dataGrid.Model.InvalidateCell(GridRangeInfo.Row(_dataGrid.Model.RowCount - 1));
                        _dataGrid.Model.InvalidateCell(GridRangeInfo.Col(0));
                    }
                }
            }
        }   

        /// <summary>
        /// Handles the QueryCellInfo event of the Model control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventArgs"/> instance containing the event data.</param>
        void Model_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            GridDataTableModel _gridDataTableModel = sender as GridDataTableModel;
            GridDataStyleInfo styleinfo = e.Style as GridDataStyleInfo;            

            //Updating the Unbound row values based on calculated summary values
            if (styleinfo.CellIdentity.TableCellType == GridDataTableCellType.UnboundRecordCell)
            {
                e.Style.Background = Brushes.LightGray;
                e.Style.Foreground = Brushes.Black;
                e.Style.ReadOnly = true;

                var columnIndex = _gridDataTableModel.ResolvePositionToVisibleColumnIndex(e.Style.ColumnIndex);
                if (columnIndex >= 0)
                {
                    var column = _gridDataTableModel.TableProperties.VisibleColumns[columnIndex];

                    if (column.MappingName == "Population")
                    {
                        e.Style.CellValue = PopulationSummary + ".00";                       
                    }
                    else if (column.MappingName == "Area")
                    {
                        e.Style.CellValue = AreaSummary + ".00";                       
                    }
                    else if (column.MappingName == "PopulationDensity")
                    {
                        e.Style.CellValue = PopulationDensitySummary + "";                       
                    }
                    else if (column.MappingName == "Status")
                        e.Style.CellValue = "Total count = " + TotoalCount_dataGrid1;
                    e.Style.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                }
            }
            //Updating the Unbound column value based on dictionary values
            if (styleinfo.CellIdentity.TableCellType == GridDataTableCellType.UnboundColumnCell)
            {
                var dictkey = (_gridDataTableModel.View.Records[styleinfo.CellIdentity.RecordIndex].Data as CountryDetails).CountryName;               
                e.Style.CellValue = UnboundColumnDictionary_dataGrid1[dictkey];
            }
        }


        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.Model.QueryCellInfo -= Model_QueryCellInfo;
            this.AssociatedObject.CurrentCellChanged -= AssociatedObject_CurrentCellChanged;
            this.AssociatedObject.ModelLoaded -= new EventHandler(AssociatedObject_ModelLoaded);
        }
    }
}
