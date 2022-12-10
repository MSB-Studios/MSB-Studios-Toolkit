using System.Windows.Input;
using System;

namespace MSB.Mvvm.Input
{
    /// <summary>
    /// A command whose sole purpose is to relay its functionality to other
    /// objects by invoking delegates.
    /// </summary>
    public sealed class RelayCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the RelayCommand class that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action execute) : this(execute, null)
        {
            this.execute = execute;
        }

        /// <summary>
        /// Initializes a new instance of the RelayCommand class.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public RelayCommand(Action execute, Func<bool>? canExecute)
        {
            if (execute is null)
                throw new ArgumentNullException(nameof(execute));
            this.execute = execute;
            this.canExecute = canExecute;
        }

        #region Fields

        /// <summary>
        /// The <see cref="Action"/> to invoke when <see cref="Execute"/> is used.
        /// </summary>
        private readonly Action execute;

        /// <summary>
        /// The optional action to invoke when <see cref="CanExecute"/> is used.
        /// </summary>
        private readonly Func<bool>? canExecute;

        #endregion

        #region Methods

        /// <inheritdoc/>
        public bool CanExecute(object parameter)
        {
            return canExecute?.Invoke() is not false;
        }

        /// <inheritdoc/>
        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
                execute();
        }

        /// <summary>
        /// Raises the <see cref="CanExecuteChanged"/> event.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Events

        /// <inheritdoc/>
        public event EventHandler? CanExecuteChanged;

        #endregion
    }
}

