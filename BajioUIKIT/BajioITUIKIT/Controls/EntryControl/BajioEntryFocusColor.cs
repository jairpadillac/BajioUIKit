using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    public class BajioEntryFocusColor : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.Focused += Bindable_Focused;
            bindable.Unfocused += Bindable_Unfocused;
        }
        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.Focused -= Bindable_Focused;
        }

        void Bindable_Focused(object sender, FocusEventArgs e)
        {
            if (sender == null)
                return;
            
            var entry = (Entry)sender;

            entry.BackgroundColor = Color.Navy;

        }

        void Bindable_Unfocused(object sender, FocusEventArgs e)
        {
            if (sender == null)
                return;

            var entry = (Entry)sender;

            entry.BackgroundColor = Color.White;
        }
    }
}
