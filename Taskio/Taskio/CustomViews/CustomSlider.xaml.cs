﻿using System;
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
            SelectedValue = ItemSource.ElementAt(index);
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
                //var labelWidth = (Slider.Width - thumbSize) / (ItemSource.Count() -1);
                var labelWidth = (Slider.Width) / (ItemSource.Count()-1);
                for (var i = 0; i < ItemSource.Count(); i++)
                {
                    var textWidth = 1;
                    var margin = (thumbSize / 2) - (textWidth / 2);
                    margin = margin > 0 ? margin : 0;
                    double widthRequest = labelWidth ;
                    if (i == 0)
                    {
                        widthRequest = labelWidth -13;
                    }
                    else if (i == (ItemSource.Count() - 1)) 
                    {
                        widthRequest = 30 -5; 
                    }
                   
                    Label label = new Label
                    {
                        Text = ItemSource.ElementAt(i).ToString(),
                        //WidthRequest = i == ItemSource.Count() - 1 ?  (labelWidth- thumbSize - margin)/2 : labelWidth -margin,
                        WidthRequest =  widthRequest,
                        //HorizontalTextAlignment = i == ItemSource.Count() -1 ? TextAlignment.End : TextAlignment.Start,
                        HorizontalTextAlignment = TextAlignment.Start,
                        //Margin = i == ItemSource.Count() - 1 ? new Thickness(0, 0, margin, 0) : new Thickness(margin, 0, 0, 0),
                        //Margin = i == ItemSource.Count() - 1 ? new Thickness(0.5, 0, 0, 0) : new Thickness(0, 0, 0, 0),
                        LineBreakMode = LineBreakMode.NoWrap
                    };
                    label.BindingContext = this;
                    double xOffset = i==0? 13 : i * labelWidth - .5; 
                    if(i == 0) 
                    {
                        BoxView intiailSpacing = new BoxView
                        {
                            WidthRequest = 15 - 3,
                            HeightRequest = 1,
                            BackgroundColor = Color.Transparent
                        };
                        intiailSpacing.Layout( new Rectangle(0, label.Y, intiailSpacing.Width, label.Height));
                        LabelHolder.Children.Add(intiailSpacing);
                    }
                    label.Layout(new Rectangle((xOffset),LabelHolder.Y,label.Width,label.Height));
                    LabelHolder.Children.Add(label);
                }
                BoxView line = new BoxView
                {
                    HeightRequest = 1,
                    WidthRequest = Slider.SeekBarWidth,
                    BackgroundColor = Color.Black
                };
                hbox.Children.Add(line);
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Slider.Value = 0;
        }
    }
}