using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using GradientSlider;
using GradientSlider.Droid;
using GradientSlider.Droid.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomGradientSlider), typeof(CustomGradientSliderRenderer))]
namespace GradientSlider.Droid
{
    public class CustomGradientSliderRenderer : SliderRenderer
    {
        public CustomGradientSliderRenderer(Context context) : base(context){}
        
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Slider> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                //convert details from CustomGradientSlider to android values
                var slider = Element as CustomGradientSlider;
                var startColor = slider.StartColor.ToAndroid();
                var centerColor = slider.CenterColor.ToAndroid();
                var endColor = slider.EndColor.ToAndroid();
                var cornerRadiusInPx = ((float)slider.CornerRadius).DpToPixels(Context);
                var heightPx = ((float)slider.HeightRequest).DpToPixels(Context);

                //create minimum track
                var p = new GradientDrawable(GradientDrawable.Orientation.LeftRight, new int[] { startColor, centerColor, endColor });
                p.SetCornerRadius(cornerRadiusInPx);
                var progress = new ClipDrawable(p, GravityFlags.Left, ClipDrawableOrientation.Horizontal);

                //create maximum track
                var background = new GradientDrawable();
                background.SetColor(Element.MaximumTrackColor.ToAndroid());
                background.SetCornerRadius(cornerRadiusInPx);

                var pd = new LayerDrawable(new Drawable[] { background, progress });

                pd.SetLayerHeight(0, (int)heightPx);
                pd.SetLayerHeight(1, (int)heightPx);
                Control.ProgressDrawable = pd;
            }
        }

        //Code from SliderRenderer https://github.com/xamarin/Xamarin.Forms/blob/master/Xamarin.Forms.Platform.Android/Renderers/SliderRenderer.cs
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            BuildVersionCodes androidVersion = Build.VERSION.SdkInt;
            if (androidVersion < BuildVersionCodes.JellyBean)
                return;

            // Thumb only supported JellyBean and higher

            if (Control == null)
                return;

            SeekBar seekbar = Control;

            Drawable thumb = seekbar.Thumb;
            int thumbTop = seekbar.Height / 2 - thumb.IntrinsicHeight / 2;

            thumb.SetBounds(thumb.Bounds.Left, thumbTop, thumb.Bounds.Left + thumb.IntrinsicWidth, thumbTop + thumb.IntrinsicHeight);
        }
    }
}