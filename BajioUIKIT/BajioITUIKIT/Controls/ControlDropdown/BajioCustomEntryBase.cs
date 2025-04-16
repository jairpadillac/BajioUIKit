using System;
using System.Runtime.CompilerServices;
using FFImageLoading.Svg.Forms;
using BajioITUIKIT.Styles;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls.ControlDropdown
{
    public class BajioCustomEntryBase : StackLayout
    {
        #region Private Properties
        private readonly ImageSourceConverter _imageSourceConverter = new ImageSourceConverter();

        private readonly SvgCachedImage _tooltipIcon = new SvgCachedImage()
        {
            WidthRequest = 18,
            HeightRequest = 16,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(10, 0, 10, 0)
        };

        /// <summary>
        /// The placeholder
        /// </summary>
        public Label Placeholder = new Label()
        {
            Style = (Xamarin.Forms.Style)Application.Current.Resources["label-primary"],
            TextColor = Theme.TextColorSecondary,
            FontSize = 14,
            FontAttributes = FontAttributes.Bold,
            IsVisible = false,
            VerticalTextAlignment = TextAlignment.End,
            VerticalOptions = LayoutOptions.End,
            HorizontalOptions = LayoutOptions.StartAndExpand,
            LineBreakMode = LineBreakMode.WordWrap,
        };

        #endregion

        #region Public Properties
        /// <summary>
        /// The title property
        /// </summary>
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title),
            typeof(string), typeof(BajioCustomEntryBase), string.Empty, BindingMode.OneWay);

        /// <summary>
        /// The tooltip title property
        /// </summary>
        public static readonly BindableProperty TooltipTitleProperty = BindableProperty.Create(nameof(TooltipTitle),
            typeof(string), typeof(BajioCustomEntryBase), string.Empty, BindingMode.TwoWay);

        /// <summary>
        /// The tooltip message visible property
        /// </summary>
        public static readonly BindableProperty TooltipMessageProperty = BindableProperty.Create(nameof(TooltipMessage),
            typeof(string), typeof(BajioCustomEntryBase), string.Empty, BindingMode.TwoWay);

        /// <summary>
        /// The tooltip visible property
        /// </summary>
        public static readonly BindableProperty TooltipVisibleProperty = BindableProperty.Create(nameof(TooltipVisible),
            typeof(bool), typeof(BajioCustomEntryBase), false, BindingMode.TwoWay);

        /// <summary>
        /// The title font size property
        /// </summary>
        public static readonly BindableProperty TitleFontSizeProperty = BindableProperty.Create(nameof(TitleFontSize),
            typeof(NamedSize), typeof(BajioCustomEntryBase), NamedSize.Micro, BindingMode.TwoWay);

        /// <summary>
        /// The error message property
        /// </summary>
        public static readonly BindableProperty ErrorMessageProperty = BindableProperty.Create(nameof(ErrorMessage),
            typeof(string), typeof(BajioCustomEntryBase), string.Empty, BindingMode.TwoWay);

        /// <summary>
        /// The enabled property
        /// </summary>
        public static readonly BindableProperty EnabledProperty = BindableProperty.Create(nameof(Enabled),
            typeof(bool), typeof(BajioCustomEntryBase), true, BindingMode.TwoWay);

        /// <summary>
        /// The error property
        /// </summary>
        public static readonly BindableProperty ErrorProperty = BindableProperty.Create(nameof(Error),
            typeof(bool), typeof(BajioCustomEntryBase), false, BindingMode.TwoWay);


        /// <summary>
        /// Gets or sets the tooltip title.
        /// </summary>
        /// <value>
        /// The tooltip title.
        /// </value>
        public string TooltipTitle
        {
            get
            {
                return (string)GetValue(TooltipTitleProperty);
            }
            set
            {
                SetValue(TooltipTitleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the tooltip message.
        /// </summary>
        /// <value>
        /// The tooltip message.
        /// </value>
        public string TooltipMessage
        {
            get
            {
                return (string)GetValue(TooltipMessageProperty);
            }
            set
            {
                SetValue(TooltipMessageProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [tooltip visible].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [tooltip visible]; otherwise, <c>false</c>.
        /// </value>
        public bool TooltipVisible
        {
            get
            {
                return (bool)GetValue(TooltipVisibleProperty);
            }
            set
            {
                SetValue(TooltipVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the size of the title font.
        /// </summary>
        /// <value>
        /// The size of the title font.
        /// </value>
        public NamedSize TitleFontSize
        {
            get
            {
                return (NamedSize)GetValue(TitleFontSizeProperty);
            }
            set
            {
                SetValue(TitleFontSizeProperty, value);
            }
        }


        /// <summary>
        /// The container for base entry.
        /// </summary>
        public BajioEntryBaseContainer Container = new BajioEntryBaseContainer
        {
            HeightRequest = 50,
            VerticalOptions = LayoutOptions.Center,
            Padding = 0,
            Spacing = 0,
            BackgroundColor = Theme.ColorSecondary
        };

        /// <summary>
        /// Enabled property to handle styles
        /// </summary>
        public bool Enabled
        {
            get { return (bool)GetValue(EnabledProperty); }
            set { SetValue(EnabledProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="PrestamoEntryBase"/> is error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if error; otherwise, <c>false</c>.
        /// </value>
        public bool Error
        {
            get { return (bool)GetValue(ErrorProperty); }
            set
            {
                SetValue(ErrorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set
            {
                SetValue(ErrorMessageProperty, value);
                ErrorMessageLabel.IsVisible = !string.IsNullOrEmpty(ErrorMessageLabel.Text);
            }
        }

        /// <summary>
        /// Title property is plain string non bindable.
        /// </summary>
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set
            {
                SetValue(TitleProperty, value);
            }
        }

        /// <summary>
        /// The title line break mode property.
        /// </summary>
        public static readonly BindableProperty TitleLineBreakModeProperty = BindableProperty.Create(nameof(TitleLineBreakMode),
                                                                                                     typeof(LineBreakMode), typeof(BajioCustomEntryBase), LineBreakMode.TailTruncation, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the title line break mode.
        /// </summary>
        /// <value>The title line break mode.</value>
        public LineBreakMode TitleLineBreakMode
        {
            get { return (LineBreakMode)GetValue(TitleLineBreakModeProperty); }
            set
            {
                SetValue(TitleLineBreakModeProperty, value);
            }
        }

        /// <summary>
        /// The error message label
        /// </summary>
        public Label ErrorMessageLabel = new Label()
        {
            Style = (Xamarin.Forms.Style)Application.Current.Resources["label-primary"],
            HorizontalOptions = LayoutOptions.StartAndExpand,
            TextColor = Theme.InvalidColorPrimary,
            FontSize = 12,
            IsVisible = false,
        };
        #endregion

        #region Public Methods 
        /// <summary>
        /// Initializes a new instance of the <see cref="PrestamoEntryBase"/> class.
        /// </summary>
        public BajioCustomEntryBase()
        {
            Orientation = StackOrientation.Vertical;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.Start;
            //Margin = 10;
            Spacing = 0;

            // Pass same bindings that this class uses
            Container.BindingContext = this;
            Container.SetBinding(BajioEntryBaseContainer.EnabledProperty, "Enabled");
            Container.SetBinding(BajioEntryBaseContainer.ErrorProperty, "Error");

            ErrorMessageLabel.BindingContext = this;
            ErrorMessageLabel.SetBinding(Label.TextProperty, "ErrorMessage");
            ErrorMessageLabel.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));

            ErrorMessageLabel.IsVisible = false;

            Placeholder.BindingContext = this;
            Placeholder.SetBinding(Label.TextProperty, nameof(Title));

            var xfSource = _imageSourceConverter.ConvertFromInvariantString("Shared_Tooltip.svg") as ImageSource;
            _tooltipIcon.Source = new SvgImageSource(xfSource, 0, 0, true);
            _tooltipIcon.BindingContext = this;
            _tooltipIcon.SetBinding(IsVisibleProperty, nameof(TooltipVisible));
            _tooltipIcon.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(OnToolTip)
            });

            var columnDefinitionCollection = new ColumnDefinitionCollection();
            columnDefinitionCollection.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            columnDefinitionCollection.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            columnDefinitionCollection.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            topContainer.RowSpacing = 0;
            topContainer.ColumnDefinitions = columnDefinitionCollection;

            topContainer.Margin = new Thickness(0, 0, 0, 4);

            topContainer.Children.Add(Placeholder, 0, 0);
            topContainer.Children.Add(_tooltipIcon, 1, 0);

            Children.Add(topContainer);
            Children.Add(Container);
            Children.Add(ErrorMessageLabel);
        }
        public Grid topContainer = new Grid();

        #endregion

        #region Private Methods

        /// <summary>
        /// Called when [tool tip].
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private async void OnToolTip(object obj)
        {
            await Application.Current.MainPage.DisplayAlert(TooltipTitle, TooltipMessage, "CLOSE");
        }

        /// <summary>
        /// Method that is called when a bound property is changed.
        /// </summary>
        /// <param name="propertyName">The name of the bound property that changed.</param>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == ErrorProperty.PropertyName)
            {
                OnError();
            }

            if (propertyName == TitleFontSizeProperty.PropertyName)
            {
                Placeholder.FontSize = Device.GetNamedSize(TitleFontSize, typeof(Label));
            }

            if (propertyName == TitleProperty.PropertyName)
            {
                Placeholder.IsVisible = !string.IsNullOrEmpty(Title);
            }

            //if (propertyName == FormattedTitleProperty.PropertyName)
            //{
            //    Placeholder.FormattedText = FormattedTitle;
            //    if (FormattedTitle != null)
            //    {
            //        Placeholder.IsVisible = true;
            //    }
            //}
            if (propertyName == ErrorMessageProperty.PropertyName)
            {
                ErrorMessageLabel.Text = ErrorMessage;
                OnError();
            }

            if (propertyName == TitleLineBreakModeProperty.PropertyName)
            {
                Placeholder.LineBreakMode = TitleLineBreakMode;
            }


        }

        /// <summary>
        /// Called when [error].
        /// </summary>
        private void OnError()
        {
            ErrorMessageLabel.IsVisible = Error;
            if (Error)
            {
                Placeholder.TextColor = Theme.InvalidColorPrimary;
            }
            else
            {
                Placeholder.TextColor = Theme.TextColorSecondary;
            }
        }
        #endregion
    }
}
