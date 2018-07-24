using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace RichTextCellDemo
{
    public class ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            _mailDataCollection = new ObservableCollection<MailData>();
            this.GetMailData();
        }
        private ObservableCollection<MailData> _mailDataCollection;

        /// <summary>
        /// Gets or sets the mail data collection.
        /// </summary>
        /// <value>The mail data collection.</value>
        public ObservableCollection<MailData> MailDataCollection
        {
            get 
            { 
                return _mailDataCollection;
            }
            set 
            { 
                _mailDataCollection = value;
            }
        }

        /// <summary>
        /// Gets the mail data.
        /// </summary>
        private void GetMailData()
        {
            ObservableCollection<OutlookData> Outlookcontent = new ObservableCollection<OutlookData>();
            Outlookcontent.Add(new OutlookData() { Flagged = true, FromAddress = "paulin@hotmail.com", Important = true, IsRead = false, Folder = "Inbox", Categories = "Red Categorie", Received = DateTime.Now, Size = 7, Subject = "Workaround For Crash In Performance Profiling Tools for WPF" });
            Outlookcontent.Add(new OutlookData() { Flagged = false, FromAddress = "mark@yahoo.com", Important = false, IsRead = false, Folder = "Inbox", Categories = "Blue Categorie", Received = DateTime.Now.Subtract(new TimeSpan(1, 1, 1, 1)), Size = 3, Subject = "Rapidly Develop Windows Phone Apps with PowerPoint " });
            Outlookcontent.Add(new OutlookData() { Flagged = true, FromAddress = "Steven@ymail.com", Important = true, IsRead = false, Folder = "Draft", Categories = "Red Categorie", Received = DateTime.Now.Subtract(new TimeSpan(1, 1, 1, 1)), Size = 6, Subject = "Microsoft Visual Studio2010 Launch/DevConnections, Las Vegas, NV    " });
            Outlookcontent.Add(new OutlookData() { Flagged = false, FromAddress = "James@yahoo.com", Important = false, IsRead = true, Folder = "Inbox", Categories = "Green Categorie", Received = DateTime.Now.Subtract(new TimeSpan(1, 1, 1, 1)), Size = 27, Subject = "WPF 4: Custom Command and Command Parameter for TextBox using Prism 4" });
            Outlookcontent.Add(new OutlookData() { Flagged = true, FromAddress = "Smith@yahoo.com", Important = false, IsRead = true, Folder = "Sharepoint", Categories = "Blue Categorie", Received = DateTime.Now, Size = 7, Subject = "Crew Wraps Up Busy Day of Cargo Transfers, Spacewalk Preps" });
            Outlookcontent.Add(new OutlookData() { Flagged = false, FromAddress = "Johndav@gmail.com", Important = true, IsRead = true, Folder = "Sharepoint", Categories = "Red Categorie", Received = DateTime.Now, Size = 713, Subject = "Multitasking on Windows Phone–Yes, no or kinda?" });
            Outlookcontent.Add(new OutlookData() { Flagged = false, FromAddress = "david@ymail.com", Important = true, IsRead = true, Folder = "Silverlight", Categories = "Red Categorie", Received = DateTime.Now, Size = 37, Subject = "Silverlight in the Azure Cloud" });
            Outlookcontent.Add(new OutlookData() { Flagged = true, FromAddress = "Mariarb@rediff.com", Important = false, IsRead = false, Folder = "Silverlight", Categories = "Blue Categorie", Received = DateTime.Now, Size = 57, Subject = "Weekly Article Digest 07/11/2011.." });
            Outlookcontent.Add(new OutlookData() { Flagged = false, FromAddress = "Julee@yahoo.com", Important = false, IsRead = false, Folder = "Inbox", Categories = "Yellow Categorie", Received = DateTime.Now, Size = 19, Subject = "  Play Media files with the MediaPlayerLauncher in Windows Phone 7.  " });
            Outlookcontent.Add(new OutlookData() { Flagged = false, FromAddress = "james@hotmail.com", Important = true, IsRead = false, Folder = "DeletedItems", Categories = "Green Categorie", Received = DateTime.Now, Size = 45, Subject = "WCF RIA Services: Strategies for Handling Your Domain Context" });
            Outlookcontent.Add(new OutlookData() { Flagged = true, FromAddress = "david1971@rediff.com", Important = true, IsRead = false, Folder = "DeletedItems", Categories = "Orange Categorie", Received = DateTime.Now, Size = 87, Subject = "Creating a 2 Node SQL Server 2008 Virtual Cluster Part 2 (SQLServerCentral 7/12/2011)" });
            Outlookcontent.Add(new OutlookData() { Flagged = false, FromAddress = "kelvin@yahoo.com", Important = true, IsRead = false, Folder = "SentItems", Categories = "Yellow Categorie", Received = DateTime.Now, Size = 19, Subject = "Building a detailed About page for your Windows Phone application" });
            Outlookcontent.Add(new OutlookData() { Flagged = true, FromAddress = "mary@rediff.com", Important = true, IsRead = false, Folder = "Inbox", Categories = "Red Categorie", Received = DateTime.Now, Size = 17, Subject = "Creating a horizontally scrolling list in Windows Phone 7" });
            Outlookcontent.Add(new OutlookData() { Flagged = true, FromAddress = "thomas@gmail.com", Important = true, IsRead = false, Folder = "Inbox", Categories = "Green Categorie", Received = DateTime.Now, Size = 71, Subject = "Rapidly Develop Windows Phone Apps with PowerPoint" });
            Outlookcontent.Add(new OutlookData() { Flagged = true, FromAddress = "paulin@hotmail.com", Important = true, IsRead = false, Folder = "Inbox", Categories = "Red Categorie", Received = DateTime.Now, Size = 55, Subject = "Play Media files with the MediaPlayerLauncher in Windows Phone 7. " });
            Outlookcontent.Add(new OutlookData() { Flagged = false, FromAddress = "mark@yahoo.com", Important = false, IsRead = true, Folder = "Inbox", Categories = "Blue Categorie", Received = DateTime.Now.Subtract(new TimeSpan(1, 1, 1, 1)), Size = 11, Subject = "Silverlight 4.0: Duplex Communication over Http using PollingDuplexHttpBinding" });
            Outlookcontent.Add(new OutlookData() { Flagged = true, FromAddress = "Steven@ymail.com", Important = true, IsRead = false, Folder = "Draft", Categories = "Green Categorie", Received = DateTime.Now.Subtract(new TimeSpan(1, 1, 1, 1)), Size = 32, Subject = "Windows Phone 7 (Mango) Tutorial - 21 - Small Demo of Accelerometer Application " });
            Outlookcontent.Add(new OutlookData() { Flagged = false, FromAddress = "James@yahoo.com", Important = false, IsRead = true, Folder = "Inbox", Categories = "Yellow Categorie", Received = DateTime.Now.Subtract(new TimeSpan(1, 1, 1, 1)), Size = 38, Subject = "Microsoft Visual Studio2010 Launch/DevConnections, Las Vegas, NV    " });
            Outlookcontent.Add(new OutlookData() { Flagged = true, FromAddress = "Smith@yahoo.com", Important = false, IsRead = true, Folder = "Sharepoint", Categories = "Blue Categorie", Received = DateTime.Now, Size = 5, Subject = "Workaround For Crash In Performance Profiling Tools for WPF" });
            Outlookcontent.Add(new OutlookData() { Flagged = false, FromAddress = "Johndav@gmail.com", Important = true, IsRead = true, Folder = "Sharepoint", Categories = "Red Categorie", Received = DateTime.Now, Size = 12, Subject = "Nokia's first Windows Phone: images and video, codenamed 'Sea Ray'" });
            Outlookcontent.Add(new OutlookData() { Flagged = false, FromAddress = "david@ymail.com", Important = true, IsRead = true, Folder = "Silverlight", Categories = "Red Categorie", Received = DateTime.Now, Size = 7, Subject = "Play Media files with the MediaPlayerLauncher in Windows Phone 7." });

            foreach (OutlookData outlookData in Outlookcontent)
            {
                MailData maildata = new MailData();
                OutlookData data = outlookData;
                if (data.Important)
                {
                    BitmapImage bi = new BitmapImage(new Uri(@"..\..\Images\Important.png", UriKind.Relative));
                    Image image = new Image();
                    image.Source = bi;
                    InlineUIContainer container = new InlineUIContainer(image);
                    Paragraph paragraph = new Paragraph();
                    paragraph.Inlines.Add(new LineBreak());
                    paragraph.Inlines.Add(container);
                    FlowDocument flowdoc = new FlowDocument(paragraph);
                    maildata.Important = flowdoc;
                }
                else
                {
                    maildata.Important = new FlowDocument();
                }
                Image image2 = new Image();
                if (data.IsRead)
                {
                    image2.Source = new BitmapImage(new Uri(@"..\..\Images\ReadMail.png", UriKind.Relative));
                }
                else
                {
                    image2.Source = new BitmapImage(new Uri(@"..\..\Images\UnreadMail.png", UriKind.Relative));
                }

                InlineUIContainer container2 = new InlineUIContainer(image2);
                Paragraph paragraph2 = new Paragraph();
                paragraph2.Inlines.Add(new LineBreak());
                paragraph2.Inlines.Add(container2);
                var flowdoc2 = new FlowDocument(paragraph2);
                maildata.IsRead = flowdoc2;

                FlowDocument fd = new FlowDocument();
                //Name                
                Paragraph ph = new Paragraph();
                Run email1 = new Run(data.FromAddress.ToString());
                if (!data.IsRead)
                    email1.FontWeight = FontWeights.Bold;
                if (data.Flagged)
                    email1.Foreground = new SolidColorBrush(Colors.Red);
                ph.Inlines.Add(email1);
                ph.Inlines.Add(new LineBreak());
                Run run2 = new Run(data.Subject);
                run2.FontWeight = FontWeights.Light;
                run2.FontStyle = FontStyles.Italic;
                ph.Inlines.Add(run2);
                ph.Inlines.Add(new LineBreak());
                Run run3 = new Run((data).Received.Date.ToString());
                run3.Foreground = new SolidColorBrush(Colors.Green);
                ph.Inlines.Add(run3);
                fd.Blocks.Add(ph);
                maildata.Subject = fd;
                maildata.Size = data.Size.ToString() + " KB";
                maildata.Folder = data.Folder;
                Image image3 = new Image();
                if (data.Flagged)
                {
                    image3.Source = new BitmapImage(new Uri(@"..\..\Images\Flagged.png", UriKind.Relative));
                }
                else
                {
                    image3.Source = new BitmapImage(new Uri(@"..\..\Images\UnFlagged.png", UriKind.Relative));
                }

                InlineUIContainer container3 = new InlineUIContainer(image3);
                Paragraph paragraph3 = new Paragraph();
                paragraph3.Inlines.Add(new LineBreak());
                paragraph3.Inlines.Add(container3);
                FlowDocument flowdoc3 = new FlowDocument(paragraph3);
                maildata.Flagged = flowdoc3;

                FlowDocument categorie = new FlowDocument();
                Paragraph paragraph4 = new Paragraph();
                Run run4 = new Run(data.Categories);
                paragraph4.Inlines.Add(run4);
                categorie.Blocks.Add(paragraph4);
                maildata.Categories = categorie;
                _mailDataCollection.Add(maildata);
            }
        }
    }
}
