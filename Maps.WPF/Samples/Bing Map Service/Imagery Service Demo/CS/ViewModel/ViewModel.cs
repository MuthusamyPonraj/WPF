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
    using Syncfusion.Windows.Controls.Map;
    using System.Collections.Generic;
    using System.Reflection;   

    public class BingMapViewModel
    {
        #region Constructor
        public BingMapViewModel()
        {
            this.m_InvokeMethodCommand = new InvokeMethodCommand(InvokeMethod);
            this.m_NavigateURLCommand = new NavigateURLCommand(NavigateURI);
        }
        #endregion

        #region Commands

        #region InvokeMethodCommand

        private InvokeMethodCommand m_InvokeMethodCommand;
        public InvokeMethodCommand InvokeMethodCommand
        {
            get { return m_InvokeMethodCommand; }
            set { this.m_InvokeMethodCommand = value; }
        }

        void InvokeMethod(object paramerter)
        {
            var param = (List<object>)paramerter;
            if (param != null && param.Count ==2)
            {
                try
                {
                    var param1 = param[0];
                    var param2 = param[1];
                    System.Type[] types = new Type[0];
                    MethodInfo minfo = param1.GetType().GetMethod(param2.ToString(), types);
                    minfo.Invoke(param1, null);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
                }
            }

        }

        #endregion

        #region NavigateURLCommand

        private NavigateURLCommand m_NavigateURLCommand;
        public NavigateURLCommand NavigateURLCommand
        {
            get { return this.m_NavigateURLCommand; }
            set { this.m_NavigateURLCommand = value; }
        }


        private void NavigateURI(object parameter)
        {
            System.Diagnostics.Process.Start(parameter.ToString());
        }
        #endregion

        #endregion

    }
}
