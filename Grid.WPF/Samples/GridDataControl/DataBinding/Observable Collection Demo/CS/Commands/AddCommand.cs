using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObservableCollectionDemo.ViewModel;
using System.Windows;
using ObservableCollectionDemo.Views;
using ObservableCollectionDemo.Model;

namespace ObservableCollectionDemo.Commands
{
    #region Add Command

    public class ZipCodeAddBehavior : ZipCodeCommandBehaviour<ZipCodeInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZipCodeAddBehavior"/> class.
        /// </summary>
        public ZipCodeAddBehavior()
            : base((s, e) =>
            {
                ManipulatorViewModel viewModel = new ManipulatorViewModel(new ZipCodeInfo(), false);
                ManipulatorView addView = new ManipulatorView(viewModel);
                addView.Owner = Application.Current.MainWindow;

                if ((bool)addView.ShowDialog())
                {
                    return viewModel.ZipInfo;
                }
                return null;
            })
        { }
    }

    public class ZipCodeAddCommand : ZipCodeCommand<ZipCodeInfo, ZipCodeAddBehavior>
    { }

    #endregion
}
