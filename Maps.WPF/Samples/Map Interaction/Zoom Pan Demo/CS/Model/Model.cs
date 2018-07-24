
namespace ZoomPanDemo
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

    public class PanZoomModel
    {

    }

    #region Commands

    public class MaxZoomTextChangeCommand : ICommand
    {
        Action handler;

        public MaxZoomTextChangeCommand(Action _handler)
        {
            this.handler = _handler;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this.handler();
        }
    }

    public class MinZoomTextChangeCommand : ICommand
    {
        Action handler;

        public MinZoomTextChangeCommand(Action _handler)
        {
            this.handler = _handler;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this.handler();
        }
    }

    #endregion
}
