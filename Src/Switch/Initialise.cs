using Microsoft.Maui.Controls.Compatibility;

namespace Switch
{
    public static class Initialise
    {
        public static MauiAppBuilder SwitchInit(this MauiAppBuilder builder)
        {
            builder.ConfigureMauiHandlers(handlers =>
            {
#if __ANDROID__
				handlers.AddCompatibilityRenderer(typeof(AdvancedFrame), typeof(PlatformSpecific.Android.AdvancedFrameRenderer));
#endif
#if __IOS__
                handlers.AddCompatibilityRenderer(typeof(AdvancedFrame), typeof(PlatformSpecific.Ios.AdvancedFrameRenderer));
#endif
            });

            return builder;
        }
    }
}
