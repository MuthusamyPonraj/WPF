using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HiLoAreaChart
{
    public class product
    {
        private DateTime _prodYear;
        private double _tea;
        private double _coffee;

        public product(DateTime _prodId, double _pCoffee, double _stock)
        {
            this._prodYear = _prodId;
            this._tea = _pCoffee;
            this._coffee = _stock;
        }
        public DateTime ProdYear
        {
            get { return _prodYear; }
            set
            {
                _prodYear = value;
            }
        }
        public double Tea
        {
            get { return _tea; }
            set
            {
                _tea = value;
            }
        }
        public double Coffee
        {
            get { return _coffee; }
            set
            {
                _coffee = value;
            }
        }
    }
}
