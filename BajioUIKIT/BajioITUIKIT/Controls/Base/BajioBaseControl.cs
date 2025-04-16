using System;
using System.Linq;
using System.Windows.Input;
using FFImageLoading.Svg.Forms;
using BajioITUIKIT.Enums;
using BajioITUIKIT.Styles;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    public class BajioBaseControl : Grid
    {
        #region Public Properties
        /// <summary>
        /// Gets or sets the lbl title.
        /// </summary>
        /// <value>The lbl title.</value>
        public Label lblTitle { get; set; }

        /// <summary>
        /// Gets or sets the clear icon.
        /// </summary>
        /// <value>The clear icon.</value>
        public BajioIcon ClearIcon { get; set; }

        /// <summary>
        /// Gets or sets the clear icon.
        /// </summary>
        /// <value>The clear icon.</value>
        public BajioIcon CustomIcon { get; set; }

        /// <summary>
        /// Gets or sets the custom svg icon.
        /// </summary>
        /// <value>The custom svg icon.</value>
        public BajioSvgIcon CustomSvgIcon { get; set; }

        /// <summary>
        /// Gets or sets the lbl error message.
        /// </summary>
        /// <value>The lbl error message.</value>
        public Label lblErrorMessage { get; set; }

        #region Elements
        /// <summary>
        /// The tool tip icon.
        /// </summary>
        public SvgCachedImage ToolTipIcon;
        #endregion

        #region Bindable Properties

        #region Properties
        /// <summary>
        /// The container control property.
        /// </summary>
        public static readonly BindableProperty ContainerControlProperty =
            BindableProperty.Create(nameof(ContainerControl), typeof(BajioContainerControl), typeof(BajioContainerControl), null, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the container control.
        /// </summary>
        /// <value>The container control.</value>
        public BajioContainerControl ContainerControl
        {
            get { return (BajioContainerControl)GetValue(ContainerControlProperty); }
            set { SetValue(ContainerControlProperty, value); }
        }

        /// <summary>
        /// The title property.
        /// </summary>
        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string), typeof(BajioBaseControl), string.Empty, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// The title font size property.
        /// </summary>
        public static readonly BindableProperty TitleFontSizeProperty =
            BindableProperty.Create(nameof(TitleFontSize), typeof(double), typeof(BajioBaseControl), 12d, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the size of the title font.
        /// </summary>
        /// <value>The size of the title font.</value>
        public double TitleFontSize
        {
            get { return (double)GetValue(TitleFontSizeProperty); }
            set { SetValue(TitleFontSizeProperty, value); }
        }

        /// <summary>
        /// The enabled property.
        /// </summary>
        public static readonly BindableProperty EnabledProperty =
            BindableProperty.Create(nameof(Enabled), typeof(bool), typeof(BajioBaseControl), true, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:BajioITUIKIT.Controls.BajioBaseControl"/> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public bool Enabled
        {
            get { return (bool)GetValue(EnabledProperty); }
            set { SetValue(EnabledProperty, value); }
        }

        /// <summary>
        /// The error property.
        /// </summary>
        public static readonly BindableProperty ErrorProperty =
            BindableProperty.Create(nameof(Error), typeof(bool), typeof(BajioBaseControl), false, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:BajioITUIKIT.Controls.BajioBaseControl"/> is error.
        /// </summary>
        /// <value><c>true</c> if error; otherwise, <c>false</c>.</value>
        public bool Error
        {
            get { return (bool)GetValue(ErrorProperty); }
            set { SetValue(ErrorProperty, value); }
        }

        /// <summary>
        /// The error message property.
        /// </summary>
        public static readonly BindableProperty ErrorMessageProperty =
            BindableProperty.Create(nameof(ErrorMessage), typeof(string), typeof(BajioBaseControl), string.Empty, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>The error message.</value>
        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }

        /// <summary>
        /// The error message font size property.
        /// </summary>
        public static readonly BindableProperty ErrorMessageFontSizeProperty =
            BindableProperty.Create(nameof(ErrorMessageFontSize), typeof(double), typeof(BajioBaseControl), 12d, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the size of the error message font.
        /// </summary>
        /// <value>The size of the error message font.</value>
        public double ErrorMessageFontSize
        {
            get { return (double)GetValue(ErrorMessageFontSizeProperty); }
            set { SetValue(ErrorMessageFontSizeProperty, value); }
        }

        /// <summary>
        /// The clear button enable property.
        /// </summary>
        public static readonly BindableProperty ClearButtonEnableProperty =
            BindableProperty.Create(nameof(ClearButtonEnable), typeof(bool), typeof(BajioBaseControl), false, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:BajioITUIKIT.Controls.BajioBaseControl"/> clear
        /// button enable.
        /// </summary>
        /// <value><c>true</c> if clear button enable; otherwise, <c>false</c>.</value>
        public bool ClearButtonEnable
        {
            get { return (bool)GetValue(ClearButtonEnableProperty); }
            set { SetValue(ClearButtonEnableProperty, value); }
        }

        /// <summary>
        /// The tool tip enable property.
        /// </summary>
        public static readonly BindableProperty ToolTipEnableProperty =
            BindableProperty.Create(nameof(ToolTipButtonEnable), typeof(bool), typeof(BajioBaseControl), false, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:BajioITUIKIT.Controls.BajioBaseControl"/> tool
        /// tip button enable.
        /// </summary>
        /// <value><c>true</c> if tool tip button enable; otherwise, <c>false</c>.</value>
        public bool ToolTipButtonEnable
        {
            get { return (bool)GetValue(ToolTipEnableProperty); }
            set { SetValue(ToolTipEnableProperty, value); }
        }

        /// <summary>
        /// The tool tip image property.
        /// </summary>
        public static readonly BindableProperty ToolTipImageProperty =
            BindableProperty.Create(nameof(ToolTipImage), typeof(string), typeof(BajioBaseControl), "Shared_Tooltip.svg", BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the tool tip image.
        /// </summary>
        /// <value>The tool tip image.</value>
        public string ToolTipImage
        {
            get { return (string)GetValue(ToolTipImageProperty); }
            set { SetValue(ToolTipImageProperty, value); }
        }

        /// <summary>
        /// The tool tip message property.
        /// </summary>
        public static readonly BindableProperty ToolTipMessageProperty =
            BindableProperty.Create(nameof(ToolTipMessage), typeof(string), typeof(BajioBaseControl), string.Empty, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the tool tip message.
        /// </summary>
        /// <value>The tool tip message.</value>
        public string ToolTipMessage
        {
            get { return (string)GetValue(ToolTipMessageProperty); }
            set { SetValue(ToolTipMessageProperty, value); }
        }

        /// <summary>
        /// The custom icon name property.
        /// </summary>
        public static readonly BindableProperty CustomIconNameProperty =
            BindableProperty.Create(nameof(CustomIconName), typeof(string), typeof(BajioBaseControl), string.Empty);

        /// <summary>
        /// Gets or sets the name of the custom icon.
        /// </summary>
        /// <value>The name of the custom icon.</value>
        public string CustomIconName
        {
            get { return (string)GetValue(CustomIconNameProperty); }
            set { SetValue(CustomIconNameProperty, value); }
        }

        /// <summary>
        /// The custom hide icon name property.
        /// </summary>
        public static readonly BindableProperty CustomHideIconNameProperty =
            BindableProperty.Create(nameof(CustomHideIconName), typeof(string), typeof(BajioBaseControl), string.Empty);

        /// <summary>
        /// Gets or sets the name of the custom hide icon.
        /// </summary>
        /// <value>The name of the custom hide icon.</value>
        public string CustomHideIconName
        {
            get { return (string)GetValue(CustomHideIconNameProperty); }
            set { SetValue(CustomHideIconNameProperty, value); }
        }

        /// <summary>
        /// The custom icon name property which is available to Show and Hide.
        /// </summary>
        public static readonly BindableProperty CustomIconNameHidingProperty =
            BindableProperty.Create(nameof(CustomIconNameHiding), typeof(string), typeof(BajioBaseControl), string.Empty);

        /// <summary>
        /// Gets or sets the name of the custom icon which is available to Show and Hide.
        /// </summary>
        /// <value>The name of the custom icon.</value>
        public string CustomIconNameHiding
        {
            get { return (string)GetValue(CustomIconNameHidingProperty); }
            set { SetValue(CustomIconNameHidingProperty, value); }
        }

        /// <summary>
        /// The custom hide icon name property which is available to Show and Hide.
        /// </summary>
        public static readonly BindableProperty CustomHideIconNameHidingProperty =
            BindableProperty.Create(nameof(CustomHideIconNameHiding), typeof(string), typeof(BajioBaseControl), string.Empty);

        /// <summary>
        /// Gets or sets the name of the custom hide icon which is available to Show and Hide.
        /// </summary>
        /// <value>The name of the custom hide icon.</value>
        public string CustomHideIconNameHiding
        {
            get { return (string)GetValue(CustomHideIconNameHidingProperty); }
            set { SetValue(CustomHideIconNameHidingProperty, value); }
        }


        /// <summary>
        /// The custom icon color property.
        /// </summary>
        public static readonly BindableProperty CustomIconColorProperty =
            BindableProperty.Create(nameof(CustomIconColor), typeof(Color), typeof(BajioBaseControl), Theme.EntryClearButtonColor);

        /// <summary>
        /// Gets or sets the color of the custom icon.
        /// </summary>
        /// <value>The color of the custom icon.</value>
        public Color CustomIconColor
        {
            get { return (Color)GetValue(CustomIconColorProperty); }
            set { SetValue(CustomIconColorProperty, value); }
        }

        /// <summary>
        /// The show or hide enable property.
        /// </summary>
        public static readonly BindableProperty ShowOrHideEnableProperty =
            BindableProperty.Create(nameof(ShowOrHideEnable), typeof(bool), typeof(BajioBaseControl), false, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:BajioITUIKIT.Controls.BajioBaseControl"/> show
        /// or hide enable.
        /// </summary>
        /// <value><c>true</c> if show or hide enable; otherwise, <c>false</c>.</value>
        public bool ShowOrHideEnable
        {
            get { return (bool)GetValue(ShowOrHideEnableProperty); }
            set { SetValue(ShowOrHideEnableProperty, value); }
        }

        /// <summary>
        /// The is password property.
        /// </summary>
        public static readonly BindableProperty IsPasswordVisibleProperty =
            BindableProperty.Create(nameof(IsPasswordVisible), typeof(bool), typeof(BajioBaseControl), false, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:BajioITUIKIT.Controls.BajioBaseControl"/> is
        /// password visible.
        /// </summary>
        /// <value><c>true</c> if is password visible; otherwise, <c>false</c>.</value>
        public bool IsPasswordVisible
        {
            get { return (bool)GetValue(IsPasswordVisibleProperty); }
            set
            {
                SetValue(IsPasswordVisibleProperty, value);
            }
        }
        /// <summary>
        /// The is custom icon property.
        /// </summary>
        public static readonly BindableProperty IsCustomIconProperty =
            BindableProperty.Create(nameof(IsCustomIcon), typeof(bool), typeof(BajioBaseControl), false, BindingMode.TwoWay);
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:BajioITUIKIT.Controls.BajioBaseControl"/> is
        /// custom icon.
        /// </summary>
        /// <value><c>true</c> if is custom icon; otherwise, <c>false</c>.</value>
        public bool IsCustomIcon
        {
            get
            {
                return (bool)GetValue(IsCustomIconProperty);
            }
            set
            {
                SetValue(IsCustomIconProperty, value);
            }
        }

        /// <summary>
        /// The hide icon and text color property.
        /// </summary>
        public static readonly BindableProperty HideIconAndTextColorProperty =
            BindableProperty.Create(nameof(HideIconAndTextColor), typeof(Color), typeof(BajioBaseControl), Color.Black, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the color of the hide icon and text.
        /// </summary>
        /// <value>The color of the hide icon and text.</value>
        public Color HideIconAndTextColor
        {
            get { return (Color)GetValue(HideIconAndTextColorProperty); }
            set { SetValue(HideIconAndTextColorProperty, value); }
        }

        /// <summary>
        /// The command parameter property.
        /// </summary>
        public static readonly BindableProperty TitleFontAttributesProperty =
            BindableProperty.Create(nameof(TitleFontAttributes), typeof(FontAttributes), typeof(BajioEntry), FontAttributes.None);

        /// <summary>
        /// Gets or sets the command parameter.
        /// </summary>
        /// <value>The command parameter.</value>
        public FontAttributes TitleFontAttributes
        {
            get { return (FontAttributes)GetValue(TitleFontAttributesProperty); }
            set { SetValue(TitleFontAttributesProperty, value); }
        }

        /// <summary>
        /// The command parameter property.
        /// </summary>
        public static readonly BindableProperty MarginShowOrHideIconProperty =
            BindableProperty.Create(nameof(MarginShowOrHideIcon), typeof(Thickness), typeof(BajioEntry), new Thickness(0));

        /// <summary>
        /// Gets or sets the command parameter.
        /// </summary>
        /// <value>The command parameter.</value>
        public Thickness MarginShowOrHideIcon
        {
            get { return (Thickness)GetValue(MarginShowOrHideIconProperty); }
            set { SetValue(MarginShowOrHideIconProperty, value); }
        }

        #endregion

        #region Commands
        /// <summary>
        /// The clear command property.
        /// </summary>
        public static readonly BindableProperty ClearCommandProperty =
            BindableProperty.Create(nameof(ClearCommand), typeof(ICommand), typeof(BajioBaseControl), null, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the clear command.
        /// </summary>
        /// <value>The clear command.</value>
        public ICommand ClearCommand
        {
            get { return (ICommand)GetValue(ClearCommandProperty); }
            set { SetValue(ClearCommandProperty, value); }
        }

        /// <summary>
        /// The tool tip command property.
        /// </summary>
        public static readonly BindableProperty ToolTipCommandProperty =
            BindableProperty.Create(nameof(ToolTipCommand), typeof(ICommand), typeof(BajioBaseControl), null, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the tool tip command.
        /// </summary>
        /// <value>The tool tip command.</value>
        public ICommand ToolTipCommand
        {
            get { return (ICommand)GetValue(ToolTipCommandProperty); }
            set { SetValue(ToolTipCommandProperty, value); }
        }

        /// <summary>
        /// The clear command parameter property.
        /// </summary>
        public static readonly BindableProperty ClearCommandParameterProperty =
            BindableProperty.Create(nameof(ClearCommandParameter), typeof(object), typeof(BajioBaseControl), null, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the clear command parameter.
        /// </summary>
        /// <value>The clear command parameter.</value>
        public object ClearCommandParameter
        {
            get { return GetValue(ClearCommandParameterProperty); }
            set { SetValue(ClearCommandParameterProperty, value); }
        }

        /// <summary>
        /// The space title entry property.
        /// </summary>
        public static readonly BindableProperty MarginTitleProperty =
            BindableProperty.Create(nameof(MarginTitle), typeof(Thickness), typeof(BajioBaseControl), new Thickness(0, 0, 0, 10), BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the space title entry.
        /// </summary>
        /// <value>The space title entry.</value>
        public Thickness MarginTitle
        {
            get { return (Thickness)GetValue(MarginTitleProperty); }
            set { SetValue(MarginTitleProperty, value); }
        }

        /// <summary>
        /// The show or hide icon text size property.
        /// </summary>
        public static readonly BindableProperty ShowOrHideIconTextSizeProperty =
            BindableProperty.Create(nameof(ShowOrHideIconTextSize), typeof(int), typeof(BajioBaseControl), 12, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the size of the show or hide icon text.
        /// </summary>
        /// <value>The size of the show or hide icon text.</value>
        public int ShowOrHideIconTextSize
        {
            get { return (int)GetValue(ShowOrHideIconTextSizeProperty); }
            set { SetValue(ShowOrHideIconTextSizeProperty, value); }
        }

        /// <summary>
        /// The title font family property.
        /// </summary>
        public static readonly BindableProperty TitleStyleProperty = BindableProperty.Create(nameof(TitleStyle), typeof(FontEnum), typeof(BajioBaseControl), FontEnum.None, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the title font family.
        /// </summary>
        /// <value>The title font family.</value>
        public FontEnum TitleStyle
        {
            get { return (FontEnum)GetValue(TitleStyleProperty); }
            set { SetValue(TitleStyleProperty, value); }
        }
        /// <summary>
        /// The title color property.
        /// </summary>
        public static readonly BindableProperty TitleColorStyleProperty = BindableProperty.Create(nameof(TitleColorStyle), typeof(Color), typeof(BajioBaseControl), Theme.TextColorSecondary, BindingMode.TwoWay);
        /// <summary>
        /// Gets or sets the title color style.
        /// </summary>
        /// <value>The title color style.</value>
        public Color TitleColorStyle
        {
            get { return (Color)GetValue(TitleColorStyleProperty); }
            set { SetValue(TitleColorStyleProperty, value); }
        }

        /// <summary>
        /// The tooltip background color property.
        /// </summary>
        public static readonly BindableProperty TooltipBackgroundColorProperty = BindableProperty.Create(nameof(TooltipBackgroundColor), typeof(Color), typeof(BajioBaseControl), Theme.AlertBackgroundPrimary, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the color of the tooltip background.
        /// </summary>
        /// <value>The color of the tooltip background.</value>
        public Color TooltipBackgroundColor
        {
            get { return (Color)GetValue(TooltipBackgroundColorProperty); }
            set { SetValue(TooltipBackgroundColorProperty, value); }
        }

        /// <summary>
        /// The tooltip text color property.
        /// </summary>
        public static readonly BindableProperty TooltipTextColorProperty = BindableProperty.Create(nameof(TooltipTextColor), typeof(Color), typeof(BajioBaseControl), Theme.TextColorPrimary, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the color of the tooltip text.
        /// </summary>
        /// <value>The color of the tooltip text.</value>
        public Color TooltipTextColor
        {
            get { return (Color)GetValue(TooltipTextColorProperty); }
            set { SetValue(TooltipTextColorProperty, value); }
        }
        #endregion

        #endregion

        #endregion

        #region Private Properties
        private ImageSourceConverter _imageSourceConverter;
        private StackLayout _titleStack;
        private StackLayout _titleAndQuestionStack;
        private StackLayout _clearAndIconStack;
        private BajioIcon _showHideIcon;
        private BajioSvgIcon _showHideIconSvg;
        private Label _showHideText;
        #endregion

        #region Protected Properties
        protected StackLayout _showOrHideStack = new StackLayout();

        #endregion

        #region Public Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BajioITUIKIT.Controls.BajioBaseControl"/> class.
        /// </summary>
        public BajioBaseControl()
        {
            _showHideIcon = new BajioIcon();
            _showHideIconSvg = new BajioSvgIcon();
            _showHideText = new Label();
            lblTitle = new Label();
            this.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
            this.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
            this.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });

            this.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            this.RowSpacing = 0;
            this.ColumnSpacing = 0;
        }

        /// <summary>
        /// On appearing event handler.
        /// </summary>
        public delegate void OnAppearingEventHandler(object sender, EventArgs e);

        /// <summary>
        /// Occurs when appearing.
        /// </summary>
        public event OnAppearingEventHandler Appearing;

        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        /// <value>The arguments.</value>
        public EventArgs Args { get; set; }

        /// <summary>
        /// Ons the appearing.
        /// </summary>
        /// <param name="e">E.</param>
        public void OnAppearing(EventArgs e)
        {
            if (Appearing != null)
            {
                Appearing(this, e);
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Ons the property changed.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(ContainerControl))
            {
                ContainerControl.RowSpacing = 0;
                ContainerControl.ColumnSpacing = 0;
                ContainerControl.Padding = new Thickness(0);
                ContainerControl.Margin = new Thickness(0);
                ContainerControl.BindingContext = this;
                ContainerControl.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
                ContainerControl.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                ContainerControl.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) });
                ContainerControl.VerticalOptions = LayoutOptions.CenterAndExpand;
                this.Children.Add(ContainerControl, 0, 1);
                return;
            }

            if (propertyName == nameof(ClearButtonEnable))
            {
                OnClearButtonEnable();
                return;
            }

            if (propertyName == nameof(ToolTipButtonEnable))
            {
                InitTitleLayout();
                if (ToolTipButtonEnable && _titleAndQuestionStack.Children.FirstOrDefault(cl => cl.StyleId == "tooltipbutton") == null)
                {
                    ToolTipIcon = new SvgCachedImage()
                    {
                        StyleId = "tooltipbutton",
                        WidthRequest = 18,
                        HeightRequest = 16,
                        VerticalOptions = LayoutOptions.Center,
                        Margin = new Thickness(5, 0, 5, 0)
                    };

                    _imageSourceConverter = new ImageSourceConverter();
                    var xfSource = _imageSourceConverter.ConvertFromInvariantString(ToolTipImage) as ImageSource;
                    ToolTipIcon.Source = new SvgImageSource(xfSource, 0, 0, true);
                    ToolTipIcon.GestureRecognizers.Add(new TapGestureRecognizer
                    {
                        Command = new Command(OnToolTip)
                    });

                    _titleAndQuestionStack.Children.Add(ToolTipIcon);
                }
                return;
            }

            if (propertyName == nameof(Error))
            {
                AddError();
                return;
            }

            if (propertyName == nameof(ErrorMessage))
            {
                AddError();
                return;
            }

            if (propertyName == nameof(Title))
            {
                InitTitleLayout();
                if (!string.IsNullOrEmpty(Title) && _titleAndQuestionStack.Children.FirstOrDefault(cl => cl.StyleId == "lbltitle") == null)
                {
                    lblTitle.StyleId = "lbltitle";
                    lblTitle.Text = Title;
                    lblTitle.HorizontalOptions = LayoutOptions.StartAndExpand;
                    lblTitle.TextColor = TitleColorStyle;
                    lblTitle.FontSize = TitleFontSize;
                    _titleAndQuestionStack.Children.Add(lblTitle);
                }
                return;
            }

            if (propertyName == nameof(TitleFontSize))
            {
                var title = _titleAndQuestionStack?.Children.FirstOrDefault(cl => cl.StyleId == "lbltitle");
                if (title != null)
                {
                    (title as Label).FontSize = TitleFontSize;
                }
            }

            if (propertyName == nameof(TitleColorStyle))
            {
                var title = _titleAndQuestionStack?.Children.FirstOrDefault(cl => cl.StyleId == "lbltitle");
                if (title != null)
                {
                    (title as Label).TextColor = TitleColorStyle;
                }
            }

            if (propertyName == nameof(CustomIconName))
            {
                InitClearAndIconLayout();
                if (!string.IsNullOrEmpty(CustomIconName)
                    && _clearAndIconStack.Children.FirstOrDefault(cl => cl.StyleId == "customicon") == null)
                {
                    if (CustomIconName.Contains(".svg") && !IsCustomIcon)
                    {
                        CustomSvgIcon = new BajioSvgIcon
                        {
                            StyleId = "customicon",
                            Icon = CustomIconName,
                            BindingContext = this,
                            WidthRequest = (int)Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                            VerticalOptions = LayoutOptions.CenterAndExpand,
                            HorizontalOptions = LayoutOptions.CenterAndExpand,
                            Orientation = StackOrientation.Horizontal,
                            Margin = new Thickness(1)
                        };
                        CustomSvgIcon.GestureRecognizers.Add(new TapGestureRecognizer
                        {
                            Command = new Command(OnShowOrHideCustomSvgTapped)
                        });
                        _clearAndIconStack.Children.Add(CustomSvgIcon);
                    }
                    else
                    {
                        CustomIcon = new BajioIcon()
                        {
                            StyleId = "customicon",
                            Icon = CustomIconName,
                            BindingContext = this,
                            Size = (int)Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                            VerticalOptions = LayoutOptions.CenterAndExpand,
                            HorizontalOptions = LayoutOptions.CenterAndExpand,
                            Orientation = StackOrientation.Horizontal,
                            Color = CustomIconColor,
                            Margin = new Thickness(1)
                        };
                        CustomIcon.GestureRecognizers.Add(new TapGestureRecognizer
                        {
                            Command = new Command(OnShowOrHideCustomTapped)
                        });
                        _clearAndIconStack.Children.Add(CustomIcon);
                    }
                }
                return;
            }

            if (propertyName == nameof(CustomIconColor))
            {
                if (!string.IsNullOrEmpty(CustomIconName))
                {
                    InitClearAndIconLayout();
                    if (!CustomIconName.Contains(".svg"))
                    {
                        var customIcon = _clearAndIconStack.Children.FirstOrDefault(cl => cl.StyleId == "customicon");
                        if (customIcon != null)
                        {
                            ((BajioIcon)customIcon).Color = CustomIconColor;
                        }
                    }
                }
                _showHideIcon.Color = CustomIconColor;
                _showHideText.TextColor = CustomIconColor;

                return;
            }

            if (propertyName == nameof(ShowOrHideIconTextSize))
            {
                _showHideIcon.Size = ShowOrHideIconTextSize + 4;
                _showHideText.FontSize = ShowOrHideIconTextSize;
            }
            if (propertyName == nameof(TitleStyle))
            {
                //lblTitle.Style = GetFontStyle(TitleStyle);
            }
            if (propertyName == nameof(ShowOrHideEnable))
            {
                InitTitleLayout();
                InitShowOrHideLayout();
                if (ShowOrHideEnable && _showOrHideStack.Children.FirstOrDefault(cl => cl.StyleId == "showorhideicon") == null)
                {

                    _showHideIcon.StyleId = "showorhideicon";
                    _showHideIcon.Icon = "fa-eye";
                    _showHideIcon.BindingContext = this;
                    _showHideIcon.Size = (int)Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                    _showHideIcon.VerticalOptions = LayoutOptions.CenterAndExpand;
                    _showHideIcon.HorizontalOptions = LayoutOptions.CenterAndExpand;
                    _showHideIcon.Orientation = StackOrientation.Horizontal;
                    _showHideIcon.Margin = new Thickness(0, 0, 0, 0);
                    _showHideIcon.InputTransparent = true;
                    _showHideIcon.Color = Color.Black;

                    _showHideIconSvg.StyleId = "customicon";
                    _showHideIconSvg.Icon = CustomIconName;
                    _showHideIconSvg.BindingContext = this;
                    _showHideIconSvg.WidthRequest = (int)Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                    _showHideIconSvg.VerticalOptions = LayoutOptions.CenterAndExpand;
                    _showHideIconSvg.HorizontalOptions = LayoutOptions.CenterAndExpand;
                    _showHideIconSvg.Orientation = StackOrientation.Horizontal;
                    _showHideIconSvg.Margin = new Thickness(0, 0, 0, 0);
                    _showHideIconSvg.InputTransparent = true;


                    _showHideText.StyleId = "showorhideicon";
                    _showHideText.Text = "Mostrar";
                    //_showHideText.Style = (Style)Application.Current.Resources["label-primary"];
                    _showHideText.BindingContext = this;
                    _showHideText.FontSize = 10;
                    _showHideText.VerticalTextAlignment = TextAlignment.Center;
                    _showHideText.VerticalOptions = LayoutOptions.CenterAndExpand;
                    _showHideText.HorizontalOptions = LayoutOptions.CenterAndExpand;
                    _showHideText.Margin = new Thickness(0);
                    _showHideText.InputTransparent = true;
                    _showHideText.TextColor = Color.Black;

                    if (IsCustomIcon)
                        _showOrHideStack.Children.Add(_showHideIconSvg);
                    else
                        _showOrHideStack.Children.Add(_showHideIcon);
                    _showOrHideStack.Children.Add(_showHideText);
                }
            }

            if (propertyName == nameof(MarginTitle))
            {
                InitTitleLayout();
                if (_titleStack != null)
                {
                    _titleStack.Margin = MarginTitle;
                }

            }
            if (propertyName == nameof(TitleFontAttributes))
            {
                lblTitle.FontAttributes = TitleFontAttributes;
            }
            if (propertyName == nameof(MarginShowOrHideIcon))
            {
                _showHideIcon.Margin = MarginShowOrHideIcon;
                if (IsCustomIcon)
                    _showHideIconSvg.Margin = MarginShowOrHideIcon;
            }
            if (propertyName == nameof(HideIconAndTextColor))
            {
                _showHideText.TextColor = HideIconAndTextColor;
                _showHideIcon.Color = HideIconAndTextColor;
            }
            if (propertyName == nameof(IsPasswordVisible))
            {
                if (IsPasswordVisible)
                {
                    _showHideText.Text = "Ocultar";
                    _showHideIcon.Icon = "fa-eye-slash";
                    if (IsCustomIcon)
                    {
                        _showHideIconSvg.Icon = CustomHideIconName;
                    }

                }
                else
                {
                    _showHideText.Text = "Mostrar";
                    _showHideIcon.Icon = "fa-eye";
                    if (IsCustomIcon)
                    {
                        _showHideIconSvg.Icon = CustomIconName;
                    }
                }
            }
        }

        /// <summary>
        /// Ons the tool tip.
        /// </summary>
        /// <param name="obj">Object.</param>
        private void OnToolTip(object obj)
        {
            var toolTip = new ToolTip(ToolTipMessage);
            toolTip.TextColor = TooltipTextColor;
            toolTip.ContentBackgroundColor = TooltipBackgroundColor;
            PopupNavigation.Instance.PushAsync(toolTip);
        }

        /// <summary>
        /// Clears the clicked.
        /// </summary>
        /// <param name="obj">Object.</param>
        private void ClearClicked(object obj)
        {
            ClearCommand?.Execute(ClearCommandParameter);
        }

        /// <summary>
        /// Ons the clear button enable.
        /// </summary>
        private void OnClearButtonEnable()
        {
            InitClearAndIconLayout();
            if (ClearButtonEnable)
            {
                if (_clearAndIconStack.Children.FirstOrDefault(cl => cl.StyleId == "clearbutton") == null)
                {
                    ClearIcon = new BajioIcon()
                    {
                        StyleId = "clearbutton",
                        Icon = "md-close",
                        BindingContext = this,
                        ClickedIcon = new Command(ClearClicked),
                        Size = (int)Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        Orientation = StackOrientation.Horizontal,
                        Color = Theme.EntryClearButtonColor,
                        Margin = new Thickness(1)
                    };
                    _clearAndIconStack.Children.Add(ClearIcon);
                }
                else
                {
                    if (_clearAndIconStack.Children.FirstOrDefault(cl => cl.StyleId == "clearbutton") != null)
                    {
                        ClearIcon.IsVisible = true;
                    }
                }
            }
            else
            {
                if (_clearAndIconStack.Children.FirstOrDefault(cl => cl.StyleId == "clearbutton") != null)
                {
                    ClearIcon.IsVisible = false;
                }
            }
        }

        /// <summary>
        /// Adds the error.
        /// </summary>
        private void AddError()
        {
            if (Error)
            {
                if (lblTitle != null)
                {
                    lblTitle.TextColor = Theme.InvalidColorPrimary;
                }
                if (this.Children.FirstOrDefault(cl => cl.StyleId == "lblerrormsg") == null)
                {
                    lblErrorMessage = new Label();
                    lblErrorMessage.StyleId = "lblerrormsg";
                    lblErrorMessage.Text = ErrorMessage;
                    lblErrorMessage.TextColor = Theme.InvalidColorPrimary;
                    lblErrorMessage.FontSize = ErrorMessageFontSize;
                    lblErrorMessage.FontAttributes = FontAttributes.Bold;
                    lblErrorMessage.HorizontalOptions = LayoutOptions.FillAndExpand;
                    this.Children.Add(lblErrorMessage, 0, 2);
                }
                else
                {
                    lblErrorMessage.Text = ErrorMessage;
                    lblErrorMessage.IsVisible = true;
                }
            }
            else
            {
                if (lblTitle != null)
                {
                    lblTitle.TextColor = TitleColorStyle;
                }
                if (this.Children.FirstOrDefault(cl => cl.StyleId == "lblerrormsg") != null)
                {
                    lblErrorMessage.IsVisible = false;
                }
            }
        }

        /// <summary>
        /// Inits the title layout.
        /// </summary>
        private void InitTitleLayout()
        {
            if (_titleStack == null)
            {
                _titleStack = new StackLayout() { Orientation = StackOrientation.Horizontal };
                _titleAndQuestionStack = new StackLayout() { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.StartAndExpand };
                _titleStack.Children.Add(_titleAndQuestionStack);
                this.Children.Add(_titleStack);
            }
        }

        /// <summary>
        /// Inits the show or hide layout.
        /// </summary>
        private void InitShowOrHideLayout()
        {
            _showOrHideStack.Orientation = StackOrientation.Horizontal;
            _showOrHideStack.HorizontalOptions = LayoutOptions.End;
            _showOrHideStack.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(OnShowOrHideTapped)
            });
            _showOrHideStack.Spacing = 0;
            _titleStack.Children.Add(_showOrHideStack);
        }

        /// <summary>
        /// Inits the clear and icon layout.
        /// </summary>
        private void InitClearAndIconLayout()
        {
            if (_clearAndIconStack == null)
            {
                _clearAndIconStack = new StackLayout() { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.End, Margin = new Thickness(5, 5, 10, 5) };
                _clearAndIconStack.Spacing = 3;
                ContainerControl.Children.Add(_clearAndIconStack, 1, 0);
            }
        }

        /// <summary>
        /// Ons the show or hide tapped.
        /// </summary>
        private void OnShowOrHideTapped()
        {
            IsPasswordVisible = !IsPasswordVisible;
        }

        /// <summary>
        /// Ons the show or hide tapped.
        /// </summary>
        private void OnShowOrHideCustomTapped()
        {
            IsPasswordVisible = !IsPasswordVisible;
            CustomIcon.Icon = IsPasswordVisible ? "fa-eye-slash" : "fa-eye";
        }

        /// <summary>
        /// Ons the show or hide custom svg tapped.
        /// </summary>
        private void OnShowOrHideCustomSvgTapped()
        {
            IsPasswordVisible = !IsPasswordVisible;
            CustomSvgIcon.Icon = IsPasswordVisible ? CustomHideIconName : CustomIconName;
        }

        /// <summary>
        /// Gets the font family.
        /// </summary>
        /// <returns>The font family.</returns>
        /// <param name="font">Font.</param>
        //private Style GetFontStyle(FontEnum font)
        //{
        //    Style style = null;
        //    switch (font)
        //    {
        //        case FontEnum.LibreFranklinBold:
        //            {
        //                style = (Style)Application.Current.Resources["label-bold"];
        //                break;
        //            }
        //        case FontEnum.LibreFranklinItalic:
        //            {
        //                style = (Style)Application.Current.Resources["label-italic"];
        //                break;
        //            }
        //        case FontEnum.LibreFranklinMedium:
        //            {
        //                style = (Style)Application.Current.Resources["label-primary"];
        //                break;
        //            }
        //        case FontEnum.LibreFranklinRegular:
        //            {
        //                style = (Style)Application.Current.Resources["label"];
        //                break;
        //            }
        //        case FontEnum.RobotoRegular:
        //            {
        //                style = (Style)Application.Current.Resources["label-roboto-regular"];
        //                break;
        //            }
        //    }
        //    return style;
        //}
        #endregion
    }
}

