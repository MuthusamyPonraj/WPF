using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Tools.Controls;

namespace CustomizedToolBarDemo
{
    public class FileOpeningAction : TargetedTriggerAction<RichTextBoxAdv>
    {
        protected override void Invoke(object parameter)
        {
            FileOpeningEventArgs args = parameter as FileOpeningEventArgs;
            if (args != null)
            {
                ((RichTextBoxAdv)Target).Document = DocxImporting.ConvertToDocumentAdv(args.DocumentStream, args.FormatType);
            }
        }
    }
}
