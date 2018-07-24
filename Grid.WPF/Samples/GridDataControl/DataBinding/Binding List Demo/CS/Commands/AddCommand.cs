using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using BindingListDemo.Model;

namespace BindingListDemo
{
    #region Add Command

    public class CustomerAddBehavior : CustomerCommandBehaviour<Customers>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAddBehavior"/> class.
        /// </summary>
        public CustomerAddBehavior()
            : base((s, e) =>
            {
                ManipulatorViewModel viewModel = new ManipulatorViewModel(new Customers(), false);
                ManipulatorView addView = new ManipulatorView(viewModel);
                addView.Owner = Application.Current.MainWindow;

                if ((bool)addView.ShowDialog())
                {
                    return viewModel.CustomerInfo;
                }
                return null;
            })
        { }
    }

    public class CustomerAddCommand : CustomerCommand<Customers, CustomerAddBehavior>
    { }

    #endregion
}
