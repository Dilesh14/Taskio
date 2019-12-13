using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Taskio.CustomViews
{
    public class CustomSlider_test:Slider
    {
        public static readonly BindableProperty ItemSourceProperty = BindableProperty.Create(
            nameof(ItemSource),typeof(IEnumerable<int>),typeof(CustomSlider_test),null,BindingMode.Default);

        public static readonly BindableProperty SelectedValueProperty = BindableProperty.Create(
            nameof(SelectedValue),typeof(int),typeof(CustomSlider_test),null,BindingMode.TwoWay);

        public IEnumerable<int> ItemSource { get; set; }
        public int SelectedValue { get; set; }

        public CustomSlider_test() 
        {
            this.ValueChanged += SliderValueChanged;
        }
        
        private void SliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            var newValue = Math.Round(e.NewValue);
        }
    }
}
