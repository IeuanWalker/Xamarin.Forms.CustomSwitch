using Switch.Enums;
using Switch.Events;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Switch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestSwitch : ContentView
    {
        #region Properties
        public SwitchStateEnum State { get; set; }
        private double _xRef = 16;
        private double TmpTotalX;

        public static readonly BindableProperty IsToggledProperty = BindableProperty.Create(nameof(IsToggled), typeof(bool), typeof(TestSwitch), false, propertyChanged: IsToggledChanged);
        public bool IsToggled
        {
            get => (bool)GetValue(IsToggledProperty);
            set => SetValue(IsToggledProperty, value);
        }

        public static readonly BindableProperty KnobHeightProperty = BindableProperty.Create(nameof(KnobHeight), typeof(double), typeof(TestSwitch), -1d, propertyChanged: SizeRequestChanged);
        public double KnobHeight
        {
            get => (double)GetValue(KnobHeightProperty);
            set => SetValue(KnobHeightProperty, value);
        }
        public static readonly BindableProperty KnobWidthProperty = BindableProperty.Create(nameof(KnobWidth),  typeof(double), typeof(TestSwitch), -1d, propertyChanged: SizeRequestChanged);
        public double KnobWidth
        {
            get => (double)GetValue(KnobWidthProperty);
            set => SetValue(KnobWidthProperty, value);
        }
        public static readonly BindableProperty SwitchColorProperty = BindableProperty.Create(nameof(SwitchColor), typeof(Color), typeof(TestSwitch), Color.Navy);
        public Color SwitchColor
        {
            get => (Color)GetValue(SwitchColorProperty);
            set => SetValue(SwitchColorProperty, value);
        }
        public static readonly BindableProperty SwitchCornerRadiusProperty = BindableProperty.Create(nameof(SwitchCornerRadius), typeof(float), typeof(TestSwitch), 0f);
        public float SwitchCornerRadius
        {
            get => (float)GetValue(SwitchCornerRadiusProperty);
            set => SetValue(SwitchCornerRadiusProperty, value);
        }
        public new static readonly BindableProperty HeightRequestProperty = BindableProperty.Create(nameof(HeightRequest), typeof(double), typeof(TestSwitch), -1d, propertyChanged: SizeRequestChanged);
        public new double HeightRequest
        {
            get => (double)GetValue(HeightRequestProperty);
            set => SetValue(HeightRequestProperty, value);
        }
        public new static readonly BindableProperty WidthRequestProperty = BindableProperty.Create(nameof(WidthRequest), typeof(double), typeof(TestSwitch), -1d, propertyChanged: SizeRequestChanged);
        public new double WidthRequest
        {
            get => (double)GetValue(WidthRequestProperty);
            set => SetValue(WidthRequestProperty, value);
        }
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(TestSwitch), 0f);
        public float CornerRadius
        {
            get => (float)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public new static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(TestSwitch), Color.Yellow);
        public new Color BackgroundColor
        {
            get => (Color)GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }
        public static readonly BindableProperty BackgroundContentProperty = BindableProperty.Create(nameof(BackgroundContent), typeof(View), typeof(TestSwitch));
        public View BackgroundContent
        {
            get => (View)GetValue(BackgroundContentProperty);
            set => SetValue(BackgroundContentProperty, value);
        }
        public static readonly BindableProperty SwitchContentProperty = BindableProperty.Create(nameof(SwitchContent), typeof(View), typeof(TestSwitch));
        public View SwitchContent
        {
            get => (View)GetValue(SwitchContentProperty);
            set => SetValue(SwitchContentProperty, value);
        }

        #endregion

        #region Events

        public event EventHandler<ToggledEventArgs> Toggled;
        public event EventHandler<SwitchPanUpdatedEventArgs> SwitchPanUpdate;

        #endregion


        public TestSwitch()
        {
            InitializeComponent();
            State = IsToggled ? SwitchStateEnum.Right : SwitchStateEnum.Left;

            SwitchFrame.SetBinding(ContentProperty, new Binding(nameof(SwitchContent)) { Source = this, Mode = BindingMode.TwoWay });

        }
        void Loaded(object sender, EventArgs e)
        {
            if (IsToggled)
            {
                GoToRight(100);
            }
            else
            {
                GoToLeft(100);
            }
        }

        void Unloaded(object sender, EventArgs e)
        {


        }

        private static void IsToggledChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is TestSwitch view)
            {
                if ((bool)newValue && view.State != SwitchStateEnum.Right)
                    view.GoToRight();
                else if (!(bool)newValue && view.State != SwitchStateEnum.Left)
                    view.GoToLeft();

                view.Toggled?.Invoke(view, new ToggledEventArgs((bool)newValue));
            }
        }

        private void GoToLeft(double pourcentage = 0.0)
        {
            if (Math.Abs(SwitchFrame.TranslationX + _xRef) > 0.0)
            {
                var dur = 100;
                var duration = Convert.ToUInt32(dur - dur * pourcentage / 100);
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
                var dur = 100;
                var duration = Convert.ToUInt32(dur - dur * pourcentage / 100);
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

        private void SendSwitchPanUpdatedEventArgs(PanStatusEnum status)
        {
            var ev = new SwitchPanUpdatedEventArgs
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

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            SendSwitchPanUpdatedEventArgs(PanStatusEnum.Started);
            if (State == SwitchStateEnum.Right)
                GoToLeft();
            else
                GoToRight();
        }

        private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            this.AbortAnimation("SwitchAnimation");
            var dragX = e.TotalX - TmpTotalX;

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
                    var percentage = IsToggled
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












        public static readonly BindableProperty SwitchLimitProperty = BindableProperty.Create(nameof(SwitchLimit), typeof(SwitchLimitEnum), typeof(TestSwitch), SwitchLimitEnum.Boundary, propertyChanged: SizeRequestChanged);
        public SwitchLimitEnum SwitchLimit
        {
            get => (SwitchLimitEnum)GetValue(SwitchLimitProperty);
            set => SetValue(SwitchLimitProperty, value);
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width <= 0 && height <= 0) return;

            SizeRequestChanged(this, 0, 0);
        }
        private static void SizeRequestChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is TestSwitch view)
            {
                //Switch
                view.SwitchFrame.WidthRequest =
                    view.SwitchFrame.WidthRequest < 0.0 ? view.Width / 2 : view.SwitchFrame.WidthRequest;
                view.SwitchFrame.HeightRequest =
                    view.SwitchFrame.HeightRequest < 0.0 ? view.Height : view.SwitchFrame.HeightRequest;

                //Background
                view.BackgroundFrame.WidthRequest = view.WidthRequest < 0.0 ? view.Width : view.WidthRequest;
                view.BackgroundFrame.HeightRequest = view.HeightRequest < 0.0 ? view.Height : view.HeightRequest;

                //View
                view.SetBaseWidthRequest(Math.Max(view.BackgroundFrame.WidthRequest,
                    view.SwitchFrame.WidthRequest * 2));

                switch (view.SwitchLimit)
                {
                    case SwitchLimitEnum.Boundary:
                        view._xRef = ((view.BackgroundFrame.WidthRequest - view.SwitchFrame.WidthRequest) / 2) - 1;
                        break;
                    case SwitchLimitEnum.Centered:
                        view._xRef = (view.BackgroundFrame.WidthRequest - view.SwitchFrame.WidthRequest) / 2
                                     - (view.BackgroundFrame.WidthRequest / 2 - view.SwitchFrame.WidthRequest) / 2;
                        break;
                    case SwitchLimitEnum.Max:
                        view._xRef = Math.Max(view.BackgroundFrame.WidthRequest, view.SwitchFrame.WidthRequest * 2) /
                                     4;
                        break;
                }

                if (view.State == SwitchStateEnum.Left)
                    view.SwitchFrame.TranslationX = -view._xRef;
                else
                    view.SwitchFrame.TranslationX = view._xRef;
            }
        }
        private void SetBaseWidthRequest(double widthRequest)
        {
            base.WidthRequest = widthRequest;
        }

    }
}