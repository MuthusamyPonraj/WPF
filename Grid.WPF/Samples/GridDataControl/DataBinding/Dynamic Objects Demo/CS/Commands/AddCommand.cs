using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Dynamic;

namespace DynamicObjectsDemo
{
    #region Add Command

    public class OrderAddBehavior : OrderCommandBehaviour<OrderInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderAddBehavior"/> class.
        /// </summary>
        public OrderAddBehavior()
            : base((s, e) =>
            {
                ManipulatorViewModel viewModel = new ManipulatorViewModel(new OrderInfo(), false);
                ManipulatorView addView = new ManipulatorView(viewModel);
                addView.Owner = Application.Current.MainWindow;

                if ((bool)addView.ShowDialog())
                {
                    return viewModel.OrdersInfo;
                }
                return null;
            })
        { } 
    }

    public class OrderAddCommand : OrderCommand<OrderInfo, OrderAddBehavior>
    { }

    #endregion
}
