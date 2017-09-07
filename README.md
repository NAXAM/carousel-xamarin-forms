<img src="./art/repo_header.png" alt="CarouselView - A Xamarin.Forms control" width="728" />

# CarouselView
A Xamarin.Forms control based on [CarouselEffectTransformer](https://github.com/bhaveshjabuvani-credencys/CarouselEffect/blob/master/app/src/main/java/com/carouseleffect/CarouselEffectTransformer.java) from @bhaveshjabuvani-credencys

![Image](https://github.com/bhaveshjabuvani-credencys/CarouselEffect/raw/master/CarouselEffectDemo.gif?raw=true)

## About
This project is maintained by Naxam Co.,Ltd.<br>
We specialize in developing mobile applications using Xamarin and native technology stack.<br>

**Looking for developers for your project?**<br>

<a href="mailto:tuyen@naxam.net"> 
<img src="https://github.com/NAXAM/naxam.github.io/blob/master/assets/img/hire_button.png?raw=true" height="40"></a> <br>

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

## License

TopTabbedPage is released under the Apache License license.
See [LICENSE](./LICENSE) for details.