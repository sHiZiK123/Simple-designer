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
using System.Windows.Input;
using System.Windows.Media;

namespace ReleaseProject
{
    class PieChart:Chart {
         StackPanel panel;
        LabelData _value;
        LabelData _argument;
        Label info_value = new Label() {
            Content = "Значение",
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Width = 85,
            Height = 26,
            Margin = new Thickness(9,0,0,0)
        };
        Label info_argument = new Label() { 
            Content = "Аргумент",
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Width = 85,
            Height = 26,
            Margin = new Thickness(9, 10, 0, 0)
        };
        Border borderForValue;
        Border borderForArgument;

        public LabelData Value { get {return _value;} set { _value = value; } }
        public LabelData Argument { get {return _argument;} set { _argument = value; } }



        public PieChart(StackPanel pnl) {
            panel = pnl;
            panel.Children.Clear();
          
            _value = new LabelData() {
            Margin=new Thickness(0,0,0,0),
            Name="firstWorkField", 
            Content="",
            HorizontalContentAlignment=HorizontalAlignment.Center,  
            AllowDrop=true,
            DependentChart = this
            };
            _value.Drop += new DragEventHandler(Target_Drop);

            _argument = new LabelData() {
                Margin = new Thickness(0, 0, 0, 0),
                Name = "firstWorkField",
                Content = "",
                HorizontalContentAlignment = HorizontalAlignment.Center,
                AllowDrop = true,
                DependentChart = this
            };
            _argument.Drop += new DragEventHandler(Target_Drop);

            borderForValue = new Border() { 
                Name="firstWorkFieldBorder", 
                Margin = new Thickness(10,0,0,0), 
                BorderBrush = System.Windows.Media.Brushes.BlueViolet, 
                BorderThickness=new System.Windows.Thickness(1), 
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top, 
                Height = 30, 
                Width = 151
            };

            borderForArgument = new Border() {
                Name = "secondWorkFieldBorder",
                Margin = new Thickness(10, 0, 0, 0),
                BorderBrush = System.Windows.Media.Brushes.BlueViolet,
                BorderThickness = new System.Windows.Thickness(1),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Height = 30,
                Width = 151
            };

            borderForValue.Child = _value;
            borderForArgument.Child = _argument;
            panel.Children.Add(info_value);
            panel.Children.Add(borderForValue);
            panel.Children.Add(info_argument);
            panel.Children.Add(borderForArgument);  
        }

       public void UpdatePanel() {
            panel.Children.Clear();
            borderForValue.Child = _value;
            borderForArgument.Child = _argument;
            panel.Children.Add(info_value);
            panel.Children.Add(borderForValue);
            panel.Children.Add(info_argument);
            panel.Children.Add(borderForArgument); 
        }

        void Target_Drop(object sender, DragEventArgs e) {
            LabelData insertLabel = sender as LabelData;
            LabelData lb = e.Data.GetData(e.Data.GetFormats()[0]) as LabelData;
            if ((((FrameworkElement)lb.Parent).Name != "firstWorkFieldBorder"
                || ((FrameworkElement)lb.Parent).Name != "secondWorkFieldBorder"
                || ((FrameworkElement)lb.Parent).Name != "seriesBorder")) {
                insertLabel.MouseDown += new MouseButtonEventHandler(lbMouseDown);
                insertLabel.Content = lb.Content;
                insertLabel.Table = lb.Table;
                BindChart(insertLabel);
            }
        }

        void BindChart(LabelData ld) {
            PieSeries sr1 = new PieSeries();
                   if ((_value.Content != null) && (_argument.Content != null)
                       && (_value.Content.ToString() != "") && (_argument.Content.ToString() != "")) {
                       if (_value.Table.Columns[0].DataType.ToString() == "System.String") {
                           List<KeyValuePair<object, object>> tmp = new List<KeyValuePair<object, object>>();
                           int i = 0;
                           foreach (DataRow a in ld.Table.Rows)
                               tmp.Add(new KeyValuePair<object, object>(_argument.Table.Rows[i++][0], a.ItemArray[0]));

                           sr1.Title = _value.Content;
                           sr1.DependentValueBinding = new Binding("Value");//!Key
                           sr1.IndependentValueBinding = new Binding("Key");//secondWorkField.Table.Columns[0].ColumnName);
                           sr1.ItemsSource = tmp;//secondWorkField.Table.DefaultView; 
                       }
                       else {
                           List<KeyValuePair<object, object>> tmp = new List<KeyValuePair<object, object>>();
                           int i = 0;
                           foreach (DataRow a in ld.Table.Rows)
                               tmp.Add(new KeyValuePair<object, object>(_argument.Table.Rows[i][0], _value.Table.Rows[i++][0]));
                           sr1.Title = _value.Content;
                           sr1.DependentValueBinding = new Binding("Value");//!Key
                           sr1.IndependentValueBinding = new Binding("Key");//secondWorkField.Table.Columns[0].ColumnName);
                           sr1.ItemsSource = tmp;//secondWorkField.Table.DefaultView; 
                       }
                   }
                   
                   

                   Series.Clear();
                   Series.Add(sr1);
        }

        private void lbMouseDown(object sender, MouseButtonEventArgs e) {
            LabelData lbl = (LabelData)sender;
            DragAndDropMaster dnd = new DragAndDropMaster();

            if (lbl.Content != null && e.LeftButton == MouseButtonState.Pressed) {
                _value.Background = new SolidColorBrush(Colors.LightBlue);
                _argument.Background = new SolidColorBrush(Colors.LightBlue);
                dnd.CreateDragDropWindow(lbl, (((panel.Parent as Border).Parent as Grid).Parent as Window));
                DragDrop.DoDragDrop(lbl, lbl, DragDropEffects.Copy);
                _value.Background = new SolidColorBrush(Colors.White);
                _argument.Background = new SolidColorBrush(Colors.White);

            }
        }
    }
}
