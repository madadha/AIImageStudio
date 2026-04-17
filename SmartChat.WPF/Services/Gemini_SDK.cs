using Google.GenAI;
using Google.GenAI.Types;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartChat.WPF.Services
{
    public class Gemini_SDK
    {
        private readonly Client geminiModel;
        private readonly string model;
        private readonly List<Content> history = new();
        private readonly GenerateContentConfig config;

        public Gemini_SDK(string modelName)
        {
            string geminiKey = "YOUR_API_KEY";

            geminiModel = new Client(apiKey: geminiKey);
            model = modelName;

            config = new GenerateContentConfig
            {
                Temperature = 0.7f,
                TopP = 0.95f,
                TopK = 40,
                CandidateCount = 1,
                ResponseMimeType = "text/plain"
            };
        }

        public async Task<string> Call(string userMessage)
        {
            history.Add(new Content
            {
                Role = "user",
                Parts = new List<Part> { new Part { Text = userMessage } }
            });

            var response = await geminiModel.Models.GenerateContentAsync(
                model: model,
                contents: history,
                config: config
            );

            var text = response.Candidates[0].Content.Parts[0].Text;

            history.Add(new Content
            {
                Role = "model",
                Parts = new List<Part> { new Part { Text = text } }
            });

            return text;
        }

        public async IAsyncEnumerable<string> CallStream(string userMessage)
        {
            history.Add(new Content
            {
                Role = "user",
                Parts = new List<Part> { new Part { Text = userMessage } }
            });

            var fullResponse = new StringBuilder();

            var stream = geminiModel.Models.GenerateContentStreamAsync(
                model: model,
                contents: history,
                config: config
            );

            await foreach (var chunk in stream)
            {
                var text = chunk.Candidates?[0].Content?.Parts?[0].Text;

                if (!string.IsNullOrEmpty(text))
                {
                    fullResponse.Append(text);
                    yield return text;
                }
            }

            history.Add(new Content
            {
                Role = "model",
                Parts = new List<Part> { new Part { Text = fullResponse.ToString() } }
            });
        }

        public void ClearMemory()
        {
            history.Clear();
        }
    }
}