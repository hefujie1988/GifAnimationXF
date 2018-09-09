using System;
using FFImageLoading.Forms;
using Xamarin.Forms;

namespace GifAnimationXF.Renderers
{
    public class GifImage : CachedImage
    {
        public bool Animate { 
            get => (bool)GetValue(AnimateProperty);
            set => SetValue(AnimateProperty, value);
        }

        public static readonly BindableProperty AnimateProperty =
            BindableProperty.Create(nameof(Animate), typeof(bool), typeof(GifImage), false);

    }
}
