# NAXAM CarouselView on Xamarin.Forms
A Xamarin.Forms control created by Naxam team internally based on [CarouselEffectTransformer](https://github.com/bhaveshjabuvani-credencys/CarouselEffect/blob/master/app/src/main/java/com/carouseleffect/CarouselEffectTransformer.java) from @bhaveshjabuvani-credencys

It's not just available on Android.

![Image](https://github.com/bhaveshjabuvani-credencys/CarouselEffect/raw/master/CarouselEffectDemo.gif?raw=true)

## Installation
```
Install-Package Naxam.CarouselView
```

## Usage
```
carousel = new CarouselView();

carousel.ItemSource = new Color[] { 
    Color.Red,
    Color.Blue,
    Color.Green,
    Color.Purple,
    Color.Yellow
};

carousel.ItemTemlate = new DataTemplate(typeof(CarouselViewCell));
```