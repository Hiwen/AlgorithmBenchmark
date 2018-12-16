using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmBenchmark.Core
{
    public class Loader4Algo : ILoader4Algo
    {
        const string TopicsPath = "Algorithms";

        IEnumerable<T> CreateInstances<T>(string dir, string patten, 
            Func<Type, bool> selector, Func<Type, T> instance, 
            Action<int> pr, bool onlyOne = false)
        {
            var res = new List<T>();

            var files = Directory.EnumerateFiles(dir, patten);
            if (files != null)
            {
                int index = 1;
                int count = files.Count();
                foreach (var item in files)
                {
                    var ass = Assembly.LoadFile(item);
                    if (ass != null)
                    {
                        var tps = ass.GetTypes();
                        if (tps != null)
                        {
                            var algos = tps.Where(selector);
                            if (algos != null)
                            {
                                res.AddRange(algos.Select(t => instance(t)));
                            }
                        }
                    }

                    if (onlyOne && res.Count > 0)
                    {
                        return res;
                    }

                    pr?.Invoke(index++ * 100 / count);
                }
            }

            return res;
        }

        IList<IAlgorithmInfo> _topics;
        public IEnumerable<IAlgorithmInfo> GetAllAlgoInfos(Action<int> pr)
        {
            if (_topics == null)
            {
                _topics = new List<IAlgorithmInfo>();

                var fn = this.GetType().Assembly.Location;
                var path = Path.GetDirectoryName(fn);
                if (!string.IsNullOrEmpty(path))
                {
                    var itps = CreateInstances<IAlgorithmInfo>(path, "Algo.*.dll", t =>
                    {
                        var refed = !t.IsAbstract && t.IsPublic;
                        var type = t.GetInterface(nameof(IAlgorithmInfo));
                        return type != null && refed;
                    }, t => Activator.CreateInstance(t) as IAlgorithmInfo, pr);

                    if (itps != null)
                    {
                        foreach (var t in itps)
                        {
                            if (t != null)
                            {
                                _topics.Add(t);
                            }
                        }
                    }
                }
            }

            return _topics;
        }

        public IEnumerable<IAlgorithm> GetAllAlgos(IAlgorithmInfo algo, Action<int> pr)
        {
            var inter = GetPracticeInterfaceType(algo);
            if (inter != null)
            {
                var path = algo.GetType().Assembly.Location;
                var dir = Path.GetDirectoryName(path);
                dir = Path.Combine(dir, TopicsPath, algo.Dir);

                var pracs = CreateInstances(dir, "*.dll", t =>
                {
                    var refed = !t.IsAbstract && t.IsPublic;
                    var type = t.GetInterface(inter.Name);
                    return type != null && refed;
                }, t => Activator.CreateInstance(t) as IAlgorithm, pr);

                return pracs;
            }

            return null;
        }

        public Type GetPracticeInterfaceType(IAlgorithmInfo algo)
        {
            var ass = algo.GetType().Assembly;
            var ps = ass.GetTypes().Where(t => 
            {
                var isI = t.IsInterface;
                if (isI && t.GetInterface(nameof(IAlgorithm)) != null)
                {
                    return true;
                }

                return false;
            });

            if (ps != null && ps.Count() > 0)
            {
                return ps.First();
            }

            return null;
        }

        public IAlgoTester GetTester(IAlgorithmInfo algo)
        {
            var path = algo.GetType().Assembly.Location;
            var dir = Path.GetDirectoryName(path);
            dir = Path.Combine(dir, TopicsPath, algo.Dir);

            var pracs = CreateInstances(dir, "Algo.*.dll", t =>
            {
                var refed = !t.IsAbstract && t.IsPublic;
                var type = t.GetInterface(nameof(IAlgoTester));
                return type != null && refed;
            }, t => Activator.CreateInstance(t) as IAlgoTester, null);

            if (pracs != null && pracs.Count() > 0)
            {
                return pracs.First();
            }

            return null;
        }
    }
}
