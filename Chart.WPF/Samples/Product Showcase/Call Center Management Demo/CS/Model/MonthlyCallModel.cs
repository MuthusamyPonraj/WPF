using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CallCenterDemo
{
    public class MonthlyCallModel
    {
        Random rand = new Random();
        public MonthlyCallModel()
        { 
            
        }

        private double _TotalCalls;
        public double TotalCalls
        {
            get
            {
                return _TotalCalls;
            }
            set
            {
                _TotalCalls = value;
            }
        }

        private string _Monthname;
        public string Monthname
        {
            get
            {
                return _Monthname;
            }
            set
            {
                _Monthname = value;
            }
        }

        public double ResolvedCalls
        {
            get;
            set;
        }

        public double EmployeeRetention
        {
            get;
            set;
        }

        public double EmployeeRetention2
        {
            get;
            set;
        }

        public double ScheduleEfficiency
        {
            get;
            set;
        }

        public double ScheduleEfficiency2
        {
            get;
            set;
        }

        public double ServiceUtilization
        {
            get;
            set;
        }

        public double ServiceUtilization2
        {
            get;
            set;
        }


    }
}
