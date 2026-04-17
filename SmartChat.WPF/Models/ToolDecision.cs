namespace SmartChat.WPF.Models
{
    public class ToolDecision
    {
        public bool UseTool { get; set; }

        public string ToolName { get; set; } = string.Empty;

        public string ToolInput { get; set; } = string.Empty;

        public string FinalAnswer { get; set; } = string.Empty;
    }
}