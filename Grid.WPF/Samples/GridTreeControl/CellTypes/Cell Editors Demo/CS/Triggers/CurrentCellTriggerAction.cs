using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows.Controls;
using Syncfusion.Windows.Controls.Grid;
using System.Windows;

namespace CellEditorsDemo
{
    class CurrentCellActivationBehavior : TargetedTriggerAction<GridTreeControl>
    {
        /// <summary>
        /// Gets or sets the target object. If TargetObject is not set, the target will look for the object specified by TargetName. If an element referred to by TargetName cannot be found, the target will default to the AssociatedObject. This is a dependency property.
        /// </summary>
        /// <value>The target object.</value>
        public object TargetObject
        {
            get { return (object)GetValue(TargetObjectProperty); }
            set { SetValue(TargetObjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TargetObject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TargetObjectProperty =
            DependencyProperty.Register("TargetObject", typeof(object), typeof(CurrentCellActivationBehavior), new PropertyMetadata());

        /// <summary>
        /// Invokes the action.
        /// </summary>
        /// <param name="parameter">The parameter to the action. If the action does not require a parameter, the parameter may be set to a null reference.</param>
        protected override void Invoke(object parameter)
        {
            var Item = (parameter as SelectionChangedEventArgs).AddedItems[0] as ComboBoxItem;
            var Target = TargetObject as GridTreeControl;

            if (Target.InternalGrid != null && Item != null)
            {
                if (Item.Content.ToString() == "ClickOnCell")
                    Target.Model.Options.ActivateCurrentCellBehavior = GridCellActivateAction.ClickOnCell;
                else if (Item.Content.ToString() == "DblClickOnCell")
                    Target.Model.Options.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell;
            }
        }
    }
}
