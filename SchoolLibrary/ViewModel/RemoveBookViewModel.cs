using System;
using System.Windows.Controls;
using System.Windows;
using SchoolLibrary.Models;

namespace SchoolLibrary.ViewModel
{
    public abstract class RemoveBookViewModel
    {
        public static void Remove(TextBox textBox)
        {
            _RemoveWarningMessage(textBox);
        }

        private static void _removeYes(string textToConvert)
        {
            if (UInt32.TryParse(textToConvert, out uint _id) && _id != 0)
            {
                Database.Database.Instance.DeleteAsync(new BookModel() { Id = _id });
            }
            else
            {
                Console.WriteLine("Wrong input");
            }
        }

        private static TextBox _removeNo(TextBox tb)
        {
            tb.Text = null;
            return tb;
        }

        private static void _removeCancel()
        {
            // another debuggig method
            //Console.WriteLine("Selected 'cancel'.");
        }

        private static void _RemoveWarningMessage(TextBox textBox)
        {
            // Put this into new ViewModel
            string messageBoxText = "Are you sure you want to delete selected book?"; // Hard-coded strings to resources <---
            string caption = "Warning!"; // Hard-coded strings to resources <---
            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult MsgBoxResult = MessageBox.Show(messageBoxText, caption, button, icon);

            // Use regex to validate input
            switch (MsgBoxResult)
            {
                case MessageBoxResult.Yes:
                    _removeYes(textBox.Text);
                    break;
                case MessageBoxResult.No:
                    _removeNo(textBox);
                    break;
                case MessageBoxResult.Cancel:
                    _removeCancel();
                    break;
                default:
                    break;
            }
        }
    }
}
