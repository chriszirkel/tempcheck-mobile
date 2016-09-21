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
using TempCheckMobile.Controls;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;
using Xamarin.Forms;
using TempCheckMobile.Droid.Controls;
using View = Android.Views.View;
using Android.Graphics.Drawables;

[assembly: ExportRenderer(typeof(RoundedBoxView), typeof(RoundedBoxViewRenderer))]
namespace TempCheckMobile.Droid.Controls
{
    // https://github.com/paulpatarinski/Xamarin.Forms.Plugins/tree/master/RoundedBoxView
    public class RoundedBoxViewRenderer : ViewRenderer<RoundedBoxView, View>
    {
        public static void Init()
        {
        }

        private RoundedBoxView _formControl
        {
            get { return Element; }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<RoundedBoxView> e)
        {
            base.OnElementChanged(e);

            InitializeFrom(_formControl);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            UpdateFrom(_formControl, e.PropertyName);
        }

        private void InitializeFrom(RoundedBoxView formsControl)
        {
            if (formsControl == null)
                return;

            var background = new GradientDrawable();

            background.SetColor(formsControl.BackgroundColor.ToAndroid());

            if (Build.VERSION.SdkInt >= BuildVersionCodes.JellyBean)
            {
                this.Background = background;
            }
            else
            {
                this.SetBackgroundDrawable(background);
            }

            UpdateCornerRadius(formsControl.CornerRadius);
            UpdateBorder(formsControl.BorderColor, formsControl.BorderThickness);
        }

        private void UpdateFrom(RoundedBoxView formsControl, string propertyChanged)
        {
            if (formsControl == null)
                return;

            if (propertyChanged == RoundedBoxView.CornerRadiusProperty.PropertyName)
            {
                UpdateCornerRadius(formsControl.CornerRadius);
            }
            if (propertyChanged == VisualElement.BackgroundColorProperty.PropertyName)
            {
                var background = Background as GradientDrawable;

                if (background != null)
                {
                    background.SetColor(formsControl.BackgroundColor.ToAndroid());
                }
            }

            if (propertyChanged == RoundedBoxView.BorderColorProperty.PropertyName)
            {
                UpdateBorder(formsControl.BorderColor, formsControl.BorderThickness);
            }

            if (propertyChanged == RoundedBoxView.BorderThicknessProperty.PropertyName)
            {
                UpdateBorder(formsControl.BorderColor, formsControl.BorderThickness);
            }
        }

        private void UpdateBorder(Color color, int thickness)
        {
            var backgroundGradient = Background as GradientDrawable;

            if (backgroundGradient != null)
            {
                var relativeBorderThickness = thickness * 3;
                backgroundGradient.SetStroke(relativeBorderThickness, color.ToAndroid());
            }
        }

        private void UpdateCornerRadius(double cornerRadius)
        {
            var backgroundGradient = Background as GradientDrawable;

            if (backgroundGradient != null)
            {
                var relativeCornerRadius = (float)(cornerRadius * 3.7);
                backgroundGradient.SetCornerRadius(relativeCornerRadius);
            }
        }
    }
}