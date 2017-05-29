using Naxam.Controls.Forms;
using Xamarin.Forms;

namespace CarouseViewQs
{
    public partial class CarouseViewQsPage : ContentPage
    {
        CarouselView carousel;

        public CarouseViewQsPage()
        {
            InitializeComponent();

            carousel = new CarouselView();

            carousel.ItemSource = new Color[] { 
                Color.Red,
                Color.Blue,
                Color.Green,
                Color.Purple,
                Color.Yellow
            };

            carousel.ItemTemlate = new DataTemplate(typeof(CarouselViewCell));

			Content = carousel;

		}
    }

    class CarouselViewCell : ViewCell {
        public CarouselViewCell()
        {
            View = new BoxView();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            View.BackgroundColor = (Color)BindingContext;
        }
    }
}
