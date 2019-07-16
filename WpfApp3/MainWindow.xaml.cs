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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp3
{
    public partial class MainWindow : Window
    {
        MyCanvas FirstElement;
        public MyCanvas CurentElement;
        Vector relativeMousePos;
        FrameworkElement draggedObject;
        int form = 4;
        int exp = -1;
        double time = -1;
        double koef = -1;

        public MainWindow()
        {
            int a;
            InitializeComponent();
            //UpdateBackPattern(null, null);
            A4Form_Checked(null, null);
            BRecMouseDown(null, null);
            string startupPath = Environment.CurrentDirectory;
            var circleUri = new Uri(String.Format(startupPath + @"\IMAGES\qwer.png"));
            //var circleUri = new Uri(String.Format(@"D:\IMAGES\qwer.png"));
            this.Icon = new BitmapImage(circleUri);
        }



        const double ScaleRate = 1.2;
        private void canvas1_MouseWheel_1(object sender, MouseWheelEventArgs e)
        {
            var element = sender as UIElement;
            var position = e.GetPosition(element);
            var transform = element.RenderTransform as MatrixTransform;
            var matrix = transform.Matrix;
            var scale = e.Delta >= 0 ? 1.2 : (1.0 / 1.2); // choose appropriate scaling factor

            matrix.ScaleAtPrepend(scale, scale, position.X, position.Y);
            transform.Matrix = matrix;
        }




        void DrawConnectLine(MyCanvas StartCanv, MyCanvas tempCanv)
        {
            double x1 = Canvas.GetLeft(StartCanv) + StartCanv.XR + 8 - 4 - 2.5;
            double y1 = Canvas.GetTop(StartCanv) + StartCanv.Y + 4 + 0.5;
            double x2 = Canvas.GetLeft(tempCanv) + tempCanv.XL + 2.5 + 4;
            double y2 = Canvas.GetTop(tempCanv) + tempCanv.Y + 4 + 0.5;

            Polyline line = new Polyline();
            if (x2 >= x1)
            {
                line.Points.Add(new Point(x1, y1));
                line.Points.Add(new Point((x2 + x1) / 2, y1));
                line.Points.Add(new Point((x2 + x1) / 2, y2));
                line.Points.Add(new Point(x2, y2));
            }
            else
            {
                line.Points.Add(new Point(x1, y1));
                line.Points.Add(new Point(x1, (y2 + y1) / 2));
                line.Points.Add(new Point(x2, (y2 + y1) / 2));
                line.Points.Add(new Point(x2, y2));
            }
            line.Stroke = Brushes.Black;
            line.StrokeThickness = 1;

            StartCanv.RightLine = line;
            tempCanv.LeftLine = StartCanv.RightLine;
            SchemePlace.Children.Add(line);
        }

        void RDragPolyLine(Polyline line, double x, double y)
        {
            y = y + 0.5;
            PointCollection LinePoints = line.Points;
            LinePoints[3] = new Point(x, y);
            if (x >= LinePoints[0].X)
            {
                LinePoints[1] = (new Point((x + LinePoints[0].X) / 2, LinePoints[0].Y));
                LinePoints[2] = (new Point((x + LinePoints[0].X) / 2, y));
            }
            else
            {
                LinePoints[1] = (new Point((LinePoints[0].X), (LinePoints[0].Y + y) / 2));
                LinePoints[2] = (new Point(x, (LinePoints[0].Y + y) / 2));
            }
        }

        void LDragPolyLine(Polyline line, double x, double y)
        {
            y = y + 0.5;
            PointCollection LinePoints = line.Points;
            LinePoints[0] = new Point(x, y);
            if (x < LinePoints[3].X)
            {
                LinePoints[2] = (new Point((x + LinePoints[3].X) / 2, LinePoints[3].Y));
                LinePoints[1] = (new Point((x + LinePoints[3].X) / 2, y));
            }
            else
            {
                LinePoints[2] = (new Point((LinePoints[3].X), (LinePoints[3].Y + y) / 2));
                LinePoints[1] = (new Point(x, (LinePoints[3].Y + y) / 2));
            }
        }

        void UpdateBackPattern(object sender, SizeChangedEventArgs e)
        {
            /*var w = Background.ActualWidth;
            var h = Background.ActualHeight;*/

            var w = 10000;
            var h = 10000;

            Background.Children.Clear();
            for (int x = 20; x < w; x += 20)
                AddLineToBackground(x, -1000, x, h);
            for (int y = -1000; y < h; y += 20)
                AddLineToBackground(0, y, w, y);
        }

        void AddLineToBackground(double x1, double y1, double x2, double y2)
        {
            var line = new Line()
            {
                X1 = x1,
                Y1 = y1,
                X2 = x2,
                Y2 = y2,
                Stroke = Brushes.LightGray,
                StrokeThickness = 1,
                SnapsToDevicePixels = true,
            };
            Background.Children.Add(line);
        }

        void UpdatePosition(MouseEventArgs e)
        {
            var point = e.GetPosition(SchemePlace);
            var newPos = point - relativeMousePos;
            if (newPos.X >= 0)
            {
                MyCanvas tempCanv = (MyCanvas)e.OriginalSource;
                Canvas.SetLeft(draggedObject, ((int)newPos.X / 20 * 20));
                Canvas.SetTop(draggedObject, ((int)newPos.Y / 20 * 20));
                if (tempCanv.LeftLine != null)
                {
                    RDragPolyLine(tempCanv.LeftLine, Canvas.GetLeft(tempCanv) + tempCanv.XL + 2.5 + 4,
                        Canvas.GetTop(tempCanv) + tempCanv.Y + 4);
                }
                if (tempCanv.RightLine != null)
                {
                    LDragPolyLine(tempCanv.RightLine, Canvas.GetLeft(tempCanv) + tempCanv.XR - 2.5 + 4,
                        Canvas.GetTop(tempCanv) + tempCanv.Y + 4);
                }
            }
        }

        void OnDragMove(object sender, MouseEventArgs e)
        {
            UpdatePosition(e);
        }

        void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            FinishDrag(sender, e);
            Mouse.Capture(null);
        }

        void OnLostCapture(object sender, MouseEventArgs e)
        {
            FinishDrag(sender, e);
        }

        void FinishDrag(object sender, MouseEventArgs e)
        {
            draggedObject.MouseMove -= OnDragMove;
            draggedObject.LostMouseCapture -= OnLostCapture;
            draggedObject.MouseUp -= OnMouseUp;
            UpdatePosition(e);
            MyCanvas a = (MyCanvas)sender;
            a.MouseRightButtonDown += RemoveClick;
        }

        public void StartDrag(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                MorecClicked(sender, e);
                return;
            }
            MyCanvas a = (MyCanvas)sender;
            a.MouseRightButtonDown -= RemoveClick;
            draggedObject = (FrameworkElement)sender;
            relativeMousePos = e.GetPosition(draggedObject) - new Point();
            draggedObject.MouseMove += OnDragMove;
            draggedObject.LostMouseCapture += OnLostCapture;
            draggedObject.MouseUp += OnMouseUp;
            Mouse.Capture(draggedObject);
        }

        void RemoveClick(object sender, MouseButtonEventArgs e)
        {
            var mouseWasDownOn = e.Source as FrameworkElement;
            string elementName = mouseWasDownOn.Uid;
            var tempCanv = SchemePlace.Children.OfType<MyCanvas>().FirstOrDefault(x => x.Uid.IndexOf(':' + elementName) > -1);
            if (tempCanv.PREVIOUS != null && tempCanv.NEXT != null)
            {
                DrawConnectLine(tempCanv.PREVIOUS, tempCanv.NEXT);
                tempCanv.PREVIOUS.NEXT = tempCanv.NEXT;
                tempCanv.NEXT.PREVIOUS = tempCanv.PREVIOUS;
            }
            else if (tempCanv.PREVIOUS != null)
            {
                tempCanv.PREVIOUS.RightLine = null;
                //tempCanv.PREVIOUS.RConnector.MouseLeftButtonDown += BRecMouseDown;
                DrowOutput(tempCanv.PREVIOUS);
                tempCanv.PREVIOUS.NEXT = null;
            }
            else if (tempCanv.NEXT != null)
            {
                tempCanv.NEXT.LeftLine = null;
                //tempCanv.NEXT.LConnector.MouseLeftButtonDown += BRecMouseDown;
                tempCanv.NEXT.PREVIOUS = null;
                DrowInput(tempCanv.NEXT);
                FirstElement = tempCanv.NEXT;
            }
            else
            {
                return;
            }

            SchemePlace.Children.Remove(tempCanv.LeftLine);
            SchemePlace.Children.Remove(tempCanv.RightLine);
            tempCanv.Children.Clear();
            SchemePlace.Children.Remove(tempCanv);
        }

        public void BRecMouseDown(object sender, MouseButtonEventArgs e)
        {
            MyCanvas tempCanv = new MyCanvas();
            tempCanv.Draw();
            tempCanv.MouseLeftButtonDown += StartDrag;
            tempCanv.MouseRightButtonDown += RemoveClick;

            if (sender != null)
            {
                Ellipse Ell = (Ellipse)e.OriginalSource;
                Ell.MouseLeftButtonDown -= BRecMouseDown;
                var mouseWasDownOn = e.Source as FrameworkElement;
                string elementName = mouseWasDownOn.Uid;
                var StartCanv = SchemePlace.Children.OfType<MyCanvas>().FirstOrDefault(x => x.Uid.IndexOf(':' + elementName) > -1);
                Canvas.SetTop(tempCanv, Canvas.GetTop(StartCanv));
                //Canvas.SetLeft(tempCanv, (Canvas.GetLeft(StartCanv) + (int)StartCanv.ElementImage.ActualWidth)
                //    - (Canvas.GetLeft(StartCanv) + (int)StartCanv.ElementImage.ActualWidth) % 20 + 60);
                Canvas.SetLeft(tempCanv, (Canvas.GetLeft(StartCanv) + (int)StartCanv.ElementImage.ActualWidth)
                    - (Canvas.GetLeft(StartCanv) + (int)StartCanv.ElementImage.ActualWidth) % 20 + 60);
                DrawConnectLine(StartCanv, tempCanv);

                DrowOutput(tempCanv);
                StartCanv.Children.Remove(Ell);
                StartCanv.Children.Remove(StartCanv.Out);

                tempCanv.PREVIOUS = StartCanv;
                StartCanv.NEXT = tempCanv;
                SchemePlace.Children.Add(tempCanv);
            }
            else
            {
                Canvas.SetTop(tempCanv, 20);
                Canvas.SetLeft(tempCanv, 20);
                DrowInput(tempCanv);
                DrowOutput(tempCanv);
                FirstElement = tempCanv;
                SchemePlace.Children.Add(tempCanv);
            }
        }

        void DrowInput(MyCanvas tempCanv)
        {
            tempCanv.ElIn = new Ellipse()
            {
                Width = 8,
                Height = 8,
                Fill = Brushes.Black
            };
            Canvas.SetTop(tempCanv.ElIn, tempCanv.Y);
            Canvas.SetLeft(tempCanv.ElIn, tempCanv.XL);
            tempCanv.Children.Add(tempCanv.ElIn);

            tempCanv.In = new TextBlock()
            {
                Text = "I",
                FontSize = 14
            };
            Canvas.SetTop(tempCanv.In, tempCanv.Y - 7);
            Canvas.SetLeft(tempCanv.In, tempCanv.XL - 5);
            tempCanv.Children.Add(tempCanv.In);
        }

        void DrowOutput(MyCanvas tempCanv)
        {
            tempCanv.Out = new TextBlock();
            tempCanv.Out.Text = "O";
            tempCanv.Out.FontSize = 14;
            Canvas.SetTop(tempCanv.Out, tempCanv.Y - 7);
            Canvas.SetLeft(tempCanv.Out, tempCanv.XR + 10);
            tempCanv.Children.Add(tempCanv.Out);

            Ellipse El = new Ellipse()
            {
                Width = 8,
                Height = 8,
                Fill = Brushes.Black,
                Uid = tempCanv.ElementImage.Uid,
                Cursor = Cursors.Hand
            };
            string a = El.Uid;
            string b = tempCanv.Uid;

            El.MouseLeftButtonDown += BRecMouseDown;
            Canvas.SetTop(El, tempCanv.Y);
            Canvas.SetLeft(El, tempCanv.XR);
            tempCanv.Children.Add(El);

        
        
            //tempCanv.Children.Remove(tempCanv.RConnector);
        }

        public void MorecClicked(object sender, MouseButtonEventArgs e)
        {
            var mouseWasDownOn = e.Source as FrameworkElement;
            string elementName = mouseWasDownOn.Uid;
            CurentElement = SchemePlace.Children.OfType<MyCanvas>().FirstOrDefault(x => x.Uid.IndexOf(':' + elementName) > -1);
            ElementsWindow wind = new ElementsWindow(CurentElement, false);
            wind.Owner = this;
            wind.OkClicksElement += AddLoaded;
            wind.ShowDialog();
            //wind.Show();
        }

        void AddLoaded(MyCanvas newElement)
        {
            //MessageBox.Show(newElement.lambda.ToString());
            if (newElement == CurentElement)
            {
                return;
            } else
            {
                Canvas.SetTop(newElement, Canvas.GetTop(CurentElement));
                Canvas.SetLeft(newElement, Canvas.GetLeft(CurentElement));
                newElement.PREVIOUS = CurentElement.PREVIOUS;
                newElement.NEXT = CurentElement.NEXT;
                if (CurentElement.PREVIOUS != null && CurentElement.NEXT != null)
                {
                    DrawConnectLine(newElement, CurentElement.NEXT);
                    DrawConnectLine(CurentElement.PREVIOUS, newElement);
                    SchemePlace.Children.Remove(CurentElement.RightLine);
                    SchemePlace.Children.Remove(CurentElement.LeftLine);
                    newElement.PREVIOUS.NEXT = newElement;
                    newElement.NEXT.PREVIOUS = newElement;
                }
                else if (CurentElement.PREVIOUS == null && CurentElement.NEXT == null)
                {
                    DrowInput(newElement);
                    DrowOutput(newElement);
                    FirstElement = newElement;
                }
                else if (CurentElement.NEXT == null)
                {
                    DrawConnectLine(CurentElement.PREVIOUS, newElement);
                    SchemePlace.Children.Remove(CurentElement.LeftLine);
                    DrowOutput(newElement);
                    newElement.PREVIOUS.NEXT = newElement;
                }
                else if (CurentElement.PREVIOUS == null)
                {
                    DrawConnectLine(newElement, CurentElement.NEXT);
                    SchemePlace.Children.Remove(CurentElement.RightLine);
                    DrowInput(newElement);
                    newElement.NEXT.PREVIOUS = newElement;
                    FirstElement = newElement;
                }
                SchemePlace.Children.Add(newElement);
                newElement.MouseLeftButtonDown += StartDrag;
                newElement.MouseRightButtonDown += RemoveClick;
                CurentElement.Children.Clear();
                SchemePlace.Children.Remove(CurentElement);
            }
        }

        bool IsInt(String str)
        {
            int res;
            bool isInt = Int32.TryParse(str, out res);
            if (isInt && res > 0)
                return true;
            else
                return false;
        }

        bool IsDouble(String str)
        {
            double res;
            bool isDouble = Double.TryParse(str, out res);
            if (isDouble && res > 0)
                return true;
            else
                return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog1 = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog1.Filter = "XML documents (*.xml)|*.xml";
            saveFileDialog1.Title = "Save Project";
            saveFileDialog1.FileName = "project.xml";
            Nullable<bool> result = saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "" && result == true)
            {
                ProjectFile.SaveProject(FirstElement, saveFileDialog1.FileName, ExpAmount.Text, Time.Text, Koef.Text);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "XML documents (*.xml)|*.xml";
            dialog.FilterIndex = 2;

            Nullable<bool> result = dialog.ShowDialog();

            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;
                SchemePlace.Children.Clear();
                FirstElement = ProjectFile.LoadProject(filename, ExpAmount, Time, Koef);
                DrowInput(FirstElement);
                MyCanvas NEXT = FirstElement;
                while (NEXT != null)
                {
                    SchemePlace.Children.Add(NEXT);
                    if (NEXT.NEXT == null)
                        DrowOutput(NEXT);
                    if (NEXT.PREVIOUS != null)
                        DrawConnectLine(NEXT.PREVIOUS, NEXT);
                    NEXT.MouseLeftButtonDown += StartDrag;
                    NEXT.MouseRightButtonDown += RemoveClick;
                    NEXT = NEXT.NEXT;
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MyCanvas temEl = FirstElement;
            while (temEl != null)
            {
                if (temEl.ElType == ELTYPE.EMPTY)
                {
                    MessageBox.Show("Не все элементы определены!");
                    return;
                }
                temEl = temEl.NEXT;
            }
            if (!IsInt(ExpAmount.Text))
            {
                MessageBox.Show("Количество экспериментов должно быть натуральным числом > 0!");
                return;
            }
            if (!IsDouble(Time.Text))
            {
                MessageBox.Show("Время работы должно быть вещественным > 0!");
                return;
            }
            if (!IsDouble(Koef.Text))
            {
                MessageBox.Show("Коэффициент доверия должен находится в пределах (0 ; 3,09)");
                return;
            } else if (Convert.ToDouble(Koef.Text) > 3.09)
            {
                MessageBox.Show("Коэффициент доверия должен находится в пределах (0 ; 3,09)");
                return;
            }
            ////MessageBox.Show("Не расчитал!");
            //Random rnd = new Random();

            ////Получить случайное число (в диапазоне от 0 до 10)
            //double value = rnd.NextDouble();
            //TL.Content = "T = " + value.ToString();

            //value = rnd.NextDouble();
            //TL_1.Content = "+- " + value.ToString();


            //value = rnd.NextDouble();
            //PL.Content = "P = " + value.ToString()[0] + value.ToString()[1] + value.ToString()[2] + value.ToString()[3] + value.ToString()[4] + value.ToString()[5] + value.ToString()[6] + value.ToString()[7];

            //value = rnd.NextDouble();
            //int a = rnd.Next(4, 7);
            //PL_1.Content = "+- " + value.ToString() + "-E" + a.ToString();
            //Вывод числа в консоль
        }

        private void A1Form_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void A2Form_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void A3Form_Checked(object sender, RoutedEventArgs e)
        {
            if (form == 3)
            {
                return;
            }
            SchemePlace.Height = SchemePlace.Width;
            SchemePlace.Width = SchemePlace.Width * 1.4142;
        }

        private void A4Form_Checked(object sender, RoutedEventArgs e)
        {
            if (sender == null || form == 4)
            {
                return;
            }
            SchemePlace.Width = SchemePlace.Height;
            SchemePlace.Height = SchemePlace.Height / 1.4142;
        }
    }
}
