namespace BajioITUIKIT.DependencyServices
{
    /// <summary>
    /// Translucent status bar.
    /// </summary>
    public interface ITranslucentStatusBar
    {
        /// <summary>
        /// Translucents this instance.
        /// </summary>
        void Translucent();

        /// <summary>
        /// Normals this instance.
        /// </summary>
        void Normal();

        /// <summary>
        /// Gets or sets a value indicating whether this instance is translucent.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is translucent; otherwise, <c>false</c>.
        /// </value>
        bool IsTranslucent { get; set; }
    }
}
