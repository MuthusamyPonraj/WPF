using System.Windows;
using System.Windows.Media;
using Syncfusion.DICOM;
using Microsoft.Win32;
using System;


namespace EssentialDICOMConverterSamples
{
    /// <summary>
    /// Interaction logic for  DICOMConverter.xaml
    /// </summary>
    public partial class DICOMConverter : Window
    {
        #region Constants
        private const string DEFAULTIMAGEPATH = @"..\..\..\..\..\..\..\..\..\..\..\Common\Images\XlsIO\{0}";
        #endregion

        # region Constructor
        /// <summary>
        /// Window Constructor
        /// </summary>
        public DICOMConverter()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
            string headerImage = GetFullImagePath("dcm_banner.png");
            this.image1.Source = (ImageSource)img.ConvertFromString(headerImage);
            this.textBox1.Text = "ImageToDicom.jpg";
            this.textBox1.Tag = @"..\..\..\..\..\..\..\..\..\..\..\Common\Data\XlsIO\ImageToDicom.jpg";
        }
        # endregion

        # region Events
        /// <summary>
        ///  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (this.textBox1.Text != String.Empty)
            {
                //Initailize the DICOM Image object.
                DICOMImage dcmImage = new DICOMImage((string)this.textBox1.Tag);
                //Save the dicom image.
                dcmImage.Save("Sample.dcm");
                //Dispose the object.
                dcmImage.Dispose();
                if (MessageBox.Show("Do you want to view the DCM file?", "File has been created", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)                    
                {
                    try
                    {
                        System.Diagnostics.Process.Start(@"Sample.dcm");
                        //Exit
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Browse an image document and click the button to convert as a DICOM.");
            }
        }
        # endregion

        #region HelperMethods
      
        /// <summary>
        /// Get the input image and return the path of the same
        /// </summary>
        /// <param name="imageFile">input image</param>
        /// <returns>path of the image</returns>
        private string GetFullImagePath(string imageFile)
        {
            return string.Format(DEFAULTIMAGEPATH, imageFile);
        }
        #endregion

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Jpeg Images(*.jpg)|*.jpg|Bmp Images(*.bmp)|*.bmp|Png Image(*.png)|*.png|Gif Images(*.gif)|*.gif| Tiff Images (*.tiff)|*.tiff|Emf Images (*.emf)|*.emf";           
            ofd.FileName = "";
            if (ofd.ShowDialog().Value)
            {
                this.textBox1.Text = ofd.SafeFileName;
                this.textBox1.Tag = ofd.FileName;
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://download.synedra.com/dodownload.php");
        }
    }
}