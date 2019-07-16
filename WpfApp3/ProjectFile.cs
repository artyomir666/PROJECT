using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Controls;

namespace WpfApp3
{
    class ProjectFile
    {
        public static void loadElement(XmlNode node, MyCanvas Element)
        {
            MyCanvas Curent = null;
            foreach (XmlNode xnode in node)
            {
                // получаем атрибут name
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("ELTYPE");
                    if (attr.Value == "EMPTY")
                        Curent = new MyCanvas();
                    else if (attr.Value == "PLAIN")
                        Curent = new Plain();
                    else if (attr.Value == "LOADED")
                    {
                        Curent = new Loaded();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "UNLOADED")
                    {
                        Curent = new Unloaded();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "SLIDINGLOAD")
                    {
                        Curent = new SlidingLoaded();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "SLIDINGUNLOAD")
                    {
                        Curent = new SlidingUnLoaded();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "MAJOR")
                    {
                        Curent = new MajorConnect();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "BRIDGE")
                    {
                        Curent = new BridgeConnect();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "BDCGLR")
                    {
                        Curent = new BackupDeviceControlGroupsLR();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "SERIAL")
                    {
                        Curent = new SerialConnect();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "BACKUP")
                    {
                        Curent = new BackupControlType2();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "RMR")
                    {
                        Curent = new ReservManageReplacing();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "LIST_")
                    {
                        Curent = new List_(null);
                        loadList(xnode, Curent);
                    }
                    Curent.Draw();
                    Canvas.SetLeft(Curent, Convert.ToDouble(xnode.Attributes.GetNamedItem("X").Value));
                    Canvas.SetTop(Curent, Convert.ToDouble(xnode.Attributes.GetNamedItem("Y").Value));
                    Curent.lambda = Convert.ToDouble(xnode.Attributes.GetNamedItem("LAMBDA").Value);
                    Curent.lambda_1 = Convert.ToDouble(xnode.Attributes.GetNamedItem("LAMBDA_1").Value);
                    Curent.ItemsAmount = Convert.ToInt32(xnode.Attributes.GetNamedItem("ITEMS").Value);
                    Curent.ItemsAmount_1 = Convert.ToInt32(xnode.Attributes.GetNamedItem("ITEMS_1").Value);
                }
                if (Element.cont == 0)
                {
                    Element.ContainEl = Curent;
                    Element.cont++;
                }
                else if (Element.cont == 1)
                {
                    Element.ContainEl_1 = Curent;
                    Element.cont++;
                }
                else if (Element.cont == 2)
                {
                    Element.ContainEl_2 = Curent;
                    Element.cont++;
                }
                Curent = Curent.NEXT;
            }
        }

