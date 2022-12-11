using System.Windows;

namespace MSB.UI
{
    /// <summary>
    /// Default styles for the controls in the library.
    /// </summary>
    public sealed class XamlControlsResources : ResourceDictionary
    {
        /// <summary>
        /// Initializes a new instance of the XamlControlsResources class.
        /// </summary>
        public XamlControlsResources()
        {
            this.Source = new($"{prefix}UI/XamlControlsResources.xaml");
        }

        const string prefix = "pack://application:,,,/MSB.UI-WPF;component/";
    }
}
