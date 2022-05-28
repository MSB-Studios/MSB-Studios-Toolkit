using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace MSB.Toolkit.Mvvm
{
    /// <summary>
    /// Represents the base class for ViewModels that implement <see cref="INotifyPropertyChanged"/>.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanging, INotifyPropertyChanged
    {
        /// <summary>
        /// Provides base class initialization behavior for ViewModelBase derived classes.
        /// </summary>
        protected ViewModelBase()
        {

        }

        #region Methods

        /// <summary>
        /// Checks if a property already matches the desired value.
        /// Sets the property and notifies listeners if necessary.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="field">Reference to a property with both getter and setter.</param>
        /// <param name="value">Desired value for the property.</param>
        /// <param name="name">Name of the property used to notify listeners.</param>
        /// <returns>**true** if the value was changed, otherwise **false**.</returns>
        protected bool SetValue<T>(ref T field, T value, [CallerMemberName] string name = "")
        {
            if (!object.Equals(field, value))
            {
                OnPropertyChanging(new PropertyChangingEventArgs(name));
                field = value;
                OnPropertyChanged(new PropertyChangedEventArgs(name));

                return true;
            }

            return false;
        }

        /// <summary>
        /// Invoked inmediately when a property value is changing.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnPropertyChanging(PropertyChangingEventArgs e)
        {
            PropertyChanging?.Invoke(this, e);
        }

        /// <summary>
        /// Invoked inmediately after a property value changes.
        /// </summary>
        /// <param name="e">Event data.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        #endregion

        #region Events

        /// <inheritdoc/>
        public event PropertyChangingEventHandler? PropertyChanging;

        /// <inheritdoc/>
        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion
    }
}
