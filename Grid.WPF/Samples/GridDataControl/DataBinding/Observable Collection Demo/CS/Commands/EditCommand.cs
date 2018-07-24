using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObservableCollectionDemo.ViewModel;
using System.Windows.Controls;
using ObservableCollectionDemo.Views;
using System.Windows;
using ObservableCollectionDemo.Model;

namespace ObservableCollectionDemo.Commands
{
    #region Edit Command

    public class ZipCodeEditBehavior : ZipCodeCommandBehaviour<ZipCodeInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZipCodeEditBehavior"/> class.
        /// </summary>
        public ZipCodeEditBehavior()
            : base((s, e) =>
            {
                GridViewModel vm = (GridViewModel)(s as Button).DataContext;
                ManipulatorView editView = new ManipulatorView(new ManipulatorViewModel(vm.SelectedZipCode, true));
                editView.Owner = Application.Current.MainWindow;

                if ((bool)editView.ShowDialog())
                {
                    return (editView.DataContext as ManipulatorViewModel).ZipInfo;
                }
                return null;
            })
        { }
    }

    public class ZipCodeEditCommand : ZipCodeCommand<ZipCodeInfo, ZipCodeEditBehavior>
    { }

    #endregion
}
