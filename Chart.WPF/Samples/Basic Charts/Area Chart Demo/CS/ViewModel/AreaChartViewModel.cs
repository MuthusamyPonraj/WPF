using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Chart;

namespace AreaChartDemo
{
    public class AreaChartViewModel
    {
        public AreaChartViewModel()
        {
            this.Power = new ObservableCollection<Power>();
            Power.Add(new Power() { country = "Japan", coal = 320, nuclear = 268, gas = 202, oil = 100 });
            Power.Add(new Power() { country = "India", coal = 513, nuclear = 320,gas = 120, oil = 63  });
            Power.Add(new Power() { country = "Germany", coal = 299,nuclear = 178, gas = 99, oil = 30  });
            Power.Add(new Power() { country = "Korea", coal = 213,nuclear = 151, gas = 89, oil = 40  });
            
           
        }
        
        public ObservableCollection<Power> Power
        {
            get;
            set;
        }

        public Array PaletteCollection
        {
            get
            {
                return new ChartColorPalette[] { ChartColorPalette.Nature, 
                                          ChartColorPalette.Metro, 
                                          ChartColorPalette.Default, 
                                          ChartColorPalette.DefaultDark,
                                          ChartColorPalette.MixedFantasy
                                        };
            }
        }

    }

}
