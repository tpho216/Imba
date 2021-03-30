using System;
using Android.App;
using Android.Graphics;
using Android.OS;
using Google.Android.Material.Tabs;
using Imba.Core.ViewModels;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;

namespace Imba.Droid
{
    [MvxActivityPresentation]
    [Activity(Label = "", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class TabsViewActivity : MvxActivity<TabsViewModel>
    {
        private string _tag;

        public TabsViewActivity()
        {
            _tag = this.ToString();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.tabs_view_activity_layout);

            if (savedInstanceState == null)
            {
                ViewModel.ShowTodoViewCommand.Execute(null);
               

            }

            var tabLayout = (TabLayout)FindViewById<TabLayout>(Resource.Id.tabs_layout);

            tabLayout.SetTabTextColors(Color.ParseColor("white"), Color.ParseColor("white"));
        }
    }
}
