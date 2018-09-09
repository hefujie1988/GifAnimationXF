using System;

using Android.Content;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using GifAnimationXF.Droid.Renderers;
using GifAnimationXF.Renderers;

using Felipecsl.GifImageViewLibrary;
using System.IO;

[assembly: ExportRenderer(typeof(GifImage), typeof(GifImageRenderer))]
namespace GifAnimationXF.Droid.Renderers
{
    public class GifImageRenderer : ViewRenderer<GifImage, GifImageView>
    {
        GifImageView gifImageView;
        public GifImageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<GifImage> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var source = Element.Source as FileImageSource;
                if(source != null){
                    var inputStream = Context.Assets.Open(source.File);
                    var memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                    byte[] bytes = memoryStream.ToArray();
                    gifImageView = new GifImageView(Context);
                    gifImageView.SetBytes(bytes);
                    gifImageView.StartAnimation();
                    SetNativeControl(gifImageView);
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == GifImage.AnimateProperty.PropertyName)
            {
                var formsElement = Element as GifImage;
                if (formsElement.Animate)
                    PauseLayer();
                else 
                    ResumeLayer();
            }
        }

        private void PauseLayer()
        {
            gifImageView.StopAnimation();
        }

        private void ResumeLayer()
        {
            gifImageView.StartAnimation();
        }
    }
}
