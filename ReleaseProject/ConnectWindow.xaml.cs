using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для ConnectWindow.xaml
    /// </summary>
    public partial class ConnectWindow : Window {
        DatabaseConnector dbcon = new DatabaseConnector();
        List<string> list;
        public ConnectWindow() {
            InitializeComponent();   

            dataBaseName.GotFocus += new RoutedEventHandler(DatabaseGetNames);
            windAut.IsChecked = true;
        }

        private void windAut_Checked(object sender, RoutedEventArgs e) {
            userName.IsEnabled = false;
            password.IsEnabled = false;
        }

        private void sqlAut_Checked(object sender, RoutedEventArgs e) {
            userName.IsEnabled = true;
            password.IsEnabled = true;
        }

        private void DatabaseGetNames(Object sender, EventArgs e) {
            if (list != null) {
                dataBaseName.ItemsSource = list;
                //dataBaseName.DataContext = list;
                //dataBaseName.SelectedIndex = 0;
                dbcon.InitialCatalog = dataBaseName.Text;
            }
            else
            {
                dataBaseName.SelectedIndex = -1;
                this.Focus();
                MessageBox.Show("Ошибка подключения.");
            }
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            dbcon.InitializeFields(serverName.Text.ToString(), (bool)sqlAut.IsChecked, userName.Text, password.Password.ToString(), dataBaseName.Text.ToString());
            if (dbcon.CheckConnect()) MessageBox.Show("OK");
            else MessageBox.Show("Ошибка подключения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void button2_Click(object sender, RoutedEventArgs e) {
            (Owner as MainWindow).Focus();
            this.Close();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            dbcon.InitializeFields(serverName.Text.ToString(), (bool)sqlAut.IsChecked, userName.Text, password.Password.ToString(), dataBaseName.Text.ToString());
            if (dbcon.CheckConnect())  {
                ChooseTableWindow tableWindow = new ChooseTableWindow(this,dbcon);
                tableWindow.Show();
                //Form f2 = new Form3(dbcon,this);
                //f2.Show();
                Hide();
            }
            else MessageBox.Show("Error!!!!", "Erorr", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void dataBaseName_DropDownOpened(object sender, EventArgs e)
        {
            dbcon.InitializeFields(serverName.Text.ToString(), (bool)sqlAut.IsChecked, userName.Text, password.Password.ToString(), dataBaseName.Text.ToString());
            list = dbcon.GetDbList();
        }




    

    }
}
