using AlgorithmBenchmark.Core;
using AlgorithmBenchmark.ResultCtrl;
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
using System.Windows.Shapes;

namespace AlgorithmBenchmark
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Loader4Algo _loadert = new Loader4Algo();


        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            resBorder.Child = new ResultCtrl4Chart();

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
                        var lists = new List<AlgoItem>();

                        foreach (var item in tps)
                        {
                            lists.Add(new AlgoItem(item));
                        }

                        algoList.ItemsSource = lists;
                    }
                });
            }, null);
        }

        IDictionary<string, TestResult> _result;

        void UpdateResult(IDictionary<string, TestResult> res)
        {
            _result = res;
            UpdateResult();
        }

        private void UpdateResult()
        {
            (resBorder.Child as IResultCtrl).ShowResult(_result);
        }

        void InvokeThis(Action action)
        {
            this.InvokeIfNeeded(action);
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

        IAlgorithmInfo _curAlgo;

        private void algoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count < 1)
            {
                return;
            }
            
            _curAlgo = ((AlgoItem)e.AddedItems[0]).algo;

            TestAlgo();
        }

        void TestAlgo()
        {

            if (_curAlgo != null)
            {
                algoDesc.Text = _curAlgo.Desc;
                int tt = 10;
                int.TryParse(testTime.Text, out tt);

                IDictionary<string, TestResult> res = null;

                var action = new Action(() =>
                {
                    var prcs = _loadert.GetAllAlgos(_curAlgo, p => InvokeThis(
                     () => SetProgress(p)));

                    var tester = _loadert.GetTester(_curAlgo);

                    InvokeThis(() =>
                    {
                        if (tester.ParamsCtrl != null)
                        {
                            gridTestParam.Height = new GridLength(tester.ParamsCtrl.Height);
                            testParam.Child = tester.ParamsCtrl;
                        }
                        else
                        {
                            gridTestParam.Height = new GridLength(0);
                        }
                    });


                    for (int i = 0; i < tt; i++)
                    {
                        tester = _loadert.GetTester(_curAlgo);
                        if (tester != null)
                        {
                            if (prcs != null)
                            {
                                res = Merge(res, tester.Test(prcs));
                            }
                        }

                        SetProgress(i * 100 / tt);
                    }
                });

                algoList.IsEnabled = false;

                action.BeginInvoke(o =>
                {
                    InvokeThis(() =>
                    {
                        algoList.IsEnabled = true;
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

        private void resChart_Click(object sender, RoutedEventArgs e)
        {
            resBorder.Child = new ResultCtrl4Chart();
            UpdateResult();
        }

        private void resGrid_Click(object sender, RoutedEventArgs e)
        {
            resBorder.Child = new ResultCtrl4Grid();
            UpdateResult();
        }

        private void resLogs_Click(object sender, RoutedEventArgs e)
        {
            resBorder.Child = new ResultCtrl4Log();
            UpdateResult();
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            TestAlgo();
        }
    }


    class AlgoItem
    {
        IAlgorithmInfo _topic;

        public AlgoItem(IAlgorithmInfo algo)
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
