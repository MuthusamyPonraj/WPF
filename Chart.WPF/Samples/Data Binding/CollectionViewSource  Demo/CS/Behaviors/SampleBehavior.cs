using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.ComponentModel;
using System.Windows.Data;

namespace CollectionViewSourceDemo
{
    public class SampleBehavior : Behavior<CollectionView>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            //this.AssociatedObject.SortBy.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(SortBy_SelectionChanged);
        }

        void SortBy_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ListSortDirection direction = ListSortDirection.Ascending;
            string name = e.AddedItems[0].ToString();
            Sort(name, direction);
        }

        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(this.AssociatedObject.DataItems.ItemsSource);
            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }


    }
}
