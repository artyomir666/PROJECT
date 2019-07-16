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
using System.Text.RegularExpressions;

namespace WpfApp3
{
    public delegate void ClickLoadedCallback(MyCanvas element);

    public partial class ElementsWindow : Window
    {
        MyCanvas FirstElement;
        MyCanvas SelectedElement;
        public ELTYPE ElementType;
        public MyCanvas CurentElement;
        public MyCanvas MainElement;
        public int CanvID = 10;
        Vector relativeMousePos;
        FrameworkElement draggedObject;
        TextBox BOX1 = new TextBox();
        TextBox BOX2 = new TextBox();
        TextBox BOX3 = new TextBox();
        TextBox BOX4 = new TextBox();
        bool Unload;

        public event ClickLoadedCallback OkClicksElement;

        public ElementsWindow(MyCanvas Element, bool unload)
        {
            InitializeComponent();

            Unload = unload;
            string startupPath = Environment.CurrentDirectory;
            var circleUri = new Uri(String.Format(startupPath + @"\IMAGES\qwer.png"));
            //var circleUri = new Uri(String.Format( @"D:\IMAGES\qwer.png"));
            this.Icon = new BitmapImage(circleUri);

            ElementType = Element.ElType;
            MainElement = Element;
            if (ElementType == ELTYPE.LIST_)
            {
                RBList.IsChecked = true;
                ListDraw(Element.ContainEl);
                FirstElement = Element.ContainEl;
            }
            else if (ElementType == ELTYPE.PLAIN)
            {
                BRecMouseDown(null, null);
                RBElement.IsChecked = true;
                ElementClicked(null, null);
            }
            else if (ElementType == ELTYPE.LOADED)
            {
                BRecMouseDown(null, null);
                RBElement.IsChecked = true;
                LoadedClicked(null, null);
            }
            else if (ElementType == ELTYPE.UNLOADED)
            {
                BRecMouseDown(null, null);
                RBElement.IsChecked = true;
                UnLoadedClicked(null, null);
            }
            else if (ElementType == ELTYPE.SLIDINGLOAD)
            {
                BRecMouseDown(null, null);
                RBElement.IsChecked = true;
                SlidingLoadedClicked(null, null);
            }
            else if (ElementType == ELTYPE.SLIDINGUNLOAD)
            {
                BRecMouseDown(null, null);
                RBElement.IsChecked = true;
                SlidingUnLoadedClicked(null, null);
            }
            else if (ElementType == ELTYPE.MAJOR)
            {
                BRecMouseDown(null, null);
                RBElement.IsChecked = true;
                MajorConnectNFMClicked(null, null);
            }
            else if (ElementType == ELTYPE.BRIDGE)
            {
                BRecMouseDown(null, null);
                RBElement.IsChecked = true;
                BridgeConnectClicked(null, null);
            }
            else if (ElementType == ELTYPE.BDCGLR)
            {
                BRecMouseDown(null, null);
                RBElement.IsChecked = true;
                BackupDeviceControlGroupsLRClicked(null, null);
            }
            else if (ElementType == ELTYPE.SERIAL)
            {
                BRecMouseDown(null, null);
                RBElement.IsChecked = true;
                SerialConnectClicked(null, null);
            }
            else if (ElementType == ELTYPE.BACKUP)
            {
                BRecMouseDown(null, null);
                RBElement.IsChecked = true;
                BackupControlType2Clicked(null, null);
            }
            else if (ElementType == ELTYPE.RMR)
            {
                BRecMouseDown(null, null);
                RBElement.IsChecked = true;
                ReservManageReplacingClicked(null, null);
            }
            else
            {
                BRecMouseDown(null, null);
                RBElement.IsChecked = true;
                ElementClicked(null, null);
            } 
        }

        void DeleteElement(MyCanvas El)
        {
            ElementParameters.Children.Remove(SelectedElement);
            SelectedElement.Margin = new Thickness();
        }

