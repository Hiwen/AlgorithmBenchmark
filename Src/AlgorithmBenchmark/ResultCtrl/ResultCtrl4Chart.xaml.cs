using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AlgorithmBenchmark.Core;
using LiveCharts;
using LiveCharts.Wpf;

namespace AlgorithmBenchmark.ResultCtrl
{
    /// <summary>
    /// ChartResultCtrl.xaml 的交互逻辑
    /// </summary>
    public partial class ChartResultCtrl : UserControl, IResultCtrl
    {
        public ChartResultCtrl()
        {
            InitializeComponent();
        }

        public UserControl Ctrl => this;

        public string Title => "图示结果";


        public void ShowResult(IDictionary<string, TestResult> result)
        {
            var list = result.ToList();
            list.Sort((a, b) => a.Value.TimeCost < b.Value.TimeCost ? 1 : -1);

            chtResult.Series = new SeriesCollection
            {
                new RowSeries
                {
                    Title = "Time",
                    Values = new ChartValues<double>(list.Select(v => v.Value.TimeCost))
                }
            };

            chtResult.AxisX[0].LabelFormatter = v => v.ToString();
            chtResult.AxisX[0].Title = "Time(ms)";
            chtResult.AxisY[0].Title = "Users";
            chtResult.AxisY[0].Labels = list.Select(v => v.Key).ToArray();
        }


    }
}
