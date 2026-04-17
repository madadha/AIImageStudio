using SmartChat.WPF.Services;
using System;
using System.Windows;
using System.Windows.Input;

namespace SmartChat.WPF.Views
{
    public partial class ChatWindowOpenAI : Window
    {
        private OpenAI_SDK_Response openAIService;

        public ChatWindowOpenAI()
        {
            InitializeComponent();
            openAIService = new OpenAI_SDK_Response("gpt-5.2");
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
                txtChatHistory.AppendText("ChatGPT: ");

                await foreach (var chunk in openAIService.CallStream(userMessage))
                {
                    txtChatHistory.AppendText(chunk);
                    txtChatHistory.ScrollToEnd();
                }

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
            openAIService.ClearMemory();
            txtChatHistory.Clear();
            txtMessage.Clear();
            txtMessage.Focus();
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