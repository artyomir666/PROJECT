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
    public enum ELTYPE { EMPTY = 1, PLAIN, LOADED, UNLOADED, SLIDINGLOAD,
        SLIDINGUNLOAD, MAJOR,  BRIDGE, BDCGLR, SERIAL, BACKUP, RMR, LIST_};

    public class MyCanvas : Canvas
    {
        public double lambda;
        public double lambda_1;
        public int ItemsAmount;
        public int ItemsAmount_1;
        public MyCanvas ContainEl;
        public MyCanvas ContainEl_1;
        public MyCanvas ContainEl_2;
        public Polyline LeftLine;
        public Polyline RightLine;
        public MyCanvas NEXT;
        public MyCanvas PREVIOUS;
        public ELTYPE ElType;
        public Image ElementImage = new Image();
        public double XL;
        public double Y;
        public double XR;
        public Ellipse El;
        public TextBlock Out;
        public Ellipse ElIn;
        public TextBlock In;
        public int cont = 0;
        public MyCanvas()
        {
            ElType = ELTYPE.EMPTY;
            XL = 4;
            XR = 69;
            Y = 6;
        }
        virtual public void Draw()
        {
            Uid = ':' + ElID.CanvID.ToString();
            Rectangle rec1 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Line LCon = new Line()
            {
                X1 = 10,
                Y1 = 10.5,
                Y2 = 10.5,
                X2 = 20,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            Line RCon = new Line()
            {
                X1 = 60,
                Y1 = 10.5,
                Y2 = 10.5,
                X2 = 71,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            TextBlock a = new TextBlock();
            a.Text = "?";
            Canvas.SetTop(a, 2);
            Canvas.SetLeft(a, 38);
            Children.Add(a);

            Canvas.SetLeft(rec1, 20);
            Children.Add(rec1);
            Children.Add(LCon);
            Children.Add(RCon);
            Cursor = Cursors.Cross;
            ElementImage.Uid = ElID.CanvID.ToString();
            ElID.CanvID++;






            //Uid = ':' + ElID.CanvID.ToString();
            //string startupPath = Environment.CurrentDirectory;
            //var circleUri = new Uri(String.Format(startupPath + @"\IMAGES\Element.png"));
            ////var circleUri = new Uri(String.Format(@"D:\IMAGES\Element.png"));
            //ElementImage.Source = new BitmapImage(circleUri);
            ////ElementImage.Height = 20;
            ////ElementImage.Margin = new Thickness(10, 0, 0, 0);
            //ElementImage.Uid = ElID.CanvID.ToString();

            //TextBlock a = new TextBlock();
            //a.Text = "?";
            //Canvas.SetTop(a, 2);
            //Canvas.SetLeft(a, 38);
            //Children.Add(a);

            //Canvas.SetLeft(ElementImage, 10);
            //Children.Add(ElementImage);
            //Cursor = Cursors.Cross;
            //ElID.CanvID++;
        }
    }

    public class Plain : MyCanvas
    {
        override public void Draw()
        {
            Uid = ':' + ElID.CanvID.ToString();
            Rectangle rec1 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Line LCon = new Line()
            {
                X1 = 10,
                Y1 = 10.5,
                Y2 = 10.5,
                X2 = 20,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            Line RCon = new Line()
            {
                X1 = 60,
                Y1 = 10.5,
                Y2 = 10.5,
                X2 = 71,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };

            Canvas.SetLeft(rec1, 20);
            Children.Add(rec1);
            Children.Add(LCon);
            Children.Add(RCon);
            Cursor = Cursors.Cross;
            ElementImage.Uid = ElID.CanvID.ToString();
            ElID.CanvID++;


            //Uid = ':' + ElID.CanvID.ToString();
            //string startupPath = Environment.CurrentDirectory;
            //var circleUri = new Uri(String.Format(startupPath + @"\IMAGES\Element.png"));
            ////var circleUri = new Uri(String.Format(@"D:\IMAGES\Element.png"));
            //ElementImage.Source = new BitmapImage(circleUri);
            ////ElementImage.Height = 20;
            //ElementImage.Uid = ElID.CanvID.ToString();
            //Canvas.SetLeft(ElementImage, 10);
            //Children.Add(ElementImage);
            //Cursor = Cursors.Cross;

            //ElID.CanvID++;
        }
        public Plain()
        {
            ElType = ELTYPE.PLAIN;
            XL = 4;
            XR = 69;
            Y = 6;
        }
    }

    public class Loaded : MyCanvas
    {
        override public void Draw()
        {
            Uid = ':' + ElID.CanvID.ToString();
            Rectangle rec1 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Rectangle rec2 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Rectangle rec3 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Line LCon1 = new Line()
            {
                X1 = 50,
                Y1 = 30.5,
                Y2 = 30.5,
                X2 = 60,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            Line RCon1 = new Line()
            {
                X1 = 100,
                Y1 = 30.5,
                Y2 = 30.5,
                X2 = 111,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            Line LCon2 = new Line()
            {
                X1 = 9,
                Y1 = 70.5,
                Y2 = 70.5,
                X2 = 60,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            Line RCon2= new Line()
            {
                X1 = 100,
                Y1 = 70.5,
                Y2 = 70.5,
                X2 = 151,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            Line LCon3 = new Line()
            {
                X1 = 50,
                Y1 = 110.5,
                Y2 = 110.5,
                X2 = 60,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            Line RCon3 = new Line()
            {
                X1 = 100,
                Y1 = 110.5,
                Y2 = 110.5,
                X2 = 111,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            Line LLine = new Line()
            {
                X1 = 50.5,
                Y1 = 30.5,
                Y2 = 110.5,
                X2 = 50.5,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            Line RLine = new Line()
            {
                X1 = 110.5,
                Y1 = 30.5,
                Y2 = 110.5,
                X2 = 110.5,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };


            Rectangle dot1 = new Rectangle()
            {
                Width = 3,
                Height = 3,
                Stroke = Brushes.Black,
                Fill = Brushes.Black
            };

            Rectangle dot2 = new Rectangle()
            {
                Width = 3,
                Height = 3,
                Stroke = Brushes.Black,
                Fill = Brushes.Black
            };

            Rectangle dot3 = new Rectangle()
            {
                Width = 3,
                Height = 3,
                Stroke = Brushes.Black,
                Fill = Brushes.Black
            };
            Canvas.SetLeft(dot1, 68);
            Canvas.SetTop(dot1, 88);
            Children.Add(dot1);
            Canvas.SetLeft(dot2, 78);
            Canvas.SetTop(dot2, 88);
            Children.Add(dot2);
            Canvas.SetLeft(dot3, 88);
            Canvas.SetTop(dot3, 88);
            Children.Add(dot3);
            Canvas.SetLeft(rec1, 60);
            Canvas.SetTop(rec1, 20);
            Children.Add(rec1);
            Canvas.SetLeft(rec2, 60);
            Canvas.SetTop(rec2, 60);
            Children.Add(rec2);
            Canvas.SetLeft(rec3, 60);
            Canvas.SetTop(rec3, 100);
            Children.Add(rec3);
            Children.Add(LCon1);
            Children.Add(RCon1);
            Children.Add(LCon2);
            Children.Add(RCon2);
            Children.Add(LCon3);
            Children.Add(RCon3);
            Children.Add(LLine);
            Children.Add(RLine);
            Cursor = Cursors.Cross;
            ElementImage.Uid = ElID.CanvID.ToString();
            ElID.CanvID++;

            //Uid = ':' + ElID.CanvID.ToString();
            //string startupPath = Environment.CurrentDirectory;
            //var circleUri = new Uri(String.Format(startupPath + @"\IMAGES\Loaded.png"));
            ////var circleUri = new Uri(String.Format(@"D:\IMAGES\Loaded.png"));
            //ElementImage.Source = new BitmapImage(circleUri);
            ////ElementImage.Height = 90;
            //ElementImage.Uid = ElID.CanvID.ToString();
            //Canvas.SetLeft(ElementImage, 10);
            //Children.Add(ElementImage);
            //Cursor = Cursors.Cross;

            //ElID.CanvID++;
        }

        public Loaded()
        {
            ElType = ELTYPE.LOADED;
            XL = 4;
            XR = 149;
            Y = 66;
            ContainEl = new MyCanvas();
        }
    }

    public class Unloaded: MyCanvas
    {
        override public void Draw()
        {
            Uid = ':' + ElID.CanvID.ToString();
            Rectangle rec1 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Rectangle rec2 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Rectangle rec3 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Polyline LTopLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            LTopLine.Points.Add(new Point(10, 70.5));
            LTopLine.Points.Add(new Point(30.5, 70.5));
            LTopLine.Points.Add(new Point(30.5, 30.5));
            LTopLine.Points.Add(new Point(60, 30.5));

            Polyline RTopLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            RTopLine.Points.Add(new Point(150, 70.5));
            RTopLine.Points.Add(new Point(130.5, 70.5));
            RTopLine.Points.Add(new Point(130.5, 30.5));
            RTopLine.Points.Add(new Point(100 , 30.5));


            Polyline LMidLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            LMidLine.Points.Add(new Point(60, 70.5));
            LMidLine.Points.Add(new Point(50.5, 70.5));
            LMidLine.Points.Add(new Point(50.5, 57.5));

            Polyline RMidLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            RMidLine.Points.Add(new Point(100, 70.5));
            RMidLine.Points.Add(new Point(110.5, 70.5));
            RMidLine.Points.Add(new Point(110.5, 57.5));

            Polyline LBotLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            LBotLine.Points.Add(new Point(60, 110.5));
            LBotLine.Points.Add(new Point(50.5, 110.5));
            LBotLine.Points.Add(new Point(50.5, 97.5));

            Polyline RBotLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            RBotLine.Points.Add(new Point(100, 110.5));
            RBotLine.Points.Add(new Point(110.5, 110.5));
            RBotLine.Points.Add(new Point(110.5, 97.5));

            Rectangle dot1 = new Rectangle()
            {
                Width = 3,
                Height = 3,
                Stroke = Brushes.Black,
                Fill = Brushes.Black
            };

            Rectangle dot2 = new Rectangle()
            {
                Width = 3,
                Height = 3,
                Stroke = Brushes.Black,
                Fill = Brushes.Black
            };

            Rectangle dot3 = new Rectangle()
            {
                Width = 3,
                Height = 3,
                Stroke = Brushes.Black,
                Fill = Brushes.Black
            };

            Line LL = new Line()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                X1 = 50.5,
                Y1 = 30,
                X2 = 50.5,
                Y2 = 40
            };

            Line RL = new Line()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                X1 = 110.5,
                Y1 = 30,
                X2 = 110.5,
                Y2 = 40
            };

            Polygon triangle1 = new Polygon() {
                Fill = Brushes.Black
            };
            triangle1.Points.Add(new Point(0, 0));
            triangle1.Points.Add(new Point(2, -8));
            triangle1.Points.Add(new Point(4, 0));

            Polygon triangle2 = new Polygon()
            {
                Fill = Brushes.Black
            };
            triangle2.Points.Add(new Point(0, 0));
            triangle2.Points.Add(new Point(2, -8));
            triangle2.Points.Add(new Point(4, 0));

            Polygon triangle3 = new Polygon()
            {
                Fill = Brushes.Black
            };
            triangle3.Points.Add(new Point(0, 0));
            triangle3.Points.Add(new Point(2, -8));
            triangle3.Points.Add(new Point(4, 0));

            Polygon triangle4 = new Polygon()
            {
                Fill = Brushes.Black
            };
            triangle4.Points.Add(new Point(0, 0));
            triangle4.Points.Add(new Point(2, -8));
            triangle4.Points.Add(new Point(4, 0));

            Canvas.SetTop(triangle1, 60);
            Canvas.SetLeft(triangle1, 48.5);
            Children.Add(triangle1);

            Canvas.SetTop(triangle2, 60);
            Canvas.SetLeft(triangle2, 108.5);
            Children.Add(triangle2);

            Canvas.SetTop(triangle3, 100);
            Canvas.SetLeft(triangle3, 48.5);
            Children.Add(triangle3);

            Canvas.SetTop(triangle4, 100);
            Canvas.SetLeft(triangle4, 108.5);
            Children.Add(triangle4);

            Canvas.SetLeft(dot1, 68);
            Canvas.SetTop(dot1, 88);
            Children.Add(dot1);

            Canvas.SetLeft(dot2, 78);
            Canvas.SetTop(dot2, 88);
            Children.Add(dot2);

            Canvas.SetLeft(dot3, 88);
            Canvas.SetTop(dot3, 88);
            Children.Add(dot3);

            Canvas.SetLeft(rec1, 60);
            Canvas.SetTop(rec1, 20);
            Children.Add(rec1);

            Canvas.SetLeft(rec2, 60);
            Canvas.SetTop(rec2, 60);
            Children.Add(rec2);

            Canvas.SetLeft(rec3, 60);
            Canvas.SetTop(rec3, 100);
            Children.Add(rec3);

            Children.Add(LTopLine);
            Children.Add(RTopLine);

            Children.Add(LMidLine);
            Children.Add(RMidLine);

            Children.Add(LBotLine);
            Children.Add(RBotLine);

            Children.Add(LL);
            Children.Add(RL);

            Cursor = Cursors.Cross;
            ElementImage.Uid = ElID.CanvID.ToString();
            ElID.CanvID++;

            //Uid = ':' + ElID.CanvID.ToString();
            //string startupPath = Environment.CurrentDirectory;
            //var circleUri = new Uri(String.Format(startupPath + @"\IMAGES\Unloaded.png"));
            ////var circleUri = new Uri(String.Format(@"D:\IMAGES\Unloaded.png"));
            //ElementImage.Source = new BitmapImage(circleUri);
            ////ElementImage.Height = 90;
            //ElementImage.Uid = ElID.CanvID.ToString();
            //Canvas.SetLeft(ElementImage, 10);
            //Children.Add(ElementImage);
            //Cursor = Cursors.Cross;

            //ElID.CanvID++;
        }

        public Unloaded()
        {
            ElType = ELTYPE.UNLOADED;
            XL = 4;
            XR = 149;
            Y = 66;
            ContainEl = new MyCanvas();
        }
    }

    public class SlidingLoaded : MyCanvas
    {
        override public void Draw()
        {
            Uid = ':' + ElID.CanvID.ToString();
            string startupPath = Environment.CurrentDirectory;
            var circleUri = new Uri(String.Format(startupPath + @"\IMAGES\SlidingLoaded.png"));
            //var circleUri = new Uri(String.Format(@"D:\IMAGES\SlidingLoaded.png"));
            ElementImage.Source = new BitmapImage(circleUri);
            //ElementImage.Height = 140;
            ElementImage.Uid = ElID.CanvID.ToString();
            Canvas.SetLeft(ElementImage, 10);
            Children.Add(ElementImage);
            Cursor = Cursors.Cross;

            ElID.CanvID++;
        }

        public SlidingLoaded()
        {
            ElType = ELTYPE.SLIDINGLOAD;
            XL = 4;
            XR = 389;
            Y = 106;
            ContainEl = new MyCanvas();
        }
    }

    public class SlidingUnLoaded : MyCanvas
    {
        override public void Draw()
        {
            Uid = ':' + ElID.CanvID.ToString();
            string startupPath = Environment.CurrentDirectory;
            var circleUri = new Uri(String.Format(startupPath + @"\IMAGES\SlidingUnLoaded.png"));
            //var circleUri = new Uri(String.Format(@"D:\IMAGES\SlidingUnLoaded.png"));
            ElementImage.Source = new BitmapImage(circleUri);
            ElementImage.Uid = ElID.CanvID.ToString();
            //Canvas.SetTop(ElementImage, -10);
            Canvas.SetLeft(ElementImage, 10);
            Children.Add(ElementImage);
            Cursor = Cursors.Cross;

            ElID.CanvID++;
        }

        public SlidingUnLoaded()
        {
            ElType = ELTYPE.SLIDINGUNLOAD;
            XL = 4;
            XR = 389;
            Y = 106;
            ContainEl = new MyCanvas();
        }
    }

    public class MajorConnect : MyCanvas
    {
        override public void Draw()
        {
                        Uid = ':' + ElID.CanvID.ToString();
            Rectangle rec1 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Rectangle rec2 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Rectangle rec3 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Ellipse el = new Ellipse()
            {
                Width = 30,
                Height = 30,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };

            Line LCon1 = new Line()
            {
                X1 = 50,
                Y1 = 30.5,
                Y2 = 30.5,
                X2 = 60,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };

            Polyline RTopLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            RTopLine.Points.Add(new Point(100, 30.5));
            RTopLine.Points.Add(new Point(110, 30.5));
            RTopLine.Points.Add(new Point(140, 60.5));

            Line LCon2 = new Line()
            {
                X1 = 9,
                Y1 = 70.5,
                Y2 = 70.5,
                X2 = 60,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            Line RCon2= new Line()
            {
                X1 = 100,
                Y1 = 70.5,
                Y2 = 70.5,
                X2 = 135,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            Line LCon3 = new Line()
            {
                X1 = 50,
                Y1 = 110.5,
                Y2 = 110.5,
                X2 = 60,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };

            Polyline RBotLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            RBotLine.Points.Add(new Point(100, 110.5));
            RBotLine.Points.Add(new Point(110, 110.5));
            RBotLine.Points.Add(new Point(140, 80.5));

            Line LLine = new Line()
            {
                X1 = 50.5,
                Y1 = 30.5,
                Y2 = 110.5,
                X2 = 50.5,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            Line RLine = new Line()
            {
                X1 = 165,
                Y1 = 70.5,
                Y2 = 70.5,
                X2 = 195,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };


            Rectangle dot1 = new Rectangle()
            {
                Width = 3,
                Height = 3,
                Stroke = Brushes.Black,
                Fill = Brushes.Black
            };

            Rectangle dot2 = new Rectangle()
            {
                Width = 3,
                Height = 3,
                Stroke = Brushes.Black,
                Fill = Brushes.Black
            };

            Rectangle dot3 = new Rectangle()
            {
                Width = 3,
                Height = 3,
                Stroke = Brushes.Black,
                Fill = Brushes.Black
            };

            RotateTransform rotate = new RotateTransform(135);

            Polygon triangle1 = new Polygon()
            {
                Fill = Brushes.Black,
                RenderTransform = rotate
            };
            triangle1.Points.Add(new Point(0, 0));
            triangle1.Points.Add(new Point(2, -8));
            triangle1.Points.Add(new Point(4, 0));

            rotate = new RotateTransform(90);

            Polygon triangle2 = new Polygon()
            {
                Fill = Brushes.Black,
                RenderTransform = rotate
            };
            triangle2.Points.Add(new Point(0, 0));
            triangle2.Points.Add(new Point(2, -8));
            triangle2.Points.Add(new Point(4, 0));

            rotate = new RotateTransform(45);
            Polygon triangle3 = new Polygon()
            {
                Fill = Brushes.Black,
                RenderTransform = rotate
            };
            triangle3.Points.Add(new Point(0, 0));
            triangle3.Points.Add(new Point(2, -8));
            triangle3.Points.Add(new Point(4, 0));

            Canvas.SetTop(triangle1, 53);
            Canvas.SetLeft(triangle1, 135.5);
            Children.Add(triangle1);

            Canvas.SetTop(triangle2, 68.5);
            Canvas.SetLeft(triangle2, 126.5);
            Children.Add(triangle2);

            Canvas.SetTop(triangle3, 84);
            Canvas.SetLeft(triangle3, 133.5);
            Children.Add(triangle3);

            Canvas.SetTop(el, 55.5);
            Canvas.SetLeft(el, 135);
            Children.Add(el);

            Canvas.SetLeft(dot1, 68);
            Canvas.SetTop(dot1, 88);
            Children.Add(dot1);

            Canvas.SetLeft(dot2, 78);
            Canvas.SetTop(dot2, 88);
            Children.Add(dot2);

            Canvas.SetLeft(dot3, 88);
            Canvas.SetTop(dot3, 88);
            Children.Add(dot3);

            Canvas.SetLeft(rec1, 60);
            Canvas.SetTop(rec1, 20);
            Children.Add(rec1);

            Canvas.SetLeft(rec2, 60);
            Canvas.SetTop(rec2, 60);
            Children.Add(rec2);

            Canvas.SetLeft(rec3, 60);
            Canvas.SetTop(rec3, 100);
            Children.Add(rec3);

            Children.Add(LCon1);
            Children.Add(RTopLine);

            Children.Add(LCon2);
            Children.Add(RCon2);

            Children.Add(LCon3);
            Children.Add(RBotLine);

            Children.Add(LLine);
            Children.Add(RLine);

            Cursor = Cursors.Cross;
            ElementImage.Uid = ElID.CanvID.ToString();
            ElID.CanvID++;

            //Uid = ':' + ElID.CanvID.ToString();
            //string startupPath = Environment.CurrentDirectory;
            //var circleUri = new Uri(String.Format(startupPath + @"\IMAGES\MajorConnectNFM.png"));
            ////var circleUri = new Uri(String.Format(@"D:\IMAGES\MajorConnectNFM.png"));
            //ElementImage.Source = new BitmapImage(circleUri);
            ////ElementImage.Height = 140;
            //ElementImage.Uid = ElID.CanvID.ToString();
            //Canvas.SetLeft(ElementImage, 10);
            //Children.Add(ElementImage);
            //Cursor = Cursors.Cross;

            //ElID.CanvID++;
        }

        public MajorConnect()
        {
            ElType = ELTYPE.MAJOR;
            XL = 4;
            XR = 189;
            Y = 66;
            ContainEl = new MyCanvas();
            ContainEl_1 = new MyCanvas();
        }
    }

    public class BridgeConnect : MyCanvas
    {
        override public void Draw()
        {
            Uid = ':' + ElID.CanvID.ToString();
            Rectangle rec1 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Rectangle rec2 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Rectangle rec3 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Rectangle rec4 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Rectangle rec5 = new Rectangle()
            {
                Width = 20,
                Height = 40,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };

            Polyline LMainLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            LMainLine.Points.Add(new Point(50, 20.5));
            LMainLine.Points.Add(new Point(40.5, 20.5));
            LMainLine.Points.Add(new Point(40.5, 120.5));
            LMainLine.Points.Add(new Point(50, 120.5));

            Polyline RMainLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            RMainLine.Points.Add(new Point(150, 20.5));
            RMainLine.Points.Add(new Point(160.5, 20.5));
            RMainLine.Points.Add(new Point(160.5, 120.5));
            RMainLine.Points.Add(new Point(150, 120.5));


            Polyline TopMidLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            TopMidLine.Points.Add(new Point(90, 20.5));
            TopMidLine.Points.Add(new Point(105, 20.5));
            TopMidLine.Points.Add(new Point(100.5, 20.5));
            TopMidLine.Points.Add(new Point(100.5, 50.5));


            Polyline BotMidLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            BotMidLine.Points.Add(new Point(90, 120.5));
            BotMidLine.Points.Add(new Point(105, 120.5));
            BotMidLine.Points.Add(new Point(100.5, 120.5));
            BotMidLine.Points.Add(new Point(100.5, 89.5));


            Line LL = new Line()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                X1 = 9,
                Y1 = 70.5,
                X2 = 40,
                Y2 = 70.5
            };

            Line RL = new Line()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                X1 = 160,
                Y1 = 70.5,
                X2 = 191,
                Y2 = 70.5
            };

            Canvas.SetLeft(rec1, 50);
            Canvas.SetTop(rec1, 10);
            Children.Add(rec1);

            Canvas.SetLeft(rec2, 110);
            Canvas.SetTop(rec2, 10);
            Children.Add(rec2);

            Canvas.SetLeft(rec3, 50);
            Canvas.SetTop(rec3, 110);
            Children.Add(rec3);

            Canvas.SetLeft(rec4, 110);
            Canvas.SetTop(rec4, 110);
            Children.Add(rec4);

            Canvas.SetLeft(rec5, 90);
            Canvas.SetTop(rec5, 50);
            Children.Add(rec5);

            Children.Add(LMainLine);
            Children.Add(RMainLine);

            Children.Add(TopMidLine);
            Children.Add(BotMidLine);

            //Children.Add(LBotLine);
            //Children.Add(RBotLine);

            Children.Add(LL);
            Children.Add(RL);

            Cursor = Cursors.Cross;
            ElementImage.Uid = ElID.CanvID.ToString();
            ElID.CanvID++;

            //Uid = ':' + ElID.CanvID.ToString();
            //string startupPath = Environment.CurrentDirectory;
            //var circleUri = new Uri(String.Format(startupPath + @"\IMAGES\BridgeConnect.png"));
            ////var circleUri = new Uri(String.Format(@"D:\IMAGES\BridgeConnect.png"));
            //ElementImage.Source = new BitmapImage(circleUri);
            ////ElementImage.Height = 100;
            //ElementImage.Uid = ElID.CanvID.ToString();
            //Canvas.SetLeft(ElementImage, 10);
            //Children.Add(ElementImage);
            //Cursor = Cursors.Cross;

            //ElID.CanvID++;
        }

        public BridgeConnect()
        {
            ElType = ELTYPE.BRIDGE;
            XL = 4;
            XR = 189;
            Y = 66;
            ContainEl = new MyCanvas();
        }
    }

    public class BackupDeviceControlGroupsLR : MyCanvas
    {
        override public void Draw()
        {
            Uid = ':' + ElID.CanvID.ToString();
            string startupPath = Environment.CurrentDirectory;
            var circleUri = new Uri(String.Format(startupPath + @"\IMAGES\BackupDeviceControlGroupsLR.png"));
            //var circleUri = new Uri(String.Format(@"D:\IMAGES\BackupDeviceControlGroupsLR.png"));
            ElementImage.Source = new BitmapImage(circleUri);
            //ElementImage.Height = 120;
            ElementImage.Uid = ElID.CanvID.ToString();
            Canvas.SetLeft(ElementImage, 10);
            //Canvas.SetTop(ElementImage, 10);
            Children.Add(ElementImage);
            Cursor = Cursors.Cross;

            ElID.CanvID++;
        }

        public BackupDeviceControlGroupsLR()
        {
            ElType = ELTYPE.BDCGLR;
            XL = 4;
            XR = 309;
            Y = 86;
            ContainEl = new MyCanvas();
            ContainEl_1 = new MyCanvas();
        }
    }

    public class SerialConnect : MyCanvas
    {
        override public void Draw()
        {
            Uid = ':' + ElID.CanvID.ToString();
            Rectangle rec1 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Rectangle rec2 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Rectangle rec3 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };

            Line line1 = new Line()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                X1 = 10,
                X2 = 20,
                Y1 = 30.5,
                Y2 = 30.5
            };

            Line line2 = new Line()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                X1 = 60,
                X2 = 80,
                Y1 = 30.5,
                Y2 = 30.5
            };

            Line line3 = new Line()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                X1 = 120,
                X2 = 160,
                Y1 = 30.5,
                Y2 = 30.5,
                StrokeDashArray = new DoubleCollection() { 6 }
        };

            Line line4 = new Line()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                X1 = 200,
                X2 = 211,
                Y1 = 30.5,
                Y2 = 30.5
            };

            Canvas.SetLeft(rec1, 20);
            Canvas.SetTop(rec1, 20);
            Children.Add(rec1);

            Canvas.SetLeft(rec2, 80);
            Canvas.SetTop(rec2, 20);
            Children.Add(rec2);

            Canvas.SetLeft(rec3, 160);
            Canvas.SetTop(rec3, 20);
            Children.Add(rec3);

            Children.Add(line1);
            Children.Add(line2);
            Children.Add(line3);
            Children.Add(line4);

            Cursor = Cursors.Cross;
            ElementImage.Uid = ElID.CanvID.ToString();
            ElID.CanvID++;

            //Uid = ':' + ElID.CanvID.ToString();
            //string startupPath = Environment.CurrentDirectory;
            //var circleUri = new Uri(String.Format(startupPath + @"\IMAGES\SerialConnect.png"));
            ////var circleUri = new Uri(String.Format(@"D:\IMAGES\SerialConnect.png"));
            //ElementImage.Source = new BitmapImage(circleUri);
            ////ElementImage.Height = 20;
            //ElementImage.Uid = ElID.CanvID.ToString();
            //Canvas.SetLeft(ElementImage, 10);
            //Children.Add(ElementImage);
            //Cursor = Cursors.Cross;

            //ElID.CanvID++;
        }

        public SerialConnect()
        {
            ElType = ELTYPE.SERIAL;
            XL = 4;
            XR = 209;
            Y = 26;
            ContainEl = new MyCanvas();
        }
    }

    public class BackupControlType2 : MyCanvas
    {
        override public void Draw()
        {
            Uid = ':' + ElID.CanvID.ToString();
            Rectangle rec1 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Rectangle rec2 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Rectangle rec3 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Rectangle rec4 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Rectangle rec5 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Rectangle rec6 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Rectangle rec7 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Rectangle rec8 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };

            Rectangle dot1 = new Rectangle()
            {
                Width = 3,
                Height = 3,
                Stroke = Brushes.Black,
                Fill = Brushes.Black
            };

            Rectangle dot2 = new Rectangle()
            {
                Width = 3,
                Height = 3,
                Stroke = Brushes.Black,
                Fill = Brushes.Black
            };

            Rectangle dot3 = new Rectangle()
            {
                Width = 3,
                Height = 3,
                Stroke = Brushes.Black,
                Fill = Brushes.Black
            };

            RotateTransform rotate = new RotateTransform(180);

            Polygon triangle1 = new Polygon()
            {
                Fill = Brushes.Black,
                RenderTransform = rotate
            };
            triangle1.Points.Add(new Point(0, 0));
            triangle1.Points.Add(new Point(2, -8));
            triangle1.Points.Add(new Point(4, 0));

            Polygon triangle2 = new Polygon()
            {
                Fill = Brushes.Black,
                RenderTransform = rotate
            };
            triangle2.Points.Add(new Point(0, 0));
            triangle2.Points.Add(new Point(2, -8));
            triangle2.Points.Add(new Point(4, 0));

            Polygon triangle3 = new Polygon()
            {
                Fill = Brushes.Black
            };
            triangle3.Points.Add(new Point(0, 0));
            triangle3.Points.Add(new Point(2, -8));
            triangle3.Points.Add(new Point(4, 0));

            Polygon triangle4 = new Polygon()
            {
                Fill = Brushes.Black
            };
            triangle4.Points.Add(new Point(0, 0));
            triangle4.Points.Add(new Point(2, -8));
            triangle4.Points.Add(new Point(4, 0));

            rotate = new RotateTransform(90);

            Polygon triangle5 = new Polygon()
            {
                Fill = Brushes.Black,
                RenderTransform = rotate
            };
            triangle5.Points.Add(new Point(0, 0));
            triangle5.Points.Add(new Point(2, -8));
            triangle5.Points.Add(new Point(4, 0));

            rotate = new RotateTransform(-90);

            Polygon triangle6 = new Polygon()
            {
                Fill = Brushes.Black,
                RenderTransform = rotate
            };
            triangle6.Points.Add(new Point(0, 0));
            triangle6.Points.Add(new Point(2, -8));
            triangle6.Points.Add(new Point(4, 0));

            Canvas.SetTop(triangle1, 50);
            Canvas.SetLeft(triangle1, 82.5);
            Children.Add(triangle1);

            Canvas.SetTop(triangle2, 50);
            Canvas.SetLeft(triangle2, 182.5);
            Children.Add(triangle2);

            Canvas.SetTop(triangle3, 170);
            Canvas.SetLeft(triangle3, 78.5);
            Children.Add(triangle3);

            Canvas.SetTop(triangle4, 170);
            Canvas.SetLeft(triangle4, 178.5);
            Children.Add(triangle4);

            Canvas.SetTop(triangle5, 113.5);
            Canvas.SetLeft(triangle5, 152);
            Children.Add(triangle5);

            Canvas.SetTop(triangle6, 107.5);
            Canvas.SetLeft(triangle6, 108);
            Children.Add(triangle6);

            //Canvas.SetLeft(dot1, 68);
            //Canvas.SetTop(dot1, 88);
            //Children.Add(dot1);

            //Canvas.SetLeft(dot2, 78);
            //Canvas.SetTop(dot2, 88);
            //Children.Add(dot2);

            //Canvas.SetLeft(dot3, 88);
            //Canvas.SetTop(dot3, 88);
            //Children.Add(dot3);

            Line LL = new Line()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                X1 = 60,
                Y1 = 110.5,
                X2 = 29.5,
                Y2 = 110.5
            };

            Line RL = new Line()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                X1 = 230.5,
                Y1 = 110.5,
                X2 = 200,
                Y2 = 110.5
            };

            Line MM = new Line()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                X1 = 100,
                Y1 = 110.5,
                X2 = 160,
                Y2 = 110.5
            };

            Polyline LVerticalLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            LVerticalLine.Points.Add(new Point(60, 70.5));
            LVerticalLine.Points.Add(new Point(50.5, 70.5));
            LVerticalLine.Points.Add(new Point(50.5, 150.5));
            LVerticalLine.Points.Add(new Point(60, 150.5));

            Polyline RVerticalLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            RVerticalLine.Points.Add(new Point(200, 70.5));
            RVerticalLine.Points.Add(new Point(210.5, 70.5));
            RVerticalLine.Points.Add(new Point(210.5, 150.5));
            RVerticalLine.Points.Add(new Point(200, 150.5));

            Polyline MidLeftLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            MidLeftLine.Points.Add(new Point(100, 70.5));
            MidLeftLine.Points.Add(new Point(110.5, 70.5));
            MidLeftLine.Points.Add(new Point(110.5, 150.5));
            MidLeftLine.Points.Add(new Point(100, 150.5));

            Polyline MidRightLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            MidRightLine.Points.Add(new Point(160, 70.5));
            MidRightLine.Points.Add(new Point(150.5, 70.5));
            MidRightLine.Points.Add(new Point(150.5, 150.5));
            MidRightLine.Points.Add(new Point(160, 150.5));

            Polyline MidTopLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            MidTopLine.Points.Add(new Point(130.5, 40));
            MidTopLine.Points.Add(new Point(130.5, 105.5));
            MidTopLine.Points.Add(new Point(102, 105.5));

            Polyline MidBotLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            MidBotLine.Points.Add(new Point(130.5, 180));
            MidBotLine.Points.Add(new Point(130.5, 115.5));
            MidBotLine.Points.Add(new Point(158, 115.5));

            Polyline TopLeftLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            TopLeftLine.Points.Add(new Point(80.5, 52));
            TopLeftLine.Points.Add(new Point(80.5, 30.5));
            TopLeftLine.Points.Add(new Point(110, 30.5));

            Polyline TopRightLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            TopRightLine.Points.Add(new Point(180.5, 52));
            TopRightLine.Points.Add(new Point(180.5, 30.5));
            TopRightLine.Points.Add(new Point(150, 30.5));

            Polyline BotRightLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            BotRightLine.Points.Add(new Point(150, 190.5));
            BotRightLine.Points.Add(new Point(180.5, 190.5));
            BotRightLine.Points.Add(new Point(180.5, 168));

            Polyline BotLeftLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            BotLeftLine.Points.Add(new Point(110, 190.5));
            BotLeftLine.Points.Add(new Point(80.5, 190.5));
            BotLeftLine.Points.Add(new Point(80.5, 168));

            Canvas.SetLeft(rec1, 60);
            Canvas.SetTop(rec1, 60);
            Children.Add(rec1);

            Canvas.SetLeft(rec2, 60);
            Canvas.SetTop(rec2, 100);
            Children.Add(rec2);

            Canvas.SetLeft(rec3, 60);
            Canvas.SetTop(rec3, 140);
            Children.Add(rec3);

            Canvas.SetLeft(rec4, 160);
            Canvas.SetTop(rec4, 60);
            Children.Add(rec4);

            Canvas.SetLeft(rec5, 160);
            Canvas.SetTop(rec5, 100);
            Children.Add(rec5);

            Canvas.SetLeft(rec6, 160);
            Canvas.SetTop(rec6, 140);
            Children.Add(rec6);

            Canvas.SetLeft(rec7, 110);
            Canvas.SetTop(rec7, 20);
            Children.Add(rec7);

            Canvas.SetLeft(rec8, 110);
            Canvas.SetTop(rec8, 180);
            Children.Add(rec8);

            Children.Add(LVerticalLine);
            Children.Add(RVerticalLine);
            Children.Add(MidLeftLine);
            Children.Add(MidRightLine);
            Children.Add(MidTopLine);
            Children.Add(MidBotLine);
            Children.Add(TopLeftLine);
            Children.Add(TopRightLine);
            Children.Add(BotRightLine);
            Children.Add(BotLeftLine);

            Children.Add(LL);
            Children.Add(RL);
            Children.Add(MM);

            Cursor = Cursors.Cross;
            ElementImage.Uid = ElID.CanvID.ToString();
            ElID.CanvID++;


            //Uid = ':' + ElID.CanvID.ToString();BotLeftLine
            //string startupPath = Environment.CurrentDirectory;
            //var circleUri = new Uri(String.Format(startupPath + @"\IMAGES\BackupControlType2.png"));
            ////var circleUri = new Uri(String.Format(@"D:\IMAGES\BackupControlType2.png"));
            //ElementImage.Source = new BitmapImage(circleUri);
            ////ElementImage.Height = 140;
            //ElementImage.Uid = ElID.CanvID.ToString();
            //Canvas.SetLeft(ElementImage, 10);
            //Children.Add(ElementImage);
            //Cursor = Cursors.Cross;

            //ElID.CanvID++;
        }

        public BackupControlType2()
        {
            ElType = ELTYPE.BACKUP;
            XL = 24;
            XR = 229;
            Y = 106;
            ContainEl = new MyCanvas();
            ContainEl_1 = new MyCanvas();
        }
    }

    public class ReservManageReplacing : MyCanvas
    {
        override public void Draw()
        {
            Uid = ':' + ElID.CanvID.ToString();
            Rectangle rec1 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Rectangle rec2 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Rectangle rec3 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Rectangle rec4 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Rectangle rec5 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Rectangle rec6 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };
            Rectangle rec7 = new Rectangle()
            {
                Width = 40,
                Height = 20,
                Fill = Brushes.Transparent,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                Uid = ElID.CanvID.ToString()
            };

            Polyline LTopLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            LTopLine.Points.Add(new Point(10, 70.5));
            LTopLine.Points.Add(new Point(30.5, 70.5));
            LTopLine.Points.Add(new Point(30.5, 30.5));
            LTopLine.Points.Add(new Point(60, 30.5));

            Polyline LMidTopLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            LMidTopLine.Points.Add(new Point(120, 30.5));
            LMidTopLine.Points.Add(new Point(100, 30.5));

            Polyline RMidTopLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            RMidTopLine.Points.Add(new Point(190, 30.5));
            RMidTopLine.Points.Add(new Point(160, 30.5));

            Polyline MidlMidlLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            MidlMidlLine.Points.Add(new Point(120, 70.5));
            MidlMidlLine.Points.Add(new Point(100, 70.5));

            Polyline MidlBotLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            MidlBotLine.Points.Add(new Point(120, 110.5));
            MidlBotLine.Points.Add(new Point(100, 110.5));

            Polyline LMidLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            LMidLine.Points.Add(new Point(60, 70.5));
            LMidLine.Points.Add(new Point(50.5, 70.5));
            LMidLine.Points.Add(new Point(50.5, 57.5));

            Polyline RMidLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            RMidLine.Points.Add(new Point(160, 70.5));
            RMidLine.Points.Add(new Point(170.5, 70.5));
            RMidLine.Points.Add(new Point(170.5, 57.5));

            Polyline LBotLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            LBotLine.Points.Add(new Point(60, 110.5));
            LBotLine.Points.Add(new Point(50.5, 110.5));
            LBotLine.Points.Add(new Point(50.5, 97.5));

            Polyline RBotLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            RBotLine.Points.Add(new Point(160, 110.5));
            RBotLine.Points.Add(new Point(170.5, 110.5));
            RBotLine.Points.Add(new Point(170.5, 97.5));

            Polyline RTopLine = new Polyline()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            RTopLine.Points.Add(new Point(230, 30.5));
            RTopLine.Points.Add(new Point(250.5, 30.5));
            RTopLine.Points.Add(new Point(250.5, 70.5));
            RTopLine.Points.Add(new Point(271, 70.5));

            Rectangle dot1 = new Rectangle()
            {
                Width = 3,
                Height = 3,
                Stroke = Brushes.Black,
                Fill = Brushes.Black
            };

            Rectangle dot2 = new Rectangle()
            {
                Width = 3,
                Height = 3,
                Stroke = Brushes.Black,
                Fill = Brushes.Black
            };

            Rectangle dot3 = new Rectangle()
            {
                Width = 3,
                Height = 3,
                Stroke = Brushes.Black,
                Fill = Brushes.Black
            };

            Rectangle dot4 = new Rectangle()
            {
                Width = 3,
                Height = 3,
                Stroke = Brushes.Black,
                Fill = Brushes.Black
            };

            Rectangle dot5 = new Rectangle()
            {
                Width = 3,
                Height = 3,
                Stroke = Brushes.Black,
                Fill = Brushes.Black
            };

            Rectangle dot6 = new Rectangle()
            {
                Width = 3,
                Height = 3,
                Stroke = Brushes.Black,
                Fill = Brushes.Black
            };

            Line LL = new Line()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                X1 = 50.5,
                Y1 = 30,
                X2 = 50.5,
                Y2 = 40
            };

            Line RL = new Line()
            {
                Stroke = Brushes.Black,
                StrokeThickness = 1,
                X1 = 170.5,
                Y1 = 30,
                X2 = 170.5,
                Y2 = 40
            };

            Polygon triangle1 = new Polygon()
            {
                Fill = Brushes.Black
            };
            triangle1.Points.Add(new Point(0, 0));
            triangle1.Points.Add(new Point(2, -8));
            triangle1.Points.Add(new Point(4, 0));

            Polygon triangle2 = new Polygon()
            {
                Fill = Brushes.Black
            };
            triangle2.Points.Add(new Point(0, 0));
            triangle2.Points.Add(new Point(2, -8));
            triangle2.Points.Add(new Point(4, 0));

            Polygon triangle3 = new Polygon()
            {
                Fill = Brushes.Black
            };
            triangle3.Points.Add(new Point(0, 0));
            triangle3.Points.Add(new Point(2, -8));
            triangle3.Points.Add(new Point(4, 0));

            Polygon triangle4 = new Polygon()
            {
                Fill = Brushes.Black
            };
            triangle4.Points.Add(new Point(0, 0));
            triangle4.Points.Add(new Point(2, -8));
            triangle4.Points.Add(new Point(4, 0));

            Canvas.SetTop(triangle1, 60);
            Canvas.SetLeft(triangle1, 48.5);
            Children.Add(triangle1);

            Canvas.SetTop(triangle2, 60);
            Canvas.SetLeft(triangle2, 168.5);
            Children.Add(triangle2);

            Canvas.SetTop(triangle3, 100);
            Canvas.SetLeft(triangle3, 48.5);
            Children.Add(triangle3);

            Canvas.SetTop(triangle4, 100);
            Canvas.SetLeft(triangle4, 168.5);
            Children.Add(triangle4);

            Canvas.SetLeft(dot1, 68);
            Canvas.SetTop(dot1, 88);
            Children.Add(dot1);

            Canvas.SetLeft(dot2, 78);
            Canvas.SetTop(dot2, 88);
            Children.Add(dot2);

            Canvas.SetLeft(dot3, 88);
            Canvas.SetTop(dot3, 88);
            Children.Add(dot3);

            Canvas.SetLeft(dot4, 128);
            Canvas.SetTop(dot4, 88);
            Children.Add(dot4);

            Canvas.SetLeft(dot5, 138);
            Canvas.SetTop(dot5, 88);
            Children.Add(dot5);

            Canvas.SetLeft(dot6, 148);
            Canvas.SetTop(dot6, 88);
            Children.Add(dot6);

            Canvas.SetLeft(rec1, 60);
            Canvas.SetTop(rec1, 20);
            Children.Add(rec1);

            Canvas.SetLeft(rec2, 60);
            Canvas.SetTop(rec2, 60);
            Children.Add(rec2);

            Canvas.SetLeft(rec3, 60);
            Canvas.SetTop(rec3, 100);
            Children.Add(rec3);

            Canvas.SetLeft(rec4, 120);
            Canvas.SetTop(rec4, 20);
            Children.Add(rec4);

            Canvas.SetLeft(rec5, 120);
            Canvas.SetTop(rec5, 60);
            Children.Add(rec5);

            Canvas.SetLeft(rec6, 120);
            Canvas.SetTop(rec6, 100);
            Children.Add(rec6);

            Canvas.SetLeft(rec7, 190);
            Canvas.SetTop(rec7, 20);
            Children.Add(rec7);

            Children.Add(LTopLine);
            Children.Add(LMidTopLine);

            Children.Add(LMidLine);
            Children.Add(RMidLine);

            Children.Add(LBotLine);
            Children.Add(RBotLine);

            Children.Add(MidlMidlLine);
            Children.Add(MidlBotLine);

            Children.Add(RMidTopLine);
            Children.Add(RTopLine);

            Children.Add(LL);
            Children.Add(RL);

            Cursor = Cursors.Cross;
            ElementImage.Uid = ElID.CanvID.ToString();
            ElID.CanvID++;

            //Uid = ':' + ElID.CanvID.ToString();RTopLine
            //string startupPath = Environment.CurrentDirectory;
            //var circleUri = new Uri(String.Format(startupPath + @"\IMAGES\ReservManageReplacing.png"));
            ////var circleUri = new Uri(String.Format(@"D:\IMAGES\ReservManageReplacing.png"));
            //ElementImage.Source = new BitmapImage(circleUri);
            ////ElementImage.Height = 90;
            //ElementImage.Uid = ElID.CanvID.ToString();
            //Canvas.SetLeft(ElementImage, 10);
            //Children.Add(ElementImage);
            //Cursor = Cursors.Cross;

            //ElID.CanvID++;
        }

        public ReservManageReplacing()
        {
            ElType = ELTYPE.RMR;
            XL = 4;
            XR = 269;
            Y = 66;
            ContainEl = new MyCanvas();
            ContainEl_1 = new MyCanvas();
            ContainEl_2 = new MyCanvas();
        }
    }

    public class List_ : MyCanvas
    {
        override public void Draw()
        {
            Uid = ':' + ElID.CanvID.ToString();
            string startupPath = Environment.CurrentDirectory;
            var circleUri = new Uri(String.Format(startupPath + @"\IMAGES\List.png"));
            //var circleUri = new Uri(String.Format(@"D:\IMAGES\List.png"));
            ElementImage.Source = new BitmapImage(circleUri);
            //ElementImage.Height = 20;
            ElementImage.Uid = ElID.CanvID.ToString();
            Canvas.SetLeft(ElementImage, 10);
            Children.Add(ElementImage);
            Cursor = Cursors.Cross;

            ElID.CanvID++;
        }
        public List_(MyCanvas FL)
        {
            ContainEl = FL;
            ElType = ELTYPE.LIST_;
            XL = 4;
            XR = 69;
            Y = 6;
        }
    }
}
