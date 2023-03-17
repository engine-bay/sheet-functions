namespace EngineBay.SheetFunctions.Tests
{
    using System.Data;
    using EngineBay.SheetFunctions;
    using Xunit;

    public class VLookupTest
    {
        [Fact]
        public void CanFindAValueInADataTable()
        {
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(new DataColumn[2] { new DataColumn("stringValues", typeof(string)), new DataColumn("NumericValues", typeof(int)) });
            dataTable.Rows.Add("A", 1);
            dataTable.Rows.Add("B", 2);
            dataTable.Rows.Add("C", 3);

            var result = EngineFunctions.VLOOKUP("C", dataTable, 2, 1);

            Assert.Equal("3", result);

            dataTable.Dispose();
        }
    }
}
