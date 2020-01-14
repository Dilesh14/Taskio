using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Taskio.Droid.Services.Interfaces;
using Xamarin.Forms;

namespace Taskio.Droid.Services
{
    public class Text_Service : IText
    {
        public double CalculateWidth(string text)
        {
            Rect bounds = new Rect();
            TextView textView = new TextView(Forms.Context);
            textView.Paint.GetTextBounds(text, 0, text.Length, bounds);
            double length = bounds.Width();
            return length / Resources.System.DisplayMetrics.ScaledDensity;
        }
    }
}