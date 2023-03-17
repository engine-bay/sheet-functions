namespace EngineBay.SheetFunctions.Tests
{
    using System.Data;
    using EngineBay.SheetFunctions;
    using Xunit;

    public class SumTest
    {
        [Fact]
        public void CanSumUpNumericValuesInADataTable()
        {
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(new DataColumn[1] { new DataColumn("NumericValues", typeof(int)) });
            dataTable.Rows.Add(1);
            dataTable.Rows.Add(2);
            dataTable.Rows.Add(3);

            var result = EngineFunctions.SUM(dataTable);

            Assert.Equal("6", result);

            dataTable.Dispose();
        }

        [Fact]
        public void CanSumUpAMatrixOfMixedNumericValuesInADataTable()
        {
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(new DataColumn[3] { new DataColumn("IntValues", typeof(int)), new DataColumn("FloatValues", typeof(float)), new DataColumn("DecimalValues", typeof(decimal)) });
            dataTable.Rows.Add(1, 2, 3);
            dataTable.Rows.Add(4, 5, 6);
            dataTable.Rows.Add(7, 8, 9);

            var result = EngineFunctions.SUM(dataTable);

            Assert.Equal("45", result);

            dataTable.Dispose();
        }
    }
}
