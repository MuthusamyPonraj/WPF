using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Data;
using Syncfusion.Windows.Controls.Grid;

namespace ListDemo
{
    #region Add Command

    public class ProductAddBehavior : ProductCommandBehaviour<ProductDetails>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductAddBehavior"/> class.
        /// </summary>
        public ProductAddBehavior()
            : base(Validate)
        { }

        /// <summary>
        /// Validates the specified s.
        /// </summary>
        /// <param name="s">The s.</param>
        /// <param name="args">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        private static ProductDetails Validate(object s, RoutedEventArgs args)
        {
            ManipulatorViewModel viewModel = new ManipulatorViewModel(new ProductDetails(), false);
            ManipulatorView addView = new ManipulatorView(viewModel);
            addView.Owner = Application.Current.MainWindow;

            if ((bool)addView.ShowDialog())
            {
                return viewModel.ProductInfo;
            }
            return null;
        }
    }

    public class ProductAddCommand : ProductCommand<ProductDetails, ProductAddBehavior>
    { }

    #endregion
}
