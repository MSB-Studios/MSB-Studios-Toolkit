using System.Windows.Controls;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;
using MSB.UI.Controls;

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

            if (btnOK is not null)
                btnOK.Click -= OnOKButtonClick;
            if (btnYes is not null)
                btnYes.Click -= OnYesButtonClick;
            if (btnNo is not null)
                btnNo.Click -= OnNoButtonClick;
            if (btnCancel is not null)
                btnCancel.Click -= OnCancelButtonClick;

            titleBarRect = (Rectangle)GetTemplateChild("TitleBarRect");

            btnOK = (Button)GetTemplateChild("BtnOK");
            btnYes = (Button)GetTemplateChild("BtnYes");
            btnNo = (Button)GetTemplateChild("BtnNo");
            btnCancel = (Button)GetTemplateChild("BtnCancel");

            if (titleBarRect is not null)
                titleBarRect.MouseDown += TitleBar_MouseDown;

            if (btnOK is not null)
                btnOK.Click += OnOKButtonClick;
            if (btnYes is not null)
                btnYes.Click += OnYesButtonClick;
            if (btnNo is not null)
                btnNo.Click += OnNoButtonClick;
            if (btnCancel is not null)
                btnCancel.Click += OnCancelButtonClick;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (!this.DialogResult.HasValue)
                e.Cancel = true;
        }

        private void OnOKButtonClick(object sender, RoutedEventArgs e)
        {
            Result = MessageDialogResult.OK;

            this.DialogResult = true;
        }

        private void OnYesButtonClick(object sender, RoutedEventArgs e)
        {
            Result = MessageDialogResult.Yes;

            this.DialogResult = true;
        }

        private void OnNoButtonClick(object sender, RoutedEventArgs e)
        {
            Result = MessageDialogResult.No;

            this.DialogResult = true;
        }

        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            Result = MessageDialogResult.Cancel;

            this.DialogResult = true;
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton is MouseButtonState.Pressed)
                this.DragMove();
        }

        #endregion

        internal MessageDialogResult Result = MessageDialogResult.None;

        Rectangle titleBarRect = null;
        Button btnOK, btnCancel, btnYes, btnNo;
    }
}
