using System;
using Xunit;
using ManticoreSearch.Client.Api;
using Xunit.Abstractions;

namespace ManticoreSearch.Client.Test
{
    public class UtilApiTest
    {
        private readonly ITestOutputHelper output;
        readonly UtilsApi util = new UtilsApi();

        public UtilApiTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test1()
        {
            try
            {
                var result = util.Sql(@"query=select * from products");
                foreach (var item in result)
                {
                    output.WriteLine($"{item.Key} {item.Value}"); 
                }
            }
            catch (Exception e)
            {
                output.WriteLine(e.Message);
                output.WriteLine(e.ToString());
            }
        }
    }
}