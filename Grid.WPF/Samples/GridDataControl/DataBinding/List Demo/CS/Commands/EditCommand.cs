using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Data;

namespace ListDemo
{
    #region Edit Command

    public class ProductEditBehavior : ProductCommandBehaviour<ProductDetails>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductEditBehavior"/> class.
        /// </summary>
        public ProductEditBehavior()
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
            GridViewModel vm = (GridViewModel)(s as MenuItem).DataContext;
            ManipulatorView editView = new ManipulatorView(new ManipulatorViewModel(vm.SelectedProduct, true));
            editView.Owner = Application.Current.MainWindow;

            if ((bool)editView.ShowDialog())
            {
                return (editView.DataContext as ManipulatorViewModel).ProductInfo;
            }
            return null;
        }
    }

    public class ProductEditCommand : ProductCommand<ProductDetails, ProductEditBehavior>
    { }

    #endregion
}
