using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;
using System.Windows.Documents;

namespace RichTextCellDemo
{
    public class MailData : NotificationObject
    {
        #region Private Members

        private FlowDocument _Important;
        private FlowDocument _IsRead;
        private FlowDocument _Subject;
        private string _Size;
        private FlowDocument _Flagged;
        private FlowDocument _Categories;
        private string _Folder;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="MailData"/> class.
        /// </summary>
        public MailData()
        {

        }

        /// <summary>
        /// Gets or sets the important.
        /// </summary>
        /// <value>The important.</value>
        public FlowDocument Important
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
        public FlowDocument Categories
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
        /// Gets or sets the is read.
        /// </summary>
        /// <value>The is read.</value>
        public FlowDocument IsRead
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
        /// Gets or sets the subject.
        /// </summary>
        /// <value>The subject.</value>
        public FlowDocument Subject
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
        /// Gets or sets the size.
        /// </summary>
        /// <value>The size.</value>
        public string Size
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
        /// Gets or sets the flagged.
        /// </summary>
        /// <value>The flagged.</value>
        public FlowDocument Flagged
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
