using BenchmarkDotNet.Analysers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Toolchains.InProcess.Emit;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySortAndSearch
{
    public class MediumConfig : ManualConfig
    {
        public MediumConfig()
        {
            AddJob(Job.Dry
         
           .WithToolchain(InProcessNoEmitToolchain.Instance)
           .WithWarmupCount(0));
            
          
            
            AddColumn(TargetMethodColumn.Method, StatisticColumn.Mean);
            //AddColumn(TargetMethodColumn.Method, StatisticColumn.StdErr);
            //AddColumn(TargetMethodColumn.Method, StatisticColumn.StdDev);
            //AddColumn(TargetMethodColumn.Method, OmittedArraySizeExpressionSyntax.);
           

            AddLogger(ConsoleLogger.Default);
            AddAnalyser(EnvironmentAnalyser.Default);
            UnionRule = ConfigUnionRule.AlwaysUseLocal;
        }
    }
}
