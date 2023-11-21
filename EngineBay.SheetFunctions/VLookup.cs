namespace EngineBay.SheetFunctions
{
    using System;
    using System.Data;

    public static partial class EngineFunctions
    {
        public static string VLOOKUP(string lookupValue, DataTable dataTable, int index, int sortDirection)
        {
            ArgumentNullException.ThrowIfNull(dataTable);

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
                                if (value == lookupValue)
                                {
                                    var offsetIndex = index - 1; // because excel stats at 1, not zero
                                    var desiredColumnName = dataTable.Columns[offsetIndex].ColumnName;
                                    var desiredValue = row[desiredColumnName].ToString();
                                    if (!string.IsNullOrEmpty(desiredValue))
                                    {
                                        return desiredValue;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return string.Empty;
        }
    }
}