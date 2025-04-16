using System;
using System.ComponentModel;
using System.Reflection;
using Android.Content;
using Android.Support.V4.Widget;
using Android.Views;
using BajioITUIKIT.Controls;
using BajioITUIKIT.Droid.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(PullToRefreshLayout), typeof(PullToRefreshLayoutRenderer))]
namespace BajioITUIKIT.Droid.Renders
{
    public class PullToRefreshLayoutRenderer : SwipeRefreshLayout, IVisualElementRenderer, SwipeRefreshLayout.IOnRefreshListener
	{

		#region Private Properties

		private bool init;
		private IVisualElementRenderer packed;
		private BindableProperty rendererProperty = null;
		private bool refreshing;

		/// <summary>
		/// Gets the bindable property.
		/// </summary>
		/// <returns>The bindable property.</returns>
		private BindableProperty RendererProperty
		{
			get
			{
				if (rendererProperty != null)
					return rendererProperty;

				var type = Type.GetType("Xamarin.Forms.Platform.Android.Platform, Xamarin.Forms.Platform.Android");
				var prop = type.GetField("RendererProperty", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
				var val = prop.GetValue(null);
				rendererProperty = val as BindableProperty;

				return rendererProperty;
			}
		}

		/// <summary>
		/// Updates the is refreshing.
		/// </summary>
		private void UpdateIsRefreshing()
		{
			try
			{
				Refreshing = RefreshView.IsRefreshing;
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine("Object disposed");
			}

		}

		/// <summary>
		/// Updates the is swipe to refresh enabled.
		/// </summary>
		private void UpdateIsSwipeToRefreshEnabled()
		{
			try
			{
				Enabled = RefreshView.IsPullToRefreshEnabled;
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine("Object disposed");
			}
		}
		#endregion

		#region Public Properties

		/// <summary>
		/// Updates the layout.
		/// </summary>
		public void UpdateLayout()
		{
			Tracker?.UpdateLayout();
		}

		/// <summary>
		/// Gets the tracker.
		/// </summary>
		/// <value>The tracker.</value>
		public VisualElementTracker Tracker { get; private set; }


		/// <summary>
		/// Gets the view group.
		/// </summary>
		/// <value>The view group.</value>
		public ViewGroup ViewGroup => this;

		/// <summary>
		/// Gets the view.
		/// </summary>
		/// <value>The view.</value>
		public Android.Views.View View => this;

		/// <summary>
		/// Gets the element.
		/// </summary>
		/// <value>The element.</value>
		public VisualElement Element { get; private set; }

		/// <summary>
		/// Gets or sets a value indicating whether this
		/// <see cref="Refractored.XamForms.PullToRefresh.Droid.PullToRefreshLayoutRenderer"/> is refreshing.
		/// </summary>
		/// <value><c>true</c> if refreshing; otherwise, <c>false</c>.</value>
		public override bool Refreshing
		{
			get
			{
				return refreshing;
			}
			set
			{
				try
				{
					refreshing = value;
					if (RefreshView != null && RefreshView.IsRefreshing != refreshing)
					{
						RefreshView.IsRefreshing = refreshing;
					}

					if (base.Refreshing == refreshing)
					{
						return;
					}

					base.Refreshing = refreshing;
				}
				catch (Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(string.Format("Error in PullToRefreshLayoutRenderer => method Refreshing :{}", ex.Message));
				}
			}
		}

		/// <summary>
		/// Occurs when element changed.
		/// </summary>
		public event EventHandler<VisualElementChangedEventArgs> ElementChanged;
		public event EventHandler<PropertyChangedEventArgs> ElementPropertyChanged;

		/// <summary>
		/// Helpers to cast our element easily
		/// Will throw an exception if the Element is not correct
		/// </summary>
		/// <value>The refresh view.</value>
		public PullToRefreshLayout RefreshView => Element == null ? null : (PullToRefreshLayout)Element;

		#endregion

		#region Private Methods

		/// <summary>
		/// Managest adding and removing the android viewgroup to our actual swiperefreshlayout
		/// </summary>
		private void UpdateContent()
		{
			if (RefreshView.Content == null)
			{
				return;
			}

			if (packed != null)
			{
				RemoveView(packed.ViewGroup);
			}
			packed = Platform.CreateRenderer(RefreshView.Content);

			try
			{
				RefreshView.Content.SetValue(RendererProperty, packed);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine("Unable to sent renderer property, maybe an issue: " + ex);
			}

			AddView(packed.ViewGroup, LayoutParams.MatchParent);

		}
		#endregion

		#region Portected Methods

		/// <summary>
		/// Cleanup layout.
		/// </summary>
		/// <param name="disposing"></param>
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Setup our SwipeRefreshLayout and register for property changed notifications.
		/// </summary>
		/// <param name="element">Element.</param>
		public void SetElement(VisualElement element)
		{
			var oldElement = Element;

			if (oldElement != null)
			{
				oldElement.PropertyChanged -= HandlePropertyChanged;
			}

			Element = element;
			if (Element != null)
			{
				UpdateContent();
				Element.PropertyChanged += HandlePropertyChanged;
			}

			if (!init)
			{
				init = true;
				Tracker = new VisualElementTracker(this);
				SetOnRefreshListener(this);
			}

			UpdateColors();
			UpdateIsRefreshing();
			UpdateIsSwipeToRefreshEnabled();

			ElementChanged?.Invoke(this, new VisualElementChangedEventArgs(oldElement, Element));
			//ElementChanged(this, new VisualElementChangedEventArgs(oldElement, this.Element));
		}

		/// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
		public PullToRefreshLayoutRenderer(Context context) : base(context)
		{
		}

		/// <summary>
		/// Used for registration with dependency service
		/// </summary>
		new public static void Init()
		{

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
				SetColorSchemeColors(RefreshView.RefreshColor.ToAndroid());
			}
			if (RefreshView.RefreshBackgroundColor != Color.Default)
			{
				SetProgressBackgroundColorSchemeColor(RefreshView.RefreshBackgroundColor.ToAndroid());
			}
		}

