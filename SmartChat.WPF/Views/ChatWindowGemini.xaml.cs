using SmartChat.WPF.Services;
using System;
using System.Windows;
using System.Windows.Input;

namespace SmartChat.WPF.Views
{
    public partial class ChatWindowGemini : Window
    {
        private GeminiToolService geminiToolService;

        public ChatWindowGemini()
        {
            InitializeComponent();
            geminiToolService = new GeminiToolService("gemini-2.5-flash");
            // geminiToolService = new GeminiToolService("gemini-1.5-flash");
        }

        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
            string userMessage = txtMessage.Text.Trim();

            if (string.IsNullOrWhiteSpace(userMessage))
            {
                MessageBox.Show("Please enter a message first.");
                txtMessage.Focus();
                return;
            }

            txtChatHistory.AppendText($"You: {userMessage}{Environment.NewLine}");
            txtMessage.Clear();

            btnSend.IsEnabled = false;
            txtMessage.IsEnabled = false;

            try
            {
                var result = await geminiToolService.ExecuteAsync(userMessage);

                if (result.ToolUsed)
                {
                    txtChatHistory.AppendText($"[Tool Used: {result.ToolName}]{Environment.NewLine}");
                }

                txtChatHistory.AppendText("Gemini: ");
                txtChatHistory.ScrollToEnd();

                txtChatHistory.AppendText(result.FinalAnswer);
                txtChatHistory.AppendText(Environment.NewLine + Environment.NewLine);
                txtChatHistory.ScrollToEnd();
            }
            catch (Exception ex)
            {
                txtChatHistory.AppendText(Environment.NewLine);
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                btnSend.IsEnabled = true;
                txtMessage.IsEnabled = true;
                txtMessage.Focus();
            }
        }

        private void btnClearChat_Click(object sender, RoutedEventArgs e)
        {
            txtChatHistory.Clear();
            txtMessage.Clear();
            txtMessage.Focus();
        }

        private void btnClearMemory_Click(object sender, RoutedEventArgs e)
        {
            txtChatHistory.Clear();
            txtMessage.Clear();
            txtMessage.Focus();

            geminiToolService = new GeminiToolService("gemini-2.5-flash");
            // geminiToolService = new GeminiToolService("gemini-1.5-flash");

            MessageBox.Show("Conversation memory cleared.");
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            SelectModelWindow window = new SelectModelWindow();
            window.Show();
            this.Close();
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Keyboard.Modifiers != ModifierKeys.Shift)
            {
                e.Handled = true;
                btnSend_Click(sender, e);
            }
        }
    }
}