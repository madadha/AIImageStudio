namespace SmartChat.WPF.Models
{
    public class ToolExecutionResult
    {
        public string FinalAnswer { get; set; } = string.Empty;

        public bool ToolUsed { get; set; }

        public string ToolName { get; set; } = string.Empty;
    }
}