		/// <summary>
		/// Gets the size of the desired.
		/// </summary>
		/// <returns>The desired size.</returns>
		/// <param name="widthConstraint">Width constraint.</param>
		/// <param name="heightConstraint">Height constraint.</param>
		public SizeRequest GetDesiredSize(int widthConstraint, int heightConstraint)
		{
			packed.ViewGroup.Measure(widthConstraint, heightConstraint);

			//Measure child here and determine size
			return new SizeRequest(new Size(packed.ViewGroup.MeasuredWidth, packed.ViewGroup.MeasuredHeight));
		}

		/// <summary>
		/// Determines whether this instance can child scroll up.
		/// We do this since the actual swipe refresh can't figure it out
		/// </summary>
		/// <returns><c>true</c> if this instance can child scroll up; otherwise, <c>false</c>.</returns>
		public override bool CanChildScrollUp() => CanScrollUp(packed.ViewGroup);

		/// <summary>
		/// Cans the scroll up.
		/// </summary>
		/// <returns><c>true</c>, if scroll up was caned, <c>false</c> otherwise.</returns>
		/// <param name="view">View.</param>
		public bool CanScrollUp(Android.Views.View view)
		{
			var viewGroup = view as ViewGroup;
			if (viewGroup == null)
			{
				return base.CanChildScrollUp();
			}

			var sdk = (int)Android.OS.Build.VERSION.SdkInt;
			if (sdk >= 16)
			{
				if (viewGroup.IsScrollContainer)
				{
					return base.CanChildScrollUp();
				}
			}

			for (int i = 0; i < viewGroup.ChildCount; i++)
			{
				var child = viewGroup.GetChildAt(i);
				if (child is Android.Widget.AbsListView)
				{
					var list = child as Android.Widget.AbsListView;
					if (list != null)
					{
						if (list.FirstVisiblePosition == 0)
						{
							var subChild = list.GetChildAt(0);

							return subChild != null && subChild.Top != 0;
						}

						return true;
					}

				}
				else if (child is Android.Widget.ScrollView)
				{
					var scrollview = child as Android.Widget.ScrollView;
					return (scrollview.ScrollY <= 0.0);
				}
				else if (child is Android.Webkit.WebView)
				{
					var webView = child as Android.Webkit.WebView;
					return (webView.ScrollY > 0.0);
				}
				else if (child is SwipeRefreshLayout)
				{
					return CanScrollUp(child as ViewGroup);
				}

			}

			return false;
		}

		/// <summary>
		/// The refresh view has been refreshed
		/// </summary>
		public void OnRefresh() => RefreshView?.RefreshCommand?.Execute(null);

		/// <summary>
		/// Handles the property changed.
		/// Update the control and trigger refreshing
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		public void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Content")
			{
				UpdateContent();
			}
			else if (e.PropertyName == PullToRefreshLayout.IsPullToRefreshEnabledProperty.PropertyName)
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
		/// Sets the label for.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public void SetLabelFor(int? id)
		{
			throw new NotImplementedException();
		}
		#endregion

	}
}