        private void ButtonOkClick(object sender, RoutedEventArgs e)
        {
            if (ElementType == ELTYPE.PLAIN)
            {
                if (!IsDouble(BOX1.Text))
                {
                    MessageBox.Show("Интенсивность отказов может быть вещественным числом > 0");
                    return;
                }
                if (Unload)
                {
                    if (!IsDouble(BOX2.Text))
                    {
                        MessageBox.Show("Интенсивность отказов может быть вещественным числом > 0");
                        return;
                    }
                    SelectedElement.lambda_1 = Convert.ToDouble(BOX2.Text);
                }
                SelectedElement.lambda = Convert.ToDouble(BOX1.Text);
                ElementParameters.Children.Remove(SelectedElement);
                SelectedElement.Margin = new Thickness();
                OkClicksElement?.Invoke(SelectedElement);
                this.Close();
                return;
            }
            else if (ElementType == ELTYPE.LOADED)
            {
                if (SelectedElement.ContainEl.ElType == ELTYPE.EMPTY)
                {
                    MessageBox.Show("Выберите тип элементов");
                    return;
                }
                if (!IsInt(BOX1.Text))
                {
                    MessageBox.Show("Количество элементов может быть целым числом > 0");
                    return;
                }
                ElementParameters.Children.Remove(SelectedElement);
                SelectedElement.Margin = new Thickness();
                SelectedElement.ItemsAmount = Convert.ToInt32(BOX1.Text);
                OkClicksElement?.Invoke(SelectedElement);
                this.Close();
                return;
            }
            else if (ElementType == ELTYPE.UNLOADED)
            {
                if (SelectedElement.ContainEl.ElType == ELTYPE.EMPTY)
                {
                    MessageBox.Show("Выберите тип элементов");
                    return;
                }
                if (!IsInt(BOX1.Text))
                {
                    MessageBox.Show("Количество элементов может быть целым числом > 0");
                    return;
                }
                ElementParameters.Children.Remove(SelectedElement);
                SelectedElement.Margin = new Thickness();
                SelectedElement.ItemsAmount = Convert.ToInt32(BOX1.Text);
                OkClicksElement?.Invoke(SelectedElement);
                this.Close();
                return;
            }
            else if (ElementType == ELTYPE.SLIDINGLOAD)
            {
                if (SelectedElement.ContainEl.ElType == ELTYPE.EMPTY)
                {
                    MessageBox.Show("Выберите тип элементов");
                    return;
                }
                if (!IsInt(BOX1.Text))
                {
                    MessageBox.Show("Количество элементов может быть целым числом > 0");
                    return;
                }
                if (!IsInt(BOX2.Text))
                {
                    MessageBox.Show("Количество элементов может быть целым числом > 0");
                    return;
                }
                ElementParameters.Children.Remove(SelectedElement);
                SelectedElement.Margin = new Thickness();
                SelectedElement.ElementImage.Height = 221;
                SelectedElement.ItemsAmount = Convert.ToInt32(BOX1.Text);
                SelectedElement.ItemsAmount_1 = Convert.ToInt32(BOX2.Text);
                OkClicksElement?.Invoke(SelectedElement);
                this.Close();
                return;
            }
            else if (ElementType == ELTYPE.SLIDINGUNLOAD)
            {
                if (SelectedElement.ContainEl.ElType == ELTYPE.EMPTY)
                {
                    MessageBox.Show("Выберите тип элементов");
                    return;
                }
                if (!IsInt(BOX1.Text))
                {
                    MessageBox.Show("Количество элементов может быть целым числом > 0");
                    return;
                }
                if (!IsInt(BOX2.Text))
                {
                    MessageBox.Show("Количество элементов может быть целым числом > 0");
                    return;
                }
                ElementParameters.Children.Remove(SelectedElement);
                SelectedElement.Margin = new Thickness();
                SelectedElement.ElementImage.Height = 221;
                SelectedElement.ItemsAmount = Convert.ToInt32(BOX1.Text);
                SelectedElement.ItemsAmount_1 = Convert.ToInt32(BOX2.Text);
                OkClicksElement?.Invoke(SelectedElement);
                this.Close();
                return;
            }
            else if (ElementType == ELTYPE.MAJOR)
            {
                if (SelectedElement.ContainEl.ElType == ELTYPE.EMPTY)
                {
                    MessageBox.Show("Выберите тип элементов");
                    return;
                }
                if (SelectedElement.ContainEl_1.ElType == ELTYPE.EMPTY)
                {
                    MessageBox.Show("Выберите тип мажоритарного элемента");
                    return;
                }
                if (!IsInt(BOX1.Text))
                {
                    MessageBox.Show("Количество элементов может быть целым числом > 0");
                    return;
                }
                if (!IsInt(BOX2.Text))
                {
                    MessageBox.Show("Количество элементов может быть целым числом > 0");
                    return;
                }
                ElementParameters.Children.Remove(SelectedElement);
                SelectedElement.Margin = new Thickness();
                SelectedElement.ItemsAmount = Convert.ToInt32(BOX1.Text);
                SelectedElement.ItemsAmount_1 = Convert.ToInt32(BOX2.Text);
                OkClicksElement?.Invoke(SelectedElement);
                this.Close();
                return;
            }
            else if (ElementType == ELTYPE.BDCGLR)
            {
                if (SelectedElement.ContainEl.ElType == ELTYPE.EMPTY)
                {
                    MessageBox.Show("Выберите тип элементов");
                    return;
                }
                if (SelectedElement.ContainEl_1.ElType == ELTYPE.EMPTY)
                {
                    MessageBox.Show("Выберите тип управляющего элемента");
                    return;
                }
                if (!IsInt(BOX1 .Text))
                {
                    MessageBox.Show("Количество элементов может быть целым числом > 0");
                    return;
                }
                ElementParameters.Children.Remove(SelectedElement);
                SelectedElement.Margin = new Thickness();
                SelectedElement.ItemsAmount = Convert.ToInt32(BOX1.Text);
                OkClicksElement?.Invoke(SelectedElement);
                this.Close();
                return;
            }
            else if (ElementType == ELTYPE.BRIDGE)
            {
                if (SelectedElement.ContainEl.ElType == ELTYPE.EMPTY)
                {
                    MessageBox.Show("Выберите тип элементов");
                    return;
                }
                ElementParameters.Children.Remove(SelectedElement);
                SelectedElement.Margin = new Thickness();
                OkClicksElement?.Invoke(SelectedElement);
                this.Close();
                return;
            }
            else if (ElementType == ELTYPE.SERIAL)
            {
                if (SelectedElement.ContainEl.ElType == ELTYPE.EMPTY)
                {
                    MessageBox.Show("Выберите тип элементов");
                    return;
                }
                if (!IsInt(BOX1.Text))
                {
                    MessageBox.Show("Количество элементов может быть целым числом > 0");
                    return;
                }
                ElementParameters.Children.Remove(SelectedElement);
                SelectedElement.Margin = new Thickness();
                SelectedElement.ItemsAmount = Convert.ToInt32(BOX1.Text);
                OkClicksElement?.Invoke(SelectedElement);
                this.Close();
                return;
            }
            else if (ElementType == ELTYPE.BACKUP)
            {
                if (SelectedElement.ContainEl.ElType == ELTYPE.EMPTY)
                {
                    MessageBox.Show("Выберите тип элементов");
                    return;
                }
                if (SelectedElement.ContainEl_1.ElType == ELTYPE.EMPTY)
                {
                    MessageBox.Show("Выберите тип управляющего элемента");
                    return;
                }
                ElementParameters.Children.Remove(SelectedElement);
                SelectedElement.Margin = new Thickness();
                OkClicksElement?.Invoke(SelectedElement);
                this.Close();
                return;
            }
            else if (ElementType == ELTYPE.RMR)
            {
                if (SelectedElement.ContainEl.ElType == ELTYPE.EMPTY)
                {
                    MessageBox.Show("Выберите тип элементов");
                    return;
                }
                if (SelectedElement.ContainEl_1.ElType == ELTYPE.EMPTY)
                {
                    MessageBox.Show("Выберите тип датчика");
                    return;
                }
                if (SelectedElement.ContainEl_2.ElType == ELTYPE.EMPTY)
                {
                    MessageBox.Show("Выберите тип управляющего элемента");
                    return;
                }
                if (!IsInt(BOX1.Text))
                {
                    MessageBox.Show("Количество элементов может быть целым числом > 0");
                    return;
                }
                ElementParameters.Children.Remove(SelectedElement);
                SelectedElement.Margin = new Thickness();
                SelectedElement.ItemsAmount = Convert.ToInt32(BOX1.Text);
                OkClicksElement?.Invoke(SelectedElement);
                this.Close();
                return;
            }
            else if (ElementType != ELTYPE.LIST_)
            {
                ElementParameters.Children.Remove(SelectedElement);
                SelectedElement.Margin = new Thickness();
                OkClicksElement?.Invoke(SelectedElement);
            }
            else if (ElementType == ELTYPE.LIST_)
            {
                if (FirstElement.NEXT == null)
                {
                    ElementType = FirstElement.ElType;
                    FirstElement.MouseLeftButtonDown -= StartDrag;
                    FirstElement.MouseRightButtonDown -= RemoveClick;
                    FirstElement.El.MouseLeftButtonDown -= BRecMouseDown;
                    SchemePlace.Children.Remove(FirstElement);
                    FirstElement.Children.Remove(FirstElement.Out);
                    FirstElement.Children.Remove(FirstElement.El);
                    FirstElement.Children.Remove(FirstElement.In);
                    FirstElement.Children.Remove(FirstElement.ElIn);
                    OkClicksElement?.Invoke(FirstElement);
                    this.Close();
                    return;
                }
                MyCanvas newElement = new List_(FirstElement);
                newElement.Draw();
                ListDisconnect(FirstElement);
                SchemePlace.Children.Clear();
                OkClicksElement?.Invoke(newElement);
            }
            this.Close();
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

        void ListDraw(MyCanvas Element)
        {
            SchemePlace.Children.Add(Element);
            if (Element.NEXT != null)
            {
                Element.MouseLeftButtonDown += StartDrag;
                Element.MouseRightButtonDown += RemoveClick;
                ListDraw(Element.NEXT);
            } else
            {
                Element.MouseLeftButtonDown += StartDrag;
                Element.MouseRightButtonDown += RemoveClick;
                DrowOutput(Element);
            }
            if (Element.PREVIOUS == null)
            {
                DrowInput(Element);
            } else
            {
                DrawConnectLine(Element.PREVIOUS, Element);
            }
        }

        void ListDisconnect(MyCanvas Element)
        {
            if (Element.NEXT != null)
            {
                Element.MouseLeftButtonDown -= StartDrag;
                Element.MouseRightButtonDown -= RemoveClick;
                ListDisconnect(Element.NEXT);
            }
            else
            {
                Element.MouseLeftButtonDown -= StartDrag;
                Element.MouseRightButtonDown -= RemoveClick;
                Element.Children.Remove(Element.El);
                Element.Children.Remove(Element.Out);
            }
        }

        private void ListButtonChecked(object sender, RoutedEventArgs e)
        {
            ElementList.Visibility = Visibility.Collapsed;
            ElementParameters.Visibility = Visibility.Collapsed;
            Background.Visibility = Visibility.Visible;
            SchemePlace.Visibility = Visibility.Visible;
            ElementType = ELTYPE.LIST_;
            this.Height = 400;
            this.Width = 900;
            ResizeMode = ResizeMode.CanResize;
        }

        private void ElementButtonChecked(object sender, RoutedEventArgs e)
        {
            ElementList.Visibility = Visibility.Visible;
            ElementParameters.Visibility = Visibility.Visible;
            Background.Visibility = Visibility.Collapsed;
            SchemePlace.Visibility = Visibility.Collapsed;
            this.Height = 405;
            this.Width = 635;
            ResizeMode = ResizeMode.NoResize;
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
                Stroke = Brushes.BlanchedAlmond,
                StrokeThickness = 1,
                SnapsToDevicePixels = true,
            };
            Background.Children.Add(line);
        }

