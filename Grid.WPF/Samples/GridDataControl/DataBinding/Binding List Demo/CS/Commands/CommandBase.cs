using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Controls.Grid;
using System.Windows;
using System.Windows.Controls;

namespace BindingListDemo
{
    #region Base Command

    public class CommandBehaviorBase<TReturn, TEventArgs> : BuilderCommandBehaviorBase<MenuItem, TEventArgs, TReturn>
    { }

    public class CommandBase<TBehavior> : ControlCommandBase<TBehavior, MenuItem> where TBehavior : CommandBehaviorBase<MenuItem>, new()
    { }

    public class CustomerCommandBehaviour<TReturn> : CommandBehaviorBase<TReturn, RoutedEventArgs>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCommandBehaviour&lt;TReturn&gt;"/> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public CustomerCommandBehaviour(Func<object, RoutedEventArgs, TReturn> builder)
        {
            this.builder = builder;
            this.CommandCanExecuteCheckEnabled = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerCommandBehaviour&lt;TReturn&gt;"/> class.
        /// </summary>
        public CustomerCommandBehaviour()
            : this(null)
        { }

        /// <summary>
        /// Called when [target attached].
        /// </summary>
        protected override void OnTargetAttached()
        {
            (TargetObject as MenuItem).Click += OnEventRaised;
        }
    }

    public class CustomerCommand<T, TBehavior> : CommandBase<TBehavior> where TBehavior : CustomerCommandBehaviour<T>, new()
    { }

    #endregion
}