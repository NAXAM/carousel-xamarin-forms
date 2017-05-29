using System;
using Android.Content;
using Android.Views;
using Android.Support.V4.View;
using Xamarin.Forms.Platform.Android;

namespace Naxam.Controls.Platform.Droid
{
    class CarouselEffectTransformer : Java.Lang.Object, ViewPager.IPageTransformer
    {
        int maxTranslateOffsetX;
        ViewPager viewPager;

        public CarouselEffectTransformer(Context context)
        {
            maxTranslateOffsetX = (int) context.ToPixels(180);
        }

        public void TransformPage(View view, float position)
        {
            if (viewPager == null)
            {
                viewPager = (ViewPager)view.Parent;
            }

            int leftInScreen = view.Left - viewPager.ScrollX;
            int centerXInViewPager = leftInScreen + view.MeasuredWidth / 2;
            int offsetX = centerXInViewPager - viewPager.MeasuredWidth / 2;
            float offsetRate = offsetX * 0.1f / viewPager.MeasuredWidth;
            float scaleFactor = 1 - Math.Abs(offsetRate);

            if (scaleFactor > 0)
            {
                view.ScaleX = scaleFactor;
                view.ScaleY = scaleFactor;
                view.TranslationX = -maxTranslateOffsetX * offsetRate;
            }
        }
    }
}