using System;
using System.Collections;
using System.Runtime.CompilerServices;
using BajioITUIKIT.Styles;
using FFImageLoading.Svg.Forms;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    public class CollapsibleListView : StackLayout
    {
        #region Binding Properties
        /// <summary>
        /// The is initially collapsed property
        /// </summary>
        public static readonly BindableProperty IsInitiallyCollapsedProperty =
            BindableProperty.Create(nameof(IsInitiallyCollapsed), typeof(bool), typeof(CollapsibleListView), true);

        /// <summary>
        /// The is header visible property
        /// </summary>
        public static readonly BindableProperty IsHeaderVisibleProperty =
            BindableProperty.Create(nameof(IsHeaderVisible), typeof(bool), typeof(CollapsibleListView), true);

        /// <summary>
        /// The title property
        /// </summary>
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string), typeof(CollapsibleListView));

        /// <summary>
        /// The items property
        /// </summary>
        public static readonly BindableProperty ItemsProperty =
            BindableProperty.Create(nameof(Items), typeof(IList), typeof(CollapsibleListView), default(IList));

        /// <summary>
        /// The item template property
        /// </summary>
        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(CollapsibleListView), default(DataTemplate));

        /// <summary>
        /// The has header list property
        /// </summary>
        public static readonly BindableProperty HasHeaderListProperty =
            BindableProperty.Create(nameof(HasHeaderList), typeof(bool), typeof(CollapsibleListView), false);

        /// <summary>
        /// The item header height property
        /// </summary>
        public static readonly BindableProperty ItemHeaderHeightProperty =
            BindableProperty.Create(nameof(ItemHeaderHeight), typeof(double), typeof(CollapsibleListView), default(double));

        /// <summary>
        /// The item height property
        /// </summary>
        public static readonly BindableProperty ItemHeightProperty =
            BindableProperty.Create(nameof(ItemHeight), typeof(double), typeof(CollapsibleListView), default(double));

        /// <summary>
        /// The is enable collapsed property
        /// </summary>
        public static readonly BindableProperty IsEnableCollapsedProperty =
            BindableProperty.Create(nameof(IsEnableCollapsed), typeof(bool), typeof(CollapsibleListView), true);

        /// <summary>
        /// The header color property
        /// </summary>
        public static readonly BindableProperty HeaderColorProperty =
            BindableProperty.Create(nameof(HeaderColor), typeof(Color), typeof(CollapsibleListView), default(Color));

        /// <summary>
        /// The header text color property
        /// </summary>
        public static readonly BindableProperty HeaderTextColorProperty =
            BindableProperty.Create(nameof(HeaderTextColor), typeof(Color), typeof(CollapsibleListView), default(Color));

        /// <summary>
        /// The SVG icon header property
        /// </summary>
        public static readonly BindableProperty SvgIconHeaderProperty =
            BindableProperty.Create(nameof(SvgIconHeader), typeof(string), typeof(CollapsibleListView), string.Empty);

        /// <summary>
        /// The height header property
        /// </summary>
        public static readonly BindableProperty HeightHeaderProperty =
            BindableProperty.Create(nameof(HeightHeader), typeof(double), typeof(CollapsibleListView), 40.00);

        ///// <summary>
        ///// The style label header property
        ///// </summary>
        //public static readonly BindableProperty StyleLabelHeaderProperty =
        //    BindableProperty.Create(nameof(StyleLabelHeader), typeof(Style), typeof(CollapsibleListView), (Style)Application.Current.Resources["label-bold"]);

        /// <summary>
        /// The title margin porperty.
        /// </summary>
        public static readonly BindableProperty HeaderTitleMarginProperty = BindableProperty.Create(nameof(HeaderTitleMargin),
        typeof(Thickness), typeof(CollapsibleListView), new Thickness(0, 0, 0, 0), BindingMode.TwoWay);

        /// <summary>
        /// The title font size porperty.
        /// </summary>
        public static readonly BindableProperty HeaderTitleSizeProperty = BindableProperty.Create(nameof(HeaderTitleSize),
        typeof(double), typeof(CollapsibleListView), Device.GetNamedSize(NamedSize.Small, typeof(Label)), BindingMode.TwoWay);

        public static readonly BindableProperty LoadMoreProperty = BindableProperty.Create(nameof(LoadMore),
            typeof(EventHandler), typeof(CollapsibleListView), null, BindingMode.TwoWay);

        public EventHandler LoadMore
        {
            set
            {
                SetValue(LoadMoreProperty, value);
            }
            get
            {
                return (EventHandler)GetValue(LoadMoreProperty);
            }
        }
        #endregion

        #region Private Properties
        private int _heighRequestHeader = 40;
        private int _sizeIcon = 32;
        private bool _isCollapsed;
        private bool _isLoaded;
        private StackLayout _headerContainer;
        private StackLayout _header;
        private Label _headerTitle;
        private BajioIcon _headerIcon;
        private StackLayout _content;
        private StackLayout mainviewcontent;
        private DataTemplate _itemTemplate;
        private ContentView _contentGradientView;
        private readonly ImageSourceConverter _imageSourceConverter = new ImageSourceConverter();
        private readonly SvgCachedImage _svgIconImage;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the height header.
        /// </summary>
        /// <value>
        /// The height header.
        /// </value>
        public double HeightHeader
        {
            get
            {
                return (double)GetValue(HeightHeaderProperty);
            }
            set
            {
                SetValue(HeightHeaderProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the SVG icon header.
        /// </summary>
        /// <value>
        /// The SVG icon header.
        /// </value>
        public string SvgIconHeader
        {
            get
            {
                return (string)GetValue(SvgIconHeaderProperty);
            }
            set
            {
                SetValue(SvgIconHeaderProperty, value);
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is initially collapsed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is initially collapsed; otherwise, <c>false</c>.
        /// </value>
        public bool IsInitiallyCollapsed
        {
            get
            {
                return (bool)GetValue(IsInitiallyCollapsedProperty);
            }
            set
            {
                SetValue(IsInitiallyCollapsedProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is header visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is header visible; otherwise, <c>false</c>.
        /// </value>
        public bool IsHeaderVisible
        {
            get
            {
                return (bool)GetValue(IsHeaderVisibleProperty);
            }
            set
            {
                SetValue(IsHeaderVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public IList Items
        {
            get
            {
                return (IList)GetValue(ItemsProperty);
            }
            set
            {
                SetValue(ItemsProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the item template.
        /// </summary>
        /// <value>
        /// The item template.
        /// </value>
        public DataTemplate ItemTemplate
        {
            get
            {
                return (DataTemplate)GetValue(ItemTemplateProperty);
            }
            set
            {
                SetValue(ItemTemplateProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has header list.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has header list; otherwise, <c>false</c>.
        /// </value>
        public bool HasHeaderList
        {
            get
            {
                return (bool)GetValue(HasHeaderListProperty);
            }
            set
            {
                SetValue(HasHeaderListProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the height of the item header.
        /// </summary>
        /// <value>
        /// The height of the item header.
        /// </value>
        public double ItemHeaderHeight
        {
            get
            {
                return (double)GetValue(ItemHeaderHeightProperty);
            }
            set
            {
                SetValue(ItemHeaderHeightProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the height of the item.
        /// </summary>
        /// <value>
        /// The height of the item.
        /// </value>
        public double ItemHeight
        {
            get
            {
                return (double)GetValue(ItemHeightProperty);
            }
            set
            {
                SetValue(ItemHeightProperty, value);
            }
        }





        /// <summary>
        /// Gets or sets a value indicating whether this instance is enable collapsed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is enable collapsed; otherwise, <c>false</c>.
        /// </value>
        public bool IsEnableCollapsed
        {
            get
            {
                return (bool)GetValue(IsEnableCollapsedProperty);
            }
            set
            {
                SetValue(IsEnableCollapsedProperty, value);
            }
        }


        /// <summary>
        /// Gets or sets the color of the header.
        /// </summary>
        /// <value>
        /// The color of the header.
        /// </value>
        public Color HeaderColor
        {
            get
            {
                return (Color)GetValue(HeaderColorProperty);
            }
            set
            {
                SetValue(HeaderColorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the header text.
        /// </summary>
        /// <value>
        /// The color of the header text.
        /// </value>
        public Color HeaderTextColor
        {
            get
            {
                return (Color)GetValue(HeaderTextColorProperty);
            }
            set
            {
                SetValue(HeaderTextColorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the header title margin.
        /// </summary>
        public Thickness HeaderTitleMargin
        {
            get
            {
                return (Thickness)GetValue(HeaderTitleMarginProperty);
            }
            set
            {
                SetValue(HeaderTitleMarginProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the header title font size.
        /// </summary>
        public double HeaderTitleSize
        {
            get
            {
                return (double)GetValue(HeaderTitleSizeProperty);
            }
            set
            {
                SetValue(HeaderTitleSizeProperty, value);
            }
        }

        #endregion

        #region Protected Methods
        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == IsHeaderVisibleProperty.PropertyName)
            {
                _headerContainer.IsVisible = IsHeaderVisible;
            }
            if (propertyName == TitleProperty.PropertyName)
            {
                if (Title != null)
                {
                    _headerTitle.Text = this.Title;
                }
            }
            if (propertyName == ItemsProperty.PropertyName)
            {
                if (Items != null)
                {
                    PopulateList();
                }
                else
                {
                    ClearListContent();
                }
            }

            if (propertyName == ItemTemplateProperty.PropertyName)
            {
                if (ItemTemplate != null)
                {
                    _itemTemplate = ItemTemplate;

                    PopulateList();
                }
            }
            if (propertyName == IsEnableCollapsedProperty.PropertyName)
            {
                _headerIcon.IsVisible = IsEnableCollapsed;
            }
            if (propertyName == HeaderColorProperty.PropertyName)
            {
                _contentGradientView.BackgroundColor = HeaderColor;
            }
            if (propertyName == HeaderTextColorProperty.PropertyName)
            {
                _headerTitle.TextColor = HeaderTextColor;
                _headerIcon.Color = HeaderTextColor;
            }
            if (propertyName == SvgIconHeaderProperty.PropertyName)
            {
                var xfSource = _imageSourceConverter.ConvertFromInvariantString(SvgIconHeader) as ImageSource;
                _svgIconImage.Source = new SvgImageSource(xfSource, 0, 0, true);
                _header.Children.Insert(0, _svgIconImage);
                _header.HorizontalOptions = LayoutOptions.FillAndExpand;
                _headerTitle.HorizontalOptions = LayoutOptions.FillAndExpand;
                _contentGradientView.HorizontalOptions = LayoutOptions.FillAndExpand;
                _headerIcon.HorizontalOptions = LayoutOptions.End;
            }
            if (propertyName == HeightHeaderProperty.PropertyName)
            {
                _contentGradientView.HeightRequest = HeightHeader;
            }
            if (propertyName == HasHeaderListProperty.PropertyName)
            {
                if (HasHeaderList)
                {
                    Children.Insert(1, mainviewcontent);
                }
            }
            if (propertyName == HeaderTitleMarginProperty.PropertyName)
            {
                _headerTitle.Margin = HeaderTitleMargin;
            }
            if (propertyName == HeaderTitleSizeProperty.PropertyName)
            {
                if (HeaderTitleSizeProperty != null)
                {
                    _headerTitle.FontSize = HeaderTitleSize;
                }
            }
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Clears the content of the list.
        /// </summary>
        private void ClearListContent()
        {
            _content.Children.Clear();
        }

        /// <summary>
        /// Populates the list.
        /// </summary>
        private void PopulateList()
        {
            _content.Children.Clear();

            if (Items != null)
            {
                foreach (object item in this.Items)
                {
                    if (_itemTemplate != null)
                    {
                        var template = (View)_itemTemplate.CreateContent();
                        template.BindingContext = item;
                        _content.Children.Add(template);
                    }
                }



                if (!IsInitiallyCollapsed && !_isLoaded)
                {
                    ToggleCollapsed();
                    _isLoaded = true;
                }
            }
        }

        /// <summary>
        /// Toggles the collapsed.
        /// </summary>
        private void ToggleCollapsed()
        {
            if (_isCollapsed)
            {
                _headerIcon.Icon = "keyboard-arrow-up";

                _content.IsVisible = true;
                if (HasHeaderList)
                {
                    mainviewcontent.HeightRequest = ItemHeaderHeight;
                    mainviewcontent.IsVisible = true;
                }
                _isCollapsed = false;
            }
            else
            {
                _headerIcon.Icon = "keyboard-arrow-down";
                _content.IsVisible = false;
                if (HasHeaderList)
                {
                    mainviewcontent.HeightRequest = 0;
                    mainviewcontent.IsVisible = false;
                }
                _isCollapsed = true;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="CollapsibleListView"/> class.
        /// </summary>
        public CollapsibleListView()
        {
            _svgIconImage = new SvgCachedImage()
            {
                WidthRequest = 18,
                HeightRequest = 16,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(0)
            };

            _headerContainer = new StackLayout
            {
                BackgroundColor = Color.Transparent,
                Padding = new Thickness(1, 0, 1, 0),
                IsVisible = IsHeaderVisible
            };

            _header = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = Color.Transparent,
                Padding = new Thickness(10, 0, 10, 0),
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            _headerTitle = new Label
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                TextColor = Theme.TextColorPrimary,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center
            };

            _headerIcon = new BajioIcon
            {
                Size = _sizeIcon,
                Margin = new Thickness(2, 2, 4, 2),
                VerticalOptions = LayoutOptions.Center,
                Color = Theme.TextColorPrimary,
                Icon = "keyboard-arrow-down",
                HorizontalOptions = LayoutOptions.End
            };

            _contentGradientView = new ContentView
            {
                BackgroundColor = Theme.PrimaryColor,
                Content = _headerContainer,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HeightRequest = _heighRequestHeader
            };

            _content = new StackLayout
            {
                IsVisible = false,
                Spacing = 0
            };

            mainviewcontent = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 0,
                IsVisible = false,
                Spacing = 0
            };

            _isCollapsed = true;
            Spacing = 0;
            BackgroundColor = Color.Transparent;
            Padding = new Thickness(0);

            _header.Children.Add(_headerTitle);
            _header.Children.Add(_headerIcon);
            _header.GestureRecognizers.Add(
                new TapGestureRecognizer
                {
                    Command = new Command(ToggleCollapsed)
                }
            );

            _headerIcon.ClickedIcon = new Command(ToggleCollapsed);

            _headerContainer.Children.Add(_header);

            Children.Add(_contentGradientView);
            Children.Add(_content);
        }
        #endregion
    }
}
