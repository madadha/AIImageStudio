using System.Windows;

namespace SmartChat.WPF.Views
{
    public partial class SelectModelWindow : Window
    {
        public SelectModelWindow()
        {
            InitializeComponent();
        }

        private void btnOpenAI_Click(object sender, RoutedEventArgs e)
        {
            ChatWindowOpenAI window = new ChatWindowOpenAI();
            window.Show();
            this.Close();
        }

        private void btnGemini_Click(object sender, RoutedEventArgs e)
        {
            ChatWindowGemini window = new ChatWindowGemini();
            window.Show();
            this.Close();
        }
    }
}