        private void DoubleValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            //Regex regex = new Regex("[0-9]");
            //e.Handled = regex.IsMatch(e.Text);
        }

        private void IntValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            //Regex regex = new Regex("[0-9]");
            //e.Handled = !regex.IsMatch(e.Text);
        }

        private void ElementClicked(object sender, RoutedEventArgs e)
        {
            ElementType = ELTYPE.PLAIN;

            ElementParameters.Children.Clear();

            Label lambda = new Label();
            lambda.Content = "Интенсивность отказов в режиме работы";
            lambda.HorizontalAlignment = HorizontalAlignment.Center;

            BOX1.Clear();
            BOX1.Width = 160;
            BOX1.PreviewTextInput += DoubleValidationTextBox;

            ElementParameters.Children.Add(lambda);
            ElementParameters.Children.Add(BOX1);

            if (Unload)
            {
                Label lambda_1 = new Label();
                lambda_1.Content = "Интенсивность отказов в режиме ожидания";
                lambda_1.HorizontalAlignment = HorizontalAlignment.Center;
                BOX2.Clear();
                BOX2.Width = 160;
                BOX2.PreviewTextInput += DoubleValidationTextBox;
                ElementParameters.Children.Add(lambda_1);
                ElementParameters.Children.Add(BOX2);
            }

            if (MainElement.ElType == ELTYPE.PLAIN)
            {
                SelectedElement = MainElement;
                MyCanvas tempLoaded = new Plain();
                tempLoaded.Draw();
                tempLoaded.Margin = new Thickness(110, 30, 0, 0);
                BOX1.Text = MainElement.lambda.ToString();
                ElementParameters.Children.Add(tempLoaded);
                if (Unload)
                    BOX2.Text = MainElement.lambda_1.ToString();
            }
            else
            {
                SelectedElement = new Plain();
                SelectedElement.Draw();
                SelectedElement.Margin = new Thickness(110, 30, 0, 0);
                ElementParameters.Children.Add(SelectedElement);
            }
        }

        private void LoadedClicked(object sender, RoutedEventArgs e)
        {
            ElementType = ELTYPE.LOADED;

            ElementParameters.Children.Clear();

            Label elementsAmount = new Label();
            elementsAmount.Content = "Количество резервных элементов";
            elementsAmount.HorizontalAlignment = HorizontalAlignment.Center;
            BOX1.Clear();
            BOX1.Width = 160;
            BOX1.PreviewTextInput += IntValidationTextBox;

            ElementParameters.Children.Add(elementsAmount);
            ElementParameters.Children.Add(BOX1);

            Button ChoseElButton = new Button()
            {
                Content = "Тип резервных элементов",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 10, 0, 0),
                Width = 160
            };
            ChoseElButton.Click += ChoseElementClicked;
            ElementParameters.Children.Add(ChoseElButton );

            if (MainElement.ElType == ELTYPE.LOADED)
            {
                SelectedElement = MainElement;
                MyCanvas tempLoaded = new Loaded();
                tempLoaded.Draw();
                tempLoaded.Margin = new Thickness(70, 30, 0, 0);
                BOX1.Text = MainElement.ItemsAmount.ToString();
                ElementParameters.Children.Add(tempLoaded);
            }
            else
            {
                SelectedElement = new Loaded();
                SelectedElement.Draw();
                SelectedElement.Margin = new Thickness(70, 30, 0, 0);
                ElementParameters.Children.Add(SelectedElement);
            }
        }

        private void UnLoadedClicked(object sender, RoutedEventArgs e)
        {
            ElementType = ELTYPE.UNLOADED;

            ElementParameters.Children.Clear();

            Label elementsAmount = new Label();
            elementsAmount.Content = "Количество резервных элементов";
            elementsAmount.HorizontalAlignment = HorizontalAlignment.Center;
            BOX1.Clear();
            BOX1.Width = 160;
            BOX1.PreviewTextInput += IntValidationTextBox;

            ElementParameters.Children.Add(elementsAmount);
            ElementParameters.Children.Add(BOX1);

            Button ChoseElButton = new Button()
            {
                Content = "Тип резервных элементов",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 10, 0, 0),
                Width = 160
            };
            ChoseElButton.Click += ChoseElementClicked;
            ElementParameters.Children.Add(ChoseElButton);

            if (MainElement.ElType == ELTYPE.UNLOADED)
            {
                SelectedElement = MainElement;
                MyCanvas tempLoaded = new Unloaded();
                tempLoaded.Draw();
                tempLoaded.Margin = new Thickness(70, 30, 0, 0);
                BOX1.Text = MainElement.ItemsAmount.ToString();
                ElementParameters.Children.Add(tempLoaded);
            }
            else
            {
                SelectedElement = new Unloaded();
                SelectedElement.Draw();
                SelectedElement.Margin = new Thickness(70, 30, 0, 0);
                ElementParameters.Children.Add(SelectedElement);
            }
        }

        private void SlidingLoadedClicked(object sender, RoutedEventArgs e)
        {
            ElementType = ELTYPE.SLIDINGLOAD;

            ElementParameters.Children.Clear();

            Label elementsAmount = new Label();
            elementsAmount.Content = "Количество основных элементов";
            elementsAmount.HorizontalAlignment = HorizontalAlignment.Center;
            BOX1.Clear();
            BOX1.Width = 160;
            BOX1.PreviewTextInput += IntValidationTextBox;

            Label relementsAmount = new Label();
            relementsAmount.Content = "Количество резервных элементов";
            relementsAmount.HorizontalAlignment = HorizontalAlignment.Center;
            BOX2.Clear();
            BOX2.Width = 160;
            BOX2.PreviewTextInput += IntValidationTextBox;

            ElementParameters.Children.Add(elementsAmount);
            ElementParameters.Children.Add(BOX1);
            ElementParameters.Children.Add(relementsAmount);
            ElementParameters.Children.Add(BOX2);

            Button ChoseElButton = new Button()
            {
                Content = "Тип элементов",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10, 10, 10, 0),
                Width = 160
            };
            ChoseElButton.Click += ChoseElementClicked;
            ElementParameters.Children.Add(ChoseElButton);

            if (MainElement.ElType == ELTYPE.SLIDINGLOAD)
            {
                SelectedElement = MainElement;
                MyCanvas tempLoaded = new SlidingLoaded();
                tempLoaded.Draw();
                tempLoaded.ElementImage.Height = 180;
                tempLoaded.Margin = new Thickness(-10, 30, 0, 0);
                BOX1.Text = MainElement.ItemsAmount.ToString();
                BOX2.Text = MainElement.ItemsAmount_1.ToString();
                ElementParameters.Children.Add(tempLoaded);
            }
            else
            {
                SelectedElement = new SlidingLoaded();
                SelectedElement.Draw();
                SelectedElement.ElementImage.Height = 180;
                SelectedElement.Margin = new Thickness(-10, 30, 0, 0);
                ElementParameters.Children.Add(SelectedElement);
            }
        }

        private void SlidingUnLoadedClicked(object sender, RoutedEventArgs e)
        {
            ElementType = ELTYPE.SLIDINGUNLOAD;

            ElementParameters.Children.Clear();

            Label elementsAmount = new Label();
            elementsAmount.Content = "Количество основных элементов";
            elementsAmount.HorizontalAlignment = HorizontalAlignment.Center;
            BOX1.Clear();
            BOX1.Width = 160;
            BOX1.PreviewTextInput += IntValidationTextBox;

            Label relementsAmount = new Label();
            relementsAmount.Content = "Количество резервных элементов";
            relementsAmount.HorizontalAlignment = HorizontalAlignment.Center;
            BOX2.Clear();
            BOX2.Width = 160;
            BOX2.PreviewTextInput += IntValidationTextBox;

            ElementParameters.Children.Add(elementsAmount);
            ElementParameters.Children.Add(BOX1);
            ElementParameters.Children.Add(relementsAmount);
            ElementParameters.Children.Add(BOX2);

            Button ChoseElButton = new Button()
            {
                Content = "Тип элементов",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10, 10, 10, 0),
                Width = 160
            };
            ChoseElButton.Click += ChoseElementClicked;
            ElementParameters.Children.Add(ChoseElButton);

            if (MainElement.ElType == ELTYPE.SLIDINGUNLOAD)
            {
                SelectedElement = MainElement;
                MyCanvas tempLoaded = new SlidingUnLoaded();
                tempLoaded.Draw();
                tempLoaded.ElementImage.Height = 180;
                tempLoaded.Margin = new Thickness(-10, 30, 0, 0);
                BOX1.Text = MainElement.ItemsAmount.ToString();
                BOX2.Text = MainElement.ItemsAmount_1.ToString();
                ElementParameters.Children.Add(tempLoaded);
            }
            else
            {
                SelectedElement = new SlidingUnLoaded();
                SelectedElement.Draw();
                SelectedElement.ElementImage.Height = 180;
                SelectedElement.Margin = new Thickness(-10, 30, 0, 0);
                ElementParameters.Children.Add(SelectedElement);
            }
        }

        private void MajorConnectNFMClicked(object sender, RoutedEventArgs e)
        {
            ElementType = ELTYPE.MAJOR;

            ElementParameters.Children.Clear();

            Label elementsAmount = new Label();
            elementsAmount.Content = "Количество основных элементов";
            elementsAmount.HorizontalAlignment = HorizontalAlignment.Center;
            BOX1.Clear();
            BOX1.Width = 160;
            BOX1.PreviewTextInput += IntValidationTextBox;

            Label relementsAmount = new Label();
            relementsAmount.Content = "Количество резервных элементов";
            relementsAmount.HorizontalAlignment = HorizontalAlignment.Center;
            BOX2.Clear();
            BOX2.Width = 160;
            BOX2.PreviewTextInput += IntValidationTextBox;

            ElementParameters.Children.Add(elementsAmount);
            ElementParameters.Children.Add(BOX1);
            ElementParameters.Children.Add(relementsAmount);
            ElementParameters.Children.Add(BOX2);

            Button ChoseElButton = new Button()
            {
                Content = "Тип элементов",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10, 10, 10, 0),
                Width = 160
            };
            ChoseElButton.Click += ChoseElementClicked;
            ElementParameters.Children.Add(ChoseElButton);

            Button ChoseElButton_1 = new Button()
            {
                Content = "Тип мажоритарного элемента",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10, 10, 10, 0),
                Width = 160,
                FontSize = 11
            };
            ChoseElButton_1.Click += ChoseElementClicked_1;
            ElementParameters.Children.Add(ChoseElButton_1);

            if (MainElement.ElType == ELTYPE.MAJOR)
            {
                SelectedElement = MainElement;
                MyCanvas tempLoaded = new MajorConnect();
                tempLoaded.Draw();
                tempLoaded.Margin = new Thickness(50, 30, 0, 0);
                BOX1.Text = MainElement.ItemsAmount.ToString();
                BOX2.Text = MainElement.ItemsAmount_1.ToString();
                ElementParameters.Children.Add(tempLoaded);
            }
            else
            {
                SelectedElement = new MajorConnect();
                SelectedElement.Draw();
                SelectedElement.Margin = new Thickness(50, 30, 0, 0);
                ElementParameters.Children.Add(SelectedElement);
            }
        }

        private void BridgeConnectClicked(object sender, RoutedEventArgs e)
        {
            ElementType = ELTYPE.BRIDGE;

            ElementParameters.Children.Clear();

            Button ChoseElButton = new Button()
            {
                Content = "Тип элементов",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10, 10, 10, 0),
                Width = 160
            };
            ChoseElButton.Click += ChoseElementClicked;
            ElementParameters.Children.Add(ChoseElButton);

            if (MainElement.ElType == ELTYPE.BRIDGE)
            {
                SelectedElement = MainElement;
                MyCanvas tempLoaded = new BridgeConnect();
                tempLoaded.Draw();
                tempLoaded.Margin = new Thickness(50, 30, 0, 0);
                ElementParameters.Children.Add(tempLoaded);
            }
            else
            {
                SelectedElement = new BridgeConnect();
                SelectedElement.Draw();
                SelectedElement.Margin = new Thickness(50, 30, 0, 0);
                ElementParameters.Children.Add(SelectedElement);
            }
        }

        private void BackupDeviceControlGroupsLRClicked(object sender, RoutedEventArgs e)
        {
            ElementType = ELTYPE.BDCGLR;

            ElementParameters.Children.Clear();

            Label elementsAmount = new Label();
            elementsAmount.Content = "Количество групп “Нагруженное резервирование”";
            elementsAmount.HorizontalAlignment = HorizontalAlignment.Center;
            BOX1.Clear();
            BOX1.Width = 160;
            BOX1.PreviewTextInput += IntValidationTextBox;

            ElementParameters.Children.Add(elementsAmount);
            ElementParameters.Children.Add(BOX1);

            Button ChoseElButton = new Button()
            {
                Content = "Тип элементов",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10, 10, 10, 0),
                Width = 160
            };
            ChoseElButton.Click += ChoseElementClicked;
            ElementParameters.Children.Add(ChoseElButton);

            Button ChoseElButton_1 = new Button()
            {
                Content = "Тип управляющего элемента",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10, 10, 10, 0),
                Width = 160,
                FontSize = 11
            };
            ChoseElButton_1.Click += ChoseElementClicked_1;
            ElementParameters.Children.Add(ChoseElButton_1);

            if (MainElement.ElType == ELTYPE.BDCGLR)
            {
                SelectedElement = MainElement;
                MyCanvas tempLoaded = new BackupDeviceControlGroupsLR();
                tempLoaded.Draw();
                tempLoaded.Margin = new Thickness(-10, 30, 0, 0);
                BOX1.Text = MainElement.ItemsAmount.ToString();
                BOX2.Text = MainElement.lambda.ToString();
                ElementParameters.Children.Add(tempLoaded);
            }
            else
            {
                SelectedElement = new BackupDeviceControlGroupsLR();
                SelectedElement.Draw();
                SelectedElement.Margin = new Thickness(-10, 30, 0, 0);
                ElementParameters.Children.Add(SelectedElement);
            }
        }

        private void SerialConnectClicked(object sender, RoutedEventArgs e)
        {
            ElementType = ELTYPE.SERIAL;

            ElementParameters.Children.Clear();

            Label elementsAmount = new Label();
            elementsAmount.Content = "Количество элементов";
            elementsAmount.HorizontalAlignment = HorizontalAlignment.Center;
            BOX1.Clear();
            BOX1.Width = 160;
            BOX1.PreviewTextInput += IntValidationTextBox;

            ElementParameters.Children.Add(elementsAmount);
            ElementParameters.Children.Add(BOX1);

            Button ChoseElButton = new Button()
            {
                Content = "Тип элементов",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 10, 0, 0),
                Width = 160
            };
            ChoseElButton.Click += ChoseElementClicked;
            ElementParameters.Children.Add(ChoseElButton);

            if (MainElement.ElType == ELTYPE.SERIAL)
            {
                SelectedElement = MainElement;
                MyCanvas tempLoaded = new SerialConnect();
                tempLoaded.Draw();
                tempLoaded.Margin = new Thickness(30, 30, 0, 0);
                BOX1.Text = MainElement.ItemsAmount.ToString();
                ElementParameters.Children.Add(tempLoaded);
            }
            else
            {
                SelectedElement = new SerialConnect();
                SelectedElement.Draw();
                SelectedElement.Margin = new Thickness(30, 30, 0, 0);
                ElementParameters.Children.Add(SelectedElement);
            }
        }

        private void BackupControlType2Clicked(object sender, RoutedEventArgs e)
        {
            ElementType = ELTYPE.BACKUP;

            ElementParameters.Children.Clear();

            Button ChoseElButton = new Button()
            {
                Content = "Тип элементов",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10, 10, 10, 0),
                Width = 160
            };
            ChoseElButton.Click += ChoseElementClicked;
            ElementParameters.Children.Add(ChoseElButton);

            Button ChoseElButton_1 = new Button()
            {
                Content = "Тип управляющего элемента",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10, 10, 10, 0),
                Width = 160,
                FontSize = 11.5,
            };
            ChoseElButton_1.Click += ChoseElementClicked_1;
            ElementParameters.Children.Add(ChoseElButton_1);

            if (MainElement.ElType == ELTYPE.BACKUP)
            {
                SelectedElement = MainElement;
                MyCanvas tempLoaded = new BackupControlType2();
                tempLoaded.Draw();
                tempLoaded.Margin = new Thickness(30, 30, 0, 0);
                ElementParameters.Children.Add(tempLoaded);
            }
            else
            {
                SelectedElement = new BackupControlType2();
                SelectedElement.Draw();
                SelectedElement.Margin = new Thickness(30, 30, 0, 0);
                ElementParameters.Children.Add(SelectedElement);
            }
        }

        private void ReservManageReplacingClicked(object sender, RoutedEventArgs e)
        {
            ElementType = ELTYPE.RMR;

            ElementParameters.Children.Clear();

            Label elementsAmount = new Label();
            elementsAmount.Content = "Количество групп";
            elementsAmount.HorizontalAlignment = HorizontalAlignment.Center;
            BOX1.Clear();
            BOX1.Width = 160;
            BOX1.PreviewTextInput += IntValidationTextBox;

            ElementParameters.Children.Add(elementsAmount);
            ElementParameters.Children.Add(BOX1);

            Button ChoseElButton = new Button()
            {
                Content = "Тип элементов",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10, 10, 10, 0),
                Width = 160
            };
            ChoseElButton.Click += ChoseElementClicked;
            ElementParameters.Children.Add(ChoseElButton);

            Button ChoseElButton_1 = new Button()
            {
                Content = "Тип датчика ",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10, 10, 10, 0),
                Width = 160
            };
            ChoseElButton_1.Click += ChoseElementClicked_1;
            ElementParameters.Children.Add(ChoseElButton_1);

            Button ChoseElButton_2 = new Button()
            {
                Content = "Тип управляющего элемента",
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(10, 10, 10, 0),
                Width = 160,
                FontSize = 11.5
            };
            ChoseElButton_2.Click += ChoseElementClicked_2;
            ElementParameters.Children.Add(ChoseElButton_2);

            if (MainElement.ElType == ELTYPE.RMR)
            {
                SelectedElement = MainElement;
                MyCanvas tempLoaded = new ReservManageReplacing();
                tempLoaded.Draw();
                tempLoaded.Margin = new Thickness(10, 30, 0, 0);
                BOX1.Text = MainElement.ItemsAmount.ToString();
                BOX2.Text = MainElement.ItemsAmount_1.ToString();
                ElementParameters.Children.Add(tempLoaded);
            }
            else
            {
                SelectedElement = new ReservManageReplacing();
                SelectedElement.Draw();
                SelectedElement.Margin = new Thickness(10, 30, 0, 0);
                ElementParameters.Children.Add(SelectedElement);
            }
        }

        private void ChoseElementClicked(object sender, RoutedEventArgs e)
        {
            ElementsWindow wind;
            if (ElementType == ELTYPE.SLIDINGUNLOAD || ElementType == ELTYPE.UNLOADED)
            {
                wind = new ElementsWindow(SelectedElement.ContainEl, true);
            }
            else
            {
                wind = new ElementsWindow(SelectedElement.ContainEl, false);
            }

            wind.Owner = this;
            wind.OkClicksElement += ElementSelected;
            wind.ShowDialog();
        }

        private void ElementSelected(MyCanvas Element)
        {
            SelectedElement.ContainEl = Element;
        }

        private void ChoseElementClicked_1(object sender, RoutedEventArgs e)
        {
            ElementsWindow wind = new ElementsWindow(SelectedElement.ContainEl_1, false);
            wind.Owner = this;
            wind.OkClicksElement += ElementSelected_1;
            wind.ShowDialog();
        }

        private void ElementSelected_1(MyCanvas Element)
        {
            SelectedElement.ContainEl_1 = Element;
        }

        private void ChoseElementClicked_2(object sender, RoutedEventArgs e)
        {
            ElementsWindow wind = new ElementsWindow(SelectedElement.ContainEl_2, false);
            wind.Owner = this;
            wind.OkClicksElement += ElementSelected_2;
            wind.ShowDialog();
        }

        private void ElementSelected_2(MyCanvas Element)
        {
            SelectedElement.ContainEl_2 = Element;
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
                Canvas.SetLeft(tempCanv, (Canvas.GetLeft(StartCanv) + (int)StartCanv.ElementImage.ActualWidth)
                    - (Canvas.GetLeft(StartCanv) + (int)StartCanv.ElementImage.ActualWidth) % 20 + 40);
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

        public void MorecClicked(object sender, MouseButtonEventArgs e)
        {
            var mouseWasDownOn = e.Source as FrameworkElement;
            string elementName = mouseWasDownOn.Uid;
            CurentElement = SchemePlace.Children.OfType<MyCanvas>().FirstOrDefault(x => x.Uid.IndexOf(':' + elementName) > -1);
            ElementsWindow wind = new ElementsWindow(CurentElement, false);
            wind.Owner = this;
            wind.OkClicksElement += AddLoaded;
            wind.ShowDialog();
        }

        void AddLoaded(MyCanvas newElement)
        {
            if (newElement != CurentElement)
            {
                newElement.MouseLeftButtonDown += StartDrag;
                newElement.MouseRightButtonDown += RemoveClick;
            }
            Canvas.SetTop(newElement, Canvas.GetTop(CurentElement));
            Canvas.SetLeft(newElement, Canvas.GetLeft(CurentElement));
            if (CurentElement.PREVIOUS != null && CurentElement.NEXT != null)
            {
                DrawConnectLine(newElement, CurentElement.NEXT);
                DrawConnectLine(CurentElement.PREVIOUS, newElement);
                SchemePlace.Children.Remove(CurentElement.RightLine);
                SchemePlace.Children.Remove(CurentElement.LeftLine);
            }
            else if (CurentElement.PREVIOUS == null && CurentElement.NEXT == null)
            {
                if (CurentElement != newElement)
                {
                    DrowOutput(newElement);
                    DrowInput(newElement);

                }
            }
            else if (CurentElement.PREVIOUS != null)
            {
                DrawConnectLine(CurentElement.PREVIOUS, newElement);
                SchemePlace.Children.Remove(CurentElement.LeftLine);
                if (CurentElement != newElement)
                {
                    DrowOutput(newElement);
                }
            }
            else if (CurentElement.NEXT != null)
            {
                DrawConnectLine(newElement, CurentElement.NEXT);
                SchemePlace.Children.Remove(CurentElement.RightLine);
                DrowInput(newElement);
            }

            newElement.PREVIOUS = CurentElement.PREVIOUS;
            newElement.NEXT = CurentElement.NEXT;
            if (newElement.PREVIOUS != null) { newElement.PREVIOUS.NEXT = newElement; }
            if (newElement.NEXT != null) { newElement.NEXT.PREVIOUS = newElement; }
            if (CurentElement == FirstElement) { FirstElement = newElement; }
            if (CurentElement != newElement)
            {
                SchemePlace.Children.Add(newElement);
                CurentElement.Children.Clear();
                SchemePlace.Children.Remove(CurentElement);
            }
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
                DrowOutput(tempCanv.PREVIOUS);
                tempCanv.PREVIOUS.NEXT = null;
            }
            else if (tempCanv.NEXT != null)
            {
                tempCanv.NEXT.LeftLine = null;
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

            tempCanv.El = new Ellipse()
            {
                Width = 8,
                Height = 8,
                Cursor = Cursors.Hand,
                Uid = tempCanv.ElementImage.Uid,
                Fill = Brushes.Black
            };

            tempCanv.El.MouseLeftButtonDown += BRecMouseDown;
            Canvas.SetTop(tempCanv.El, tempCanv.Y);
            Canvas.SetLeft(tempCanv.El, tempCanv.XR);
            tempCanv.Children.Add(tempCanv.El);
        }

    }
}
