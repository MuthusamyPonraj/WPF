using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Controls.Grid;
using ObservableCollectionDemo.Model;
using System.Windows;
using System.Windows.Controls;
using ObservableCollectionDemo.Views;
using ObservableCollectionDemo.ViewModel;

namespace ObservableCollectionDemo.Commands
{
    #region Base Command
    
    public class CommandBehaviorBase<TReturn, TEventArgs> : BuilderCommandBehaviorBase<Button, TEventArgs, TReturn>
    { }

    public class CommandBase<TBehavior> : ControlCommandBase<TBehavior, Button> where TBehavior : CommandBehaviorBase<Button>, new()
    { }

    public class ZipCodeCommandBehaviour<TReturn> : CommandBehaviorBase<TReturn, RoutedEventArgs>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZipCodeCommandBehaviour&lt;TReturn&gt;"/> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public ZipCodeCommandBehaviour(Func<object, RoutedEventArgs, TReturn> builder)
        {
            this.builder = builder;
            this.CommandCanExecuteCheckEnabled = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ZipCodeCommandBehaviour&lt;TReturn&gt;"/> class.
        /// </summary>
        public ZipCodeCommandBehaviour()
            : this(null)
        { }

        /// <summary>
        /// Called when [target attached].
        /// </summary>
        protected override void OnTargetAttached()
        {
            (TargetObject as Button).Click += new RoutedEventHandler(OnEventRaised);
        }
    }

    public class ZipCodeCommand<T, TBehavior> : CommandBase<TBehavior> where TBehavior : ZipCodeCommandBehaviour<T>, new()
    { }

    #endregion
}