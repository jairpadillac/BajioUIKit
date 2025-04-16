using System;
namespace BajioITUIKIT.Interfaces
{
    /// <summary>
    /// Base content page.
    /// </summary>
    public interface IBaseContentPage
    {
        /// <summary>
        /// Gets or sets a value indicating whether [back button visible].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [back button visible]; otherwise, <c>false</c>.
        /// </value>
        bool BackButtonVisible { get; set; }

        /// <summary>
        /// Used to display the done button on the top right corner
        /// </summary>
        /// <value><c>true</c> if done button visible; otherwise, <c>false</c>.</value>
        bool DoneButtonVisible { get; set; }
    }
}
