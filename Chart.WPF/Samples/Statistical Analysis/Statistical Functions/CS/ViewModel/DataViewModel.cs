using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace StatisticalFunctions
{
    public class DataCollection : ObservableCollection<Data>
    {
        public DataCollection()
        {
            Random r1 = new Random();
            Random r2 = new Random();
            Random r3 = new Random();
            Random r4 = new Random();
            //for(int i=0; i<10; i++)
            {
                this.Add(new Data() { X = 5, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 0, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 5, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 0, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 0.75, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 0.75, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 0.75, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 0.75, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 0.75, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 1, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 0.75, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 1, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 1, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 2, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 1.75, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 2, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 2, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 1, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 1, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 5, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 2.75, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 5, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });
                this.Add(new Data() { X = 3, Y1 = r1.Next(0, 100), Y2 = r2.Next(0, 50), Y3 = r3.Next(10, 80) });

            }
        }
    }
}
