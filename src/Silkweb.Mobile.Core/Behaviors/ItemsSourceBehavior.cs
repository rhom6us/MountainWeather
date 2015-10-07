using System;
using Xamarin.Forms;
using System.Collections;

namespace Silkweb.Mobile.Core.Behaviors
{
    public class ItemsSourceBehavior : Behavior<StackLayout>
    {
        private StackLayout _stackLayout;

        public static readonly BindableProperty ItemsSourceProperty = 
            BindableProperty.Create<ItemsSourceBehavior, IEnumerable>(p => p.ItemsSource, null, BindingMode.Default, null, ItemsSourceChanged);

        public IEnumerable ItemsSource
        { 
            get { return (IEnumerable)GetValue(ItemsSourceProperty); } 
            set { SetValue(ItemsSourceProperty, value); } 
        }

        public static readonly BindableProperty ItemTemplateProperty = 
            BindableProperty.Create<ItemsSourceBehavior, DataTemplate>(p => p.ItemTemplate, null);

        public DataTemplate ItemTemplate
        { 
            get { return (DataTemplate)GetValue(ItemTemplateProperty); } 
            set { SetValue(ItemTemplateProperty, value); } 
        }

        private static void ItemsSourceChanged(BindableObject bindable, IEnumerable oldValue, IEnumerable newValue)
        {
            var behavior = bindable as ItemsSourceBehavior;
            behavior.SetItems();
        }

        private void SetItems()
        {
            _stackLayout.Children.Clear();

            if (ItemsSource == null)
                return;

            foreach (var item in ItemsSource)
                _stackLayout.Children.Add(GetItemView(item));
        }

        private View GetItemView(object item)
        {
            var content = ItemTemplate.CreateContent();
            var view = content as View;
            view.BindingContext = item;
            return view;
        }

        protected override void OnAttachedTo(StackLayout bindable)
        {
            base.OnAttachedTo(bindable);

            bindable.BindingContextChanged += (sender, e) =>
                BindingContext = _stackLayout.BindingContext;

            _stackLayout = bindable;
        }
    }
}

