#region Copyright Syncfusion Inc. 2001 - 2010
// Copyright Syncfusion Inc. 2001 - 2010. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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

namespace TreeviewBindingDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        #region Public Variables

        //Declarinng the Public variables
        MyObjectList myObj;
        #endregion

        #region Constructor

        public Window1()
        {
            InitializeComponent();
            myObj = this.Resources["myList"] as MyObjectList;
        }
        #endregion

        #region Private Functions

        // Adding a Node 
        private void AddNode_Click(object sender, RoutedEventArgs e)
        {
            foreach (object obj in diagramView.SelectionList)
            {
                if (obj is Node)
                {
                    //Get the Selected object
                    Node n = obj as Node;
                    if (n.Content is ObjectTree)
                    {
                        ObjectTree newItem = new ObjectTree("[Text]");
                        (n.Content as ObjectTree).Add(newItem);
                        newItem.ParentObjectTree = n.Content as ObjectTree;
                    }
                }
            }
        }

        // Deleting a Node        
        private void DeleteNode_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < diagramView.SelectionList.Count; i++)
            {
                //Get the Selected object
                object obj = diagramView.SelectionList[i];
                if (obj is Node)
                {
                    Node n = obj as Node;
                    if (n.Content is ObjectTree)
                    {
                        if ((n.Content as ObjectTree).ParentObjectTree != null)
                        {
                            (n.Content as ObjectTree).ParentObjectTree.Remove(n.Content as ObjectTree);
                        }
                        else
                        {
                            myObj.Clear();
                        }
                    }
                }
            }
        }
        #endregion
    }
}
