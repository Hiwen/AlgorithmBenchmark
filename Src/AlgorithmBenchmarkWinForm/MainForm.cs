using AlgorithmBenchmark.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AlgorithmBenchmarkWinForm
{
    public partial class MainForm : Form
    {
        Loader4Algo _loadert = new Loader4Algo();

        public MainForm()
        {
            InitializeComponent();
        }

        // test commit

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            IEnumerable<IAlgorithmInfo> tps = null;
            var loadTopics = new Action(() => tps = _loadert.GetAllAlgoInfos(
                p => InvokeThis(
                    () => 
                    {
                        if (p != progress.Value)
                            progress.Value = p;
                    })));

            loadTopics.BeginInvoke(o => 
            {
                InvokeThis(() =>
                {
                    if (tps != null)
                    {
                        cmbTopics.Items.Clear();

                        foreach (var item in tps)
                        {
                            cmbTopics.Items.Add(new TopicItem(item));
                        }

                        if (cmbTopics.Items.Count > 0)
                        {
                            cmbTopics.SelectedIndex = 0;
                        }

                        cmbTopics.Items.Add("请您期待其他测试... ...");
                    }
                });
            }, null);
        }

        // test hotfix

        void UpdateChart(IDictionary<string, TestResult> res)
        {
            chtResult.Series.Clear();

            var s = new Series()
            {
                ChartType = SeriesChartType.Bar,
                Name = "测试结果",
            };

            var sk = new SortedSet<string>(res.Keys);
            foreach (var item in sk)
            {
                var p = new DataPoint();
                p.SetValueXY(item, res[item].TimeCost);
                s.Points.Add(p);
            }

            chtResult.Series.Add(s);
            chtResult.ChartAreas[0].AxisY.IsLabelAutoFit = true;
            chtResult.ChartAreas[0].RecalculateAxesScale();
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

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (cmbTopics.SelectedItem != null)
            {
                int testTime = 10;
                if(!int.TryParse(teTime.Text, out testTime))
                {
                    MessageBox.Show("您输入的测试次数不正确!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var algo = ((TopicItem)cmbTopics.SelectedItem).algo;
                if (algo != null)
                {
                    IDictionary<string, TestResult> res = null;

                    var action = new Action(() =>
                    {
                        var prcs = _loadert.GetAllAlgos(algo, p => InvokeThis(
                         () =>
                         {
                             if (p != progress.Value)
                                 progress.Value = p;
                         }));

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

                            InvokeThis(() => progress.Value = i * 100 / testTime);
                        }
                    });

                    btnTest.Enabled = false;

                    action.BeginInvoke(o => {
                        InvokeThis(() =>
                        {
                            btnTest.Enabled = true;
                            progress.Value = 100;
                            if (res != null && res.Count > 0)
                            {
                                UpdateChart(res);
                                return;
                            }
                            else
                            {
                                MessageBox.Show("测试失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        });
                    }, null);
                }
            }
        }

        void InvokeThis(Action action)
        {
            if (action != null)
            {
                if (InvokeRequired)
                {
                    Invoke(action);
                }
                else
                {
                    action?.Invoke();
                }
            }
        }
        private void cmbTopics_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnTest.Enabled = cmbTopics.SelectedItem as TopicItem != null;
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
