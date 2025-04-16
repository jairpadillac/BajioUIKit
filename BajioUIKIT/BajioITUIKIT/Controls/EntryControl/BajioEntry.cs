using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using FFImageLoading.Svg.Forms;
using BajioITUIKIT.Enums;
using BajioITUIKIT.Styles;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    public class BajioEntry : BajioBaseControl
    {
        #region Public Properties

        #region NEXT VIEW

        /// <summary>
        /// The focus view property declaration.
        /// </summary>
        public static readonly BindableProperty FocusViewProperty =
            BindableProperty.Create(nameof(FocusView),
                                    typeof(bool),
                                    typeof(BajioEntry),
                                    false);

        /// <summary>
        /// Property used to focus on the entry of the control
        /// </summary>
        /// <value><c>true</c> if focus view; otherwise, <c>false</c>.</value>
        public bool FocusView
        {
            get { return (bool)GetValue(FocusViewProperty); }
            set { SetValue(FocusViewProperty, value); }
        }

        /// <summary>
        /// The return entry command property.
        /// </summary>
        public static readonly BindableProperty ReturnEntryCommandProperty = BindableProperty.Create("ReturnEntryCommand",
            typeof(object), typeof(BajioEntry), null, BindingMode.TwoWay);

        /// <summary>
        /// The next entry command property.
        /// </summary>
        public static readonly BindableProperty NextEntryCommandProperty = BindableProperty.Create("NextEntryCommand",
                   typeof(object), typeof(BajioEntry), null, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the return entry command.
        /// </summary>
        /// <value>The return entry command.</value>
        public ICommand ReturnEntryCommand
        {
            get { return (ICommand)GetValue(ReturnEntryCommandProperty); }
            set { SetValue(ReturnEntryCommandProperty, value); }
        }

        /// <summary>
        /// Command used for when the nextEntry is called
        /// </summary>
        /// <value>The next entry command.</value>
        public ICommand NextEntryCommand
        {
            get { return (ICommand)GetValue(NextEntryCommandProperty); }
            set { SetValue(NextEntryCommandProperty, value); }
        }


        /// <summary>
        /// The should invoke action property.
        /// </summary>
        public static readonly BindableProperty ShouldInvokeActionProperty =
            BindableProperty.Create(nameof(ShouldInvokeAction), typeof(bool), typeof(BajioEntry), false);

        /// <summary>
        /// Gets or sets a value indicating whether this should
        /// invoke action.
        /// </summary>
        /// <value><c>true</c> if should invoke action; otherwise, <c>false</c>.</value>
        public bool ShouldInvokeAction
        {
            get { return (bool)GetValue(ShouldInvokeActionProperty); }
            set { SetValue(ShouldInvokeActionProperty, value); }
        }



        #endregion


        /// <summary>
        /// Occurs when on completed.
        /// </summary>
        public event EventHandler OnCompleted;

        #region Elements
        /// <summary>
        /// The entry.
        /// </summary>
        public BajioEntryBase EntryEditor = new BajioEntryBase()
        {
            TextColor = Theme.TextColorSecondary,
            KeyBoardType = EntryKeyBoardType.Chat
        };
        #endregion

        #region Bindable Properties
        /// <summary>
        /// The mask property.
        /// </summary>
        public static readonly BindableProperty MaskProperty =
            BindableProperty.Create(nameof(Mask), typeof(EntryMaskType?), typeof(BajioEntry), null, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the mask.
        /// </summary>
        /// <value>The mask.</value>
        public EntryMaskType? Mask
        {
            get { return (EntryMaskType?)GetValue(MaskProperty); }
            set { SetValue(MaskProperty, value); }
        }

        /// <summary>
        /// The text property.
        /// </summary>
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(BajioEntry), string.Empty, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// The init value property.
        /// </summary>
        public static readonly BindableProperty InitValueProperty =
            BindableProperty.Create(nameof(InitValue), typeof(string), typeof(BajioEntry), string.Empty);

        /// <summary>
        /// Gets or sets the init value.
        /// </summary>
        /// <value>The init value.</value>
        public string InitValue
        {
            get { return (string)GetValue(InitValueProperty); }
            set { SetValue(InitValueProperty, value); }
        }

        /// <summary>
        /// The previous value property.
        /// </summary>
        public static readonly BindableProperty PrevValueProperty =
            BindableProperty.Create(nameof(PrevValue), typeof(string), typeof(BajioEntry), string.Empty);

        /// <summary>
        /// Gets or sets the previous value.
        /// </summary>
        /// <value>The previous value.</value>
        public string PrevValue
        {
            get { return (string)GetValue(PrevValueProperty); }
            set { SetValue(PrevValueProperty, value); }
        }

        /// <summary>
        /// The entry font size property.
        /// </summary>
        public static readonly BindableProperty EntryFontSizeProperty =
            BindableProperty.Create(nameof(EntryFontSize), typeof(double), typeof(BajioEntry), 12d);

        /// <summary>
        /// Gets or sets the size of the entry font.
        /// </summary>
        /// <value>The size of the entry font.</value>
        public double EntryFontSize
        {
            get { return (double)GetValue(EntryFontSizeProperty); }
            set { SetValue(EntryFontSizeProperty, value); }
        }

        /// <summary>
        /// The entry text color property.
        /// </summary>
        public static readonly BindableProperty EntryTextColorProperty =
            BindableProperty.Create(nameof(EntryTextColor), typeof(Color), typeof(BajioEntry), Theme.TextColorSecondary);

        /// <summary>
        /// Gets or sets the color of the entry text.
        /// </summary>
        /// <value>The color of the entry text.</value>
        public Color EntryTextColor
        {
            get { return (Color)GetValue(EntryTextColorProperty); }
            set { SetValue(EntryTextColorProperty, value); }
        }

        /// <summary>
        /// The entry horizontal text aligment property.
        /// </summary>
        public static readonly BindableProperty EntryHorizontalTextAligmentProperty =
            BindableProperty.Create(nameof(EntryHorizontalTextAligment), typeof(TextAlignment), typeof(BajioEntry), TextAlignment.Start);

        /// <summary>
        /// Gets or sets the entry horizontal text aligment.
        /// </summary>
        /// <value>The entry horizontal text aligment.</value>
        public TextAlignment EntryHorizontalTextAligment
        {
            get { return (TextAlignment)GetValue(EntryHorizontalTextAligmentProperty); }
            set { SetValue(EntryHorizontalTextAligmentProperty, value); }
        }

        /// <summary>
        /// The entry max length property.
        /// </summary>
        public static readonly BindableProperty EntryMaxLengthProperty =
            BindableProperty.Create(nameof(EntryMaxLength), typeof(int), typeof(BajioEntry), 200, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the length of the entry max.
        /// </summary>
        /// <value>The length of the entry max.</value>
        public int EntryMaxLength
        {
            get { return (int)GetValue(EntryMaxLengthProperty); }
            set { SetValue(EntryMaxLengthProperty, value); }
        }

        /// <summary>
        /// The entry height property.
        /// </summary>
        public static readonly BindableProperty EntryHeightProperty =
            BindableProperty.Create(nameof(EntryHeight), typeof(double), typeof(BajioEntry), 45d, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the height of the entry.
        /// </summary>
        /// <value>The height of the entry.</value>
        public double EntryHeight
        {
            get { return (double)GetValue(EntryHeightProperty); }
            set { SetValue(EntryHeightProperty, value); }
        }

        /// <summary>
        /// The entry stroke border property.
        /// </summary>
        public static readonly BindableProperty EntryStrokeBorderProperty =
            BindableProperty.Create(nameof(EntryStrokeBorder), typeof(Color), typeof(BajioEntry), Theme.EntryStrokeBorder, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the entry stroke border.
        /// </summary>
        /// <value>The entry stroke border.</value>
        public Color EntryStrokeBorder
        {
            get { return (Color)GetValue(EntryStrokeBorderProperty); }
            set { SetValue(EntryStrokeBorderProperty, value); }
        }

        /// <summary>
        /// The entry invalid color property.
        /// </summary>
        public static readonly BindableProperty EntryInvalidColorProperty =
            BindableProperty.Create(nameof(EntryInvalidColor), typeof(Color), typeof(BajioEntry), Theme.InvalidColorPrimary, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the color of the entry invalid.
        /// </summary>
        /// <value>The color of the entry invalid.</value>
        public Color EntryInvalidColor
        {
            get { return (Color)GetValue(EntryInvalidColorProperty); }
            set { SetValue(EntryInvalidColorProperty, value); }
        }

        /// <summary>
        /// The entry enabled background property.
        /// </summary>
        public static readonly BindableProperty EntryEnabledBackgroundProperty =
            BindableProperty.Create(nameof(EntryEnabledBackground), typeof(Color), typeof(BajioEntry), Theme.EntryEnabledBackground, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the entry enabled background.
        /// </summary>
        /// <value>The entry enabled background.</value>
        public Color EntryEnabledBackground
        {
            get { return (Color)GetValue(EntryEnabledBackgroundProperty); }
            set { SetValue(EntryEnabledBackgroundProperty, value); }
        }

        /// <summary>
        /// The entry disabled background property.
        /// </summary>
        public static readonly BindableProperty EntryDisabledBackgroundProperty =
            BindableProperty.Create(nameof(EntryDisabledBackground), typeof(Color), typeof(BajioEntry), Theme.EntryDisabledBackground, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the entry disabled background.
        /// </summary>
        /// <value>The entry disabled background.</value>
        public Color EntryDisabledBackground
        {
            get { return (Color)GetValue(EntryDisabledBackgroundProperty); }
            set { SetValue(EntryDisabledBackgroundProperty, value); }
        }

        /// <summary>
        /// The is border displayed property.
        /// </summary>
        public static readonly BindableProperty IsBorderDisplayedProperty =
            BindableProperty.Create(nameof(IsBorderDisplayed), typeof(bool), typeof(BajioEntry), true);

        /// <summary>
        /// Gets or sets a value indicating whether this is border displayed.
        /// </summary>
        /// <value><c>true</c> if is border displayed; otherwise, <c>false</c>.</value>
        public bool IsBorderDisplayed
        {
            get { return (bool)GetValue(IsBorderDisplayedProperty); }
            set { SetValue(IsBorderDisplayedProperty, value); }
        }

        /// <summary>
        /// The on focus error property.
        /// </summary>
        public static readonly BindableProperty OnFocusErrorProperty =
            BindableProperty.Create(nameof(OnFocusError), typeof(bool), typeof(BajioEntry), false, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether this on focus error.
        /// </summary>
        /// <value><c>true</c> if on focus error; otherwise, <c>false</c>.</value>
        public bool OnFocusError
        {
            get { return (bool)GetValue(OnFocusErrorProperty); }
            set { SetValue(OnFocusErrorProperty, value); }
        }

        /// <summary>
        /// The edit value property.
        /// </summary>
        public static readonly BindableProperty EditValueProperty =
            BindableProperty.Create(nameof(EditValue), typeof(double), typeof(BajioEntry), double.MinValue, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the edit value.
        /// </summary>
        /// <value>The edit value.</value>
        public double EditValue
        {
            get { return (double)GetValue(EditValueProperty); }
            set { SetValue(EditValueProperty, value); }
        }

        /// <summary>
        /// The decimal positions property.
        /// </summary>
        public static readonly BindableProperty DecimalPositionsProperty =
            BindableProperty.Create(nameof(DecimalPositions), typeof(int), typeof(BajioEntry), 0, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the decimal positions.
        /// </summary>
        /// <value>The decimal positions.</value>
        public int DecimalPositions
        {
            get { return (int)GetValue(DecimalPositionsProperty); }
            set { SetValue(DecimalPositionsProperty, value); }
        }

        /// <summary>
        /// The parent scroll property.
        /// </summary>
        public static readonly BindableProperty ParentScrollProperty =
            BindableProperty.Create(nameof(ParentScroll), typeof(ScrollView), typeof(BajioEntry), null, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the parent scroll.
        /// </summary>
        /// <value>The parent scroll.</value>
        public ScrollView ParentScroll
        {
            get { return (ScrollView)GetValue(ParentScrollProperty); }
            set { SetValue(ParentScrollProperty, value); }
        }

        /// <summary>
        /// The text changed command property.
        /// </summary>
        public static readonly BindableProperty TextChangedCommandProperty =
            BindableProperty.Create(nameof(TextChangedCommand), typeof(Command), typeof(BajioEntry), null, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the text changed command.
        /// </summary>
        /// <value>The text changed command.</value>
        public Command TextChangedCommand
        {
            get { return (Command)GetValue(TextChangedCommandProperty); }
            set { SetValue(TextChangedCommandProperty, value); }
        }

        /// <summary>
        /// The corner radius property.
        /// </summary>
        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(BajioEntry), 4f);

        /// <summary>
        /// Gets or sets the corner radius.
        /// </summary>
        /// <value>The corner radius.</value>
        public float CornerRadius
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        /// <summary>
        /// The border width property.
        /// </summary>
        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.Create(nameof(BorderWidth), typeof(float), typeof(BajioEntry), 2f);

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        public float BorderWidth
        {
            get { return (float)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        /// <summary>
        /// The has changes property.
        /// </summary>
        public static readonly BindableProperty HasChangesProperty =
            BindableProperty.Create(nameof(HasChanges), typeof(bool), typeof(BajioEntry), false, BindingMode.OneWayToSource);

        /// <summary>
        /// Gets or sets a value indicating whether this has changes.
        /// </summary>
        /// <value><c>true</c> if has changes; otherwise, <c>false</c>.</value>
        public bool HasChanges
        {
            get { return (bool)GetValue(HasChangesProperty); }
            set { SetValue(HasChangesProperty, value); }
        }

        /// <summary>
        /// The custom format property.
        /// </summary>
        public static readonly BindableProperty CustomFormatProperty =
            BindableProperty.Create(nameof(CustomFormat), typeof(string), typeof(BajioEntry), string.Empty, BindingMode.OneWay);

        /// <summary>
        /// Gets or sets the custom format.
        /// </summary>
        /// <value>The custom format.</value>
        public string CustomFormat
        {
            get { return (string)GetValue(CustomFormatProperty); }
            set { SetValue(CustomFormatProperty, value); }
        }

        /// <summary>
        /// The custom place holder property.
        /// </summary>
        public static readonly BindableProperty CustomPlaceHolderProperty =
            BindableProperty.Create(nameof(CustomPlaceHolder), typeof(string), typeof(BajioEntry), string.Empty, BindingMode.OneWay);

        /// <summary>
        /// Gets or sets the custom place holder.
        /// </summary>
        /// <value>The custom place holder.</value>
        public string CustomPlaceHolder
        {
            get { return (string)GetValue(CustomPlaceHolderProperty); }
            set { SetValue(CustomPlaceHolderProperty, value); }
        }


        /// <summary>
        /// The custom place holder color property.
        /// </summary>
        public static readonly BindableProperty CustomPlaceHolderColorProperty =
            BindableProperty.Create(nameof(CustomPlaceHolderColor), typeof(Color), typeof(BajioEntry), Theme.TextColorThird, BindingMode.OneWay);

        /// <summary>
        /// Gets or sets the color of the custom place holder.
        /// </summary>
        /// <value>The color of the custom place holder.</value>
        public Color CustomPlaceHolderColor
        {
            get { return (Color)GetValue(CustomPlaceHolderColorProperty); }
            set { SetValue(CustomPlaceHolderColorProperty, value); }
        }

        /// <summary>
        /// The separator property.
        /// </summary>
        public static readonly BindableProperty SeparatorProperty =
            BindableProperty.Create(nameof(Separator), typeof(List<string>), typeof(BajioEntry), default(List<string>), BindingMode.OneWay);

        /// <summary>
        /// Gets or sets the separator.
        /// </summary>
        /// <value>The separator.</value>
        public List<string> Separator
        {
            get { return (List<string>)GetValue(SeparatorProperty); }
            set { SetValue(SeparatorProperty, value); }
        }

        /// <summary>
        /// The return type property.
        /// </summary>
        public static readonly BindableProperty ReturnTypeProperty =
            BindableProperty.Create(nameof(ReturnType), typeof(ReturnTypeKeyboard), typeof(BajioEntry), ReturnTypeKeyboard.Done, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the type of the return.
        /// </summary>
        /// <value>The type of the return.</value>
        public ReturnTypeKeyboard ReturnType
        {
            get { return (ReturnTypeKeyboard)GetValue(ReturnTypeProperty); }
            set { SetValue(ReturnTypeProperty, value); }
        }

        /// <summary>
        /// The on complete command property.
        /// </summary>
        public static readonly BindableProperty OnCompleteCommandProperty =
            BindableProperty.Create(nameof(OnCompleteCommand), typeof(ICommand), typeof(BajioEntry), null, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the on complete command.
        /// </summary>
        /// <value>The on complete command.</value>
        public ICommand OnCompleteCommand
        {
            get { return (ICommand)GetValue(OnCompleteCommandProperty); }
            set { SetValue(OnCompleteCommandProperty, value); }
        }

        /// <summary>
        /// The command parameter property.
        /// </summary>
        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(BajioEntry), null);

        /// <summary>
        /// Gets or sets the command parameter.
        /// </summary>
        /// <value>The command parameter.</value>
        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }


        /// <summary>
        /// The space title entry property.
        /// </summary>
        public static readonly BindableProperty MarginEntryProperty =
            BindableProperty.Create(nameof(MarginEntry), typeof(Thickness), typeof(BajioEntry), new Thickness(12, 2, 0, 2), BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the space title entry.
        /// </summary>
        /// <value>The space title entry.</value>
        public Thickness MarginEntry
        {
            get { return (Thickness)GetValue(MarginEntryProperty); }
            set { SetValue(MarginEntryProperty, value); }
        }

        /// <summary>
        /// The un focus command property.
        /// </summary>
        public static readonly BindableProperty UnFocusedCommandProperty =
            BindableProperty.Create(nameof(UnFocusedCommand), typeof(Command), typeof(BajioEntry), null, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the un focus command.
        /// </summary>
        /// <value>The un focus command.</value>
        public Command UnFocusedCommand
        {
            get { return (Command)GetValue(UnFocusedCommandProperty); }
            set { SetValue(UnFocusedCommandProperty, value); }
        }

        /// <summary>
        /// The prevent keyboard suggestions property.
        /// </summary>
        public static readonly BindableProperty PreventKeyboardSuggestionsProperty =
            BindableProperty.Create(nameof(PreventKeyboardSuggestions), typeof(bool), typeof(BajioEntry), false, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether this prevent
        /// keyboard suggestions.
        /// </summary>
        /// <value><c>true</c> if prevent keyboard suggestions; otherwise, <c>false</c>.</value>
        public bool PreventKeyboardSuggestions
        {
            get
            {
                return (bool)GetValue(PreventKeyboardSuggestionsProperty);
            }
            set
            {
                SetValue(PreventKeyboardSuggestionsProperty, value);
            }
        }

        /// <summary>
        /// The next view property.
        /// </summary>
        public static readonly BindableProperty NextViewProperty =
            BindableProperty.Create(nameof(NextView), typeof(BajioEntry), typeof(BajioEntry));
        /// <summary>
        /// Gets or sets the next view.
        /// </summary>
        /// <value>The next view.</value>
        public BajioEntry NextView
        {
            get { return (BajioEntry)GetValue(NextViewProperty); }
            set { SetValue(NextViewProperty, value); }
        }
        /// <summary>
        /// The previous view property.
        /// </summary>
        public static readonly BindableProperty PrevViewProperty =
            BindableProperty.Create(nameof(PrevView), typeof(BajioEntry), typeof(BajioEntry));
        /// <summary>
        /// Gets or sets the previous view.
        /// </summary>
        /// <value>The previous view.</value>
        public BajioEntry PrevView
        {
            get { return (BajioEntry)GetValue(PrevViewProperty); }
            set { SetValue(PrevViewProperty, value); }
        }

        /// <summary>
        /// The index value property.
        /// </summary>
        public static readonly BindableProperty IndexValueProperty =
            BindableProperty.Create(nameof(IndexValue), typeof(int), typeof(BajioEntry), default(int), BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the index value.
        /// </summary>
        /// <value>The index value.</value>
        public int IndexValue
        {
            get
            {
                return (int)GetValue(IndexValueProperty);
            }
            set
            {
                SetValue(IndexValueProperty, value);
            }
        }

        /// <summary>
        /// The new value property.
        /// </summary>
        public static readonly BindableProperty NewValueProperty =
            BindableProperty.Create(nameof(NewValue), typeof(string), typeof(BajioEntry), default(string), BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the new value.
        /// </summary>
        /// <value>The new value.</value>
        public string NewValue
        {
            get { return (string)GetValue(NewValueProperty); }
            set { SetValue(NewValueProperty, value); }
        }

        /// <summary>
        /// Gets or sets the empty value.
        /// </summary>
        /// <value>The empty value.</value>
        public string EmptyValue
        {
            get
            {
                return _emptyValue;
            }
            set
            {
                _emptyValue = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The custom format property.
        /// </summary>
        public static readonly BindableProperty FormatedValueProperty =
            BindableProperty.Create(nameof(CustomFormat), typeof(string), typeof(BajioEntry), string.Empty, BindingMode.OneWay);

        /// <summary>
        /// Gets or sets the custom format.
        /// </summary>
        /// <value>The custom format.</value>
        public string FormatedValue
        {
            get { return (string)GetValue(FormatedValueProperty); }
            set { SetValue(FormatedValueProperty, value); }
        }

        /// <summary>
        /// The formated value hidden property.
        /// </summary>
        public static readonly BindableProperty FormatedValueHiddenProperty =
            BindableProperty.Create(nameof(FormatedValueHidden), typeof(string), typeof(BajioEntry), default(string), BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the formated value hidden.
        /// </summary>
        /// <value>The formated value hidden.</value>
        public string FormatedValueHidden
        {
            get
            {
                return (string)GetValue(FormatedValueHiddenProperty);
            }
            set
            {
                SetValue(FormatedValueHiddenProperty, value);
            }
        }

        /// <summary>
        /// The value to send property.
        /// </summary>
        public static readonly BindableProperty ValueToSendProperty =
            BindableProperty.Create(nameof(ValueToSend), typeof(string), typeof(BajioEntry), default(string), BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the value to send.
        /// </summary>
        /// <value>The value to send.</value>
        public string ValueToSend
        {
            get
            {
                return (string)GetValue(ValueToSendProperty);
            }
            set
            {
                SetValue(ValueToSendProperty, value);
            }
        }

        /// <summary>
        /// The is SSNP roperty.
        /// </summary>
        public static readonly BindableProperty IsSSNProperty =
            BindableProperty.Create(nameof(IsSSN), typeof(bool), typeof(BajioEntry), false, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether this  is ssn.
        /// </summary>
        /// <value><c>true</c> if is ssn; otherwise, <c>false</c>.</value>
        public bool IsSSN
        {
            get
            {
                return (bool)GetValue(IsSSNProperty);
            }
            set
            {
                SetValue(IsSSNProperty, value);
            }
        }

        /// <summary>
        /// The on focused command property.
        /// </summary>
        public static readonly BindableProperty OnFocusedCommandProperty =
            BindableProperty.Create(nameof(OnFocusedCommand), typeof(Command), typeof(BajioEntry), null, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the on focused command.
        /// </summary>
        /// <value>The on focused command.</value>
        public Command OnFocusedCommand
        {
            get { return (Command)GetValue(OnFocusedCommandProperty); }
            set { SetValue(OnFocusedCommandProperty, value); }
        }

        /// <summary>
        /// The icon entry login source property.
        /// </summary>
        public static readonly BindableProperty IconEntryLoginSourceProperty =
            BindableProperty.Create(nameof(IconEntryLoginSource), typeof(string), typeof(BajioEntry), string.Empty, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the icon entry login source.
        /// </summary>
        /// <value>The icon entry login source.</value>
        public string IconEntryLoginSource
        {
            get
            {
                return (string)GetValue(IconEntryLoginSourceProperty);
            }
            set
            {
                SetValue(IconEntryLoginSourceProperty, value);
            }
        }

        /// <summary>
        /// The entry automation identifier property.
        /// </summary>
		public static readonly BindableProperty EntryAutomationIdProperty =
            BindableProperty.Create(nameof(EntryAutomationId), typeof(string), typeof(BajioEntry), string.Empty, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the entry automation identifier.
        /// </summary>
        /// <value>The entry automation identifier.</value>
		public string EntryAutomationId
        {
            get
            {
                return (string)GetValue(EntryAutomationIdProperty);
            }
            set
            {
                SetValue(EntryAutomationIdProperty, value);
            }
        }

        /// <summary>
        /// The show or hides stack automation identifier property.
        /// </summary>
        public static readonly BindableProperty ShowOrHidesStackAutomationIdProperty =
            BindableProperty.Create(nameof(ShowOrHidesStackAutomationId), typeof(string), typeof(BajioEntry), string.Empty, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the show or hides stack automation identifier.
        /// </summary>
        /// <value>The show or hides stack automation identifier.</value>
		public string ShowOrHidesStackAutomationId
        {
            get
            {
                return (string)GetValue(ShowOrHidesStackAutomationIdProperty);
            }
            set
            {
                SetValue(ShowOrHidesStackAutomationIdProperty, value);
            }
        }

        /// <summary>
        /// The biometrics icon source property.
        /// </summary>
        public static readonly BindableProperty BiometricsIconSourceProperty =
           BindableProperty.Create(nameof(BiometricsIconSource), typeof(string), typeof(BajioEntry), string.Empty, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets the biometrics icon source.
        /// </summary>
        /// <value>The biometrics icon source.</value>
        public string BiometricsIconSource
        {
            get
            {
                return (string)GetValue(BiometricsIconSourceProperty);
            }
            set
            {
                SetValue(BiometricsIconSourceProperty, value);
            }
        }


        /// <summary>
        /// The biometrics command property.
        /// </summary>
        public static readonly BindableProperty BiometricsCommandProperty =
            BindableProperty.Create(nameof(BiometricsCommand), typeof(Command), typeof(BajioEntry), null, BindingMode.TwoWay);


        /// <summary>
        /// Gets or sets the biometrics command.
        /// </summary>
        /// <value>The biometrics command.</value>
        public Command BiometricsCommand
        {
            get { return (Command)GetValue(BiometricsCommandProperty); }
            set { SetValue(BiometricsCommandProperty, value); }
        }

        /// <summary>
        /// Is to show a disable label with the amount.
        /// </summary>
        public static readonly BindableProperty IsVisibleDisableLabelProperty =
            BindableProperty.Create(nameof(IsVisibleDisableLabel), typeof(bool), typeof(BajioEntry), false, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets a value indicating whether this is visible
        /// disable label.
        /// </summary>
        /// <value><c>true</c> if is visible disable label; otherwise, <c>false</c>.</value>
        public bool IsVisibleDisableLabel
        {
            get { return (bool)GetValue(IsVisibleDisableLabelProperty); }
            set { SetValue(IsVisibleDisableLabelProperty, value); }
        }

        /// <summary>
        /// The edit value disable property.
        /// </summary>
        public static readonly BindableProperty EditValueDisableProperty =
            BindableProperty.Create(nameof(EditValueDisable), typeof(double), typeof(BajioEntry), double.MinValue, BindingMode.TwoWay);

        /// <summary>
        ///  Used to assing the Amount value when the control shows as disable contro
        /// </summary>
        /// <value>The edit value disable.</value>
        public double EditValueDisable
        {
            get { return (double)GetValue(EditValueDisableProperty); }
            set { SetValue(EditValueDisableProperty, value); }
        }

        /// <summary>
        /// Icon size property
        /// </summary>
        public static readonly BindableProperty IconSizeProperty = BindableProperty.Create(nameof(IconSize),
            typeof(int), typeof(BajioEntry), 20, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets value indicating icon size
        /// </summary>
        public int IconSize
        {
            get { return (int)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }

        /// <summary>
        /// Show Icon property
        /// </summary>
        public static readonly BindableProperty ShowIconProperty = BindableProperty.Create(nameof(ShowIcon),
            typeof(bool), typeof(BajioEntry), false, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets value indicating show icon
        /// </summary>
        public bool ShowIcon
        {
            get { return (bool)GetValue(ShowIconProperty); }
            set { SetValue(ShowIconProperty, value); }
        }

        /// <summary>
        /// Icon Source property
        /// </summary>
        public static readonly BindableProperty IconSourceProperty = BindableProperty.Create(nameof(IconSource),
            typeof(EntryIcon), typeof(BajioEntry), EntryIcon.SearchIcon, BindingMode.TwoWay);

        /// <summary>
        /// Gets or sets value indicating icon source
        /// </summary>
        public EntryIcon IconSource
        {
            get { return (EntryIcon)GetValue(IconSourceProperty); }
            set { SetValue(IconSourceProperty, value); }
        }

        /// <summary>
        /// The svg image render
        /// </summary>
        private readonly SvgCachedImage _svgIconImage = new SvgCachedImage()
        {
            WidthRequest = 20,
            HeightRequest = 20,
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            Margin = new Thickness(10, 0, 0, 0),
            Source = "search.svg",
            IsVisible = false
        };
        #endregion

        #endregion

        #region Private Properties
        private bool IsLoading = true;
        private string CurrencySymbol;
        private string PercentageSymbol;
        private string DecimalFormat;
        private string _emptyValue = string.Empty;
        private bool _isCreatedBiometricsEntry = false;
        private bool _isCreatedCustomEyeballEntry = false;

        private Label _editValueDisableLabel = new Label()
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.FillAndExpand,
            VerticalTextAlignment = TextAlignment.Center,
        };

        private BajioEntryCurrencyBehavior _dollarBehavior;
        #endregion

        #region Public Methods
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public BajioEntry()
        {
            //Setting up bindings
            EntryEditor.BindingContext = this;
            EntryEditor.VerticalOptions = LayoutOptions.Center;
            EntryEditor.SetBinding(Entry.FontSizeProperty, nameof(EntryFontSize));
            EntryEditor.SetBinding(Entry.TextColorProperty, nameof(EntryTextColor));
            EntryEditor.SetBinding(Entry.TextProperty, nameof(Text), BindingMode.TwoWay);
            EntryEditor.SetBinding(Entry.HorizontalTextAlignmentProperty, nameof(EntryHorizontalTextAligment));
            EntryEditor.SetBinding(HeightRequestProperty, nameof(EntryHeight), BindingMode.TwoWay);
            EntryEditor.Focused += EntryEditor_Focused;
            EntryEditor.TextChanged += EntryEditor_TextChanged;
            EntryEditor.Unfocused += EntryEditor_Unfocused;
            EntryEditor.Completed += EntryEditor_Completed;
            EntryEditor.Margin = MarginEntry;
            if (ClearCommand == null)
            {
                ClearCommand = new Command(OnClear);
            }
            //Add controls
            ContainerControl = new BajioContainerControl();
            ContainerControl.BindingContext = this;
            ContainerControl.SetBinding(BajioContainerControl.ErrorMessageProperty, nameof(ErrorMessage), BindingMode.TwoWay);
            ContainerControl.SetBinding(BajioContainerControl.ErrorProperty, nameof(Error), BindingMode.TwoWay);
            ContainerControl.SetBinding(BajioContainerControl.IsBorderDisplayedProperty, nameof(IsBorderDisplayed));
            ContainerControl.SetBinding(BajioContainerControl.BorderWidthProperty, nameof(BorderWidth));
            ContainerControl.SetBinding(BajioContainerControl.CornerRadiusProperty, nameof(CornerRadius));
            ContainerControl.ColumnDefinitions?.Clear();
            ContainerControl.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            ContainerControl.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            ContainerControl.RowSpacing = 0;
            ContainerControl.ColumnSpacing = 0;
            ContainerControl.Padding = new Thickness(0, 0, 10, 0);

            _editValueDisableLabel.SetBinding(Label.FontSizeProperty, nameof(EntryFontSize));
            _editValueDisableLabel.SetBinding(Label.TextColorProperty, nameof(EntryTextColor));
            _editValueDisableLabel.SetBinding(Label.HorizontalTextAlignmentProperty, nameof(EntryHorizontalTextAligment));
            _editValueDisableLabel.SetBinding(HeightRequestProperty, nameof(EntryHeight), BindingMode.TwoWay);
            _editValueDisableLabel.SetBinding(BackgroundColorProperty, nameof(BackgroundColor), BindingMode.TwoWay);
            _editValueDisableLabel.SetBinding(Label.IsVisibleProperty, nameof(IsVisibleDisableLabel), BindingMode.TwoWay);
            _editValueDisableLabel.SetBinding(Label.MarginProperty, nameof(MarginEntry), BindingMode.TwoWay);

            ContainerControl.Children.Add(EntryEditor, 1, 0);
            ContainerControl.Children.Add(_editValueDisableLabel, 1, 0);
            ContainerControl.Children.Add(_svgIconImage, 0, 0);
            Appearing += OnAppearing;

            EntryEditor.Completed += _entry_Completed;

            ClearButtonEnable = true;
        }

        /// <summary>
        /// Entries the editor focused.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        public async void EntryEditor_Focused(object sender, FocusEventArgs e)
        {
            OnFocusedCommand?.Execute(e);
            if (EntryEditor.Text != null)
            {
                EntryEditor.CursorPosition = EntryEditor.Text.Length;
            }

            if (ParentScroll == null || Device.RuntimePlatform != Device.iOS)
            {
                return;
            }

            await ParentScroll.ScrollToAsync(EntryEditor, ScrollToPosition.Start, true);
        }

        /// <summary>
        /// Entries the editor text changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        public void EntryEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Text))
            {
                Text = ((Entry)sender).Text;
            }

            if (IsLoading || e.NewTextValue == null)
            {
                return;
            }

            if (e.NewTextValue != e.OldTextValue)
            {
                PrevValue = e.OldTextValue;
            }

            if ((e.NewTextValue != (string.IsNullOrEmpty(InitValue) ? string.Empty : InitValue) && Mask != EntryMaskType.Dollar ||
                 e.NewTextValue != (string.IsNullOrEmpty(InitValue) ? string.Empty : InitValue) && Mask == EntryMaskType.Dollar && EditValue != double.MinValue)
                && e.NewTextValue != PrevValue)
            {
                HasChanges = true;
            }
            else
            {
                HasChanges = false;
            }
            TextChangedCommand?.Execute(e);
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Ons the property changed.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(IconEntryLoginSource))
            {
                if (!string.IsNullOrEmpty(IconEntryLoginSource))
                {
                    var iconForLoginEntries = new SvgCachedImage()
                    {
                        WidthRequest = 18,
                        HeightRequest = 16,
                        VerticalOptions = LayoutOptions.Center,
                        Margin = new Thickness(5, 0, 5, 0)
                    };

                    var _imageSourceConverter = new ImageSourceConverter();
                    var xfSource = _imageSourceConverter.ConvertFromInvariantString(IconEntryLoginSource) as ImageSource;
                    iconForLoginEntries.Source = new SvgImageSource(xfSource, 0, 0, true);

                    var stackClearButton = ContainerControl?.Children[1];

                    ContainerControl = new BajioContainerControl();
                    ContainerControl.ColumnSpacing = 0;
                    ContainerControl.RowDefinitions?.Clear();
                    ContainerControl.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });

                    ContainerControl.ColumnDefinitions?.Clear();
                    ContainerControl.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                    ContainerControl.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                    ContainerControl.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                    var currentMarginEntry = EntryEditor.Margin;
                    currentMarginEntry.Left = 0;
                    EntryEditor.Margin = currentMarginEntry;
                    ContainerControl.Children.Add(iconForLoginEntries, 0, 1);
                    ContainerControl.Children.Add(EntryEditor, 1, 1);
                    ContainerControl.Children.Add(stackClearButton, 2, 1);
                }
            }
            if (propertyName == nameof(Enabled))
            {
                EntryEditor.IsEnabled = Enabled;
                ContainerControl.IsEnabled = Enabled;
                if (ClearIcon != null)
                {
                    ClearIcon.Enabled = Enabled;
                }
                return;
            }

            if (propertyName == nameof(Mask))
            {
                SetKeyboardType();

                if (Mask == EntryMaskType.Numeric)
                {
                    var textBehavior = new BajioEntryMaxLengthBehavior
                    {
                        BindingContext = this
                    };
                    textBehavior.SetBinding(BajioEntryMaxLengthBehavior.MaxLengthProperty, nameof(EntryMaxLength));
                    EntryEditor.Behaviors.Add(textBehavior);
                    return;
                }
                if (Mask == EntryMaskType.Text)
                {
                    var textBehavior = new BajioEntryMaxLengthBehavior
                    {
                        BindingContext = this
                    };
                    textBehavior.SetBinding(BajioEntryMaxLengthBehavior.MaxLengthProperty, nameof(EntryMaxLength));
                    EntryEditor.Behaviors.Add(textBehavior);
                    return;
                }

                if (Mask == EntryMaskType.Number)
                {
                    var numberBehavior = new BajioEntryNumberBehavior
                    {
                        BindingContext = this
                    };
                    numberBehavior.SetBinding(BajioEntryNumberBehavior.EntryMaxLengthProperty, nameof(EntryMaxLength));
                    EntryEditor.Behaviors.Add(numberBehavior);
                    return;
                }

                if (Mask == EntryMaskType.HashTagNumber)
                {
                    var numberBehavior = new BajioEntryHashTagNumberBehaivor
                    {
                        BindingContext = this
                    };
                    numberBehavior.SetBinding(BajioEntryHashTagNumberBehaivor.EntryMaxLengthProperty, nameof(EntryMaxLength));
                    EntryEditor.Behaviors.Add(numberBehavior);
                    return;
                }

                if (Mask == EntryMaskType.Code)
                {
                    var codeBehavior = new BajioEntryCodeBehavior
                    {
                        BindingContext = this
                    };
                    codeBehavior.SetBinding(BajioEntryCodeBehavior.EntryMaxLengthProperty, nameof(EntryMaxLength));
                    codeBehavior.SetBinding(BajioEntryCodeBehavior.TextProperty, nameof(Text));
                    EntryEditor.Behaviors.Add(codeBehavior);
                    return;
                }

                if (Mask == EntryMaskType.Dollar)
                {
                    _dollarBehavior = new BajioEntryCurrencyBehavior
                    {
                        BindingContext = this
                    };
                    CurrencySymbol = CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
                    DecimalFormat = "{0:###,###,##0." + "".PadRight(DecimalPositions, '0') + "}";
                    _dollarBehavior.CurrencySymbol = CurrencySymbol;
                    _dollarBehavior.SetBinding(BajioEntryCurrencyBehavior.MaxLengthProperty, nameof(EntryMaxLength));
                    _dollarBehavior.SetBinding(BajioEntryCurrencyBehavior.EditValueProperty, nameof(EditValue));
                    _dollarBehavior.SetBinding(BajioEntryCurrencyBehavior.TextProperty, nameof(Text));
                    _dollarBehavior.SetBinding(BajioEntryCurrencyBehavior.DecimalPostionsProperty, nameof(DecimalPositions));
                    EntryEditor.Behaviors.Add(_dollarBehavior);
                    return;
                }

                if (Mask == EntryMaskType.Percentage)
                {
                    var customPercentageBehavior = new BajioEntryPercentageBehavior
                    {
                        BindingContext = this,
                    };
                    PercentageSymbol = "%";
                    DecimalFormat = "{0:###,###,##0." + "".PadRight(DecimalPositions, '0') + "}";
                    customPercentageBehavior.PercentageSymbol = PercentageSymbol;
                    customPercentageBehavior.SetBinding(BajioEntryPercentageBehavior.MaxLengthProperty, nameof(EntryMaxLength));
                    customPercentageBehavior.SetBinding(BajioEntryPercentageBehavior.EditValueProperty, nameof(EditValue));
                    customPercentageBehavior.SetBinding(BajioEntryPercentageBehavior.TextProperty, nameof(Text));
                    customPercentageBehavior.SetBinding(BajioEntryPercentageBehavior.DecimalPostionsProperty, nameof(DecimalPositions));
                    EntryEditor.Behaviors.Add(customPercentageBehavior);
                    return;
                }

                if (Mask == EntryMaskType.Percentage)
                {
                    var customPercentageBehavior = new BajioEntryPercentageBehavior
                    {
                        BindingContext = this,
                    };
                    PercentageSymbol = "%";
                    DecimalFormat = "{0:###,###,##0." + "".PadRight(DecimalPositions, '0') + "}";
                    customPercentageBehavior.PercentageSymbol = PercentageSymbol;
                    customPercentageBehavior.SetBinding(BajioEntryPercentageBehavior.MaxLengthProperty, nameof(EntryMaxLength));
                    customPercentageBehavior.SetBinding(BajioEntryPercentageBehavior.EditValueProperty, nameof(EditValue));
                    customPercentageBehavior.SetBinding(BajioEntryPercentageBehavior.TextProperty, nameof(Text));
                    customPercentageBehavior.SetBinding(BajioEntryPercentageBehavior.DecimalPostionsProperty, nameof(DecimalPositions));
                    EntryEditor.Behaviors.Add(customPercentageBehavior);
                    return;
                }

                if (Mask == EntryMaskType.Password)
                {
                    var passwordBehavior = new BajioEntryMaxLengthBehavior
                    {
                        BindingContext = this
                    };
                    passwordBehavior.SetBinding(BajioEntryMaxLengthBehavior.MaxLengthProperty, nameof(EntryMaxLength));
                    EntryEditor.Behaviors.Add(passwordBehavior);
                    IsPasswordVisible = false;
                    EntryEditor.IsPassword = true;
                    return;
                }

                if (Mask == EntryMaskType.SSN)
                {
                    CustomFormat = "###-##-####";
                    CustomPlaceHolder = "###-##-####";

                    Separator = new List<string>
                    {
                        "-"
                    };

                    var customSSNBehavior = new BajioEntryCustomFormatBehavior
                    {
                        BindingContext = this,
                    };
                    customSSNBehavior.SetBinding(BajioEntryCustomFormatBehavior.TextProperty, nameof(Text));
                    customSSNBehavior.SetBinding(BajioEntryCustomFormatBehavior.CustomFormatProperty, nameof(CustomFormat));
                    customSSNBehavior.SetBinding(BajioEntryCustomFormatBehavior.CustomPlaceHolderProperty, nameof(CustomPlaceHolder));
                    customSSNBehavior.SetBinding(BajioEntryCustomFormatBehavior.SeparatorProperty, nameof(Separator));
                    customSSNBehavior.SetBinding(BajioEntryCustomFormatBehavior.FormatedValueProperty, nameof(FormatedValue));
                    customSSNBehavior.SetBinding(BajioEntryCustomFormatBehavior.ValueToSendProperty, nameof(ValueToSend));
                    EntryEditor.IsValuePassword = true;
                    EntryEditor.Behaviors.Add(customSSNBehavior);
                    return;
                }

                if (Mask == EntryMaskType.Phone)
                {
                    CustomFormat = "(###)-###-####";
                    CustomPlaceHolder = "(###)-###-####";

                    Separator = new List<string>
                    {
                        "(",
                        ")",
                        "-"
                    };

                    var customPhoneBehavior = new BajioEntryCustomFormatBehavior
                    {
                        BindingContext = this
                    };
                    customPhoneBehavior.SetBinding(BajioEntryCustomFormatBehavior.TextProperty, nameof(Text));
                    customPhoneBehavior.SetBinding(BajioEntryCustomFormatBehavior.CustomFormatProperty, nameof(CustomFormat));
                    customPhoneBehavior.SetBinding(BajioEntryCustomFormatBehavior.CustomPlaceHolderProperty, nameof(CustomPlaceHolder));
                    customPhoneBehavior.SetBinding(BajioEntryCustomFormatBehavior.SeparatorProperty, nameof(Separator));
                    customPhoneBehavior.SetBinding(BajioEntryCustomFormatBehavior.ValueToSendProperty, nameof(ValueToSend));
                    EntryEditor.Behaviors.Add(customPhoneBehavior);
                    return;
                }

                if (Mask == EntryMaskType.PhoneSecond)
                {
                    CustomFormat = "(###) ###-####";
                    CustomPlaceHolder = "(###) ###-####";

                    Separator = new List<string>
                    {
                        "(",
                        ")",
                        "-"
                    };

                    var customPhoneBehavior = new BajioEntryCustomFormatBehavior
                    {
                        BindingContext = this
                    };
                    customPhoneBehavior.SetBinding(BajioEntryCustomFormatBehavior.TextProperty, nameof(Text));
                    customPhoneBehavior.SetBinding(BajioEntryCustomFormatBehavior.CustomFormatProperty, nameof(CustomFormat));
                    customPhoneBehavior.SetBinding(BajioEntryCustomFormatBehavior.CustomPlaceHolderProperty, nameof(CustomPlaceHolder));
                    customPhoneBehavior.SetBinding(BajioEntryCustomFormatBehavior.SeparatorProperty, nameof(Separator));
                    customPhoneBehavior.SetBinding(BajioEntryCustomFormatBehavior.ValueToSendProperty, nameof(ValueToSend));
                    EntryEditor.Behaviors.Add(customPhoneBehavior);
                    return;
                }

                if (Mask == EntryMaskType.WorkPhone)
                {
                    CustomFormat = "(###)-###-#### ext ####";
                    CustomPlaceHolder = "(###)-###-#### ext ####";

                    Separator = new List<string>
                    {
                        "(",
                        ")",
                        "-",
                        " ",
                        "e",
                        "x",
                        "t",
                        " "
                    };

                    var customWorkPhoneBehavior = new BajioEntryCustomFormatBehavior
                    {
                        BindingContext = this
                    };
                    customWorkPhoneBehavior.SetBinding(BajioEntryCustomFormatBehavior.TextProperty, nameof(Text));
                    customWorkPhoneBehavior.SetBinding(BajioEntryCustomFormatBehavior.CustomFormatProperty, nameof(CustomFormat));
                    customWorkPhoneBehavior.SetBinding(BajioEntryCustomFormatBehavior.CustomPlaceHolderProperty, nameof(CustomPlaceHolder));
                    customWorkPhoneBehavior.SetBinding(BajioEntryCustomFormatBehavior.SeparatorProperty, nameof(Separator));
                    customWorkPhoneBehavior.SetBinding(BajioEntryCustomFormatBehavior.ValueToSendProperty, nameof(ValueToSend));
                    EntryEditor.Behaviors.Add(customWorkPhoneBehavior);
                    return;
                }

                if (Mask == EntryMaskType.Email)
                {
                    var customEmailTextBehavior = new BajioEntryCustomFormatBehavior
                    {
                        BindingContext = this
                    };
                    customEmailTextBehavior.SetBinding(BajioEntryCustomFormatBehavior.TextProperty, nameof(Text));
                    return;
                }
            }
            if (propertyName == nameof(DecimalPositions))
            {
                DecimalFormat = "{0:###,###,##0." + "".PadRight(DecimalPositions, '0') + "}";
                return;
            }
            if (propertyName == nameof(EditValue))
            {
                if (Mask == EntryMaskType.Dollar)
                {
                    if (Text.Replace(CurrencySymbol, string.Empty).Replace(",", string.Empty) == EditValue.ToString())
                        return;

                    Text = EditValue.ToString();
                }
                else if (Mask == EntryMaskType.Percentage)
                {
                    if (Text.Replace(PercentageSymbol, string.Empty).Replace(",", string.Empty) == EditValue.ToString())
                        return;

                    Text = EditValue.ToString();
                }
                else
                {
                    Text = EditValue.ToString();
                }
                return;
            }
            if (propertyName == nameof(Error))
            {
                ContainerControl.Error = Error;
                return;
            }
            if (propertyName == nameof(ErrorMessage))
            {
                ContainerControl.ErrorMessage = ErrorMessage;
                return;
            }
            if (propertyName == nameof(OnFocusError))
            {
                if (OnFocusError && !EntryEditor.IsFocused && !IsVisibleDisableLabel)
                {
                    if (_dollarBehavior == null)
                    {
                        EntryEditor.Focus();
                    }

                }
            }
            if (propertyName == nameof(EntryHeight))
            {
                EntryEditor.HeightRequest = EntryHeight;
                return;
            }
            if (propertyName == nameof(Title))
            {
                return;
            }
            if (propertyName == nameof(IsPasswordVisible))
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (EntryEditor.IsSSN)
                    {
                        EntryEditor.IsValuePassword = !IsPasswordVisible;
                        if (IsPasswordVisible)
                        {
                            EntryEditor.Text = EntryEditor.FormatedValue;
                        }
                        else
                        {
                            EntryEditor.Text = EntryEditor.FormatedValueHidden;
                        }
                    }
                    else
                    {
                        EntryEditor.IsPassword = !IsPasswordVisible;
                    }
                });
                return;
            }
            if (propertyName == nameof(CustomPlaceHolder))
            {
                EntryEditor.Placeholder = CustomPlaceHolder;
                return;
            }
            if (propertyName == nameof(ShouldInvokeAction))
            {
                if (ShouldInvokeAction)
                {
                    EntryEditor.ShouldInvokeAction = ShouldInvokeAction;
                }
            }
            if (propertyName == nameof(ReturnType))
            {
                EntryEditor.ReturnType = ReturnType;
            }
            if (propertyName == nameof(Text))
            {
                EntryEditor.Text = Text;
                ValueToSend = EntryEditor.ValueToSend;
            }
            if (propertyName == nameof(OnCompleteCommand))
            {
                EntryEditor.OnCompleteCommand = OnCompleteCommand;
            }
            if (propertyName == nameof(CommandParameter))
            {
                EntryEditor.CommandParameter = CommandParameter;
            }
            if (propertyName == nameof(EntryStrokeBorder))
            {
                ContainerControl.SetBinding(BajioContainerControl.StrokeBorderProperty, nameof(EntryStrokeBorder));
            }
            if (propertyName == nameof(MarginEntry))
            {
                EntryEditor.Margin = MarginEntry;
                _editValueDisableLabel.Margin = MarginEntry;
            }
            if (propertyName == FocusViewProperty.PropertyName)
            {
                EntryEditor.Focus();
            }
            if (propertyName == PreventKeyboardSuggestionsProperty.PropertyName)
            {
                if (PreventKeyboardSuggestions)
                    EntryEditor.PreventKeyboardSuggestions = true;
            }
            if (propertyName == nameof(NextView))
            {
                EntryEditor.NextView = NextView;
            }
            if (propertyName == nameof(PrevView))
            {
                EntryEditor.PrevView = PrevView;
            }
            if (propertyName == nameof(FormatedValue))
            {
                EntryEditor.FormatedValue = FormatedValue;
            }
            if (propertyName == nameof(FormatedValueHidden))
            {
                EntryEditor.FormatedValueHidden = FormatedValueHidden;
            }
            if (propertyName == nameof(ValueToSend))
            {
                EntryEditor.ValueToSend = ValueToSend;
            }
            if (propertyName == nameof(IsSSN))
            {
                EntryEditor.IsSSN = IsSSN;
            }
            if (propertyName == nameof(OnCompleteCommand))
            {
                EntryEditor.OnCompleteCommand = OnCompleteCommand;
            }
            if (propertyName == nameof(UnFocusedCommand))
            {
                EntryEditor.UnfocusedCommand = UnFocusedCommand;
            }
            if (propertyName == nameof(OnFocusedCommand))
            {
                EntryEditor.OnfocusedCommand = OnFocusedCommand;
            }
            if (propertyName == nameof(TextChangedCommand))
            {
                EntryEditor.TextChangedCommand = TextChangedCommand;
            }
            if (propertyName == nameof(EntryAutomationId))
            {
                EntryEditor.AutomationId = EntryAutomationId;
            }
            if (propertyName == nameof(ShowOrHidesStackAutomationId))
            {
                _showOrHideStack.AutomationId = ShowOrHidesStackAutomationId;
            }
            if (propertyName == BackgroundColorProperty.PropertyName)
            {
                EntryEditor.BackgroundColor = BackgroundColor;
                ContainerControl.BackgroundColor = BackgroundColor;
                _editValueDisableLabel.BackgroundColor = BackgroundColor;
            }
            if (propertyName == CustomPlaceHolderColorProperty.PropertyName)
            {
                EntryEditor.PlaceholderColor = CustomPlaceHolderColor;
            }
            if (propertyName == EntryTextColorProperty.PropertyName)
            {
                EntryEditor.TextColor = EntryTextColor;
                EntryEditor.CustomTextColor = EntryTextColor;
            }

            if (propertyName == BiometricsIconSourceProperty.PropertyName)
            {
                if (!string.IsNullOrEmpty(BiometricsIconSource))
                {
                    IsPasswordVisible = false;
                    ChangeDefaultCustomIcon();
                    var iconForBiometrics = new SvgCachedImage()
                    {
                        WidthRequest = 30,
                        HeightRequest = 30,
                        VerticalOptions = LayoutOptions.Center,
                        Margin = new Thickness(5, 0, 5, 0)
                    };


                    iconForBiometrics.GestureRecognizers.Add
                                     (
                                         new TapGestureRecognizer
                                         {
                                             Command = new Command(BiometricsClicked)
                                         }
                                       );

                    var _imageSourceConverter = new ImageSourceConverter();
                    var xfSource = _imageSourceConverter.ConvertFromInvariantString(BiometricsIconSource) as ImageSource;
                    iconForBiometrics.Source = new SvgImageSource(xfSource, 0, 0, true);

                    if (!_isCreatedBiometricsEntry && !_isCreatedCustomEyeballEntry)
                    {
                        ContainerControl = new BajioContainerControl();
                        ContainerControl.ColumnSpacing = 0;
                        ContainerControl.RowDefinitions?.Clear();
                        ContainerControl.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
                        ContainerControl.BorderWidth = BorderWidth;
                        ContainerControl.StrokeBorder = EntryStrokeBorder;
                        ContainerControl.CornerRadius = CornerRadius;

                        ContainerControl.ColumnDefinitions?.Clear();
                        ContainerControl.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                        ContainerControl.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                        ContainerControl.RowSpacing = 0;
                        ContainerControl.Children.Add(EntryEditor, 0, 1);
                        _isCreatedBiometricsEntry = true;
                    }

                    var hasBiometrics = ContainerControl.Children.FirstOrDefault(ch => ch is SvgCachedImage);
                    if (hasBiometrics == null)
                    {
                        ContainerControl.Children.Add(iconForBiometrics, 1, 1);
                    }
                    else
                    {
                        hasBiometrics.IsVisible = true;
                    }

                }
                else
                {
                    var hasBiometrics = ContainerControl.Children.FirstOrDefault(ch => ch is SvgCachedImage);
                    if (hasBiometrics != null)
                    {
                        hasBiometrics.IsVisible = false;
                    }
                }
            }

            if (propertyName == nameof(CustomIconNameHiding))
            {
                if (!string.IsNullOrEmpty(CustomIconNameHiding))
                {

                    if (CustomIconNameHiding.Contains(".svg") && !IsCustomIcon)
                    {
                        if (!_isCreatedCustomEyeballEntry && !_isCreatedBiometricsEntry)
                        {
                            ContainerControl = new BajioContainerControl();
                            ContainerControl.ColumnSpacing = 0;
                            ContainerControl.RowDefinitions?.Clear();
                            ContainerControl.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
                            ContainerControl.BorderWidth = BorderWidth;
                            ContainerControl.StrokeBorder = EntryStrokeBorder;
                            ContainerControl.CornerRadius = CornerRadius;

                            ContainerControl.ColumnDefinitions?.Clear();
                            ContainerControl.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                            ContainerControl.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                            ContainerControl.RowSpacing = 0;
                            ContainerControl.Children.Add(EntryEditor, 0, 1);
                            _isCreatedCustomEyeballEntry = true;
                        }

                        var customItem = ContainerControl.Children.FirstOrDefault(cl => cl.StyleId == "customicon");
                        if (customItem == null)
                        {
                            CustomSvgIcon = new BajioSvgIcon
                            {
                                StyleId = "customicon",
                                Icon = CustomIconNameHiding,
                                BindingContext = this,
                                WidthRequest = (int)Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                                VerticalOptions = LayoutOptions.CenterAndExpand,
                                HorizontalOptions = LayoutOptions.CenterAndExpand,
                                Orientation = StackOrientation.Horizontal,
                                Margin = new Thickness(5, 0, 12, 0)
                            };
                            CustomSvgIcon.GestureRecognizers.Add(new TapGestureRecognizer
                            {
                                Command = new Command(OnShowOrHideCustomSvgTapped)
                            });

                            ContainerControl.Children.Add(CustomSvgIcon, 1, 1);
                        }
                        else
                        {
                            customItem.IsVisible = true;
                        }
                    }

                }
                else
                {
                    var customItem = ContainerControl.Children.FirstOrDefault(cl => cl.StyleId == "customicon");
                    if (customItem != null)
                    {
                        customItem.IsVisible = false;
                    }
                }
                return;
            }

            if (propertyName == nameof(EntryHorizontalTextAligment))
            {
                if (EntryHorizontalTextAligment == TextAlignment.Center)
                {
                    EntryEditor.IsCenterText = true;
                }
            }
            if (propertyName == nameof(IsVisibleDisableLabel))
            {
                _editValueDisableLabel.IsVisible = IsVisibleDisableLabel;
            }
            if (propertyName == nameof(EditValueDisable))
            {
                _editValueDisableLabel.Text = $"{CurrencySymbol}{string.Format(DecimalFormat, EditValueDisable)}"; ;
            }
            if (propertyName == IconSizeProperty.PropertyName)
            {
                _svgIconImage.HeightRequest = IconSize;
                _svgIconImage.WidthRequest = IconSize;
            }
            if (propertyName == ShowIconProperty.PropertyName)
            {
                if (ShowIcon)
                {
                    _svgIconImage.IsVisible = true;
                }
            }
            if (propertyName == IconSourceProperty.PropertyName)
            {
                switch (IconSource)
                {
                    case EntryIcon.SearchIcon:
                        _svgIconImage.Source = "search.svg";
                        break;
                    case EntryIcon.User:
                        _svgIconImage.Source = "Login_User.svg";
                        break;
                    case EntryIcon.Pass:
                        _svgIconImage.Source = "Login_Pass.svg";
                        break;
                }
            }
        }

        /// <summary>
        /// Ons the appearing.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        protected void OnAppearing(object sender, EventArgs e)
        {
            ConfigureDefaultMask();

            if (Mask == EntryMaskType.Dollar)
            {
                //Format initial value during load
                Text = $"{CurrencySymbol}{string.Format(DecimalFormat, EditValue)}";
            }
            if (Mask == EntryMaskType.Percentage)
            {
                //Format initial value during load
                Text = $"{string.Format(DecimalFormat, EditValue)}{PercentageSymbol}";
            }
            InitValue = this.Text;

            //finishing loading control
            IsLoading = false;
            //has changes always must be at the end of appearing control
            HasChanges = false;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Set eyeball when it disappears.
        /// </summary>
        private void ChangeDefaultCustomIcon()
        {
            if (!string.IsNullOrEmpty(CustomIconNameHiding))
            {
                CustomSvgIcon.Icon = CustomIconNameHiding;
            }
        }

        /// <summary>
        /// Ons the show or hide custom svg tapped.
        /// </summary>
        private void OnShowOrHideCustomSvgTapped()
        {
            IsPasswordVisible = !IsPasswordVisible;
            CustomSvgIcon.Icon = IsPasswordVisible ? CustomHideIconNameHiding : CustomIconNameHiding;
        }

        /// <summary>
        /// Ons the clear.
        /// </summary>
        private void OnClear()
        {
            Text = EmptyValue;
            if (!EntryEditor.IsFocused)
            {
                EntryEditor.Focus();
            }
        }

        /// <summary>
        /// Sets the type of the keyboard.
        /// </summary>
        private void SetKeyboardType()
        {
            switch (Mask)
            {
                case EntryMaskType.Phone:
                case EntryMaskType.WorkPhone:
                case EntryMaskType.PhoneSecond:
                    EntryEditor.KeyBoardType = EntryKeyBoardType.Telephone;
                    EntryEditor.Keyboard = Keyboard.Telephone;
                    EmptyValue = string.Empty;
                    break;
                case EntryMaskType.Number:
                case EntryMaskType.Numeric:
                    EntryEditor.KeyBoardType = EntryKeyBoardType.Numeric;
                    EntryEditor.Keyboard = Keyboard.Numeric;
                    EmptyValue = string.Empty;
                    break;
                case EntryMaskType.Code:
                    EntryEditor.KeyBoardType = EntryKeyBoardType.Numeric;
                    EntryEditor.Keyboard = Keyboard.Numeric;
                    EmptyValue = string.Empty;
                    break;
                case EntryMaskType.Dollar:
                case EntryMaskType.Percentage:
                    EntryEditor.KeyBoardType = EntryKeyBoardType.Decimal;
                    EntryEditor.Keyboard = Keyboard.Numeric;
                    EmptyValue = "0";
                    break;
                case EntryMaskType.Email:
                    EntryEditor.KeyBoardType = EntryKeyBoardType.Email;
                    EntryEditor.Keyboard = Keyboard.Email;
                    EmptyValue = string.Empty;
                    break;
                case EntryMaskType.SSN:
                    EntryEditor.KeyBoardType = EntryKeyBoardType.Numeric;
                    EntryEditor.Keyboard = Keyboard.Numeric;
                    EmptyValue = string.Empty;
                    break;
                case EntryMaskType.HashTagNumber:
                    EntryEditor.KeyBoardType = EntryKeyBoardType.Numeric;
                    EntryEditor.Keyboard = Keyboard.Numeric;
                    EmptyValue = "#";
                    break;
                case EntryMaskType.Password:
                    EntryEditor.KeyBoardType = EntryKeyBoardType.Plain;
                    EntryEditor.Keyboard = Keyboard.Plain;
                    EmptyValue = string.Empty;
                    break;
                default:
                    EntryEditor.Keyboard = Keyboard.Text;
                    EntryEditor.KeyBoardType = EntryKeyBoardType.Text;
                    EmptyValue = string.Empty;
                    break;
            }
        }

        /// <summary>
        /// Configures the default mask.
        /// </summary>
        private void ConfigureDefaultMask()
        {
            if (Mask == null)
            {
                Mask = EntryMaskType.Text;
            }
        }

        /// <summary>
        /// Entries the editor completed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void EntryEditor_Completed(object sender, EventArgs e)
        {
            OnCompleted?.Invoke(this, e);
        }

        /// <summary>
        /// the next view action is completed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void _entry_NextViewCompleted(object sender, EventArgs e)
        {
            NextEntryCommand?.Execute(null);
        }

        /// <summary>
        /// Entries the completed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void _entry_Completed(object sender, System.EventArgs e)
        {
            ReturnEntryCommand?.Execute(e);
        }

        /// <summary>
        /// Entries the editor unfocused.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void EntryEditor_Unfocused(object sender, FocusEventArgs e)
        {
            UnFocusedCommand?.Execute(e);
        }

        /// <summary>
        /// Biometricses the clicked.
        /// </summary>
        private void BiometricsClicked()
        {
            BiometricsCommand?.Execute(null);
        }
        #endregion
    }
}
