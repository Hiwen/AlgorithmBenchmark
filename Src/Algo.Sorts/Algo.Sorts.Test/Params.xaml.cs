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

namespace Algo.Sorts.Test
{
    /// <summary>
    /// Params.xaml 的交互逻辑
    /// </summary>
    public partial class Params : UserControl
    {
        public Params()
        {
            InitializeComponent();
        }

        int _dataNum = 10000;

        public int DataNum
        {
            get
            {
                this.InvokeIfNeeded(()=>
                int.TryParse(tbDataNum.Text, out _dataNum));
                
                return _dataNum;
            }
            set
            {
                if (value > 0)
                {
                    tbDataNum.Text = value.ToString();
                }
            }
        }
    }
}
