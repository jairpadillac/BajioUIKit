
using System;
using System.Diagnostics;
using BajioITUIKIT.Controls;
using BajioITUIKIT.iOS.Renders;
using UIKit;
using WebKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(PullToRefreshLayout), typeof(PullToRefreshLayoutRenderer))]
namespace BajioITUIKIT.iOS.Renders
{
    public class PullToRefreshLayoutRenderer : ViewRenderer<PullToRefreshLayout, UIView>
    {

        #region Private Properties

        private UIRefreshControl refreshControl;
        private UIScrollView uiScrollView;
        private WKWebView wkWebView;
        private UITableView uiTableView;
        private UICollectionView uiCollectionView;
        private BindableProperty rendererProperty;
        private bool isRefreshing;

        /// <summary>
        /// Gets the refresh view.
        /// </summary>
        /// <value>The refresh view.</value>
        private PullToRefreshLayout RefreshView
        {
            get { return Element; }
        }

        #endregion

        #region Public Properties

        #endregion

        #region Private Methods

        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        new public static void Init()
        {
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Raises the element changed event.
        /// </summary>
        /// <param name="e">E.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<PullToRefreshLayout> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }

            refreshControl = new UIRefreshControl();

            refreshControl.ValueChanged += OnRefresh;

            try
            {
                TryInsertRefresh(this);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("View is not supported in PullToRefreshLayout: " + ex);
            }

            UpdateColors();
            UpdateIsRefreshing();
            UpdateIsSwipeToRefreshEnabled();
        }

        /// <summary>
        /// Raises the element property changed event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == PullToRefreshLayout.IsPullToRefreshEnabledProperty.PropertyName)
            {
                UpdateIsSwipeToRefreshEnabled();
            }
            else if (e.PropertyName == PullToRefreshLayout.IsRefreshingProperty.PropertyName)
            {
                UpdateIsRefreshing();
            }
            else if (e.PropertyName == PullToRefreshLayout.RefreshColorProperty.PropertyName)
            {
                UpdateColors();
            }
            else if (e.PropertyName == PullToRefreshLayout.RefreshBackgroundColorProperty.PropertyName)
            {
                UpdateColors();
            }
        }

        /// <summary>
        /// Dispose the specified disposing.
        /// </summary>
        /// <param name="disposing">If set to <c>true</c> disposing.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (refreshControl != null)
            {
                refreshControl.ValueChanged -= OnRefresh;
            }

            uiTableView = null;
            uiCollectionView = null;
            wkWebView = null;
            uiScrollView = null;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Tries the insert refresh.
        /// </summary>
        /// <returns><c>true</c>, if insert refresh was tryed, <c>false</c> otherwise.</returns>
        /// <param name="view">View.</param>
        /// <param name="index">Index.</param>
        public bool TryInsertRefresh(UIView view, int index = 0)
        {
            if (view is UITableView)
            {
                uiTableView = view as UITableView;
                view.InsertSubview(refreshControl, index);
                return true;
            }

            if (view is UICollectionView)
            {
                uiCollectionView = view as UICollectionView;
                view.InsertSubview(refreshControl, index);
                return true;
            }

            wkWebView = view as WKWebView;
            if (wkWebView != null)
            {
                wkWebView.ScrollView.InsertSubview(refreshControl, index);
                return true;
            }

            uiScrollView = view as UIScrollView;
            if (uiScrollView != null)
            {
                view.InsertSubview(refreshControl, index);
                uiScrollView.AlwaysBounceVertical = true;
                return true;
            }

            if (view.Subviews == null)
                return false;

            for (int i = 0; i < view.Subviews.Length; i++)
            {
                var control = view.Subviews[i];
                if (TryInsertRefresh(control, i))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the bindable property.
        /// </summary>
        /// <returns>The bindable property.</returns>
        public BindableProperty RendererProperty
        {
            get
            {
                if (rendererProperty != null)
                {
                    return rendererProperty;
                }

                var type = Type.GetType("Xamarin.Forms.Platform.iOS.Platform, Xamarin.Forms.Platform.iOS");
                var prop = type.GetField("RendererProperty");
                var val = prop.GetValue(null);
                rendererProperty = val as BindableProperty;

                return rendererProperty;
            }
        }

        /// <summary>
        /// Updates the colors.
        /// </summary>
        public void UpdateColors()
        {
            if (RefreshView == null)
            {
                return;
            }
            if (RefreshView.RefreshColor != Color.Default)
            {
                refreshControl.TintColor = RefreshView.RefreshColor.ToUIColor();
            }
            if (RefreshView.RefreshBackgroundColor != Color.Default)
            {
                refreshControl.BackgroundColor = RefreshView.RefreshBackgroundColor.ToUIColor();
            }
        }

        /// <summary>
        /// Updates the is refreshing.
        /// </summary>
        public void UpdateIsRefreshing()
        {
            IsRefreshing = RefreshView.IsRefreshing;
        }

        /// <summary>
        /// Updates the is swipe to refresh enabled.
        /// </summary>
        public void UpdateIsSwipeToRefreshEnabled()
        {
            refreshControl.Enabled = RefreshView.IsPullToRefreshEnabled;
            refreshControl.UserInteractionEnabled = RefreshView.IsPullToRefreshEnabled;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is refreshing.
        /// </summary>
        /// <value><c>true</c> if this instance is refreshing; otherwise, <c>false</c>.</value>
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                isRefreshing = value;
                if (isRefreshing)
                {
                    refreshControl.BeginRefreshing();
                }
                else
                {
                    refreshControl.EndRefreshing();
                }
            }
        }

        /// <summary>
        /// The refresh view has been refreshed
        /// </summary>
        public void OnRefresh(object sender, EventArgs e)
        {
            //someone pulled down to refresh or it is done
            if (RefreshView == null)
            {
                return;
            }

            var command = RefreshView.RefreshCommand;
            if (command == null)
            {
                return;
            }

            command.Execute(null);
        }

        #endregion

    }

}
