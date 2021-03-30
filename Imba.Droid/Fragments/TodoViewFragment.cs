using System;
using Android.OS;
using Android.Runtime;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Imba.Core.ViewModels;
using MvvmCross.DroidX.RecyclerView;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views.Fragments;

namespace Imba.Droid.Fragments
{
    [MvxTabLayoutPresentation(TabLayoutResourceId = Resource.Id.tabs_layout, ViewPagerResourceId = Resource.Id.viewpager, Title = "To Do", ActivityHostViewModelType =typeof(TabsViewModel))]
    [Register("Imba.droid.views.TodoViewFragment")]
    public class TodoViewFragment : MvxFragment<TodoViewModel>
    {
        private MvxRecyclerView _recyclerView;
        public TodoViewFragment()
        {
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState); 


            var view = this.BindingInflate(Resource.Layout.todo_view_fragment_layout, null);

            _recyclerView = view.FindViewById<MvvmCross.DroidX.RecyclerView.MvxRecyclerView>(Resource.Id.recycler_view);

            if (_recyclerView != null)
            {
                _recyclerView.HasFixedSize = true;
                var layoutManager = new LinearLayoutManager(this.Activity);
                _recyclerView.SetLayoutManager(layoutManager);
            }

            return view;

            
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();
            ViewModel.ViewDestroy(true);
        }
        public class TodoAdapter : MvxRecyclerAdapter
        {
            public TodoAdapter(IMvxAndroidBindingContext bindingContext) : base(bindingContext)
            {

            }

            public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
            {
                return base.OnCreateViewHolder(parent, viewType);
            }

            public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
            {
                base.OnBindViewHolder(holder, position);
            }

        }

        
    }

    
}
