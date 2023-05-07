using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;

namespace MSB.UI
{
    internal sealed class DialogWindow : Window
    {
        public DialogWindow()
        {
            this.DefaultStyleKey = typeof(DialogWindow);
        }

        #region Methods

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (titleBarRect is not null)
                titleBarRect.MouseDown -= TitleBar_MouseDown;

            titleBarRect = (Rectangle)GetTemplateChild("TitleBarRect");

            if (titleBarRect is not null)
                titleBarRect.MouseDown += TitleBar_MouseDown;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (!this.DialogResult.HasValue)
                e.Cancel = true;
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton is MouseButtonState.Pressed)
                this.DragMove();
        }

        #endregion

        Rectangle titleBarRect = null;
    }
}
