using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using GradientSlider;
using GradientSlider.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomGradientSlider), typeof(CustomGradientSliderRenderer))]
namespace GradientSlider.iOS
{
    public class CustomGradientSliderRenderer : SliderRenderer
    {
        public CGColor StartColor { get; set; }
        public CGColor CenterColor { get; set; }
        public CGColor EndColor { get; set; }
        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {

            if (Control == null)
            {
                var customSlider = e.NewElement as CustomGradientSlider;
                StartColor = customSlider.StartColor.ToCGColor();
                CenterColor = customSlider.CenterColor.ToCGColor();
                EndColor = customSlider.EndColor.ToCGColor();

                var slider = new SlideriOS
                {
                    Continuous = true,

                    Height = (nfloat)customSlider.HeightRequest
                };

                SetNativeControl(slider);
            }

            base.OnElementChanged(e);
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            if (Control != null)
            {
                Control.SetMinTrackImage(CreateGradientImage(rect.Size), UIControlState.Normal);
            }
        }

        void OnControlValueChanged(object sender, EventArgs eventArgs)
        {
            ((IElementController)Element).SetValueFromRenderer(Slider.ValueProperty, Control.Value);
        }

        public UIImage CreateGradientImage(CGSize rect)
        {
            var gradientLayer = new CAGradientLayer()
            {
                StartPoint = new CGPoint(0, 0.5),
                EndPoint = new CGPoint(1, 0.5),
                Colors = new CGColor[] { StartColor, CenterColor, EndColor },
                Frame = new CGRect(0, 0, rect.Width, rect.Height),
                CornerRadius = 5.0f
            };

            UIGraphics.BeginImageContext(gradientLayer.Frame.Size);
            gradientLayer.RenderInContext(UIGraphics.GetCurrentContext());
            var image = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();

            return image.CreateResizableImage(UIEdgeInsets.Zero);
        }
    }

    public class SlideriOS : UISlider
    {
        public nfloat Height { get; set; }

        public override CGRect TrackRectForBounds(CGRect forBounds)
        {
            var rect = base.TrackRectForBounds(forBounds);
            return new CGRect(rect.X, rect.Y, rect.Width, Height);
        }
    }
}