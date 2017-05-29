using System.Collections;
using Xamarin.Forms;

namespace Naxam.Controls.Forms
{
    public class CarouselView : View
    {
        public static BindableProperty PositionProperty = BindableProperty.Create(
            nameof(Position),
            typeof(int),
            typeof(CarouselView),
            0,
            BindingMode.TwoWay
        );

        public int Position
        {
            get { return (int)GetValue(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }

        public static BindableProperty SelectedItemProperty = BindableProperty.Create(
            nameof(SelectedItem),
            typeof(object),
            typeof(CarouselView),
            null,
            BindingMode.TwoWay
        );
        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static BindableProperty ItemSourceProperty = BindableProperty.Create(
            nameof(ItemSource),
            typeof(IList),
            typeof(CarouselView),
            null,
            BindingMode.TwoWay
        );

        public IList ItemSource
        {
            get { return (IList)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }

        public static BindableProperty ItemTemlateProperty = BindableProperty.Create(
            nameof(ItemTemlate),
            typeof(DataTemplate),
            typeof(CarouselView),
            null,
            BindingMode.TwoWay
        );

        public DataTemplate ItemTemlate
        {
            get { return (DataTemplate)GetValue(ItemTemlateProperty); }
            set { SetValue(ItemTemlateProperty, value); }
        }
    }
}
