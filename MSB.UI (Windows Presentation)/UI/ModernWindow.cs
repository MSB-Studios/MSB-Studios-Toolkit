using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace MSB.UI
{
    /// <summary>
    /// Represents a window with new functions, such as the ability to hide the icon,
    /// the title or cover the title bar with its contents.
    /// </summary>
    public sealed class ModernWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the ModernWindow class.
        /// </summary>
        public ModernWindow()
        {
            this.DefaultStyleKey = typeof(ModernWindow);
        }

        #region Properties

        /// <summary>
        /// Gets the currently activated window.
        /// </summary>
        public static Window Current
        {
            get
            {
                Window activeWindow = null;

                foreach(Window window in Application.Current.Windows)
                {
                    if (window.IsActive)
                    {
                        activeWindow = window;
                        break;
                    }
                }

                return activeWindow;
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether the contents of the window
        /// should extend into the title bar.
        /// <para>Note: Changing the value to **true** will hide the draggable area of the window.</para>
        /// <para>The default is **false**.</para>
        /// </summary>
        public bool ExtendViewIntoTitleBar
        {
            get => (bool)GetValue(ExtendViewIntoTitleBarProperty);
            set => SetValue(ExtendViewIntoTitleBarProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the icon in the title bar should be displayed.
        /// <para>Note: If the "ExtendViewIntoTitleBar" property is set to **true**,
        /// this property will have no effect.</para>
        /// <para>The default is **true**.</para>
        /// </summary>
        public bool IsIconVisible
        {
            get => (bool)GetValue(IsIconVisibleProperty);
            set => SetValue(IsIconVisibleProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the window title should be displayed or not.
        /// <para>Note: If the "ExtendViewIntoTitleBar" property is set to **true**,
        /// this property will have no effect.</para>
        /// <para>The default is **true**.</para>
        /// </summary>
        public bool IsTitleVisible
        {
            get => (bool)GetValue(IsTitleVisibleProperty);
            set => SetValue(IsTitleVisibleProperty, value);
        }

        #endregion

        #region Dependency properties

        /// <summary>
        /// Identifies the ExtendViewIntoTitleBar dependency property.
        /// </summary>
        public static readonly DependencyProperty ExtendViewIntoTitleBarProperty =
                DependencyProperty.Register(nameof(ExtendViewIntoTitleBar), typeof(bool), typeof(ModernWindow), new PropertyMetadata(false));

        /// <summary>
        /// Identifies the IsIconVisible dependency property.
        /// </summary>
        public static readonly DependencyProperty IsIconVisibleProperty =
                DependencyProperty.Register(nameof(IsIconVisible), typeof(bool), typeof(ModernWindow), new PropertyMetadata(true));

        /// <summary>
        /// Identifies the IsTitleVisible dependency property.
        /// </summary>
        public static readonly DependencyProperty IsTitleVisibleProperty =
                DependencyProperty.Register(nameof(IsTitleVisible), typeof(bool), typeof(ModernWindow), new PropertyMetadata(true));

        #endregion

        #region Methods

        /// <inheritdoc />
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (titleBarRect != null)
                titleBarRect.MouseDown -= TitleBar_MouseDown;

            if (minButton != null)
                minButton.Click -= MinimzeButton_Click;
            if (maxButton != null)
                maxButton.Click -= MaxRestButton_Click;
            if (closeButton != null)
                closeButton.Click -= CloseButton_Click;

            titleBarRect = (Rectangle)GetTemplateChild("TitleBarRect");
            minButton = (Button)GetTemplateChild("Minimize");
            maxButton = (Button)GetTemplateChild("MaxRest");
            closeButton = (Button)GetTemplateChild("Close");

            if (titleBarRect != null)
                titleBarRect.MouseDown += TitleBar_MouseDown;

            if (minButton != null)
                minButton.Click += MinimzeButton_Click;
            if (maxButton != null)
                maxButton.Click += MaxRestButton_Click;
            if (closeButton != null)
                closeButton.Click += CloseButton_Click;
        }

        private void MinimzeButton_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        private void MaxRestButton_Click(object sender, RoutedEventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Maximized:
                    SystemCommands.RestoreWindow(this);
                    break;
                case WindowState.Normal:
                    SystemCommands.MaximizeWindow(this);
                    break;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton is MouseButtonState.Pressed)
                this.DragMove();
        }

        #endregion

        Rectangle titleBarRect = null;
        Button minButton = null,
               maxButton = null,
               closeButton = null;
    }
}
