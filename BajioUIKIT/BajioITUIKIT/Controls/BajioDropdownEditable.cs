using FFImageLoading.Svg.Forms;
using BajioITUIKIT.Controls.ControlDropdown;
using BajioITUIKIT.Controls.ControlModels;
using BajioITUIKIT.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    public class BajioDropdownEditable : StackLayout
    {
        #region Private Properties
        /// <summary>
        /// The placeholder
        /// </summary>
        private readonly Label _placeholder = new Label()
        {
            Style = (Xamarin.Forms.Style)Application.Current.Resources["label-primary"],
            TextColor = Theme.TextColorSecondary,
            FontSize = 10,
            VerticalOptions = LayoutOptions.StartAndExpand,
            HorizontalOptions = LayoutOptions.StartAndExpand,
            Margin = new Thickness(0, 2, 0, 10),
            LineBreakMode = LineBreakMode.TailTruncation
        };
        /// <summary>
        /// The description
        /// </summary>
        private readonly Label _description = new Label()
        {
            Style = (Xamarin.Forms.Style)Application.Current.Resources["label-primary"],
            TextColor = Theme.TextColorSecondary,
            FontSize = 10,
            IsVisible = false,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.StartAndExpand
        };
        /// <summary>
        /// The picker container
        /// </summary>
        private readonly BajioContainerControl _pickerContainer;
        /// <summary>
        /// The chevron
        /// </summary>
        private readonly BajioIcon _chevron = new BajioIcon()
        {
            Icon = "arrow-drop-down",
            HorizontalOptions = LayoutOptions.End,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            WidthRequest = 44,
            Size = 25,
            Color = Theme.TextColorSecondary
        };
        /// <summary>
        /// The error message label
        /// </summary>
        private Label _errorMessageLabel = new Label()
        {
            Style = (Xamarin.Forms.Style)Application.Current.Resources["label-primary"],
            HorizontalOptions = LayoutOptions.StartAndExpand,
            TextColor = Theme.InvalidColorPrimary,
            FontSize = 12
        };

        /// <summary>
        /// The entry editable
        /// </summary>
        private BajioCustomEntry _entryEditable = new BajioCustomEntry();

        /// <summary>
        /// The image source converter
        /// </summary>
        private readonly ImageSourceConverter _imageSourceConverter = new ImageSourceConverter();

        /// <summary>
        /// The icon
        /// </summary>
        private string _icon = string.Empty;

        /// <summary>
        /// The svg image render
        /// </summary>
        private readonly SvgCachedImage _svgIconImage = new SvgCachedImage()
        {
            WidthRequest = 30,
            HeightRequest = 25,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Margin = new Thickness(10, 0, 10, 0)
        };
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        public string Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                var xfSource = _imageSourceConverter.ConvertFromInvariantString(value) as ImageSource;
                _svgIconImage.Source = new SvgImageSource(xfSource, 0, 0, true);
            }
        }

        /// <summary>
        /// Occurs when [selected index changed].
        /// </summary>
        public event EventHandler SelectedIndexChanged;

        /// <summary>
        /// The items property
        /// </summary>
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items),
            typeof(List<DropdownItem>), typeof(BajioDropdownEditable), null, BindingMode.OneWay, propertyChanged: ChangeItems);

        /// <summary>
        /// The selected item property
        /// </summary>
        public static readonly BindableProperty SelectedItemProperty = BindableProperty.Create(nameof(SelectedItem),
            typeof(DropdownItem), typeof(BajioDropdownEditable), null, BindingMode.TwoWay, propertyChanged: SelectedItemChanged);

        /// <summary>
        /// The enabled property
        /// </summary>
        public static readonly BindableProperty EnabledProperty = BindableProperty.Create(nameof(Enabled),
            typeof(bool), typeof(BajioDropdownEditable), true, BindingMode.TwoWay, propertyChanged: ToggleEnabled);

        /// <summary>
        /// The is title visible property
        /// </summary>
        public static readonly BindableProperty IsTitleVisibleProperty = BindableProperty.Create(nameof(IsTitleVisible),
            typeof(bool), typeof(BajioDropdownEditable), true, BindingMode.TwoWay);

        /// <summary>
        /// The title property
        /// </summary>
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title),
            typeof(string), typeof(BajioDropdownEditable), string.Empty, BindingMode.OneWay, propertyChanged: TitleChange);

        /// <summary>
        /// The error message property
        /// </summary>
        public static readonly BindableProperty ErrorMessageProperty = BindableProperty.Create(nameof(ErrorMessage),
            typeof(string), typeof(BajioEntryBase), string.Empty, BindingMode.TwoWay);

        /// <summary>
        /// The error property
        /// </summary>
        public static readonly BindableProperty ErrorProperty = BindableProperty.Create(nameof(Error),
            typeof(bool), typeof(BajioEntryBase), false, BindingMode.TwoWay);


        /// <summary>
        /// The is place holder visible property
        /// </summary>
        public static readonly BindableProperty IsPlaceHolderVisibleProperty = BindableProperty.Create(nameof(IsPlaceHolderVisible),
            typeof(bool), typeof(BajioDropdownEditable), false, BindingMode.TwoWay);

        /// <summary>
        /// The height request Bajio dropdown property
        /// </summary>
        public static readonly BindableProperty HeightRequestBajioDropdownProperty = BindableProperty.Create(nameof(HeightRequestBajioDropdown),
            typeof(int), typeof(BajioDropdownEditable), 60, BindingMode.TwoWay);


        /// <summary>
        /// The maximum length entry property
        /// </summary>
        public static readonly BindableProperty MaxLengthEntryProperty = BindableProperty.Create(nameof(MaxLengthEntry),
            typeof(int), typeof(BajioDropdownEditable), 255, BindingMode.TwoWay);


        /// <summary>
        /// The is image on rigth visible property
        /// </summary>
        public static readonly BindableProperty IsImageOnRigthVisibleProperty = BindableProperty.Create(nameof(IsImageOnRigthVisible),
            typeof(bool), typeof(BajioDropdownEditable), false, BindingMode.TwoWay);

        /// <summary>
        /// The open contacts command property
        /// </summary>
        public static readonly BindableProperty OpenContactsCommandProperty = BindableProperty.Create(nameof(OpenContactsCommand),
            typeof(ICommand), typeof(BajioDropdownEditable), null, BindingMode.TwoWay);


        /// <summary>
        /// The value editable dropdown property
        /// </summary>
        public static readonly BindableProperty ValueEditableDropdownProperty = BindableProperty.Create(nameof(ValueEditableDropdown),
            typeof(string), typeof(BajioDropdownEditable), string.Empty, BindingMode.TwoWay);

        /// <summary>
        /// The place holder text dropdown property
        /// </summary>
        public static readonly BindableProperty PlaceHolderTextDropdownProperty = BindableProperty.Create(nameof(PlaceHolderTextDropdown),
            typeof(string), typeof(BajioDropdownEditable), string.Empty, BindingMode.TwoWay);

        /// <summary>
        /// The is editable dropdown property
        /// </summary>
        public static readonly BindableProperty IsEditableDropdownProperty = BindableProperty.Create(nameof(IsEditableDropdown),
            typeof(bool), typeof(BajioDropdownEditable), false, BindingMode.TwoWay);


        /// <summary>
        /// The is Bajio dropdown editable focus property.
        /// </summary>
        public static readonly BindableProperty IsBajioDropdownEditableFocusProperty = BindableProperty.Create(nameof(IsBajioDropdownEditableFocus),
            typeof(bool), typeof(BajioDropdownEditable), false, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the clear command.
        /// </summary>
        /// <value>
        /// The clear command.
        /// </value>
        public ICommand OpenContactsCommand
        {
            get
            {
                return (ICommand)GetValue(OpenContactsCommandProperty);
            }
            set
            {
                SetValue(OpenContactsCommandProperty, value);
            }
        }



        /// <summary>
        /// The picker
        /// </summary>
        public CustomPicker Picker;

        /// <summary>
        /// Is enable property
        /// </summary>
        public bool Enabled
        {
            get
            {
                return (bool)GetValue(EnabledProperty);
            }
            set
            {
                SetValue(EnabledProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is title visible.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is title visible; otherwise, <c>false</c>.
        /// </value>
        public bool IsTitleVisible
        {
            get
            {
                return (bool)GetValue(IsTitleVisibleProperty);
            }
            set
            {
                SetValue(IsTitleVisibleProperty, value);
            }
        }

        /// <summary>
        /// IsSelected Item property
        /// </summary>
        public DropdownItem SelectedItem
        {
            get
            {
                return (DropdownItem)GetValue(SelectedItemProperty);
            }
            set
            {
                SetValue(SelectedItemProperty, value);
            }
        }

        /// <summary>
        /// Items property
        /// </summary>
        public List<DropdownItem> Items
        {
            get
            {
                return (List<DropdownItem>)GetValue(ItemsProperty);
            }
            set
            {
                SetValue(ItemsProperty, value);
            }
        }

        /// <summary>
        /// Title property is plain string non bindable.
        /// </summary>
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
        /// Gets or sets a value indicating whether this <see cref="BajioDropdownEditable"/> is error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if error; otherwise, <c>false</c>.
        /// </value>
        public bool Error
        {
            get
            {
                return (bool)GetValue(ErrorProperty);
            }
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
            get
            {
                return (string)GetValue(ErrorMessageProperty);
            }
            set
            {
                SetValue(ErrorMessageProperty, value);
                _errorMessageLabel.IsVisible = !string.IsNullOrEmpty(_errorMessageLabel.Text);
            }
        }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is place holder visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is place holder visible; otherwise, <c>false</c>.
        /// </value>
        public bool IsPlaceHolderVisible
        {
            get
            {
                return (bool)GetValue(IsPlaceHolderVisibleProperty);
            }
            set
            {
                SetValue(IsPlaceHolderVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the height request Bajio dropdown.
        /// </summary>
        /// <value>
        /// The height request Bajio dropdown.
        /// </value>
        public int HeightRequestBajioDropdown
        {
            get
            {
                return (int)GetValue(HeightRequestBajioDropdownProperty);
            }
            set
            {
                SetValue(HeightRequestBajioDropdownProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the maximum length entry.
        /// </summary>
        /// <value>
        /// The maximum length entry.
        /// </value>
        public int MaxLengthEntry
        {
            get
            {
                return (int)GetValue(MaxLengthEntryProperty);
            }
            set
            {
                SetValue(MaxLengthEntryProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is image on rigth visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is image on rigth visible; otherwise, <c>false</c>.
        /// </value>
        public bool IsImageOnRigthVisible
        {
            get
            {
                return (bool)GetValue(IsImageOnRigthVisibleProperty);
            }
            set
            {
                SetValue(IsImageOnRigthVisibleProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the value editable dropdown.
        /// </summary>
        /// <value>
        /// The value editable dropdown.
        /// </value>
        public string ValueEditableDropdown
        {
            get
            {
                return (string)GetValue(ValueEditableDropdownProperty);
            }
            set
            {
                SetValue(ValueEditableDropdownProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the place holder text dropdown.
        /// </summary>
        /// <value>
        /// The place holder text dropdown.
        /// </value>
        public string PlaceHolderTextDropdown
        {
            get
            {
                return (string)GetValue(PlaceHolderTextDropdownProperty);
            }
            set
            {
                SetValue(PlaceHolderTextDropdownProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is editable dropdown.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is editable dropdown; otherwise, <c>false</c>.
        /// </value>
        public bool IsEditableDropdown
        {
            get
            {
                return (bool)GetValue(IsEditableDropdownProperty);
            }
            set
            {
                SetValue(IsEditableDropdownProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this is Bajio dropdown editable focus.
        /// </summary>
        /// <value><c>true</c> if is Bajio dropdown editable focus; otherwise, <c>false</c>.</value>
        public bool IsBajioDropdownEditableFocus
        {
            get
            {
                return (bool)GetValue(IsBajioDropdownEditableFocusProperty);
            }
            set
            {
                SetValue(IsBajioDropdownEditableFocusProperty, value);
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="BajioDropdownEditable" /> class.
        /// </summary>
        public BajioDropdownEditable()
        {
            // Container config
            Orientation = StackOrientation.Vertical;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.Start;
            Spacing = 0;
            //HeightRequest = 70;

            Picker = new CustomPicker()
            {
                TextColor = Theme.TextColorSecondary,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Title = string.Empty,
            };

            Picker.SelectedIndexChanged += OnSelectedItem;
            Picker.Unfocused += (object sender, FocusEventArgs e) => {
                if (Picker.SelectedItem != null)
                {
                    if (IsBajioDropdownEditableFocus || Picker.SelectedItem.ToString().Contains("Enter your own question"))
                    {
                        //_entryEditable._entry.Focus();
                    }
                }

            };


            var gesture = new TapGestureRecognizer
            {
                Command = new Command((o) =>
                {
                    if (Enabled)
                    {
                        Device.BeginInvokeOnMainThread(() => {
                            Picker.Focus();
                        });

                    }
                })
            };

            // Trigger picker on chevron tap
            _chevron.GestureRecognizers.Add(gesture);

            // Trigger picker on description tap
            _description.GestureRecognizers.Add(gesture);

            _pickerContainer = new BajioContainerControl()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand

            };

            // Pass same bindings that this class uses
            _pickerContainer.BindingContext = this;
            _pickerContainer.SetBinding(BajioEntryBaseContainer.EnabledProperty, "Enabled");
            _pickerContainer.SetBinding(BajioEntryBaseContainer.ErrorProperty, "Error");

            var descriptionContent = new Grid()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };
            _pickerContainer.GestureRecognizers.Add(gesture);

            descriptionContent.Children.Add(Picker, 0, 0);

            descriptionContent.Padding = new Thickness(10, 0, 0, 0);
            _entryEditable.BindingContext = this;
            _entryEditable.HasIconLeft = false;
            _entryEditable.ClearButtonEnable = true;
            _entryEditable.VerticalOptions = LayoutOptions.Center;
            _entryEditable.HorizontalOptions = LayoutOptions.FillAndExpand;
            _entryEditable.BackgroundColor = Theme.EntryEnabledBackground;
            _entryEditable.SetBinding(BajioEntry.TextProperty, "ValueEditableDropdown");
            descriptionContent.Children.Add(_entryEditable, 0, 0);

            if (Device.RuntimePlatform == Device.Android)
            {
                _pickerContainer.Padding = new Thickness(0, 0, 0, 0);
            }
            else
            {
                _description.Margin = new Thickness(5, 0, 0, 0);
            }

            _pickerContainer.Children.Add(descriptionContent);
            _pickerContainer.Children.Add(_chevron);

            _errorMessageLabel.BindingContext = this;
            _errorMessageLabel.SetBinding(Label.TextProperty, "ErrorMessage");
            _errorMessageLabel.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));

            _errorMessageLabel.IsVisible = false;

            _placeholder.BindingContext = this;
            _placeholder.SetBinding(IsVisibleProperty, nameof(IsTitleVisible));
            _placeholder.FontSize = 14;
            _placeholder.FontAttributes = FontAttributes.Bold;


            Padding = new Thickness(0, 0, 0, 10);

            Children.Add(_placeholder);
            Children.Add(_pickerContainer);
            Children.Add(_errorMessageLabel);

        }
        #endregion

        #region Protected Methods        

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
            if (propertyName == IsPlaceHolderVisibleProperty.PropertyName)
            {
                Picker.Title = Title;
            }
            if (propertyName == HeightRequestBajioDropdownProperty.PropertyName)
            {
                _pickerContainer.HeightRequest = HeightRequestBajioDropdown;
            }
            if (propertyName == IsImageOnRigthVisibleProperty.PropertyName)
            {
                if (IsImageOnRigthVisible)
                {
                    _pickerContainer.Children.Insert(2, new BoxView()
                    {
                        WidthRequest = 0.5,
                        BackgroundColor = Theme.EntryStrokeBorder,
                        Margin = new Thickness(0, 5, 0, 5)
                    });
                    _pickerContainer.Children.Insert(3, _svgIconImage);
                }
            }
            if (propertyName == OpenContactsCommandProperty.PropertyName)
            {
                _svgIconImage.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = OpenContactsCommand
                });
            }
            if (propertyName == MaxLengthEntryProperty.PropertyName)
            {
                _entryEditable.MaxLengthPrestamoEntry = MaxLengthEntry;
                _entryEditable.ClearButtonEnable = true;
            }
            if (propertyName == PlaceHolderTextDropdownProperty.PropertyName)
            {
                _entryEditable.Placeholder = PlaceHolderTextDropdown;
            }
            if (propertyName == IsEditableDropdownProperty.PropertyName)
            {
                if (IsEditableDropdown)
                {
                    _svgIconImage.WidthRequest = 0;
                    _pickerContainer.Children.Insert(2, new BoxView()
                    {
                        WidthRequest = 0.5,
                        HeightRequest = 50,
                    });
                    _pickerContainer.Children.Insert(3, _svgIconImage);
                }
            }

            if (propertyName == IsBajioDropdownEditableFocusProperty.PropertyName)
            {
                _entryEditable.FocusView = IsBajioDropdownEditableFocus;

            }
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Togle is enable flag.
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private static void ToggleEnabled(BindableObject bindable, object oldValue, object newValue)
        {
            var dropdown = ((BajioDropdownEditable)bindable);
            if (dropdown.Enabled)
            {
                dropdown.Picker.IsEnabled = true;
                dropdown._pickerContainer.Enabled = true;
                if (Device.RuntimePlatform == Device.iOS)
                {
                    dropdown.Picker.BackgroundColor = Theme.EntryEnabledBackground;
                }
            }
            else
            {
                dropdown.Picker.IsEnabled = false;
                dropdown._pickerContainer.Enabled = false;
                if (Device.RuntimePlatform == Device.iOS)
                {
                    dropdown.Picker.BackgroundColor = Theme.EntryDisabledBackground;
                }
            }
        }

        /// <summary>
        /// Items Change handler
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private static void ChangeItems(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue == null) return;

            var picker = ((BajioDropdownEditable)bindable).Picker;
            var items = (List<DropdownItem>)newValue;

            picker.Items.Clear();
            foreach (var i in items)
            {
                picker.Items.Add(i.Title);
            }
        }

        /// <summary>
        /// Selecteds the item changed.
        /// </summary>
        /// <param name="bindable">The bindable.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        private static void SelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //var dropdown = ((BajioDropdownEditable)bindable);
            //if (dropdown.SelectedItem == null)
            //{
            //    dropdown.Picker.SelectedIndex = -1;
            //}
            //else
            //{
            //    dropdown.Picker.SelectedIndex = dropdown.Items.IndexOf(dropdown.SelectedItem);
            //}
        }

        /// <summary>
        /// Titles the change.
        /// </summary>
        /// <param name="bindable">The bindable.</param>
        /// <param name="oldvalue">The oldvalue.</param>
        /// <param name="newvalue">The newvalue.</param>
        private static void TitleChange(BindableObject bindable, object oldvalue, object newvalue)
        {
            var dropdown = ((BajioDropdownEditable)bindable);
            var title = newvalue.ToString();

            dropdown._placeholder.Text = title;
            if (Device.RuntimePlatform == Device.iOS)
            {
                dropdown.Picker.Title = title;
            }

        }

        /// <summary>
        /// Handle item change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSelectedItem(object sender, EventArgs e)
        {
            var index = ((Picker)sender).SelectedIndex;
            if (index == -1)
            {
                _description.IsVisible = false;
            }
            else
            {
                SelectedItem = Items.ElementAt(index);
                _description.Text = SelectedItem.Description;
                // Show description only if there is a description
                _description.IsVisible = !string.IsNullOrEmpty(SelectedItem.Description);
                _entryEditable.Text = SelectedItem.Value;
                _entryEditable.Unfocus();
            }

            SelectedIndexChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Called when [error].
        /// </summary>
        private void OnError()
        {
            _errorMessageLabel.IsVisible = Error;

            if (Error)
            {
                _placeholder.TextColor = Theme.InvalidColorPrimary;
            }
            else
            {
                _placeholder.TextColor = Theme.TextColorSecondary;
            }
        }
        #endregion
    }
}
