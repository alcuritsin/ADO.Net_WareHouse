using System;
using System.Collections.Generic;
using MySqlX.XDevAPI.Relational;

namespace LibDB
{
    public class AnyTables
    {
        public TableRow Title { get; set; }
        public List<TableRow> Table { get; set; }

        public AnyTables()
        {
            Title = new TableRow();
            Table = new List<TableRow>();
        }
        public void SetTitle(TableRow tableRow)
        {
            Title = tableRow;
        }

        public void SetTable (List<TableRow> table)
        {
            Table = table;
        }

        public void AddToTitle(string value)
        {
            Title.Row.Add(new TableCell(value));
        }

        public void AddToTable(TableRow row)
        {
            Table.Add(row);
        }
    }
    public class TableRow
    {
        public List<TableCell> Row { get; }

        public TableRow()
        {
            Row = new List<TableCell>();
        }

        public void AddCell(TableCell cell)
        {
            Row.Add(cell);
        }

        public void AddCell(string valueCell)
        {
            Row.Add(new TableCell(valueCell));
        }
        
    }
    public class TableCell
    {
        private string CellValue;
    
        public TableCell()
        {
            CellValue= String.Empty;
        }
    
        public TableCell(string value)
        {
            CellValue = value;
        }

        public string GetValue()
        {
            return CellValue;
        }
    }
}