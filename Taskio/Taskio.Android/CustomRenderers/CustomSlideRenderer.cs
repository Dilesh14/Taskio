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
using Taskio.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSlider_test), typeof(CustomSlideRenderer))]  
namespace Taskio.Droid.CustomRenderer
{
    public class CustomSlideRenderer:SliderRenderer
    {
       
        public CustomSlideRenderer(Context context) : base(context)
        {
            
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);
            if(this.Control != null) 
            {
                var slider = (CustomSlider_test)this.Element;
                this.Control.TickMark = Resources.GetDrawable(Resource.Drawable.icon1);
                Control.Max = slider.ItemSourceCount -1;
                Control.Min = 0;
                Control.Progress =(int)slider.Value;
            }
        }
    }
}