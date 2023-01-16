using System.Windows.Controls.Primitives;
using System.Windows;
using System.Windows.Markup;

namespace MSB.UI.Controls
{
    /// <summary>
    /// 
    /// </summary>
    [ContentProperty(nameof(Icon))]
    public sealed class AppBarButton : ButtonBase
    {
        /// <summary>
        /// Initializes a new instance of the AppBarButton class.
        /// </summary>
        public AppBarButton()
        {
            this.DefaultStyleKey = typeof(AppBarButton);
        }

        #region Properties

        /// <summary>
        /// Gets or sets the icon to be displayed on the control.
        /// <para>The default is **null**.</para>
        /// </summary>
        public IconElement Icon
        {
            get => (IconElement)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        /// <summary>
        /// Gets or sets the icon padding inside the control.
        /// <para>The default is a Thickness with values of 11 on all four sides.</para>
        /// </summary>
        public Thickness IconPadding
        {
            get => (Thickness)GetValue(IconPaddingProperty);
            set => SetValue(IconPaddingProperty, value);
        }

        /// <summary>
        /// Gets or sets the text to be displayed on the control.
        /// <para>The default is an empty string.</para>
        /// </summary>
        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        #endregion

        #region Dependency properties

        /// <summary>
        /// Identifies the Icon dependency property.
        /// </summary>
        public static readonly DependencyProperty IconProperty =
                    DependencyProperty.Register(nameof(Icon), typeof(IconElement), typeof(AppBarButton), new PropertyMetadata(null));

        /// <summary>
        /// Identifies the IconPadding dependency property.
        /// </summary>
        public static readonly DependencyProperty IconPaddingProperty =
                    DependencyProperty.Register(nameof(IconPadding), typeof(Thickness), typeof(AppBarButton), new PropertyMetadata(new Thickness(11)));

        /// <summary>
        /// Identifies the Label dependency property.
        /// </summary>
        public static readonly DependencyProperty LabelProperty =
                    DependencyProperty.Register(nameof(Label), typeof(string), typeof(AppBarButton), new PropertyMetadata(string.Empty));

        #endregion
    }
}
