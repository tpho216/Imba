using System;
using Android.App;
using Android.Content.PM;
using Firebase;
using MvvmCross.Platforms.Android.Views;

namespace Imba.Droid
{

    [Activity(
        Label = "Imba"
        , MainLauncher = true
        , Icon = "@mipmap/ic_launcher"
        , Theme = "@style/AppTheme.Splash"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen() : base(Resource.Layout.splash_screen_layout)
        {
            FirebaseApp app = FirebaseApp.InitializeApp(this);

        }
    }
}
