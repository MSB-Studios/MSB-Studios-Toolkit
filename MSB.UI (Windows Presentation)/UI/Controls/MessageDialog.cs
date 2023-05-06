using System.Windows.Controls;
using System.Windows;

namespace MSB.UI.Controls
{
    /// <summary>
    /// Represents a dialog box that displays a message or content and returns a value.
    /// </summary>
    public sealed class MessageDialog : Control
    {
        /// <summary>
        /// Initializes a new instance of the MessageDialog class.
        /// </summary>
        public MessageDialog()
        {
            this.DefaultStyleKey = typeof(MessageDialog);
        }

        #region Properties

        /// <summary>
        /// Gets or sets the text to display.
        /// </summary>
        public string Content
        {
            get => (string)GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        /// <summary>
        /// Gets or sets the title bar caption to display.
        /// </summary>
        public string Caption
        {
            get => (string)GetValue(CaptionProperty);
            set => SetValue(CaptionProperty, value);
        }

        /// <summary>
        /// Gets or sets a custom content to be displayed in the control.
        /// </summary>
        public UIElement CustomContent
        {
            get => (UIElement)GetValue(CustomContentProperty);
            set => SetValue(CustomContentProperty, value);
        }

        /// <summary>
        /// Gets or sets a value that specifies which button or buttons to display.
        /// </summary>
        public MessageDialogButton Buttons
        {
            get => (MessageDialogButton)GetValue(ButtonsProperty);
            set => SetValue(ButtonsProperty, value);
        }

        #endregion

        #region Dependency properties

        /// <summary>
        /// Identifies the Content dependency property.
        /// </summary>
        public static readonly DependencyProperty ContentProperty =
                DependencyProperty.Register(nameof(Content), typeof(string), typeof(MessageDialog), new PropertyMetadata(string.Empty));

        /// <summary>
        /// Identifies the Caption dependency property.
        /// </summary>
        public static readonly DependencyProperty CaptionProperty =
                DependencyProperty.Register(nameof(Caption), typeof(string), typeof(MessageDialog), new PropertyMetadata(string.Empty));

        /// <summary>
        /// Identifies the CustomContent dependency property.
        /// </summary>
        public static readonly DependencyProperty CustomContentProperty =
                DependencyProperty.Register(nameof(CustomContent), typeof(UIElement), typeof(MessageDialog), new PropertyMetadata(null));

        /// <summary>
        /// Identifies the Buttons dependency property.
        /// </summary>
        public static readonly DependencyProperty ButtonsProperty =
                DependencyProperty.Register(nameof(Buttons), typeof(MessageDialogButton), typeof(MessageDialog), new PropertyMetadata(MessageDialogButton.OK));

        #endregion

        #region Methods

        /// <inheritdoc/>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (btnOK is not null)
                btnOK.Click -= OnOKButtonClick;
            if (btnYes is not null)
                btnYes.Click -= OnYesButtonClick;
            if (btnNo is not null)
                btnNo.Click -= OnNoButtonClick;
            if (btnCancel is not null)
                btnCancel.Click -= OnCancelButtonClick;

            btnOK = (Button)GetTemplateChild("BtnOK");
            btnYes = (Button)GetTemplateChild("BtnYes");
            btnNo = (Button)GetTemplateChild("BtnNo");
            btnCancel = (Button)GetTemplateChild("BtnCancel");

            if (btnOK is not null)
                btnOK.Click += OnOKButtonClick;
            if (btnYes is not null)
                btnYes.Click += OnYesButtonClick;
            if (btnNo is not null)
                btnNo.Click += OnNoButtonClick;
            if (btnCancel is not null)
                btnCancel.Click += OnCancelButtonClick;

        }

        private void OnOKButtonClick(object sender, RoutedEventArgs e)
        {
            result = MessageDialogResult.OK;

            hostWindow.DialogResult = true;
        }

        private void OnYesButtonClick(object sender, RoutedEventArgs e)
        {
            result = MessageDialogResult.Yes;

            hostWindow.DialogResult = true;
        }

        private void OnNoButtonClick(object sender, RoutedEventArgs e)
        {
            result = MessageDialogResult.No;

            hostWindow.DialogResult = true;
        }

        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            result = MessageDialogResult.Cancel;

            hostWindow.DialogResult = true;
        }

        /// <summary>
        /// Displays the dialog that has a message and that returns a result.
        /// </summary>
        /// <returns>A <see cref="MessageDialogResult"/> value that specifies which message dialog button
        /// is clicked by the user.</returns>
        public MessageDialogResult Show()
        {
            hostWindow = new()
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                Content = this,
            };

            foreach (Window window in Application.Current.Windows)
            {
                if (window.IsActive)
                {
                    hostWindow.Owner = window;
                    break;
                }
            }

            hostWindow.ShowDialog();
            return result;
        }

#endregion

        Button btnOK, btnCancel, btnYes, btnNo;
        DialogWindow hostWindow = null;
        MessageDialogResult result = MessageDialogResult.None;
    }
}
