using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySortAndSearch
{
    public class BenchmarkLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName) => new BenchmarkLogger();

        public void Dispose() { }
    }
}
