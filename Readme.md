# Xamarin.Forms.CustomSwitch

This is a switch/ toggle control that would alow you to create any style switch you'd like.
Taka a look at the sample app included within this project -

![Sample App](Doc/SampleApp.gif)

## How to use it?
Install the [NuGet package]() into your shared project project
```
Install-Package IeuanWalker.CustomSwitch
```

## What can I do with it?
### Properties
| Property | What it does | Extra info |
|---|---|---- |
| IsToggled | A `bool` to indicate the togles status of the switch | Default value is **false** |
| KnobHeight | The height of the knob on the switch | Default value is **0** |
| KnobWidth | The width of the knob on the switch | Default value is **0** |
| KnobColor | The solid color of the knob | Default value is **Color.Default** |
| KnobColorGradientStops | Sets the gradient colors for the Knob. <br> This is property exposed from [PancakeView](https://github.com/sthewissen/Xamarin.Forms.PancakeView)  | More info on how to use this in the [PancakeView docs](https://github.com/sthewissen/Xamarin.Forms.PancakeView/wiki/Gradients) <br> Default value is **new GradientStopCollection()** |
| KnobColorGradientStartPoint | Defines the relative start point of the gradient. <br> This is property exposed from [PancakeView](https://github.com/sthewissen/Xamarin.Forms.PancakeView)  | More info on how to use this in the [PancakeView docs - Gradients](https://github.com/sthewissen/Xamarin.Forms.PancakeView/wiki/Gradients) <br> Default value is **0,0** |
| KnobColorGradientEndPoint | Defines the relative endpoint of the gradient. <br> This is property exposed from [PancakeView](https://github.com/sthewissen/Xamarin.Forms.PancakeView)  | More info on how to use this in the [PancakeView docs - Gradients](https://github.com/sthewissen/Xamarin.Forms.PancakeView/wiki/Gradients) <br> Default value is **1,0** |
| KnobBorder | The border for the knob. <br> This is property exposed from [PancakeView](https://github.com/sthewissen/Xamarin.Forms.PancakeView)  | More info on how to use this in the [PancakeView docs - Borders](https://github.com/sthewissen/Xamarin.Forms.PancakeView/wiki/Borders) <br> Default value is **default(Border)** |
| KnobCornerRadius | A `CornerRadius` object representing each individual corner's radius for the knob. <br> This is property exposed from [PancakeView](https://github.com/sthewissen/Xamarin.Forms.PancakeView)  | More info on how to use this in the [PancakeView docs - Rounded corners](https://github.com/sthewissen/Xamarin.Forms.PancakeView/wiki/Rounded-Corners) <br> Default value is **default(CornerRadius)** |
| HeightRequest | The Height of the switch  | Default value is **0** |
| WidthRequest | The width of the switch  | Default value is **0** |
| CornerRadius | A `CornerRadius` object representing each individual corner's radius for the switch. <br> This is property exposed from [PancakeView](https://github.com/sthewissen/Xamarin.Forms.PancakeView)  | More info on how to use this in the [PancakeView docs - Rounded corners](https://github.com/sthewissen/Xamarin.Forms.PancakeView/wiki/Rounded-Corners) <br> Default value is **default(CornerRadius)** |
| BackgroundColor | The solid color of the switch | Default value is **Color.Default** |
| BackgroundColorGradientStops | Sets the gradient colors for the switch. <br> This is property exposed from [PancakeView](https://github.com/sthewissen/Xamarin.Forms.PancakeView)  | More info on how to use this in the [PancakeView docs](https://github.com/sthewissen/Xamarin.Forms.PancakeView/wiki/Gradients) <br> Default value is **new GradientStopCollection()** |
| BackgroundColorGradientStartPoint | Defines the relative start point of the gradient. <br> This is property exposed from [PancakeView](https://github.com/sthewissen/Xamarin.Forms.PancakeView)  | More info on how to use this in the [PancakeView docs - Gradients](https://github.com/sthewissen/Xamarin.Forms.PancakeView/wiki/Gradients) <br> Default value is **0,0** |
| BackgroundColorGradientEndPoint | Defines the relative endpoint of the gradient. <br> This is property exposed from [PancakeView](https://github.com/sthewissen/Xamarin.Forms.PancakeView)  | More info on how to use this in the [PancakeView docs - Gradients](https://github.com/sthewissen/Xamarin.Forms.PancakeView/wiki/Gradients) <br> Default value is **1,0** |
| Border | The border for the switch. <br> This is property exposed from [PancakeView](https://github.com/sthewissen/Xamarin.Forms.PancakeView)  | More info on how to use this in the [PancakeView docs - Borders](https://github.com/sthewissen/Xamarin.Forms.PancakeView/wiki/Borders) <br> Default value is **default(Border)** |
| BackgroundContent | Sets the content of the switch. See [samples](/Sample/Sample/Sample/Examples/) for an  idea how to utilise it  | Default value is **null** |
| KnobContent | Sets the content of the knob. See [samples]() for an  idea how to utilise it | Default value is **null** |
| HorizontalKnobMargin | Adds a margin to the max distance the knob can travel | Default value is **0** |
| KnobLimit | Used to calculate the knob position. See [samples]() for an  idea how to utilise it | Default value is **KnobLimitEnum.Boundary** |
| VibrateDuration | Used to set the duration of the vibration when the switch is toggles | Default value is **20** <br> To disble the vibrate set the value to `0` |
| ToggleAnimationDuration | Used to set the duration of the toggle animation | Default value is **100** <br> To disble the animation set the value to `0` |

## Events
| Event | What it does | Extra info |
|---|---|---- |
| Toggled | Triggered whent the switch is toggled | Default value is **false** |
