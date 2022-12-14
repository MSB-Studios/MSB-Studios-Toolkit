using System.Windows.Controls;

namespace MSB.UI.Controls
{
    /// <summary>
    /// Represents the base class for an icon UI element.
    /// </summary>
    public abstract class IconElement : Control
    {
        /// <summary>
        /// Provides base class initialization behavior for IconElement derived class.
        /// </summary>
        protected IconElement()
        {
            this.Focusable = false;
        }
    }
}
