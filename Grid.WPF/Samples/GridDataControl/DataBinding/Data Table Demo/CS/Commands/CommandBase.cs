using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Controls.Grid;
using System.Windows;
using System.Windows.Controls;

namespace DataTableDemo
{
    #region Base Command

    public class CommandBehaviorBase<TReturn, TEventArgs> : BuilderCommandBehaviorBase<MenuItem, TEventArgs, TReturn>
    { }

    public class CommandBase<TBehavior> : ControlCommandBase<TBehavior, MenuItem> where TBehavior : CommandBehaviorBase<MenuItem>, new()
    { }

    public class EmployeeCommandBehaviour<TReturn> : CommandBehaviorBase<TReturn, RoutedEventArgs>
    {
        public EmployeeCommandBehaviour(Func<object, RoutedEventArgs, TReturn> builder)
        {
            this.builder = builder;
			this.CommandCanExecuteCheckEnabled = true;
        }

        public EmployeeCommandBehaviour()
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

    public class EmployeeCommand<T, TBehavior> : CommandBase<TBehavior> where TBehavior : EmployeeCommandBehaviour<T>, new()
    { }

    #endregion
}