        public static void loadList(XmlNode node, MyCanvas Element)
        {
            MyCanvas Curent = null;
            MyCanvas PREVIOUS = null; foreach (XmlNode xnode in node)
            {
                // получаем атрибут name
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("ELTYPE");
                    if (attr.Value == "EMPTY")
                        Curent = new MyCanvas();
                    else if (attr.Value == "PLAIN")
                        Curent = new Plain();
                    else if (attr.Value == "LOADED")
                    {
                        Curent = new Loaded();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "UNLOADED")
                    {
                        Curent = new Unloaded();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "SLIDINGLOAD")
                    {
                        Curent = new SlidingLoaded();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "SLIDINGUNLOAD")
                    {
                        Curent = new SlidingUnLoaded();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "MAJOR")
                    {
                        Curent = new MajorConnect();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "BRIDGE")
                    {
                        Curent = new BridgeConnect();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "BDCGLR")
                    {
                        Curent = new BackupDeviceControlGroupsLR();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "SERIAL")
                    {
                        Curent = new SerialConnect();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "BACKUP")
                    {
                        Curent = new BackupControlType2();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "RMR")
                    {
                        Curent = new ReservManageReplacing();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "LIST_")
                    {
                        Curent = new List_(null);
                        loadList(xnode, Curent);
                    }
                    Curent.Draw();
                    Canvas.SetLeft(Curent, Convert.ToDouble(xnode.Attributes.GetNamedItem("X").Value));
                    Canvas.SetTop(Curent, Convert.ToDouble(xnode.Attributes.GetNamedItem("Y").Value));
                    Curent.lambda = Convert.ToDouble(xnode.Attributes.GetNamedItem("LAMBDA").Value);
                    Curent.lambda_1 = Convert.ToDouble(xnode.Attributes.GetNamedItem("LAMBDA_1").Value);
                    Curent.ItemsAmount = Convert.ToInt32(xnode.Attributes.GetNamedItem("ITEMS").Value);
                    Curent.ItemsAmount_1 = Convert.ToInt32(xnode.Attributes.GetNamedItem("ITEMS_1").Value);
                }
                if (Element.ContainEl == null)
                    Element.ContainEl = Curent;
                Curent.PREVIOUS = PREVIOUS;
                if (PREVIOUS != null)
                    PREVIOUS.NEXT = Curent;
                PREVIOUS = Curent;
                Curent = Curent.NEXT;
            }
        }

        public static MyCanvas LoadProject(string filename, TextBox a, TextBox b, TextBox c)
        {
            MyCanvas FirstElement = null;
            MyCanvas Curent = null;
            MyCanvas PREVIOUS = null;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filename);
            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;
            // обход всех узлов в корневом элементе
            if (xRoot.Attributes.Count > 0)
            {
                a.Text = xRoot.Attributes.GetNamedItem("EXP").Value;
                b.Text = xRoot.Attributes.GetNamedItem("TIME").Value;
                c.Text = xRoot.Attributes.GetNamedItem("KOEF").Value;
            }
            foreach (XmlNode xnode in xRoot)
            {
                // получаем атрибут name
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("ELTYPE");
                    if (attr.Value == "EMPTY")
                        Curent = new MyCanvas();
                    else if (attr.Value == "PLAIN")
                        Curent = new Plain();
                    else if (attr.Value == "LOADED")
                    {
                        Curent = new Loaded();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "UNLOADED")
                    {
                        Curent = new Unloaded();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "SLIDINGLOAD")
                    {
                        Curent = new SlidingLoaded();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "SLIDINGUNLOAD")
                    {
                        Curent = new SlidingUnLoaded();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "MAJOR")
                    {
                        Curent = new MajorConnect();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "BRIDGE")
                    {
                        Curent = new BridgeConnect();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "BDCGLR")
                    {
                        Curent = new BackupDeviceControlGroupsLR();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "SERIAL")
                    {
                        Curent = new SerialConnect();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "BACKUP")
                    {
                        Curent = new BackupControlType2();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "RMR")
                    {
                        Curent = new ReservManageReplacing();
                        loadElement(xnode, Curent);
                    }
                    else if (attr.Value == "LIST_")
                    {
                        Curent = new List_(null);
                        loadList(xnode, Curent);
                    }
                    Curent.Draw();
                    Canvas.SetLeft(Curent, Convert.ToDouble(xnode.Attributes.GetNamedItem("X").Value));
                    Canvas.SetTop(Curent, Convert.ToDouble(xnode.Attributes.GetNamedItem("Y").Value));
                    Curent.lambda = Convert.ToDouble(xnode.Attributes.GetNamedItem("LAMBDA").Value);
                    Curent.lambda_1 = Convert.ToDouble(xnode.Attributes.GetNamedItem("LAMBDA_1").Value);
                    Curent.ItemsAmount = Convert.ToInt32(xnode.Attributes.GetNamedItem("ITEMS").Value);
                    Curent.ItemsAmount_1 = Convert.ToInt32(xnode.Attributes.GetNamedItem("ITEMS_1").Value);
                }
                if (FirstElement == null)
                    FirstElement = Curent;
                Curent.PREVIOUS = PREVIOUS;
                if (PREVIOUS != null)
                    PREVIOUS.NEXT = Curent;
                PREVIOUS = Curent;
                Curent = Curent.NEXT;
            }        
            return FirstElement;
        }

        public static void saveElement(XmlDocument doc, XmlNode node, MyCanvas Element)
        {
            if (Element == null)
                return;
            XmlNode elementNode = doc.CreateElement("ELEMENT");

            XmlAttribute elementType = doc.CreateAttribute("ELTYPE");
            elementType.Value = Element.ElType.ToString();
            elementNode.Attributes.Append(elementType);

            XmlAttribute elementX = doc.CreateAttribute("X");
            elementX.Value = Canvas.GetLeft(Element).ToString();
            elementNode.Attributes.Append(elementX);

            XmlAttribute elementY = doc.CreateAttribute("Y");
            elementY.Value = Canvas.GetTop(Element).ToString();
            elementNode.Attributes.Append(elementY);

            XmlAttribute lambda = doc.CreateAttribute("LAMBDA");
            lambda.Value = Element.lambda.ToString();
            elementNode.Attributes.Append(lambda);
            node.AppendChild(elementNode);

            XmlAttribute lambda_1 = doc.CreateAttribute("LAMBDA_1");
            lambda_1.Value = Element.lambda_1.ToString();
            elementNode.Attributes.Append(lambda_1);
            node.AppendChild(elementNode);

            XmlAttribute items = doc.CreateAttribute("ITEMS");
            items.Value = Element.ItemsAmount.ToString();
            elementNode.Attributes.Append(items);
            node.AppendChild(elementNode);

            XmlAttribute items_1 = doc.CreateAttribute("ITEMS_1");
            items_1.Value = Element.ItemsAmount_1.ToString();
            elementNode.Attributes.Append(items_1);
            node.AppendChild(elementNode);

            if (Element.ContainEl != null)
                saveElement(doc, elementNode, Element.ContainEl);
            if (Element.ContainEl_1 != null)
                saveElement(doc, elementNode, Element.ContainEl_1);
            if (Element.ContainEl_2 != null)
                saveElement(doc, elementNode, Element.ContainEl_2);

            saveElement(doc, node, Element.NEXT);
        }

        public static void SaveProject(MyCanvas Element, string filename, string a, string b, string c)
        {
            
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode scheme = doc.CreateElement("SCHEME");

            XmlAttribute exp = doc.CreateAttribute("EXP");
            exp.Value = a;
            scheme.Attributes.Append(exp);

            XmlAttribute t = doc.CreateAttribute("TIME");
            t.Value = b;
            scheme.Attributes.Append(t);

            XmlAttribute k = doc.CreateAttribute("KOEF");
            k.Value = c;
            scheme.Attributes.Append(k);

            doc.AppendChild(scheme);

            saveElement(doc, scheme, Element);

            doc.Save(filename);
        }
    }
}
