using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStarted_Chart
{
    public class ChartModel
    {
        public DateTime Date { get; set; }

        public double High { get; set; }

        public double Low { get; set; }

        public double Open { get; set; }

        public double Close { get; set; }

        public double EMA { get; set; }

        public double SMA { get; set; }

        public ChartModel(DateTime date, double high, double low, double open, double close, double yValue1, double yValue2 )
        {
            Date = date;
            High = high;
            Low = low;
            Open = open;
            Close = close;
            EMA = yValue1;
            SMA = yValue2;
        }
    }
}