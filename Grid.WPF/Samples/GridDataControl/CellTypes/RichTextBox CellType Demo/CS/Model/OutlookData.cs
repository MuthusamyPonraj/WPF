using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;

namespace RichTextCellDemo
{
    public class OutlookData : NotificationObject
    {

        #region Private Members

        private bool _Important;
        private bool _IsRead;
        private string _FromAddress;
        private string _Subject;
        private DateTime _Received;
        private int _Size;
        private bool _Flagged;
        private string _Categories;
        private string _Folder;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="OutlookData"/> class.
        /// </summary>
        public OutlookData()
        {

        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="OutlookData"/> is important.
        /// </summary>
        /// <value><c>true</c> if important; otherwise, <c>false</c>.</value>
        public bool Important
        {
            get
            {
                return this._Important;
            }
            set
            {
                this._Important = value;
                this.RaisePropertyChanged("Important");
            }
        }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>The categories.</value>
        public string Categories
        {
            get
            {
                return this._Categories;
            }
            set
            {
                this._Categories = value;
                this.RaisePropertyChanged("Categories");
            }
        }

        /// <summary>
        /// Gets or sets the folder.
        /// </summary>
        /// <value>The folder.</value>
        public string Folder
        {
            get
            {
                return this._Folder;
            }
            set
            {
                this._Folder = value;
                this.RaisePropertyChanged("Folder");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is read.
        /// </summary>
        /// <value><c>true</c> if this instance is read; otherwise, <c>false</c>.</value>
        public bool IsRead
        {
            get
            {
                return this._IsRead;
            }
            set
            {
                this._IsRead = value;
                this.RaisePropertyChanged("IsRead");
            }
        }

        /// <summary>
        /// Gets or sets from address.
        /// </summary>
        /// <value>From address.</value>
        public string FromAddress
        {
            get
            {
                return this._FromAddress;
            }
            set
            {
                this._FromAddress = value;
                this.RaisePropertyChanged("FromAddress");
            }
        }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>The subject.</value>
        public string Subject
        {
            get
            {
                return this._Subject;
            }
            set
            {
                this._Subject = value;
                this.RaisePropertyChanged("Subject");
            }
        }

        /// <summary>
        /// Gets or sets the received.
        /// </summary>
        /// <value>The received.</value>
        public DateTime Received
        {
            get
            {
                return this._Received;
            }
            set
            {
                this._Received = value;
                this.RaisePropertyChanged("Received");
            }
        }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public int Size
        {
            get
            {
                return this._Size;
            }
            set
            {
                this._Size = value;
                this.RaisePropertyChanged("Size");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="OutlookData"/> is flagged.
        /// </summary>
        /// <value><c>true</c> if flagged; otherwise, <c>false</c>.</value>
        public bool Flagged
        {
            get
            {
                return this._Flagged;
            }

            set
            {
                this._Flagged = value;
                this.RaisePropertyChanged("Flagged");
            }
        }
    }
}
