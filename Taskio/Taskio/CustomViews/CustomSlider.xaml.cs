using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Taskio.CustomViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomSlider : ContentView
    {
        //private int StepCount;

        public static readonly BindableProperty ItemSourceProperty = BindableProperty.Create(
        nameof(ItemSource), typeof(IEnumerable<int>), typeof(CustomSlider), null, BindingMode.Default);

        public static readonly BindableProperty SelectedValueProperty = BindableProperty.Create(
            nameof(SelectedValue), typeof(int), typeof(CustomSlider), null, BindingMode.TwoWay);
        
        public IEnumerable<int> ItemSource { get; set; }
        public int SelectedValue { get; set; }
        
        
        public CustomSlider()
        {
            InitializeComponent();
            ItemSource = new List<int> { 8,12,16,20};
            Slider.ItemSourceCount = ItemSource.Count();
            Slider.ValueChanged += Slider_ValueChanged;
            Slider.Minimum = 0;
            Slider.Maximum = 100;
            
            Slider.BindingContext = this;
            Slider.PropertyChanged += Slider_PropertyChanged;
        }

        private void Slider_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var slider = sender as Slider;
            if (e.PropertyName == "Height")
            {
                BuildSlider();
            }
            else if (e.PropertyName == "Width" && slider.Height > 0) 
            {
                BuildSlider();
            }
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var newValue = e.NewValue * 10;
            int index = Convert.ToInt32(newValue);
            string text= index.ToString();
            Label l1 = new Label { Text = text + $"Maps to {ItemSource.ElementAt(index)}"};
            LabelTest.Children.Clear();
            LabelTest.Children.Add(l1);

        }
        private void BuildSlider() 
        {
            if(ItemSource != null) 
            {
                LabelHolder.Children.Clear();


                var thumbSize = Slider.Height;
                var labelWidth = (Slider.Width - thumbSize) / (ItemSource.Count() -1);
                for (var i = 0; i < ItemSource.Count(); i++)
                {
                    var textWidth = 1;
                    var margin = (thumbSize / 2) - (textWidth / 2);
                    margin = margin > 0 ? margin : 0;
                    Label label = new Label
                    {
                        Text = ItemSource.ElementAt(i).ToString(),
                        WidthRequest = i == ItemSource.Count() - 1 ?  (labelWidth- thumbSize - margin)/2 : labelWidth -margin,
                        HorizontalTextAlignment = i == ItemSource.Count() -1 ? TextAlignment.End : TextAlignment.Start,
                        Margin = i == ItemSource.Count() - 1 ? new Thickness(0, 0, margin, 0) : new Thickness(margin, 0, 0, 0),
                        LineBreakMode = LineBreakMode.NoWrap
                    };
                    label.BindingContext = this;
                    LabelHolder.Children.Add(label);
                }
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Slider.Value = 50;
        }
    }
}