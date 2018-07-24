using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Controls.Grid;
using System.Windows;
using System.Windows.Controls;

namespace ListDemo
{
    #region Base Command

    public class CommandBehaviorBase<TReturn, TEventArgs> : BuilderCommandBehaviorBase<MenuItem, TEventArgs, TReturn>
    { }

    public class CommandBase<TBehavior> : ControlCommandBase<TBehavior, MenuItem> where TBehavior : CommandBehaviorBase<MenuItem>, new()
    { }

    public class ProductCommandBehaviour<TReturn> : CommandBehaviorBase<TReturn, RoutedEventArgs>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCommandBehaviour&lt;TReturn&gt;"/> class.
        /// </summary>
        /// <param name="builder">The builder.</param>
        public ProductCommandBehaviour(Func<object, RoutedEventArgs, TReturn> builder)
        {
            this.builder = builder;
			this.CommandCanExecuteCheckEnabled = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductCommandBehaviour&lt;TReturn&gt;"/> class.
        /// </summary>
        public ProductCommandBehaviour()
            : this(null)
        { }

        /// <summary>
        /// Called when [target attached].
        /// </summary>
        protected override void OnTargetAttached()
        {
            (TargetObject as MenuItem).Click += new RoutedEventHandler(OnEventRaised);
        }
    }

    public class ProductCommand<T, TBehavior> : CommandBase<TBehavior> where TBehavior : ProductCommandBehaviour<T>, new()
    { }

    #endregion
}