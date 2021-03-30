using System;
using Android.Content;
using Imba.Core;
using Imba.Core.Services.Interfaces;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.ViewModels;

namespace Imba.Droid
{
    public class Setup : MvxAndroidSetup<App>
    {
        public Setup()
        {
        }

        protected override void InitializeFirstChance()
        {
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IFirebaseDatabaseService, AndroidFirebaseDatabaseService>();
            base.InitializeFirstChance();
        }
    }
}
