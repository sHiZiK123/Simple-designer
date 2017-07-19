using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ReleaseProject {
    public partial class LabelData : Label {
        DataTable table = new DataTable();
        FrameworkElement dependChart;

        public FrameworkElement DependentChart { get { return dependChart; } set { dependChart = value; } }

        public LabelData() {
            table = new DataTable();
        }
        public DataTable Table { get { return table; } set { table = value; } }
        public void FillTable(DataTable dt, string colName) {
            DataColumn idColumn = new DataColumn();
            idColumn.DataType = dt.Columns[colName].DataType; ;
            idColumn.ColumnName = colName;
            table.Columns.Add(idColumn);
            foreach (DataRow Tab1Row in dt.Rows) {
                DataRow row = table.NewRow();
                foreach (DataColumn Tab1Column in dt.Columns)
                    if (Tab1Column.ColumnName == colName) row[Tab1Column.ColumnName] = Tab1Row[Tab1Column.ColumnName];
                table.Rows.Add(row);
            }
        }
    }
}
