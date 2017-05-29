using Android.Content;
using Xamarin.Forms.Platform.Android;
using Android.Support.V4.View;
using Xamarin.Forms;
using System.ComponentModel;
using Naxam.Controls.Platform.Droid;
using Naxam.Controls.Forms;

[assembly: ExportRenderer(typeof(CarouselView), typeof(CarouselViewRenderer))]
namespace Naxam.Controls.Platform.Droid
{
    public class CarouselViewRenderer : ViewRenderer<CarouselView, ViewPager>
    {
        ViewPager nativeView;
        CarouselViewListener listener;
        CarouselViewAdapter adapter;

        public CarouselViewRenderer()
        {
            listener = new CarouselViewListener();
            adapter = new CarouselViewAdapter();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CarouselView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                nativeView = Control;

                if (nativeView == null)
                {
                    nativeView = new ViewPager(Context);
                    nativeView.LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
                    nativeView.SetClipToPadding(false);
                    nativeView.SetClipChildren(false);

                    nativeView.OffscreenPageLimit = 5;
                    nativeView.PageMargin = (int)Context.ToPixels(24);

                    var spacing = (int)Context.ToPixels(40);
                    nativeView.SetPadding(spacing, 0, spacing, 0);

					nativeView.SetPageTransformer(false, new CarouselEffectTransformer(Context));
					nativeView.SetOnPageChangeListener(listener);
                    nativeView.Adapter = adapter;

                    SetNativeControl(nativeView);
                }
			}

			listener.Element = e.NewElement;
            adapter.Element = e.NewElement;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == CarouselView.ItemSourceProperty.PropertyName)
            {
                adapter.NotifyDataSetChanged();
            }
            if (e.PropertyName == CarouselView.PositionProperty.PropertyName)
			{
				//if forms position change => change native position
				if (nativeView.CurrentItem != Element.Position)
				{
					nativeView.SetCurrentItem(Element.Position, true);
				}
            }
            if (e.PropertyName == CarouselView.SelectedItemProperty.PropertyName)
            {
                if (nativeView != null && Element.SelectedItem != null)
                {
                    if (Element.SelectedItem != Element.ItemSource[nativeView.CurrentItem])
                    {
                        nativeView.SetCurrentItem(Element.ItemSource.IndexOf(Element.SelectedItem), true);
                    }
                }
            }
        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
        }
    }
}