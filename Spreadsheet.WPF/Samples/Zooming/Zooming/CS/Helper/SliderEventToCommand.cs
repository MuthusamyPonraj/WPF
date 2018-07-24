using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Shared;
using System.Windows.Controls;
using System.Windows;

namespace Zooming.Helper
{
    #region SliderCommandBase
    public class SliderCommandBase<TBehavior> : ControlCommandBase<TBehavior, Slider> where TBehavior : CommandBehaviorBase<Slider>, new()
    { }

    public class SliderCommandBehaviorBase<TReturn, TEventArgs> : BuilderCommandBehaviorBase<Slider, TEventArgs, TReturn>
    { }
    #endregion

    #region SliderValueChanged

    public class SliderValueChangedCommand<T, TBehavior> : SliderCommandBase<TBehavior> where TBehavior : SliderValueChangedCommandBehavior<T>, new()
    { }

    public class SliderValueChangedCommandBehavior<TReturn> : SliderCommandBehaviorBase<TReturn, RoutedPropertyChangedEventArgs<double>>
    {
        public SliderValueChangedCommandBehavior(Func<object, RoutedPropertyChangedEventArgs<double>, TReturn> builder)
        {
            this.builder = builder;
        }

        public SliderValueChangedCommandBehavior()
            : this(null)
        { }

        protected override void OnTargetAttached()
        {
            TargetObject.ValueChanged += OnEventRaised;
        }
    }

    public class SliderValueChangedCommand : SliderCommandBase<SliderValueChangedCommandBehavior>
    { }

    public class SliderValueChangedCommandBehavior : SliderValueChangedCommandBehavior<object>
    { }

    public class SliderValueChangedCommandWithEventArgs : SliderValueChangedCommand<RoutedPropertyChangedEventArgs<double>, SliderValueChangedCommandBehaviorWithEventArgs>
    { }

    public class SliderValueChangedCommandBehaviorWithEventArgs : SliderValueChangedCommandBehavior<RoutedPropertyChangedEventArgs<double>>
    {
        public SliderValueChangedCommandBehaviorWithEventArgs()
            : base((o, e) => e)
        { }
    }
    #endregion
}
