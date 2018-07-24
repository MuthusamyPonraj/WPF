using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObservableCollectionDemo.Model;

namespace ObservableCollectionDemo.Commands
{
    #region Delete Command

    public class ZipCodeDeleteBehavior : ZipCodeCommandBehaviour<ZipCodeInfo>
    { }

    public class ZipCodeDeleteCommand : ZipCodeCommand<ZipCodeInfo, ZipCodeDeleteBehavior>
    { }

    #endregion
}
