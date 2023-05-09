using System.Windows.Documents;
using System.Windows.Media;
using System.Windows;
using System;

namespace MSB.UI.Controls
{
    /// <summary>
    /// Represents the base class for an icon UI element.
    /// </summary>
    public abstract class IconElement : FrameworkElement
    {
        static IconElement()
        {
            FocusableProperty.OverrideMetadata(typeof(PathIcon), new UIPropertyMetadata(false));
            ForegroundProperty.OverrideMetadata(typeof(PathIcon), new FrameworkPropertyMetadata(null, ForegroundChanged_Callback));
        }

        /// <summary>
        /// Provides base class initialization behavior for IconElement derived class.
        /// </summary>
        protected IconElement()
        {
            
        }

        #region Properties

        /// <summary>
        /// Gets or sets a brush that describes the foreground color.
        /// </summary>
        public Brush Foreground
        {
            get => (Brush)GetValue(ForegroundProperty);
            set => SetValue(ForegroundProperty, value);
        }

        #endregion

        #region Dependency property

        /// <summary>
        /// Identifies the Foreground dependency property.
        /// </summary>
        public static readonly DependencyProperty ForegroundProperty =
                TextElement.ForegroundProperty.AddOwner(typeof(PathIcon));

        #endregion

        #region Callbacks

        private static void ForegroundChanged_Callback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue != e.NewValue && d is IconElement iconElement)
            {
                iconElement.OnForegroundChanged(EventArgs.Empty);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnForegroundChanged(EventArgs e)
        {
            // none...
        }

        #endregion
    }
}
