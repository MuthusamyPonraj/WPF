using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Tools.Controls;

namespace CustomizedToolBarDemo
{
    public class FileSavingAction : TargetedTriggerAction<RichTextBoxAdv>
    {
        protected override void Invoke(object parameter)
        {
            FileSavingEventArgs args = parameter as FileSavingEventArgs;
            if (args != null)
            {
                DocxExporting.ConvertToDocument(((RichTextBoxAdv)Target).Document, args.DoucmentStream, args.FormatType);
            }
        }
    }
}
