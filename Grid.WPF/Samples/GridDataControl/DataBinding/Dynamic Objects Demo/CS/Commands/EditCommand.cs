using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace DynamicObjectsDemo
{
    #region Edit Command

    public class OrderEditBehavior : OrderCommandBehaviour<dynamic>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderEditBehavior"/> class.
        /// </summary>
        public OrderEditBehavior()
            : base((s, e) =>
            {
                GridViewModel vm = (GridViewModel)(s as MenuItem).DataContext;
                ManipulatorView editView = new ManipulatorView(new ManipulatorViewModel(vm.SelectedOrder, true));
                editView.Owner = Application.Current.MainWindow;

                if ((bool)editView.ShowDialog())
                {
                    return (editView.DataContext as ManipulatorViewModel).OrdersInfo;
                }
                return null;
            })
        {}        
    }

    public class OrderEditCommand : OrderCommand<dynamic, OrderEditBehavior>
    { }

    #endregion
}
