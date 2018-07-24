using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace RightToLeftSupport
{
    public class RightToLeftSupportViewModel
    {
        public RightToLeftSupportViewModel()
        {
            this.RTLModel = new ObservableCollection<RTLDataViewModel>();
            RTLModel.Add(new RTLDataViewModel() { YEAR = 2002, EXPORT = 50, IMPORT = 80 });
            RTLModel.Add(new RTLDataViewModel() { YEAR = 2003, EXPORT = 88, IMPORT = 50 });
            RTLModel.Add(new RTLDataViewModel() { YEAR = 2004, EXPORT = 66, IMPORT = 78 });
            RTLModel.Add(new RTLDataViewModel() { YEAR = 2005, EXPORT = 35, IMPORT = 85 });
            RTLModel.Add(new RTLDataViewModel() { YEAR = 2006, EXPORT = 67, IMPORT = 90 });
            RTLModel.Add(new RTLDataViewModel() { YEAR = 2007, EXPORT = 70, IMPORT = 95 });
            RTLModel.Add(new RTLDataViewModel() { YEAR = 2008, EXPORT = 40, IMPORT = 67 });
        }

        public ObservableCollection<RTLDataViewModel> RTLModel { get; set; }


    }
}
