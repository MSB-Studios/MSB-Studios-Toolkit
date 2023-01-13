using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Markup;

namespace MSB.UI.Controls
{
    /// <summary>
    /// 
    /// </summary>
    [ContentProperty(nameof(Icon))]
    public sealed class IconPresenter : Control
    {
        /// <summary>
        /// Initializes a new instance of the IconPresenter class.
        /// </summary>
        public IconPresenter()
        {
            this.DefaultStyleKey = typeof(IconPresenter);
        }

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public IconElement Icon
        {
            get => (IconElement)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public new Brush Foreground
        {
            get => (Brush)GetValue(ForegroundProperty);
            set => SetValue(ForegroundProperty, value);
        }

        #endregion

        #region Dependency properties

        /// <summary>
        /// Identifies the Foreground dependency property.
        /// </summary>
        public static new readonly DependencyProperty ForegroundProperty =
                DependencyProperty.Register(nameof(Foreground), typeof(Brush), typeof(IconPresenter), new PropertyMetadata(null, ForegroundChanged_Callback));

        /// <summary>
        /// Identifies the Icon dependency property.
        /// </summary>
        public static readonly DependencyProperty IconProperty =
                DependencyProperty.Register(nameof(Icon), typeof(IconElement), typeof(IconPresenter), new PropertyMetadata(null, IconChanged_Callback));

        #endregion

        #region Callbacks

        private static void ForegroundChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is IconPresenter iconPresenter)
            {
                if (iconPresenter.Icon is null)
                    return;

                iconPresenter.Icon.Foreground = (Brush)e.NewValue;
            }
        }

        private static void IconChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && e.NewValue != null && d is IconPresenter iconPresenter)
            {
                if (iconPresenter.Foreground is null)
                    return;

                iconPresenter.Icon.Foreground = iconPresenter.Foreground;
            }
        }

        #endregion
    }
}
