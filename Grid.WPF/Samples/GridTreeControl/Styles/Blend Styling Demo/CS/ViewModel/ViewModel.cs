using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlendStylingDemo
{
    public class ViewModel
    {
        private List<BookInfo> _BookDetails;
        /// <summary>
        /// Gets or sets the book details.
        /// </summary>
        /// <value>The book details.</value>
        public List<BookInfo> BookDetails
        {
            get
            {
                return _BookDetails;
            }
            set
            {
                _BookDetails = value;
            }
        }

        private List<BookInfo> bookcollection;
        /// <summary>
        /// Gets or sets the book collection.
        /// </summary>
        /// <value>The book collection.</value>
        public List<BookInfo> BookCollection
        {
            get
            {
                return bookcollection;
            }
            set
            {
                bookcollection = value;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        /// 
        public ViewModel()
        {
            this.BookDetails = new List<BookInfo>();

            BookDetails.Add(new BookInfo() { ISBN = "0-123-1233-0", AuthorName = "Alexandre Dumas", Title = "The Three Musketeers", PublisherName = "Grosset & Dunlap", Binding = "hc", RetailPrice = 15.95, PulicationYear = "1953", NoInHand = 10 });
            BookDetails.Add(new BookInfo() { ISBN = "0-125-3344-1", AuthorName = "Alexandre Dumas", Title = "The Black Tulip", PublisherName = "P. F. Collier & Son", Binding = "hc", RetailPrice = 18.95, PulicationYear = "1902", NoInHand = 3 });
            BookDetails.Add(new BookInfo() { ISBN = "0-124-5544-X", AuthorName = "Alexandre Dumas", Title = "The Titans", PublisherName = "Harper", Binding = "hc", RetailPrice = 18.95, PulicationYear = "1957", NoInHand = 4 });


            BookDetails.Add(new BookInfo() { ISBN = "0-128-3939-2", AuthorName = "James Clavell", Title = "Gai-Jin", PublisherName = "Delacorte", Binding = "hc", RetailPrice = 25.95, PulicationYear = "1993", NoInHand = 15 });
            BookDetails.Add(new BookInfo() { ISBN = "0-128-3939-X", AuthorName = "James Clavell", Title = "Noble House", PublisherName = "Delacorte", Binding = "hc", RetailPrice = 22.95, PulicationYear = "1981", NoInHand = 12 });
            BookDetails.Add(new BookInfo() { ISBN = "0-128-4321-1", AuthorName = "James Clavell", Title = "Tai-Pan", PublisherName = "Delacorte", Binding = "hc", RetailPrice = 22.95, PulicationYear = "1966", NoInHand = 12 });

            BookDetails.Add(new BookInfo() { ISBN = "0-129-4567-1", AuthorName = "Anne McCaffrey", Title = "Dragonsong", PublisherName = "Atheneum", Binding = "hc", RetailPrice = 18.95, PulicationYear = "1976", NoInHand = 12 });
            BookDetails.Add(new BookInfo() { ISBN = "0-129-4912-0", AuthorName = "Anne McCaffrey", Title = "Dragonsinger", PublisherName = "Atheneum", Binding = "hc", RetailPrice = 19.95, PulicationYear = "1977", NoInHand = 14 });
            BookDetails.Add(new BookInfo() { ISBN = "0-130-2939-4", AuthorName = "Anne McCaffrey", Title = "The White Dragon", PublisherName = "Ballantine Books", Binding = "hc", RetailPrice = 21.95, PulicationYear = "1978", NoInHand = 8 });

            BookDetails.Add(new BookInfo() { ISBN = "0-134-3945-7", AuthorName = "Robert Louis Stevenson", Title = "A Child's Garden of Verses", PublisherName = "Scribner", Binding = "hc", RetailPrice = 21.95, PulicationYear = "1905", NoInHand = 12 });
            BookDetails.Add(new BookInfo() { ISBN = "0-129-4912-0", AuthorName = "Robert Louis Stevenson", Title = "Treasure Island", PublisherName = "J. W. Lovell Co.", Binding = "hc", RetailPrice = 24.95, PulicationYear = "1886", NoInHand = 8 });
            BookDetails.Add(new BookInfo() { ISBN = "0-130-2939-4", AuthorName = "Robert Louis Stevenson", Title = "Kidnapped", PublisherName = "Mead Dodd", Binding = "hc", RetailPrice = 21.95, PulicationYear = "1949", NoInHand = 8 });

            BookDetails.Add(new BookInfo() { ISBN = "0-131-3021-2", AuthorName = "Anne Rice", Title = "The Tale of the Body Thief", PublisherName = "Knopf", Binding = "hc", RetailPrice = 24.95, PulicationYear = "1992", NoInHand = 18 });
            BookDetails.Add(new BookInfo() { ISBN = "0-131-4809-X", AuthorName = "Anne Rice", Title = "The Vampire Lestat", PublisherName = "Knopf", Binding = "hc", RetailPrice = 22.95, PulicationYear = "1985", NoInHand = 12 });
            BookDetails.Add(new BookInfo() { ISBN = "0-131-1458-9", AuthorName = "Anne Rice", Title = "Interview with the Vampire", PublisherName = "Knopf", Binding = "hc", RetailPrice = 23.95, PulicationYear = "1976", NoInHand = 12 });

            BookDetails.Add(new BookInfo() { ISBN = "0-132-3949-2", AuthorName = "Mark Twain", Title = "The Prince and the Pauper", PublisherName = "James R. Osgood and Co.", Binding = "hc", RetailPrice = 19.95, PulicationYear = "1882", NoInHand = 10 });
            BookDetails.Add(new BookInfo() { ISBN = "0-132-9876-4", AuthorName = "Mark Twain", Title = "Life on the Mississippi", PublisherName = "James R. Osgood and Co.", Binding = "hc", RetailPrice = 22.95, PulicationYear = "1883", NoInHand = 8 });
            BookDetails.Add(new BookInfo() { ISBN = "0-133-2956-6", AuthorName = "Mark Twain", Title = "The Inocents Abroad", PublisherName = "American Publishing Co.", Binding = "hc", RetailPrice = 19.95, PulicationYear = "1869", NoInHand = 6 });

            BookDetails.Add(new BookInfo() { ISBN = "0-134-3945-7", AuthorName = "Robert Louis Stevenson", Title = "A Child's Garden of Verses", PublisherName = "Scribner", Binding = "hc", RetailPrice = 21.95, PulicationYear = "1905", NoInHand = 12 });
            BookDetails.Add(new BookInfo() { ISBN = "0-135-2222-2", AuthorName = "Robert Louis Stevenson", Title = "Treasure Island", PublisherName = "J. W. Lovell Co.", Binding = "hc", RetailPrice = 24.95, PulicationYear = "1886", NoInHand = 18 });
            BookDetails.Add(new BookInfo() { ISBN = "0-136-3956-1", AuthorName = "Robert Louis Stevenson", Title = "Kidnapped", PublisherName = "Mead Dodd", Binding = "hc", RetailPrice = 22.95, PulicationYear = "1949", NoInHand = 12 });

            BookDetails.Add(new BookInfo() { ISBN = "0-137-1293-9", AuthorName = "Sir Walter Scott", Title = "TRob Roy", PublisherName = "D. Appleton & Co.", Binding = "hc", RetailPrice = 21.95, PulicationYear = "1898", NoInHand = 22 });
            BookDetails.Add(new BookInfo() { ISBN = "0-138-1379-8", AuthorName = "Sir Walter Scott", Title = "Ivanhoe", PublisherName = "Hart Publishing Co.", Binding = "hc", RetailPrice = 22.95, PulicationYear = "1977", NoInHand = 6 });
            BookDetails.Add(new BookInfo() { ISBN = "0-140-3877-0", AuthorName = "Sir Walter Scott", Title = "Waverly Novels", PublisherName = "University of Nebraska Press", Binding = "hc", RetailPrice = 27.95, PulicationYear = "1978", NoInHand = 3 });


            BookCollection = new List<BookInfo>();
            var AuthorCollection = BookDetails.Select(x => x.AuthorName).Distinct().ToList();

            foreach (var Author in AuthorCollection)
            {
                BookCollection.Add(new BookInfo() { AuthorName = Author, Children = BookDetails.Where(x => x.AuthorName == Author).ToList()});
            }
        }
    }
}
