using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Collections.Specialized;

namespace TreeviewBindingDemo
{

    #region ObjectClass

    //MyObjectList class
    public class MyObjectList : ObservableCollection<ObjectTree>
    {
        public MyObjectList()
        {
            ObjectTree root = new ObjectTree("[Text]");
            this.Add(root);
            //Initialze the Object/tree
            ObjectTree level1 = addObjectTree(root, "[Text]");
            ObjectTree level2 = addObjectTree(root, "[Text]");
            ObjectTree level1Item1 = addObjectTree(level1, "[Text]");
            ObjectTree leve11Item2 = addObjectTree(level1, "[Text]");
            ObjectTree level2Item1 = addObjectTree(level2, "[Text]");
            ObjectTree leve12Item2 = addObjectTree(level2, "[Text]");
        }

        //Add the Level
        private ObjectTree addObjectTree(ObjectTree root, string p)
        {
            ObjectTree level = new ObjectTree(p);
            root.Add(level);
            level.ParentObjectTree = root;
            return level;
        }
    }
    #endregion


    #region ObjectTree

    public class ObjectTree : ObservableCollection<ObjectTree>, INotifyPropertyChanged
    {
        //Declaring the Proeprties
        public ObjectTree ParentObjectTree { get; set; }
        private string name;
        public ObjectTree(string name) { Name = name; }

        //Property
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;

                    //Invoke when property values get changed
                    this.OnPropertyChanged(new PropertyChangedEventArgs("Name"));
                }
            }
        }

        #region INotifyPropertyChanged

        //Register the Eventhandler for PropertyChangedEvent
        public event PropertyChangedEventHandler PropertyChanged;

        //Function to handle the Proeprty value changes
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged.Invoke(this, e);
        }
        #endregion
    }
    #endregion
}
