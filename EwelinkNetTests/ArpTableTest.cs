using EwelinkNet.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace EwelinkNet.Tests
{
    public class ArpTableTest
    {
        private readonly ITestOutputHelper output;
        

        public ArpTableTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void RestoreFromFile()
        {
            var arpTable = new ArpTable();
            arpTable.RestoreFromFile();

            foreach (var item in arpTable.Entries)
            {
                output.WriteLine(item.ToString());
            }
        }

    }
}
