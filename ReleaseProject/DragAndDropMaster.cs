using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ReleaseProject {
    class DragAndDropMaster {
        Window _dragdropWindow;
        Rectangle rect;
        public void CreateDragDropWindow(Visual dragElement, Window win) {
            _dragdropWindow = new Window();
            _dragdropWindow.WindowStyle = WindowStyle.None;
            _dragdropWindow.AllowsTransparency = true;
            _dragdropWindow.AllowDrop = false;
            _dragdropWindow.Background = new SolidColorBrush(Colors.SkyBlue);
            _dragdropWindow.IsHitTestVisible = true;
            _dragdropWindow.SizeToContent = SizeToContent.WidthAndHeight;
            _dragdropWindow.Topmost = true;
            _dragdropWindow.Opacity = 0.6;
            _dragdropWindow.ShowInTaskbar = false;
            this._dragdropWindow.Left = 0;
            this._dragdropWindow.Top = 0;
           
            rect = new Rectangle();
            rect.Width = ((FrameworkElement)dragElement).ActualWidth;
            rect.Height = ((FrameworkElement)dragElement).ActualHeight;
            rect.Stroke = System.Windows.Media.Brushes.Blue;
            rect.Fill = new VisualBrush(dragElement);
            rect.RadiusX = 3;
            rect.RadiusY = 3;
            rect.Fill = new VisualBrush(dragElement); 
           
            this._dragdropWindow.Content = rect;

            var transform = PresentationSource.FromVisual(dragElement).CompositionTarget.TransformFromDevice;
            var mouse = transform.Transform(GetMousePosition());

            _dragdropWindow.Left = mouse.X - rect.Width/2+15;
            _dragdropWindow.Top =  mouse.Y - rect.Height/16+5;
            
            _dragdropWindow.Show();
            win.Focus();

            _dragdropWindow.DragMove(); 
            _dragdropWindow.Close();
        }
        public void CloseWindow(){
            _dragdropWindow.Close();
        }



        System.Windows.Point GetMousePosition() {
            System.Drawing.Point point = System.Windows.Forms.Control.MousePosition;
            return new System.Windows.Point(point.X, point.Y);
        }
    }
}
   