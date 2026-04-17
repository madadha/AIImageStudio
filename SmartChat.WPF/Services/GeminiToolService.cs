using Google.GenAI;
using SmartChat.WPF.Models;
using SmartChat.WPF.Tools;
using System.Text.Json;

namespace SmartChat.WPF.Services
{
    public class GeminiToolService
    {
        private readonly Client geminiClient;
        private readonly string model;

        public GeminiToolService(string modelName)
        {
            string geminiKey = "YOUR_API_KEY";
            geminiClient = new Client(apiKey: geminiKey);
            model = modelName;
        }

        public async Task<ToolDecision> DecideAsync(string userMessage)
        {
            string systemPrompt =
            """
            You are an assistant that must respond only in valid JSON.
            Decide whether you need to use a tool.

            Available tools:
            - current_date : use it when the user asks about today's date, current time, day, or current date and time.
            - calculator : use it when the user asks for a mathematical calculation or gives a math expression.

            Return JSON only in one of these formats:

            {"UseTool": true, "ToolName": "current_date", "ToolInput": "", "FinalAnswer": ""}
            {"UseTool": true, "ToolName": "calculator", "ToolInput": "2+2", "FinalAnswer": ""}
            {"UseTool": false, "ToolName": "", "ToolInput": "", "FinalAnswer": "your final answer here"}
            """;

            string fullPrompt = systemPrompt + "\n\nUser message: " + userMessage;

            var response = await geminiClient.Models.GenerateContentAsync(
                model: model,
                contents: fullPrompt
            );

            string jsonText = response.Candidates[0].Content.Parts[0].Text;

            try
            {
                ToolDecision? decision = JsonSerializer.Deserialize<ToolDecision>(jsonText);

                if (decision == null)
                {
                    return new ToolDecision
                    {
                        UseTool = false,
                        ToolName = string.Empty,
                        ToolInput = string.Empty,
                        FinalAnswer = "Could not parse model response."
                    };
                }

                return decision;
            }
            catch
            {
                return new ToolDecision
                {
                    UseTool = false,
                    ToolName = string.Empty,
                    ToolInput = string.Empty,
                    FinalAnswer = jsonText
                };
            }
        }

        public async Task<ToolExecutionResult> ExecuteAsync(string userMessage)
        {
            ToolDecision decision = await DecideAsync(userMessage);

            if (!decision.UseTool)
            {
                return new ToolExecutionResult
                {
                    FinalAnswer = decision.FinalAnswer,
                    ToolUsed = false,
                    ToolName = string.Empty
                };
            }

            string toolResult;

            if (decision.ToolName == "current_date")
            {
                toolResult = DateTimeTool.GetCurrentDateTime();
            }
            else if (decision.ToolName == "calculator")
            {
                toolResult = CalculatorTool.Calculate(decision.ToolInput);
            }
            else
            {
                return new ToolExecutionResult
                {
                    FinalAnswer = "Unknown tool requested.",
                    ToolUsed = false,
                    ToolName = string.Empty
                };
            }

            string finalPrompt =
            $"""
            The user asked: {userMessage}

            You requested the tool: {decision.ToolName}

            Tool input:
            {decision.ToolInput}

            Tool result:
            {toolResult}

            Based on the tool result, answer the user clearly and naturally.
            """;

            var finalResponse = await geminiClient.Models.GenerateContentAsync(
                model: model,
                contents: finalPrompt
            );

            return new ToolExecutionResult
            {
                FinalAnswer = finalResponse.Candidates[0].Content.Parts[0].Text,
                ToolUsed = true,
                ToolName = decision.ToolName
            };
        }
    }
}