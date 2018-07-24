using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Shared;

namespace ColumnChooserDemo
{
    public class ColumnChooserViewModel:NotificationObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnChooserViewModel"/> class.
        /// </summary>
        /// <param name="totalColumns">The total columns.</param>
        public ColumnChooserViewModel(ObservableCollection<ColumnChooserItems> totalColumns)
        {
            ColumnCollection = totalColumns;  
            OkCommand = new DelegateCommand<object>(this.ClickOK);
        }

        /// <summary>
        /// Gets or sets the column collection.
        /// </summary>
        /// <value>The column collection.</value>
        public ObservableCollection<ColumnChooserItems> ColumnCollection
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the ok command.
        /// </summary>
        /// <value>The ok command.</value>
        public DelegateCommand<object> OkCommand
        {
            get;
            set;
        }

        /// <summary>
        /// Clicks the OK.
        /// </summary>
        /// <param name="param">The param.</param>
        public void ClickOK(object param)
        {
            
        }          
    }
}
