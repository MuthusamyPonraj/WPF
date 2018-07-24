#region Copyright Syncfusion Inc. 2001 - 2012
// Copyright Syncfusion Inc. 2001 - 2012. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;

namespace SerializationDemo
{
    class PersonInfo : NotificationObject
    {
        #region Private Fields

        private static int _globalId = 0;
        private int _id;
        private string _firstName;
        private string _lastName;
        private bool _likesCake;
        private string _cake = String.Empty;
        private DateTime _dob;
        private string _eyecolor;
        private ObservableCollection<PersonInfo> _children;

        #endregion Private Fields

        #region Public Properties

        public ObservableCollection<PersonInfo> Children
        {
            get
            {
                return _children;
            }
            set
            {
                _children = value;
                RaisePropertyChanged("Children");
            }
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                RaisePropertyChanged("Id");
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        public bool LikesCake
        {
            get
            {
                return _likesCake;
            }
            set
            {
                _likesCake = value;
                RaisePropertyChanged("LikesCake");
            }
        }

        public string Cake
        {
            get
            {
                return _cake;
            }
            set
            {
                _cake = value;
                RaisePropertyChanged("Cake");
            }
        }

        public DateTime DOB
        {
            get
            {
                return _dob;
            }
            set
            {
                _dob = value;
                RaisePropertyChanged("DOB");
            }
        }

        public string MyEyeColor
        {
            get
            {
                return _eyecolor;
            }
            set
            {
                _eyecolor = value;
                RaisePropertyChanged("MyEyeColor");
            }
        }

        #endregion

        #region Constructors


        /// <summary>
        /// Initializes a new instance of the <see cref="PersonInfo"/> class.
        /// </summary>
        public PersonInfo()
            : this("Enter FirstName", "Enter LastName", "Enter EyeColor", new DateTime(2008, 10, 26), null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonInfo"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="eyecolor">The eyecolor.</param>
        /// <param name="dob">The dob.</param>
        /// <param name="maxGenerations">The max generations.</param>
        public PersonInfo(string firstName, string lastName, string eyecolor, DateTime dob, ObservableCollection<PersonInfo> child)
        {
            FirstName = firstName;
            LastName = lastName;
            MyEyeColor = eyecolor;
            LikesCake = true;
            Cake = "Chocolate";
            DOB = dob;
            Id = _globalId++;
            Children = child;
        }

        #endregion Constructors
    }
}
