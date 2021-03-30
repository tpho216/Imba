
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmCross.DroidX.RecyclerView;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Imba.Core.ViewModels;
using MvvmCross.Platforms.Android.Views;
using Android.Content.PM;
using Imba.Droid.Util;

namespace Imba.Droid.Activities
{
    [Activity(Label = "MainActivity",
        Theme = "@style/AppTheme",
        LaunchMode = LaunchMode.SingleTop,
        Name = "Imba.Droid.Actiity.MainViewActivity")]
    public class MainViewActivity : MvxActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main_view_activity_layout);


            //**Deprecated not using**//

            //Set Listener for custom click event for View Model navigation
            //SafeOnClickListener customClickListener = new SafeOnClickListener(ViewModel);
            //_showTabViewBtn.SetOnClickListener(customClickListener);

            //**Deprecated not using**//
        }
    }
}
