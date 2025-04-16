using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BajioITUIKIT.Styles
{
    public partial class Theme : ResourceDictionary
    {
        public Theme()
        {
            InitializeComponent();
        }
        public static Color InactiveColor { get { return (Color)Application.Current.Resources["InactiveColor"]; } }
        public static Color EntryStrokeBorder { get { return (Color)Application.Current.Resources["EntryStrokeBorder"]; } }
        public static Color InvalidColorPrimary { get { return (Color)Application.Current.Resources["InvalidColorPrimary"]; } }
        public static Color EntryEnabledBackground { get { return (Color)Application.Current.Resources["EntryEnabledBackground"]; } }
        public static Color EntryDisabledBackground { get { return (Color)Application.Current.Resources["EntryDisabledBackground"]; } }
        public static Color EntryClearButtonColor { get { return (Color)Application.Current.Resources["EntryClearButtonColor"]; } }
        public static Color TextColorSecondary { get { return (Color)Application.Current.Resources["TextColorSecondary"]; } }
        public static Color AlertBackgroundPrimary { get { return (Color)Application.Current.Resources["AlertBackgroundPrimary"]; } }
        public static Color TextColorPrimary { get { return (Color)Application.Current.Resources["TextColorPrimary"]; } }
        public static Color PrimaryColor { get { return (Color)Application.Current.Resources["PrimaryColor"]; } }
        public static Color InactiveColorPrimary { get { return (Color)Application.Current.Resources["InactiveColorPrimary"]; } }
        public static Color TextColorThird { get { return (Color)Application.Current.Resources["TextColorThird"]; } }
        public static Color TextInactiveColorSecondary { get { return (Color)Application.Current.Resources["TextInactiveColorSecondary"]; } }
        public static Color ColorSecondary { get { return (Color)Application.Current.Resources["ColorSecondary"]; } }
        public static Color EntryPlaceholderColor { get { return (Color)Application.Current.Resources["EntryPlaceholderColor"]; } }
        public static Color TextColorTitleTabPage { get { return (Color)Application.Current.Resources["TextColorTitleTabPage"]; } }
    }
}
