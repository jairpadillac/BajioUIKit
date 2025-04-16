using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace BajioITUIKIT.Controls
{
    public partial class ToolTip : PopupPage
    {
        #region Public Properties
        /// <summary>
        /// Gets or sets the alert text.
        /// </summary>
        /// <value>
        /// The alert text.
        /// </value>
        public string AlertText
        {
            get { return _alertText; }
            set
            {
                _alertText = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the close command.
        /// </summary>
        /// <value>
        /// The close command.
        /// </value>
        public Command CloseCommand
        {
            get { return _closeCommand; }
            set
            {
                _closeCommand = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the color of the content background.
        /// </summary>
        /// <value>
        /// The color of the content background.
        /// </value>
        public Color ContentBackgroundColor
        {
            get { return _contentBackgroundColor; }
            set
            {
                _contentBackgroundColor = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the color of the text.
        /// </summary>
        /// <value>The color of the text.</value>
        public Color TextColor
        {
            get { return _textColor; }
            set
            {
                _textColor = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Private Properties
        private string _alertText;
        private Command _closeCommand;
        private Color _contentBackgroundColor = Color.White;
        private Color _textColor;
        #endregion

        #region Public Methods
        /// <summary>
        /// Initializes a new instance of the <see cref="ToolTip"/> class.
        /// </summary>
        public ToolTip(string text = "")
        {
            InitializeComponent();
            AlertText = text;

            Content2.BindingContext = this;
            CloseCommand = new Command(OnClose);
        }
        #endregion

        #region Protected Methods
        #endregion

        #region Private Methods


        /// <summary>
        /// Raises the Close event.
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnClose(object obj)
        {
            PopupNavigation.Instance.PopAsync(true);
        }
        #endregion
    }
}
