using System;
using Android.OS;
using Android.Util;
using Android.Views;
using Imba.Core.ViewModels;
using MvvmCross.ViewModels;

namespace Imba.Droid.Util
{
    //this class is written in order to prevent dampen effect of Android
    //Button click and is mostly used to bind with ViewModel task 

    public class SafeOnClickListener : Java.Lang.Object, View.IOnClickListener
    {
        private static long lastClickMs = 0;
        private static readonly string _tag = "SafeOnClickListener";
        private static long TOO_SOON_DURATION_MS = 1000;
        private MvxViewModel _viewModel;
        public SafeOnClickListener()
        {
        }

        public SafeOnClickListener(MvxViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void OnClick(View v)
        {
            long nowMs = SystemClock.CurrentThreadTimeMillis();
            if (lastClickMs != 0 && (nowMs - lastClickMs) < TOO_SOON_DURATION_MS)
            {
                Log.Debug(_tag, "onClick: too soon");
                return;
            }
            Log.Debug(_tag, "onClick: Ok");
            lastClickMs = nowMs;


            onOneClick(v);
        }

        /**
          * Override this function to handle clicks.
          * reset() must be called after each click for this function to be called
          * again.
          *
          * @param v
          */
        public void onOneClick(View v)
        {
            if (_viewModel is MainViewModel)
            {
                (_viewModel as MainViewModel).ShowTabsViewCommand.Execute();
            }
        }
    }
}