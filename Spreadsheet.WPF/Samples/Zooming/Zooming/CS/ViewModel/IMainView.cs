using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zooming.ViewModel
{
    public interface IMainView
    {
        void ZoomIn();
        void ZoomOut();
        void ZoomScaleChanged();
    }
}
