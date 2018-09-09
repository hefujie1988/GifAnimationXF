using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace GifAnimationXF
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void GifImage_Tapped(object sender, System.EventArgs e)
        {
            gifImage.Animate  = !gifImage.Animate;
        }
    }
}
