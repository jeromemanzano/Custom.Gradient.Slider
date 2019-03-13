using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GradientSlider
{
    /// <summary>
    /// A custom Xamarin.Forms.Slider that have options to change height, corner radius and apply gradient background in the Minimum Track
    /// </summary>
    public class CustomGradientSlider : Slider
    {
        /// <summary>
        /// Backing store for CustomGradientSlider.CornerRadius property.
        /// </summary>
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(
            propertyName: nameof(CornerRadius),
            returnType: typeof(double),
            declaringType: typeof(CustomGradientSlider),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay
            );

        /// <summary>
        /// Backing store for CustomGradientSlider.StartColor property.
        /// </summary>
        public static readonly BindableProperty StartColorProperty = BindableProperty.Create(
            propertyName: nameof(StartColor),
            returnType: typeof(Color),
            declaringType: typeof(CustomGradientSlider),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay
            );

        /// <summary>
        /// Backing store for CustomGradientSlider.EndColor property.
        /// </summary>
        public static readonly BindableProperty EndColorProperty = BindableProperty.Create(
            propertyName: nameof(EndColor),
            returnType: typeof(Color),
            declaringType: typeof(CustomGradientSlider),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay
            );

        /// <summary>
        /// Backing store for CustomGradientSlider.CenterColor property.
        /// </summary>
        public static readonly BindableProperty CenterColorProperty = BindableProperty.Create(
            propertyName: nameof(CenterColor),
            returnType: typeof(Color),
            declaringType: typeof(CustomGradientSlider),
            defaultValue: null,
            defaultBindingMode: BindingMode.TwoWay
            );

        /// <summary>
        /// Gets or sets the corner radius of slider
        /// </summary>
        public double CornerRadius
        {
            get => (double)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        //     Gets or sets the start color of the gradient portion of the slider track that contains the minimum
        //     value of the slider.
        public Color StartColor
        {
            get => (Color)GetValue(StartColorProperty);
            set => SetValue(StartColorProperty, value);
        }

        //     Gets or sets the end color of the gradient portion of the slider track that contains the minimum
        //     value of the slider.
        public Color EndColor
        {
            get => (Color)GetValue(EndColorProperty);
            set => SetValue(EndColorProperty, value);
        }

        //     Gets or sets the center color of the gradient portion of the slider track that contains the minimum
        //     value of the slider.
        public Color CenterColor
        {
            get => (Color)GetValue(CenterColorProperty);
            set => SetValue(CenterColorProperty, value);
        }
    }
}
