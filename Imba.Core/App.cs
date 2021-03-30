using System;
using Imba.Core.Services;
using Imba.Core.Services.Implementation;
using Imba.Core.Services.Interfaces;
using Imba.Core.ViewModels;
using MvvmCross;
using MvvmCross.ViewModels;

namespace Imba.Core
{
    public class App : MvxApplication
    {
        public App()
        {
        }

        public override void Initialize()
        {
            base.Initialize();

            Mvx.IoCProvider.RegisterType<IBroadcastStateService, BroadcastStateService>();
            //Mvx.IoCProvider.RegisterSingleton<IFirebaseDatabaseService>(new FirebaseDatabaseService());
            RegisterAppStart<MainViewModel>();
        }
    }
}
