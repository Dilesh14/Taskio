using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Taskio.CustomViews;
using Taskio.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

//[assembly: ExportRenderer(typeof(CustomSlider), typeof(CustomSliderViewRenderer))]
namespace Taskio.Droid.CustomRenderers
{
    public class CustomSliderViewRenderer: ViewRenderer
    {
        private ContentView _contentView;
        private CustomSlider_test _slider;
        public CustomSliderViewRenderer(Context context) : base(context) 
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
            
            var mainStack = this.Element.FindByName<StackLayout>("Main");
            _slider = this.Element.FindByName<CustomSlider_test>("Slider");
        }
    }
}