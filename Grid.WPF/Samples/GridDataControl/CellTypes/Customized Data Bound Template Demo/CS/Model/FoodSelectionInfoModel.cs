using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Syncfusion.Windows.Shared;

namespace CustomizedDataBoundTemplateDemo
{
    public class FoodSelectionInfo:NotificationObject
    {
        private bool pepsi;
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FoodSelectionInfo"/> is pepsi.
        /// </summary>
        /// <value><c>true</c> if pepsi; otherwise, <c>false</c>.</value>
        public bool Pepsi
        {
            get
            {
                return pepsi; 
            }
            set
            {
                pepsi = value;
                RaisePropertyChanged("Pepsi");
            }
        }

        private bool coke;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FoodSelectionInfo"/> is coke.
        /// </summary>
        /// <value><c>true</c> if coke; otherwise, <c>false</c>.</value>
        public bool Coke
        {
            get 
            {
                return coke; 
            }
            set
            {
                coke = value;
                RaisePropertyChanged("Coke");
            }
        }

        private bool popcorn;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FoodSelectionInfo"/> is popcorn.
        /// </summary>
        /// <value><c>true</c> if popcorn; otherwise, <c>false</c>.</value>
        public bool Popcorn
        {
            get
            {
                return popcorn; 
            }
            set
            {
                popcorn = value;
                RaisePropertyChanged("Popcorn");
            }
        }

        private bool coffee;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FoodSelectionInfo"/> is coffee.
        /// </summary>
        /// <value><c>true</c> if coffee; otherwise, <c>false</c>.</value>
        public bool Coffee
        {
            get
            {
                return coffee; 
            }
            set
            {
                coffee = value;
                RaisePropertyChanged("Coffee");
            }
        }

        private bool tea;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FoodSelectionInfo"/> is tea.
        /// </summary>
        /// <value><c>true</c> if tea; otherwise, <c>false</c>.</value>
        public bool Tea
        {
            get
            {
                return tea; 
            }
            set
            {
                tea = value;
                RaisePropertyChanged("Tea");
            }
        }

    }
}
