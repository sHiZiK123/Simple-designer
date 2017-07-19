using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xceed.Wpf.AvalonDock.Layout;

namespace ReleaseProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();   
        }

        public List<LabelData> DataForCharts { get; set; }


        ///Перетаскивание объектов
        private void lbMouseDown(object sender, MouseButtonEventArgs e) {
            LabelData lbl = (LabelData)sender;
            DragAndDropMaster dnd = new DragAndDropMaster();

            if (lbl.Content != null && e.LeftButton == MouseButtonState.Pressed) {
            //  firstWorkField.Background = new SolidColorBrush(Colors.LightBlue);
            //  secondWorkField.Background = new SolidColorBrush(Colors.LightBlue);
                dnd.CreateDragDropWindow(lbl, this);
                DragDrop.DoDragDrop(lbl, lbl, DragDropEffects.Copy);
                //secondWorkField.Background = new SolidColorBrush(Colors.White);
                //firstWorkField.Background = new SolidColorBrush(Colors.White);
                
            }
        }



        private void stackPanel1_Drop(object sender, DragEventArgs e) {
            LabelData lb = e.Data.GetData(e.Data.GetFormats()[0]) as LabelData;
            if (lb.Parent.GetType().ToString() == "System.Windows.Controls.Border" && (((Border)lb.Parent).Name == "firstWorkFieldBorder"
                || ((Border)lb.Parent).Name == "secondWorkFieldBorder"
                || ((Border)lb.Parent).Name == "seriesBorder")) {
                lb.Content = null;
                lb.Table = null;
                (lb.DependentChart as Chart).Series.Clear();
            }
        }

        private void TargetSeries_Drop(object sender, DragEventArgs e) {
            LabelData insertLabel = sender as LabelData;
            LabelData lb = e.Data.GetData(e.Data.GetFormats()[0]) as LabelData;
            if ((((FrameworkElement)lb.Parent).Name != "firstWorkFieldBorder"
                || ((FrameworkElement)lb.Parent).Name != "secondWorkFieldBorder"
                || ((FrameworkElement)lb.Parent).Name != "seriesBorder")) {
                insertLabel.MouseDown += new MouseButtonEventHandler(lbMouseDown);
                insertLabel.Content = lb.Content;
                insertLabel.Table = lb.Table;
            }
        }



        public void Update() {
            foreach(var label in DataForCharts) {
                label.MouseDown += new MouseButtonEventHandler(lbMouseDown);
                stackPanel.Children.Add(label);
            }
        }

        private void NewDataBaseConnect(object sender, RoutedEventArgs e) {
            ConnectWindow wind = new ConnectWindow();
            wind.Owner = Window.GetWindow(this);
            wind.Show();
        }

        private void NewFileCreate(object sender, RoutedEventArgs e) {

        }

        private void OpenSavedFile(object sender, RoutedEventArgs e) {

        }

        private void SaveDataToFile(object sender, RoutedEventArgs e) {

        }


        
        void Update_Panel(object sender, System.ComponentModel.PropertyChangedEventArgs e) {
            try {
                ((sender as LayoutAnchorable).Content as ColumnChart).UpdatePanel();
            }
            catch {}
            try {
                ((sender as LayoutAnchorable).Content as PieChart).UpdatePanel();
            }
            catch {}
            try {
                ((sender as LayoutAnchorable).Content as AreaChart).UpdatePanel();
            }
            catch {}
            try
            {
                ((sender as LayoutAnchorable).Content as LineChart).UpdatePanel();
            }
            catch { }
        }

        void NewColumnChart(object sender, RoutedEventArgs e) {
            ColumnChart chrt = new ColumnChart(stackPanel1);
            LayoutAnchorablePaneGroup tmp = new LayoutAnchorablePaneGroup();
            tmp.Orientation = Orientation.Vertical;
            LayoutAnchorablePaneGroup tmp2 = new LayoutAnchorablePaneGroup();
            tmp.Orientation = Orientation.Horizontal;
            LayoutAnchorablePane tmp3 = new LayoutAnchorablePane();
            LayoutAnchorable tmp4 = new LayoutAnchorable();
            tmp4.Title = "Гистограмма";
            tmp4.ContentId = "Гистограмма";
            tmp4.Content = new ColumnChart(stackPanel1);
            tmp4.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Update_Panel);
            tmp.Children.Add(tmp2);
            tmp2.Children.Add(tmp3);
            tmp3.Children.Add(tmp4);
            Test2.Children.Add(tmp);
        }

        void NewPieChart(object sender, RoutedEventArgs e) {
            LayoutAnchorablePaneGroup tmp = new LayoutAnchorablePaneGroup();
            tmp.Orientation = Orientation.Vertical;
            LayoutAnchorablePaneGroup tmp2 = new LayoutAnchorablePaneGroup();
            tmp.Orientation = Orientation.Horizontal;
            LayoutAnchorablePane tmp3 = new LayoutAnchorablePane();
            LayoutAnchorable tmp4 = new LayoutAnchorable();
            tmp4.Title = "Диаграмма";
            tmp4.ContentId = "Диаграмма";
            tmp4.Content = new PieChart(stackPanel1);
            tmp4.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Update_Panel);
            tmp.Children.Add(tmp2);
            tmp2.Children.Add(tmp3);
            tmp3.Children.Add(tmp4);
            Test2.Children.Add(tmp);
        }

        void NewAreaChart(object sender, RoutedEventArgs e) {
            LayoutAnchorablePaneGroup tmp = new LayoutAnchorablePaneGroup();
            tmp.Orientation = Orientation.Vertical;
            LayoutAnchorablePaneGroup tmp2 = new LayoutAnchorablePaneGroup();
            tmp.Orientation = Orientation.Horizontal;
            LayoutAnchorablePane tmp3 = new LayoutAnchorablePane();
            LayoutAnchorable tmp4 = new LayoutAnchorable();
            tmp4.Title = "Диаграмма-область";
            tmp4.ContentId = "Диаграмма-область";
            tmp4.Content = new AreaChart(stackPanel1);
            tmp4.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Update_Panel);
            tmp.Children.Add(tmp2);
            tmp2.Children.Add(tmp3);
            tmp3.Children.Add(tmp4);
            Test2.Children.Add(tmp);
        }

        void NewLineChart(object sender, RoutedEventArgs e) {
            LayoutAnchorablePaneGroup tmp = new LayoutAnchorablePaneGroup();
            tmp.Orientation = Orientation.Vertical;
            LayoutAnchorablePaneGroup tmp2 = new LayoutAnchorablePaneGroup();
            tmp.Orientation = Orientation.Horizontal;
            LayoutAnchorablePane tmp3 = new LayoutAnchorablePane();
            LayoutAnchorable tmp4 = new LayoutAnchorable();
            tmp4.Title = "Линейная диаграмма";
            tmp4.ContentId = "Линейная диаграмма";
            tmp4.Content = new LineChart(stackPanel1);
            tmp4.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Update_Panel);
            tmp.Children.Add(tmp2);
            tmp2.Children.Add(tmp3);
            tmp3.Children.Add(tmp4);
            Test2.Children.Add(tmp);
        }

     
    }
}
