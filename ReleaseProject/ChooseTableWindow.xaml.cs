using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ReleaseProject
{
    /// <summary>
    /// Логика взаимодействия для ChooseTableWindow.xaml
    /// </summary>
    public partial class ChooseTableWindow : Window {
        Window window;
        DatabaseConnector connector;
        List<LabelData> dataForCharts = new List<LabelData>();
        DataTable sourceData = new DataTable();
        int index = 0;
        bool btnpress = false;


        public ChooseTableWindow(Window wind, DatabaseConnector con) {
            InitializeComponent();
            window = wind;
            connector = con;

            //TreeViewItem item = new TreeViewItem();
            //item.Header = "Test";
            //item.Items.Add(new CheckBox());
            //item.Items.Add(new CheckBox());
            //item.Items.Add(new CheckBox());
            //tree.Items.Add(item);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            string selectCommand = "SELECT * FROM sys.objects WHERE type in (N'U')";
            DataTable table = new DataTable();

            var a = connector.ConnectionString.ToString();

            using (SqlConnection con = new SqlConnection(connector.ConnectionString.ToString())) {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommand, con);
                adapter.Fill(table);
                con.Close();
            }
   
            for (int i = 0; i < table.Rows.Count; i++) {
                TreeViewItem item = new TreeViewItem();
                CheckBox cbx = new CheckBox();
                cbx.Content = table.Rows[i][0].ToString();
                item.Header = cbx;
                cbx.Checked += new RoutedEventHandler(HeaderChecked);
                cbx.Unchecked += new RoutedEventHandler(HeaderUnchecked);
                tree.Items.Add(item);
            }
         
            foreach (TreeViewItem bb in tree.Items) {
                DataTable dt = new DataTable();
                string tmp = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '";
                tmp += (bb.Header as CheckBox).Content.ToString()+"';";
                SqlConnection con = new SqlConnection(connector.ConnectionString.ToString());
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(tmp, con);
                adapter.Fill(dt);
               // foreach(var hh in table.Columns)
                for(int i=0;i<dt.Rows.Count;i++){
                    CheckBox cbx = new CheckBox();
                    cbx.Content = dt.Rows[i][0];
                    cbx.Checked += new RoutedEventHandler(AddInInfoTable);
                    cbx.Unchecked += new RoutedEventHandler(RemoveFromInfoTable);
                    bb.Items.Add(cbx);
                }
                con.Close();
            }
        }

        void AddInInfoTable(object sender, RoutedEventArgs e) {
            string req = "select " + (sender as CheckBox).Content + " from " + 
                (((TreeViewItem)(sender as CheckBox).Parent).Header as CheckBox).Content;
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(connector.ConnectionString.ToString());
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(req, con);
            adapter.Fill(dt);
            LabelData ld = new LabelData();
            ld.Content = (sender as CheckBox).Content;
            ld.Table = dt;
            dataForCharts.Add(ld);
            DataColumn col = new DataColumn();
            col.ColumnName = (sender as CheckBox).Content.ToString();
            col.DataType = dt.Columns[0].DataType;
            sourceData.Columns.Add((sender as CheckBox).Content.ToString(),dt.Columns[0].DataType);

            for (int i = 0; i < dt.Rows.Count; ++i) {
                if(index==0) {
                DataRow dtr = sourceData.NewRow();
                sourceData.Rows.Add(dtr);
                }
                sourceData.Rows[i][index] = dt.Rows[i][0];
            }
            ++index;
            
            infoTable.ItemsSource = null;
            infoTable.ItemsSource = sourceData.DefaultView;
        }

        void RemoveFromInfoTable(object sender, RoutedEventArgs e) {
            var removeValue = dataForCharts.First(x => x.Content == (sender as CheckBox).Content);
            dataForCharts.Remove(removeValue);
            foreach (DataColumn col in sourceData.Columns)
                if (col.ColumnName.ToString() == (sender as CheckBox).Content.ToString()) {
                    sourceData.Columns.Remove(col);
                    --index;
                    if (index == 0)
                        sourceData = new DataTable();
                    infoTable.ItemsSource = null;
                    infoTable.ItemsSource = sourceData.DefaultView;
                    break;
                }
        }

        void HeaderUnchecked(object sender, RoutedEventArgs e) {
            foreach (TreeViewItem v in tree.Items)
               if ((v.Header as CheckBox) == (sender as CheckBox))
                    foreach (CheckBox vv in v.Items)
                        vv.IsChecked = false;
        }

        void HeaderChecked(object sender, RoutedEventArgs e) {
            foreach (TreeViewItem v in tree.Items) 
                if ((v.Header as CheckBox) == (sender as CheckBox))
                    foreach (CheckBox vv in v.Items)
                        vv.IsChecked = true;
        }

        private void Window_Closed(object sender, EventArgs e) {
            if(!btnpress)
            window.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            window.Show();
            btnpress = true;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            window.Close();
            Close();
            (window.Owner as MainWindow).DataForCharts = dataForCharts;
            (window.Owner as MainWindow).Update();
        }
    }
}
