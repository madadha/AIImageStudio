#pragma warning disable OPENAI001
using OpenAI.Responses;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartChat.WPF.Services
{
    public class OpenAI_SDK_Response
    {
        private readonly ResponsesClient gptModel;
        private readonly List<ResponseItem> history = new();
        private readonly CreateResponseOptions config;

        public OpenAI_SDK_Response(string model)
        {
            string openAIKey = "sk-proj-YOUR_API_KEY";

            gptModel = new ResponsesClient(openAIKey);

            config = new CreateResponseOptions
            {
                Model = model,
                TruncationMode = ResponseTruncationMode.Auto,
                EndUserId = "user-1234",
                ReasoningOptions = new ResponseReasoningOptions
                {
                    ReasoningEffortLevel = ResponseReasoningEffortLevel.Medium,
                    ReasoningSummaryVerbosity = ResponseReasoningSummaryVerbosity.Auto
                }
            };
        }

        public async Task<string> Call(string userMessage)
        {
            history.Add(ResponseItem.CreateUserMessageItem(userMessage));

            config.InputItems.Clear();
            foreach (var item in history)
            {
                config.InputItems.Add(item);
            }

            ResponseResult response = await gptModel.CreateResponseAsync(config);

            foreach (var item in response.OutputItems)
            {
                history.Add(item);
            }

            return response.GetOutputText();
        }

        public async IAsyncEnumerable<string> CallStream(string userMessage)
        {
            history.Add(ResponseItem.CreateUserMessageItem(userMessage));

            config.InputItems.Clear();
            foreach (var item in history)
            {
                config.InputItems.Add(item);
            }

            var fullResponse = new StringBuilder();
            config.StreamingEnabled = true;

            await foreach (var update in gptModel.CreateResponseStreamingAsync(config))
            {
                if (update is StreamingResponseOutputTextDeltaUpdate textDelta)
                {
                    fullResponse.Append(textDelta.Delta);
                    yield return textDelta.Delta;
                }
            }

            config.StreamingEnabled = false;
            history.Add(ResponseItem.CreateAssistantMessageItem(fullResponse.ToString()));
        }

        public void ClearMemory()
        {
            history.Clear();
            config.InputItems.Clear();
        }
    }
}