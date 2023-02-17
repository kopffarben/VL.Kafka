using Neo4j.Driver;
using VL.Lib.Collections;

using System.Linq;

namespace Memgraph
{
    public class Memgraph : IDisposable
    {
        private readonly IDriver _driver;

        public Memgraph(string uri = "bolt://localhost:7687")
        {
            _driver = GraphDatabase.Driver(uri, AuthTokens.None);
        }

        public void ExecuteWrite(string query, bool apply, out Spread<Spread<string>> result)
        {
            var sb = new SpreadBuilder<Spread<string>>();
            if (apply)
            {                

                using (var session = _driver.Session())
                {
                    
                    var record = session.Run(query).Select(record => record);
                    foreach(var r in record)
                    {
                        List<string> list = new List<string>();
                        foreach (var c in r.Values)
                        {
                            list.Add(c.Value.As<string>());
                        }
                        sb.Add(list.ToSpread());
                    }
                }
            }
            result = sb.ToSpread();
        }

        public void Dispose()
        {
            _driver?.Dispose();
        }
    }
}