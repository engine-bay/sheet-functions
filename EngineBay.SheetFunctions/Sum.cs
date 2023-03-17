namespace EngineBay.SheetFunctions
{
    using System;
    using System.Data;
    using System.Globalization;

    public static partial class EngineFunctions
    {
        public static string SUM(DataTable dataTable)
        {
            if (dataTable is null)
            {
                throw new ArgumentNullException(nameof(dataTable));
            }

            double sum = 0;
            foreach (DataColumn col in dataTable.Columns)
            {
                if (!string.IsNullOrEmpty(col.ColumnName))
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row[col.ColumnName] is not null)
                        {
                            var value = row[col.ColumnName].ToString();
                            if (!string.IsNullOrEmpty(value))
                            {
                                sum += double.Parse(value, CultureInfo.InvariantCulture);
                            }
                        }
                    }
                }
            }

            return sum.ToString(CultureInfo.InvariantCulture);
        }
    }
}