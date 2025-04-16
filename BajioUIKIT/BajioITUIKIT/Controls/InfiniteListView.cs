using System;
using System.Collections;
using System.Windows.Input;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    public class InfiniteListView : ListView
    {
        /// <summary>
        /// The clear command property
        /// </summary>
        public static readonly BindableProperty LoadMoreCommandProperty = BindableProperty.Create(nameof(InfiniteListView),
            typeof(ICommand), typeof(BajioCustomEditor), null, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the clear command.
        /// </summary>
        /// <value>
        /// The clear command.
        /// </value>
        public ICommand LoadMoreCommand
        {
            get { return (ICommand)GetValue(LoadMoreCommandProperty); }
            set { SetValue(LoadMoreCommandProperty, value); }
        }

        public InfiniteListView()
        {
            ItemAppearing += InfiniteListView_ItemAppearing;
        }

        void InfiniteListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var items = ItemsSource as IList;

            if (items != null && e.Item == items[items.Count - 1])
            {
                if (LoadMoreCommand != null && LoadMoreCommand.CanExecute(null))
                {
                    LoadMoreCommand.Execute(null);
                }
            }
        }
    }
}
