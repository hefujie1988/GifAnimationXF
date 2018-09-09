using CoreAnimation;

using FFImageLoading.Forms.Platform;

using Xamarin.Forms;

using GifAnimationXF.iOS.Renderers;
using GifAnimationXF.Renderers;

[assembly: ExportRenderer(typeof(GifImage), typeof(GifImageRenderer))]
namespace GifAnimationXF.iOS.Renderers
{
    public class GifImageRenderer : CachedImageRenderer
    {

        protected override void OnElementPropertyChanged(object sender, 
                                                         System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == GifImage.AnimateProperty.PropertyName)
            {
                var formsElement = this.Element as GifImage;
                if (formsElement.Animate)
                    PauseLayer(Control.Layer);
                else
                    ResumeLayer(Control.Layer);
            }
        }

        private void PauseLayer(CALayer layer)
        {
            var time = layer.ConvertTimeFromLayer(CAAnimation.CurrentMediaTime(), null);
            layer.Speed = 0;
            layer.TimeOffset = time;
        }

        private void ResumeLayer(CALayer layer)
        {
            var time = layer.TimeOffset;
            layer.Speed = 1;
            layer.TimeOffset = 0;
            layer.BeginTime = 0;
            var timeSincePause = layer.ConvertTimeFromLayer(CAAnimation.CurrentMediaTime(), null) - time;
            layer.BeginTime = timeSincePause;
        }
    }
}
