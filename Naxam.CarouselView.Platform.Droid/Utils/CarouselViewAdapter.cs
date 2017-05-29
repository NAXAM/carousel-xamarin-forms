using Android.Views;
using Android.Support.V4.View;
using Xamarin.Forms;
using Naxam.Controls.Forms;

namespace Naxam.Controls.Platform.Droid
{
    class CarouselViewAdapter : PagerAdapter
	{
        CarouselView element;
        public CarouselView Element
        {
            get
            {
                return element;
            }

            set
            {
                if (ReferenceEquals(value, element)) return;

                element = value;
                NotifyDataSetChanged();
            }
        }

        public override int Count
        {
            get
            {
                return Element?.ItemSource?.Count ?? 0;
            }
        }

        public override bool IsViewFromObject(Android.Views.View view, Java.Lang.Object @object)
        {
            return view == @object;
        }

        public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
        {
            var cell = (ViewCell)Element.ItemTemlate.CreateContent();
            cell.Parent = Element;
            cell.BindingContext = Element.ItemSource[position];

            var view = new ViewCellContainer(container.Context, container, cell);
            container.AddView(view);

            return view;
        }

        public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object @object)
        {
            container.RemoveView((Android.Views.View)@object);
        }
    }
}