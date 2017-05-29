using System;
using Android.Support.V4.View;
using Naxam.Controls.Forms;

namespace Naxam.Controls.Platform.Droid
{
    class CarouselViewListener : Java.Lang.Object, ViewPager.IOnPageChangeListener
    {
        public CarouselView Element { get; set; }

        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels) { }

        public void OnPageScrollStateChanged(int state) { }

        public void OnPageSelected(int position)
        {
            if (Element == null) {
                return;
            }

            Element.SelectedItem = Element.ItemSource[position];
            Element.Position = position;
        }
    }
}
