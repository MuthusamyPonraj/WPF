using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Diagram;
using Syncfusion.Windows.Shared;
using System.IO;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;

namespace DiagramExportDemo_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    /// 
    public partial class Window1 : Window
    {

        #region Public Variables

        //Declaring the public variables
        string selection;
        CheckBox checkbox;
        string selecteditemname;
        Rect savearea;
        #endregion

        #region Contructor

        public Window1()
        {
            InitializeComponent();
            //Creating the Nodes
            createNodes();
        }
        #endregion

        #region HelperMethods

        //Defining the nodes.
        private void createNodes()
        {
            // Add Nodes
            Node node1 = addNode("HealthFitness", 275, 250, "HealthFitness", "Health Fitness", 0);
            Node node2 = addNode("Diet", 275, 100, "Diet", "Diet", 1);
            Node node3 = addNode("Flexibility", 475, 200, "Flexibility", "Flexibility", 3);
            Node node4 = addNode("MuscularEndurance", 490, 385, "MuscularEndurance", "Muscular Endurance", 5);
            Node node5= addNode("MuscularStrength", 150, 370, "Muscularstrength", "Muscular strength", 2);
            Node node6= addNode("CardiovascularStrength", 70, 220, "CardiovascularStrength", "Cardiovascular Strength", 4);
   
            Connect(node1, node2);
            Connect(node1, node3);
            Connect(node1, node4);
            Connect(node1,node5);
            Connect(node1, node6);
        }

      
        //Creating connection and adding to the model
        void Connect(Node HeadNode, Node TailNode)
        {
            LineConnector connection = new LineConnector();
            connection.ConnectorType = ConnectorType.Straight;
            // Specify the TailNode node
            connection.TailNode = TailNode;
            //Specifying the Head Node
            connection.HeadNode = HeadNode;
            connection.TailDecoratorShape = DecoratorShape.Arrow;

            //Adding to the Diagram Model
            diagramModel.Connections.Add(connection);
        }
        #endregion

        #region Event Handlers

        //Prints the page.
        private void Print_Click(object sender, RoutedEventArgs e)
        {
            diagramView.Print();
        }

        //Saves the page into the specified format.
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            diagramControl.Save();
        }

        //Save the Diagram With different formats
        private void Clip_Click(object sender, RoutedEventArgs e)
        {
            Button but = (sender as Button);
            string name = but.Name;
            switch (name)
            {
                case "CopyToClipcommand":
                    diagramView.CopyToClipboard();
                    break;
            }
            switch (selection)
            {
                case "Memory":
                    MemoryStream ms = new MemoryStream();
                    diagramView.Save(ms);
                    break;
                case "File":
                    string filename = SaveFile("JPEG File(*.jpg)|*.jpg");
                    if (!(string.IsNullOrEmpty(filename)))
                    {
                        System.IO.FileStream filestream = new System.IO.FileStream(filename, System.IO.FileMode.Create);
                        System.IO.StreamReader reader = new System.IO.StreamReader(filestream);
                        string content = reader.ReadToEnd();
                        reader.Close();
                        filestream = new System.IO.FileStream(filename, System.IO.FileMode.Open);
                        System.IO.StreamWriter writer = new System.IO.StreamWriter(filestream);
                        writer.WriteLine(content);
                        writer.Close();
                        diagramView.Save(filestream);
                    }
                    break;
            }


        }

        //For Display the Dialog gor exporting
        private string SaveFile(string filter)
        {
            string name=string.Empty;
            System.Windows.Forms.SaveFileDialog m_SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            m_SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            m_SaveFileDialog.Filter = filter;
            m_SaveFileDialog.FileName = "Diagram";
            m_SaveFileDialog.ShowDialog();
            if (m_SaveFileDialog.FileName != string.Empty)
            {
                 name = m_SaveFileDialog.FileName;
            }
            return name;
        }

        //Saving using the Memory
        private void Memory_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radio = (sender as RadioButton);
            selection = radio.Name;
        }

        ///Savieng using the Memory in Image format
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (selection)
            {
                case "Memory":
                    MemoryStream ms = new MemoryStream();
                    ms.Position = 0;
                    diagramControl.Load(ms);
                    break;
                case "File":
                    string filename = LoadFile("JPEG File(*.jpg)|*.jpg");
                    if (!(string.IsNullOrEmpty(filename)))
                    {

                        FileStream fs = new FileStream(filename, FileMode.Create);
                        diagramControl.Load(fs);
                    }

                    break;
            }
        }

        //Load the Diagram from the Xaml file
        private string LoadFile(string filter)
        {
            System.Windows.Forms.OpenFileDialog m_OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            m_OpenFileDialog.Filter = filter;
            System.Windows.Forms.DialogResult result = m_OpenFileDialog.ShowDialog();
            string s = string.Empty;
            if (result == System.Windows.Forms.DialogResult.OK || result == System.Windows.Forms.DialogResult.Yes)
            {
                if (m_OpenFileDialog.FileName != "" && m_OpenFileDialog.Filter == "JPEG File(*.jpg)|*.jpg")
                {
                    s = m_OpenFileDialog.FileName;
                }
            }
            return s;
        }

        //Update the Imagefromat according the fromat selected
        private void JPEG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            selecteditemname = (sender as Syncfusion.Windows.Tools.Controls.ComboBoxItemAdv).Name;

            UpadteImageformat();
        }

        //Update the Imagefromat according the fromat selected
        private void UpadteImageformat()
        {
            if (selecteditemname == "JPEG")
            {
                if (checkbox != null)
                {
                    if (checkbox.IsChecked == true)
                    {
                        format.SelectedIndex = 0;
                        format.SelectedItem = "JPEG Format";
                        string name = SaveFile("JPEG File(*.jpg)|*.jpg");
                        if (name != string.Empty)
                        {
                            diagramView.Save(name, savearea);
                        }
                    }

                }
                else
                {
                    format.SelectedIndex = 0;
                    string name = SaveFile("JPEG File(*.jpg)|*.jpg");
                    if (name != string.Empty)
                    {
                        diagramView.Save(name);
                    }
                    
                }
            }
            else if (selecteditemname == "PNG")
            {
                if (checkbox != null)
                {
                    if (checkbox.IsChecked == true && checkbox != null)
                    {
                        format.SelectedIndex = 1;
                        string name = SaveFile("PNG File(*.png)|*.png");
                        if (name != string.Empty)
                        {
                            diagramView.Save(name, savearea);
                        }
                    }
                }
                else
                {
                    format.SelectedIndex = 1;
                    string name = SaveFile("PNG File(*.png)|*.png");
                    if (name != string.Empty)
                    {
                        diagramView.Save(name);
                    }
                }
            }
            else if (selecteditemname == "Bitmap")
            {
                if (checkbox != null)
                {
                    if (checkbox.IsChecked == true && checkbox != null)
                    {
                        format.SelectedIndex = 2;
                        string name = SaveFile("BMP File(*.bmp)|*.bmp");
                        if (name != string.Empty)
                        {
                            diagramView.Save(name, savearea);
                        }
                    }
                }
                else
                {
                    format.SelectedIndex = 2;
                    string name = SaveFile("BMP File(*.bmp)|*.bmp");
                    if (name != string.Empty)
                    {
                        diagramView.Save(name);
                    }
                    
                }
            }
            else if (selecteditemname == "XPS")
            {
                if (checkbox != null)
                {
                    if (checkbox.IsChecked == true && checkbox != null)
                    {
                        format.SelectedIndex = 3;
                        string name = SaveFile("XPS File(*.xps)|*.xps");
                        if (name != string.Empty)
                        {
                            diagramView.Save(name, savearea);
                        }
                    }
                }
                else
                {
                    format.SelectedIndex = 3;
                    string name = SaveFile("XPS File(*.xps)|*.xps");
                    if (name != string.Empty)
                    {
                        diagramView.Save(name);
                    }
                    
                 
                }
            }
            else if (selecteditemname == "Tiff")
            {
                if (checkbox != null)
                {
                    if (checkbox.IsChecked == true && checkbox != null)
                    {
                        format.SelectedIndex = 4;
                        string name = SaveFile("TIF File(*.tif)|*.tif");
                        if (name != string.Empty)
                        {
                            diagramView.Save(name, savearea);
                        }
                    }
                }
                else
                {
                    format.SelectedIndex = 4;
                    string name = SaveFile("TIF File(*.tif)|*.tif");
                    if (name != string.Empty)
                    {
                        diagramView.Save(name);
                    }
                }
            }
            else if (selecteditemname == "Gif" )
            {
                if (checkbox != null)
                {
                    if (checkbox.IsChecked == true && checkbox != null)
                    {
                        format.SelectedIndex = 5;
                        string name = SaveFile("GIF File(*.gif)|*.gif");
                        if (name != string.Empty)
                        {
                            diagramView.Save(name, savearea);
                        }
                    }
                }
                else
                {
                    format.SelectedIndex = 5;
                    string name = SaveFile("GIF File(*.gif)|*.gif");
                    if (name != string.Empty)
                    {
                        diagramView.Save(name);
                    }
                   
                }
            }
            else if (selecteditemname == "WDP" )
            {
                if (checkbox != null)
                {
                    if (checkbox.IsChecked == true && checkbox != null)
                    {
                        format.SelectedIndex = 6;
                        string name = SaveFile("WDP File(*.wdp)|*.wdp");
                        if (name != string.Empty)
                        {
                            diagramView.Save(name, savearea);
                        }
                    }
                }
                else
                {
                    format.SelectedIndex = 6;
                    string name = SaveFile("WDP File(*.wdp)|*.wdp");
                    if (name != string.Empty)
                    {
                        diagramView.Save(name);
                    }
                   
                }
            }
        }

        //save the Diagram with Specified Area.
        private void left_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox box = (sender as TextBox);

            try
            {
                   
                    if (double.Parse(box.Text) > 400)
                    {
                        MessageBox.Show("Please enter the value 0 to 400");
                        box.Text = "0";
                    }
                    if (box.Name == "left")
                    {
                        savearea.X = double.Parse(box.Text);
                    }
                    else if (box.Name == "right")
                    {
                        savearea.Width = double.Parse(box.Text);
                    }
                    else if (box.Name == "top")
                    {
                        savearea.Y = double.Parse(box.Text);
                    }
                    else if (box.Name == "bottom")
                    {
                        savearea.Height = double.Parse(box.Text);
                    }
               
            }
            catch
            {

            }
        }

        //Enable save with Sepcifed area
        private void check_Checked(object sender, RoutedEventArgs e)
        {
            checkbox = (sender as CheckBox);

            if (checkbox.Name == "check1")
            {
                if (check != null)
                {
                    check.IsChecked = false;
                    savegridarea.IsEnabled = false;
                }
            }
            if (checkbox.Name == "check")
            {
                if (check != null)
                {
                    savegridarea.IsEnabled = true;
                }
            }

        }

        //Enable save with Sepcifed area
        private void check_Unchecked(object sender, RoutedEventArgs e)
        {
            checkbox = (sender as CheckBox);
            savegridarea.IsEnabled = false;

        }
        #endregion

        #region Properties Setting functions

        //add the Node to DiagramModel
        private Node addNode(String name, double offsetx, double offsety, String tooltip, String content, Int32 level)
        {
            Node node = new Node(Guid.NewGuid(), name);
            node.Height = 50;
            node.Width = 130;
            node.LabelWidth = 75;
            node.LabelTextWrapping = TextWrapping.Wrap;
            node.OffsetX = offsetx;
            node.OffsetY = offsety;
            node.ToolTip = tooltip;
            node.Label = content;
            node.Level = level;
            diagramModel.Nodes.Add(node);
            return node;
        }

        #endregion

        //private void PDF_PreviewMouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        //{
        //    Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
        //    saveFileDialog.Filter = "PDF File|*.pdf";
        //    saveFileDialog.Title = "Save to a PDF file";
        //    saveFileDialog.ShowDialog();
        //    if (!string.IsNullOrEmpty(saveFileDialog.FileName))
        //    {
        //        float docWidth = (float)diagramView.Page.ActualWidth;
        //        float docHeight = (float)diagramView.Page.ActualHeight;
        //        string jpgFileName = "tempjpg.jpg";
        //        string xpsFileName = "tempXpS.xps";
        //        Syncfusion.XPS.XPSToPdfConverter xpsTopdfConverter = new Syncfusion.XPS.XPSToPdfConverter();
        //        Syncfusion.Pdf.Graphics.PdfUnitConvertor converter = new Syncfusion.Pdf.Graphics.PdfUnitConvertor();
        //        float pdfHeight = converter.ConvertUnits(docHeight, Syncfusion.Pdf.Graphics.PdfGraphicsUnit.Inch, Syncfusion.Pdf.Graphics.PdfGraphicsUnit.Point);
        //        float pdfWidth = converter.ConvertUnits(docWidth, Syncfusion.Pdf.Graphics.PdfGraphicsUnit.Inch, Syncfusion.Pdf.Graphics.PdfGraphicsUnit.Point);
        //        System.Drawing.SizeF pageSize = new System.Drawing.SizeF(pdfWidth, pdfHeight);
        //        diagramView.Save(jpgFileName, new Size(docWidth * 1.5, docHeight * 1.5), ImageStretch.Expand);
        //        Syncfusion.Pdf.PdfDocument pdfDocument = new Syncfusion.Pdf.PdfDocument();
        //        pdfDocument.PageSettings.Orientation = PdfPageOrientation.Landscape;
        //        pdfDocument.PageSettings.Margins.All = 0;
        //        PdfImage image = new PdfBitmap(jpgFileName);
        //        pdfDocument.PageSettings.Size = image.PhysicalDimension;
        //        Syncfusion.Pdf.PdfPage page = pdfDocument.Pages.Add();
        //        page.Graphics.DrawImage(image, 0, 0);
        //        pdfDocument.Save(saveFileDialog.FileName);
        //        pdfDocument.Close(true);
        //        UpadteImageformat();
        //    }
        //}

        private void ExportToPDF_Click_1(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "PDF File|*.pdf";
            saveFileDialog.Title = "Save to a PDF file";
            saveFileDialog.FileName = "Diagram";
            saveFileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(saveFileDialog.FileName))
            {
                float docWidth = (float)diagramView.Page.ActualWidth;
                float docHeight = (float)diagramView.Page.ActualHeight;
                string jpgFileName = "tempjpg.jpg";
                string xpsFileName = "tempXpS.xps";
                Syncfusion.XPS.XPSToPdfConverter xpsTopdfConverter = new Syncfusion.XPS.XPSToPdfConverter();
                Syncfusion.Pdf.Graphics.PdfUnitConvertor converter = new Syncfusion.Pdf.Graphics.PdfUnitConvertor();
                float pdfHeight = converter.ConvertUnits(docHeight, Syncfusion.Pdf.Graphics.PdfGraphicsUnit.Inch, Syncfusion.Pdf.Graphics.PdfGraphicsUnit.Point);
                float pdfWidth = converter.ConvertUnits(docWidth, Syncfusion.Pdf.Graphics.PdfGraphicsUnit.Inch, Syncfusion.Pdf.Graphics.PdfGraphicsUnit.Point);
                System.Drawing.SizeF pageSize = new System.Drawing.SizeF(pdfWidth, pdfHeight);
                diagramView.Save(jpgFileName, new Size(docWidth * 1.5, docHeight * 1.5), ImageStretch.Expand);
                Syncfusion.Pdf.PdfDocument pdfDocument = new Syncfusion.Pdf.PdfDocument();
                pdfDocument.PageSettings.Orientation = PdfPageOrientation.Landscape;
                pdfDocument.PageSettings.Margins.All = 0;
                PdfImage image = new PdfBitmap(jpgFileName);
                pdfDocument.PageSettings.Size = image.PhysicalDimension;
                Syncfusion.Pdf.PdfPage page = pdfDocument.Pages.Add();
                page.Graphics.DrawImage(image, 0, 0);
                pdfDocument.Save(saveFileDialog.FileName);
                pdfDocument.Close(true);
                //UpadteImageformat();
            }
        }
    }
}
