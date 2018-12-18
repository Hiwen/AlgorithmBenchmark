﻿using System;
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

namespace AlgorithmBenchmark
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindowOld : Window
    {
        Loader4Algo _loadert = new Loader4Algo();

        public MainWindowOld()
        {
            InitializeComponent();
            InitWindow();

            DataContext = this;
        }

        public override void EndInit()
        {
            base.EndInit();
        }

        void InvokeThis(Action action)
        {
            this.InvokeIfNeeded(action);
        }

        void InitWindow()
        {

            if (ResultCtrls.ResultCtrl != null && ResultCtrls.ResultCtrl.Count() > 0)
            {
                tabResult.Items.Clear();
                foreach (var item in ResultCtrls.ResultCtrl)
                {
                    tabResult.Items.Add(new TabItem()
                    {
                        Header = item.Title,
                        Content = item.Ctrl
                    });
                }

                var res = new Dictionary<string, TestResult>();
                res.Add("张三", new TestResult() { MemoryCost = 0, Successed = true, TimeCost = 200 });
                res.Add("李四", new TestResult() { MemoryCost = 0, Successed = true, TimeCost = 500 });
                res.Add("王五", new TestResult() { MemoryCost = 0, Successed = true, TimeCost = 400 });
                UpdateResult(res);

                IEnumerable<IAlgorithmInfo> tps = null;
                var loadTopics = new Action(() => tps = _loadert.GetAllAlgoInfos(
                    p => SetProgress(p)));

                loadTopics.BeginInvoke(o =>
                {
                    InvokeThis(() =>
                    {
                        if (tps != null)
                        {
                            cmbAlgos.Items.Clear();

                            foreach (var item in tps)
                            {
                                cmbAlgos.Items.Add(new TopicItem(item));
                            }

                            if (cmbAlgos.Items.Count > 0)
                            {
                                cmbAlgos.SelectedIndex = 0;
                            }

                            cmbAlgos.Items.Add("请您期待其他测试... ...");
                        }
                    });
                }, null);
            }
        }

        private void btnBench_Click(object sender, RoutedEventArgs e)
        {

            if (cmbAlgos.SelectedItem != null)
            {
                int testTime = 10;
                if (!int.TryParse(teTestTime.Text, out testTime))
                {
                    MessageBox.Show("您输入的测试次数不正确!", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var algo = ((TopicItem)cmbAlgos.SelectedItem).algo;
                if (algo != null)
                {
                    IDictionary<string, TestResult> res = null;

                    var action = new Action(() =>
                    {
                        var prcs = _loadert.GetAllAlgos(algo, p => InvokeThis(
                         () => SetProgress(p)));

                        for (int i = 0; i < testTime; i++)
                        {
                            var tester = _loadert.GetTester(algo);
                            if (tester != null)
                            {
                                if (prcs != null)
                                {
                                    res = Merge(res, tester.Test(prcs));
                                }
                            }

                            SetProgress(i * 100 / testTime);
                        }
                    });

                    btnBench.IsEnabled = false;

                    action.BeginInvoke(o => {
                        InvokeThis(() =>
                        {
                            btnBench.IsEnabled = true;
                            SetProgress(100);
                            if (res != null && res.Count > 0)
                            {
                                UpdateResult(res);
                                return;
                            }
                            else
                            {
                                MessageBox.Show("测试失败!", "提示", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        });
                    }, null);
                }
            }
        }
        private void cmbAlgos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnBench.IsEnabled = cmbAlgos.SelectedItem as TopicItem != null;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

        IDictionary<string, TestResult> _result;

        void UpdateResult(IDictionary<string, TestResult> res)
        {
            _result = res;
            UpdateResult();
        }

        IDictionary<string, TestResult> Merge(IDictionary<string, TestResult> dst, IDictionary<string, TestResult> src)
        {
            if (dst == null)
            {
                return src;
            }

            foreach (var item in src)
            {
                if (dst.ContainsKey(item.Key))
                {
                    dst[item.Key] += item.Value;
                }
                else
                {
                    dst.Add(item);
                }
            }

            return dst;
        }

        void SetProgress(int prg)
        {
            InvokeThis(() =>
            {
                if (prg != progress.Value)
                {
                    progress.Value = prg;

                    var vsbl = prg != 100 ? Visibility.Visible : Visibility.Hidden;
                    if (progress.Visibility != vsbl)
                    {
                        progress.Visibility = vsbl;
                    }
                }
            });
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateResult();
        }

        void UpdateResult()
        {
            if (tabResult.SelectedIndex > -1 && tabResult.SelectedIndex < ResultCtrls.ResultCtrl.Count())
            {
                ResultCtrls.ResultCtrl[tabResult.SelectedIndex]?.ShowResult(_result);
            }
        }
    }

    /// <summary>
    /// 算法Item
    /// </summary>
    class TopicItem
    {
        IAlgorithmInfo _topic;

        public TopicItem(IAlgorithmInfo algo)
        {
            _topic = algo;
        }

        public override string ToString()
        {
            return _topic.Name;
        }

        public IAlgorithmInfo algo => _topic;
    }
}
