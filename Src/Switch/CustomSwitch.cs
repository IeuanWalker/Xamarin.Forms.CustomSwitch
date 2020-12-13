using Switch.Enums;
using Switch.Events;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Switch
{
    public class CustomSwitch : Grid
    {
        /// <summary>
        ///     The switch height request property.
        /// </summary>
        public static readonly BindableProperty HorizontalSwitchMarginProperty = BindableProperty.Create(
            nameof(HorizontalSwitchMargin),
            typeof(double), typeof(CustomSwitch), 0d, propertyChanged: SizeRequestChanged);

        /// <summary>
        ///     The switch height request property.
        /// </summary>
        public static readonly BindableProperty SwitchHeightRequestProperty = BindableProperty.Create(
            nameof(SwitchHeightRequest),
            typeof(double), typeof(CustomSwitch), -1d, propertyChanged: SizeRequestChanged);

        /// <summary>
        ///     The switch width request property.
        /// </summary>
        public static readonly BindableProperty SwitchWidthRequestProperty = BindableProperty.Create(
            nameof(SwitchWidthRequest),
            typeof(double), typeof(CustomSwitch), -1d, propertyChanged: SizeRequestChanged);

        /// <summary>
        ///     The switch background color property.
        /// </summary>
        public static readonly BindableProperty SwitchColorProperty = BindableProperty.Create(nameof(SwitchColor),
            typeof(Color), typeof(CustomSwitch), Color.Navy);

        /// <summary>
        ///     The corner radius property.
        /// </summary>
        public static readonly BindableProperty SwitchCornerRadiusProperty = BindableProperty.Create(
            nameof(SwitchCornerRadius),
            typeof(float), typeof(CustomSwitch), 0f);

        /// <summary>
        ///     The icon switch content property.
        /// </summary>
        public static readonly BindableProperty SwitchContentProperty = BindableProperty.Create(nameof(SwitchContent),
            typeof(View), typeof(CustomSwitch));

        /// <summary>
        ///     The background height request property.
        /// </summary>
        public new static readonly BindableProperty HeightRequestProperty = BindableProperty.Create(
            nameof(HeightRequest),
            typeof(double), typeof(CustomSwitch), -1d, propertyChanged: SizeRequestChanged);

        /// <summary>
        ///     The background width request property.
        /// </summary>
        public new static readonly BindableProperty WidthRequestProperty = BindableProperty.Create(nameof(WidthRequest),
            typeof(double), typeof(CustomSwitch), -1d, propertyChanged: SizeRequestChanged);

        /// <summary>
        ///     The background color property.
        /// </summary>
        public new static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(
            nameof(BackgroundColor),
            typeof(Color), typeof(CustomSwitch), Color.Yellow);

        /// <summary>
        ///     The corner radius property.
        /// </summary>
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius),
            typeof(float), typeof(CustomSwitch), 0f);

        /// <summary>
        ///     The background content property.
        /// </summary>
        public static readonly BindableProperty BackgroundContentProperty = BindableProperty.Create(
            nameof(BackgroundContent),
            typeof(View), typeof(CustomSwitch));

        /// <summary>
        ///     The isToggled property.
        /// </summary>
        public static readonly BindableProperty IsToggledProperty = BindableProperty.Create(nameof(IsToggled),
            typeof(bool), typeof(CustomSwitch), false, propertyChanged: IsToggledChanged);

        /// <summary>
        ///     The isToggled property.
        /// </summary>
        public static readonly BindableProperty SwitchLimitProperty = BindableProperty.Create(nameof(KnobLimit),
            typeof(KnobLimitEnum), typeof(CustomSwitch), KnobLimitEnum.Boundary, propertyChanged: SizeRequestChanged);

        private readonly Frame _backgroundFrame;
        private readonly Frame SwitchFrame;
        private double _xRef;
        private double TmpTotalX;

        public CustomSwitch()
        {
            State = SwitchStateEnum.Left;
            base.BackgroundColor = Color.Transparent;

            _backgroundFrame = new Frame
            {
                IsClippedToBounds = true,
                Padding = 0,
                HasShadow = false,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            Children.Add(_backgroundFrame, 0, 0);

            _backgroundFrame.SetBinding(Frame.CornerRadiusProperty,
                new Binding(nameof(CornerRadius)) { Source = this, Mode = BindingMode.OneWay });
            _backgroundFrame.SetBinding(VisualElement.HeightRequestProperty,
                new Binding(nameof(HeightRequest)) { Source = this, Mode = BindingMode.OneWay });
            _backgroundFrame.SetBinding(VisualElement.WidthRequestProperty,
                new Binding(nameof(WidthRequest)) { Source = this, Mode = BindingMode.OneWay });
            _backgroundFrame.SetBinding(VisualElement.BackgroundColorProperty,
                new Binding(nameof(BackgroundColor)) { Source = this, Mode = BindingMode.OneWay });
            _backgroundFrame.SetBinding(Frame.BorderColorProperty,
                new Binding(nameof(BackgroundColor)) { Source = this, Mode = BindingMode.OneWay });
            _backgroundFrame.SetBinding(ContentView.ContentProperty,
                new Binding(nameof(BackgroundContent)) { Source = this, Mode = BindingMode.OneWay });

            SwitchFrame = new Frame
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HasShadow = false,
                IsClippedToBounds = true,
                Padding = 0
            };
            SwitchFrame.SetBinding(Frame.CornerRadiusProperty,
                new Binding(nameof(SwitchCornerRadius)) { Source = this, Mode = BindingMode.OneWay });
            SwitchFrame.SetBinding(VisualElement.HeightRequestProperty,
                new Binding(nameof(SwitchHeightRequest)) { Source = this, Mode = BindingMode.OneWay });
            SwitchFrame.SetBinding(VisualElement.WidthRequestProperty,
                new Binding(nameof(SwitchWidthRequest)) { Source = this, Mode = BindingMode.OneWay });
            SwitchFrame.SetBinding(ContentView.ContentProperty,
                new Binding(nameof(SwitchContent)) { Source = this, Mode = BindingMode.TwoWay });
            SwitchFrame.SetBinding(VisualElement.BackgroundColorProperty,
                new Binding(nameof(SwitchColor)) { Source = this, Mode = BindingMode.OneWay });
            SwitchFrame.SetBinding(Frame.BorderColorProperty,
                new Binding(nameof(SwitchColor)) { Source = this, Mode = BindingMode.OneWay });

            Children.Add(SwitchFrame, 0, 0);

            PanGestureRecognizer panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnPanUpdated;
            GestureRecognizers.Add(panGesture);

            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnTap;
            GestureRecognizers.Add(tapGestureRecognizer);

            if (IsToggled)
            {
                OnTap(this, null);
            }
        }

        public SwitchStateEnum State { get; set; }
        public double ProgressRate { get; set; }

        public double HorizontalSwitchMargin
        {
            get => (double)GetValue(HorizontalSwitchMarginProperty);
            set => SetValue(HorizontalSwitchMarginProperty, value);
        }

        /// <summary>
        ///     Gets or sets the Switch Height Request.
        /// </summary>
        /// <value>The Switch Height Request.</value>
        public double SwitchHeightRequest
        {
            get => (double)GetValue(SwitchHeightRequestProperty);
            set => SetValue(SwitchHeightRequestProperty, value);
        }

        /// <summary>
        ///     Gets or sets the Switch Width Request.
        /// </summary>
        /// <value>The Switch Width Request.</value>
        public double SwitchWidthRequest
        {
            get => (double)GetValue(SwitchWidthRequestProperty);
            set => SetValue(SwitchWidthRequestProperty, value);
        }

        /// <summary>
        ///     Gets or sets the switch Color.
        /// </summary>
        /// <value>The Background Color.</value>
        public Color SwitchColor
        {
            get => (Color)GetValue(SwitchColorProperty);
            set => SetValue(SwitchColorProperty, value);
        }

        /// <summary>
        ///     Gets or sets the Corner Radius.
        /// </summary>
        /// <value>The Corner Radius.</value>
        public float SwitchCornerRadius
        {
            get => (float)GetValue(SwitchCornerRadiusProperty);
            set => SetValue(SwitchCornerRadiusProperty, value);
        }

        /// <summary>
        ///     Gets or sets the Switch Content.
        /// </summary>
        /// <value>The Switch Content.</value>
        public View SwitchContent
        {
            get => (View)GetValue(SwitchContentProperty);
            set => SetValue(SwitchContentProperty, value);
        }

        /// <summary>
        ///     Gets or sets the Background Height Request.
        /// </summary>
        /// <value>The Background Height Request.</value>
        public new double HeightRequest
        {
            get => (double)GetValue(HeightRequestProperty);
            set => SetValue(HeightRequestProperty, value);
        }

        /// <summary>
        ///     Gets or sets the Background Width Request.
        /// </summary>
        /// <value>The Background width Request.</value>
        public new double WidthRequest
        {
            get => (double)GetValue(WidthRequestProperty);
            set => SetValue(WidthRequestProperty, value);
        }

        /// <summary>
        ///     Gets or sets the Background Color.
        /// </summary>
        /// <value>The Background Color.</value>
        public new Color BackgroundColor
        {
            get => (Color)GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }

        /// <summary>
        ///     Gets or sets the Corner Radius.
        /// </summary>
        /// <value>The Corner Radius.</value>
        public float CornerRadius
        {
            get => (float)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        /// <summary>
        ///     Gets or sets the Background Content.
        /// </summary>
        /// <value>The Background Content.</value>
        public View BackgroundContent
        {
            get => (View)GetValue(BackgroundContentProperty);
            set => SetValue(BackgroundContentProperty, value);
        }

        /// <summary>
        ///     Gets or sets the position of  the Toggle.
        /// </summary>
        /// <value>The Toggled Position.</value>
        public bool IsToggled
        {
            get => (bool)GetValue(IsToggledProperty);
            set => SetValue(IsToggledProperty, value);
        }

        /// <summary>
        ///     Gets or sets the Switch's Limit.
        /// </summary>
        /// <value>The Toggled Position.</value>
        public KnobLimitEnum KnobLimit
        {
            get => (KnobLimitEnum)GetValue(SwitchLimitProperty);
            set => SetValue(SwitchLimitProperty, value);
        }

        public event EventHandler<ToggledEventArgs> Toggled;
        public event EventHandler<SwitchPanUpdatedEventArgs> SwitchPanUpdate;

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width <= 0 && height <= 0) return;

            SizeRequestChanged(this, 0, 0);
        }

        /// <summary>
        ///     The Switch Height Request property changed.
        /// </summary>
        /// <param name="bindable">The object.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        private static void SizeRequestChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is CustomSwitch view)
            {
                //Switch
                view.SwitchFrame.WidthRequest =
                    view.SwitchWidthRequest < 0.0 ? view.Width / 2 : view.SwitchWidthRequest;
                view.SwitchFrame.HeightRequest =
                    view.SwitchHeightRequest < 0.0 ? view.Height : view.SwitchHeightRequest;

                //Background
                view._backgroundFrame.WidthRequest = view.WidthRequest < 0.0 ? view.Width : view.WidthRequest;
                view._backgroundFrame.HeightRequest = view.HeightRequest < 0.0 ? view.Height : view.HeightRequest;

                //View
                view.SetBaseWidthRequest(Math.Max(view._backgroundFrame.WidthRequest,
                    view.SwitchFrame.WidthRequest * 2));

                switch (view.KnobLimit)
                {
                    case KnobLimitEnum.Boundary:
                        view._xRef = ((view._backgroundFrame.WidthRequest - view.SwitchFrame.WidthRequest) / 2) - view.HorizontalSwitchMargin;
                        break;
                    case KnobLimitEnum.Centered:
                        view._xRef = (view._backgroundFrame.WidthRequest - view.SwitchFrame.WidthRequest) / 2 - (view._backgroundFrame.WidthRequest / 2 - view.SwitchFrame.WidthRequest) / 2;
                        break;
                    case KnobLimitEnum.Max:
                        view._xRef = Math.Max(view._backgroundFrame.WidthRequest, view.SwitchFrame.WidthRequest * 2) / 4;
                        break;
                }

                view.SwitchFrame.TranslationX = view.State == SwitchStateEnum.Left ? -view._xRef : view._xRef;
            }
        }

        private void SetBaseWidthRequest(double widthRequest)
        {
            base.WidthRequest = widthRequest;
        }

        /// <summary>
        ///     The IsToggled property changed.
        /// </summary>
        /// <param name="bindable">The object.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        private static void IsToggledChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is CustomSwitch view)
            {
                if ((bool)newValue && view.State != SwitchStateEnum.Right)
                    view.GoToRight();
                else if (!(bool)newValue && view.State != SwitchStateEnum.Left)
                    view.GoToLeft();

                view.Toggled?.Invoke(view, new ToggledEventArgs((bool)newValue));
            }
        }

        private void OnTap(object sender, EventArgs e)
        {
            SendSwitchPanUpdatedEventArgs(PanStatusEnum.Started);
            if (State == SwitchStateEnum.Right)
                GoToLeft();
            else
                GoToRight();
        }

        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            this.AbortAnimation("SwitchAnimation");
            double dragX = e.TotalX - TmpTotalX;

            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    SendSwitchPanUpdatedEventArgs(PanStatusEnum.Started);
                    break;
                case GestureStatus.Running:
                    SwitchFrame.TranslationX = Math.Min(_xRef, Math.Max(-_xRef, SwitchFrame.TranslationX + dragX));
                    TmpTotalX = e.TotalX;
                    SendSwitchPanUpdatedEventArgs(PanStatusEnum.Running);
                    break;
                case GestureStatus.Completed:
                    double percentage = IsToggled
                        ? Math.Abs(SwitchFrame.TranslationX - _xRef) / (2 * _xRef) * 100
                        : Math.Abs(SwitchFrame.TranslationX + _xRef) / (2 * _xRef) * 100;

                    if (SwitchFrame.TranslationX > 0)
                        GoToRight(percentage);
                    else
                        GoToLeft(percentage);
                    TmpTotalX = 0;
                    break;
                case GestureStatus.Canceled:
                    SendSwitchPanUpdatedEventArgs(PanStatusEnum.Canceled);
                    break;
            }
        }

        private void SendSwitchPanUpdatedEventArgs(PanStatusEnum status)
        {
            SwitchPanUpdatedEventArgs ev = new SwitchPanUpdatedEventArgs
            {
                xRef = _xRef,
                IsToggled = IsToggled,
                TranslateX = SwitchFrame.TranslationX,
                Status = status,
                Percentage = IsToggled
                    ? Math.Abs(SwitchFrame.TranslationX - _xRef) / (2 * _xRef) * 100
                    : Math.Abs(SwitchFrame.TranslationX + _xRef) / (2 * _xRef) * 100
            };

            if (!double.IsNaN(ev.Percentage))
                SwitchPanUpdate?.Invoke(this, ev);
        }

        private void GoToLeft(double pourcentage = 0.0)
        {
            if (Math.Abs(SwitchFrame.TranslationX + _xRef) > 0.0)
            {
                const int dur = 100;
                uint duration = Convert.ToUInt32(dur - dur * pourcentage / 100);
                this.AbortAnimation("SwitchAnimation");
                new Animation
                {
                    {0, 1, new Animation(v => SwitchFrame.TranslationX = v, SwitchFrame.TranslationX, -_xRef)},
                    {0, 1, new Animation(v => SendSwitchPanUpdatedEventArgs(PanStatusEnum.Running))}
                }.Commit(this, "SwitchAnimation", 16, duration, null, (d, b) =>
                {
                    this.AbortAnimation("SwitchAnimation");
                    State = SwitchStateEnum.Left;
                    IsToggled = false;
                    SendSwitchPanUpdatedEventArgs(PanStatusEnum.Completed);
                });
            }
            else
            {
                this.AbortAnimation("SwitchAnimation");
                State = SwitchStateEnum.Left;
                IsToggled = false;
                SendSwitchPanUpdatedEventArgs(PanStatusEnum.Completed);
            }
        }

        private void GoToRight(double pourcentage = 0.0)
        {
            if (Math.Abs(SwitchFrame.TranslationX - _xRef) > 0.0)
            {
                int dur = 100;
                uint duration = Convert.ToUInt32(dur - dur * pourcentage / 100);
                this.AbortAnimation("SwitchAnimation");
                new Animation
                {
                    {0, 1, new Animation(v => SwitchFrame.TranslationX = v, SwitchFrame.TranslationX, _xRef)},
                    {0, 1, new Animation(v => SendSwitchPanUpdatedEventArgs(PanStatusEnum.Running))}
                }.Commit(this, "SwitchAnimation", 16, duration, null, (d, b) =>
                {
                    this.AbortAnimation("SwitchAnimation");
                    State = SwitchStateEnum.Right;
                    IsToggled = true;
                    SendSwitchPanUpdatedEventArgs(PanStatusEnum.Completed);
                });
            }
            else
            {
                this.AbortAnimation("SwitchAnimation");
                State = SwitchStateEnum.Right;
                IsToggled = true;
                SendSwitchPanUpdatedEventArgs(PanStatusEnum.Completed);
            }
        }
    }
}
