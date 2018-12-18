using AlgorithmBenchmark.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;

namespace AlgorithmBenchmark.ResultCtrl
{
    /// <summary>
    /// GridResultCtrl.xaml 的交互逻辑
    /// </summary>
    public partial class ResultCtrl4Grid : UserControl, IResultCtrl
    {
        public ResultCtrl4Grid()
        {
            InitializeComponent();
            gridRes.AutoGenerateColumns = true;
            gridRes.ItemsSource = new List<DataItem>();

            var type = typeof(DataItem);
            var pps = type.GetProperties();
            _columns = new Dictionary<string, string>();

            foreach (var p in pps)
            {
                var chName = p.Name;
                var atts = p.GetCustomAttributes(typeof(DisplayNameAttribute), false);
                if (atts.Count() > 0)
                {
                    chName = (atts[0] as DisplayNameAttribute).DisplayName;
                }
                _columns.Add(p.Name, chName);
            }
        }

        public UserControl Ctrl => this;

        public string Title => "表格结果";
        IDictionary<string, string> _columns;

        public void ShowResult(IDictionary<string, TestResult> result)
        {
            var temp = result.Select(p => new DataItem(p)).ToList();
            temp.Sort((a, b) => a.TimeCost < b.TimeCost ? -1 : 1);
            gridRes.ItemsSource = temp;
            foreach (var item in gridRes.Columns)
            {
                item.Header = _columns[item.Header.ToString()];
            }
        }

        class DataItem
        {
            KeyValuePair<string, TestResult> _pair;

            public DataItem(KeyValuePair<string, TestResult> pair)
            {
                _pair = pair;
            }

            [DisplayName("用户ID")]
            public string UserId => _pair.Key;

            /// <summary>
            /// 是否通过
            /// </summary>
            [DisplayName("是否通过")]
            public bool Successed => _pair.Value.Successed;

            /// <summary>
            /// 运行时间开销
            /// </summary>
            [DisplayName("时间开销(ms)")]
            public double TimeCost => _pair.Value.TimeCost;

            ///// <summary>
            ///// 运行内存开销
            ///// </summary>
            //[DisplayName("内存开销(KB)")]
            //public double MemoryCost => _pair.Value.MemoryCost;
        }
    }
}
