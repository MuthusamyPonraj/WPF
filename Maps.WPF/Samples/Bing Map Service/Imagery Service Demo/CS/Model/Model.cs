namespace Imagery_Service_Demo
{
    using System;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Ink;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;

    #region InvokeMethod Command
    public class InvokeMethodCommand:ICommand
    {      
        Action<object> Handler;
       
        public InvokeMethodCommand(Action<object> m_Handler)
        {
            this.Handler = m_Handler;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
           
            this.Handler(parameter);
        }
    }
    #endregion

    #region NavigateURLCommand

    public class NavigateURLCommand : ICommand
    {
        Action<object> Handler;
        public NavigateURLCommand(Action<object> m_handler)
        {
            this.Handler = m_handler;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this.Handler(parameter);
        }
    }

    #endregion

}
