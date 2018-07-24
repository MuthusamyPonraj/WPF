using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;

namespace Zooming.ViewModel
{
    public class MainViewModel
    {
        IMainView View;
        public MainViewModel(IMainView View)
        {
            this.View = View;
        }

        public DelegateCommand<object> zoomIn;
        public DelegateCommand<object> ZoomIn
        {
            get
            {
                if (zoomIn == null)
                    zoomIn = new DelegateCommand<object>(OnExcuteZoonIn, CanExcuteZoomIn);
                return zoomIn;
            }
            set
            {
                zoomIn = value;
            }
        }

        private void OnExcuteZoonIn(object param)
        {
            View.ZoomIn();
        }

        private bool CanExcuteZoomIn(object param)
        {
            if (View != null)
                return true;
            else
                return false;
        }

        public DelegateCommand<object> zoomOut;
        public DelegateCommand<object> ZoomOut
        {
            get
            {
                if (zoomOut == null)
                    zoomOut = new DelegateCommand<object>(OnExcuteZoonOut, CanExcuteZoomOut);
                return zoomOut;
            }
            set
            {
                zoomOut = value;
            }
        }

        private void OnExcuteZoonOut(object param)
        {
            View.ZoomOut();
        }

        private bool CanExcuteZoomOut(object param)
        {
            if (View != null)
                return true;
            else
                return false;
        }

        public DelegateCommand<object> zoomScale;
        public DelegateCommand<object> ZoomScale
        {
            get
            {
                if (zoomScale == null)
                    zoomScale = new DelegateCommand<object>(OnExcuteZoomScale, CanExcuteZoomScale);
                return zoomScale;
            }
            set
            {
                zoomScale = value;
            }
        }

        private void OnExcuteZoomScale(object param)
        {
            View.ZoomScaleChanged();
        }

        private bool CanExcuteZoomScale(object param)
        {
            if (View != null)
                return true;
            else
                return false;
        }
    }
}
