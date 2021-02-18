using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot;
using OxyPlot.Series;


namespace project
{
     public class MainViewModel
    {
        public MainViewModel()
        {
            if (Dan.Y != null)
            {
                this.Title = "График";
                this.Points = new List<DataPoint>();
                this.Points2 = new List<DataPoint>();
                double hm = 0;
                for (int i = 0; i < Dan.Y.Length; i++)
                {
                    Points.Add(new DataPoint(hm, Dan.Y[i]));
                    Points2.Add(new DataPoint(hm, Dan.Y_Sort[i]));
                    hm += Dan.h;
                }

            }
        }
        public string Title { get; private set; }
        public PlotModel MyModel { get; private set; }
        public IList<DataPoint> Points { get; private set; }
        public IList<DataPoint> Points2 { get; private set; }
    }
}
