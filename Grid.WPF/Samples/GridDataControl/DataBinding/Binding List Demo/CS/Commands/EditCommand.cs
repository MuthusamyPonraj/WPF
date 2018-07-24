using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using BindingListDemo.Model;

namespace BindingListDemo
{
    #region Edit Command

    public class CustomerEditBehavior : CustomerCommandBehaviour<Customers>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerEditBehavior"/> class.
        /// </summary>
        public CustomerEditBehavior()
            : base((s, e) =>
            {
                GridViewModel vm = (GridViewModel)(s as MenuItem).DataContext;
                ManipulatorView editView = new ManipulatorView(new ManipulatorViewModel(vm.SelectedCustomer, true));
                editView.Owner = Application.Current.MainWindow;

                if ((bool)editView.ShowDialog())
                {
                    return (editView.DataContext as ManipulatorViewModel).CustomerInfo;
                }
                return null;
            })
        { }
    }

    public class CustomerEditCommand : CustomerCommand<Customers, CustomerEditBehavior>
    { }

    #endregion
}
