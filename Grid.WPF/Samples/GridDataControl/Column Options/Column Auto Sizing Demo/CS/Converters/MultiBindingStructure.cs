using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Controls.Grid;

namespace ColumnAutoSizingDemo
{
    class MultiBindingStructure
    {
        /// <summary>
        /// Gets or sets the selected column.
        /// </summary>
        /// <value>The selected column.</value>
        public string SelectedColumn
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the selected sizer.
        /// </summary>
        /// <value>The selected sizer.</value>
        public GridControlLengthUnitType SelectedSizer
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>The width.</value>
        public double width
        {
            get;
            set;
        }
    }
}
