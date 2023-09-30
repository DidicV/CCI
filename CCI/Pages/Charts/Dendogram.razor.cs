using CCI.Model;
using Microsoft.AspNetCore.Components.Forms;

namespace CCI.Pages.Charts
{
    public partial class Dendogram
    {
        private List<UploadedFile> selectedFiles = new List<UploadedFile>();
        private HashSet<string> distinctWords = new HashSet<string>();

        private async Task OnFileSelected(InputFileChangeEventArgs e)
        {
            selectedFiles.Clear();
            distinctWords.Clear();

            foreach (var file in e.GetMultipleFiles())
            {
                var content = await ReadFileContent(file);
                var words = GetWords(content);
                var wordFrequencies = CountWordFrequencies(words);

                selectedFiles.Add(new UploadedFile { Name = file.Name, Content = content, WordFrequencies = wordFrequencies });

                foreach (var word in words)
                {
                    distinctWords.Add(word);
                }
            }

            StateHasChanged();
        }

        private async Task<string> ReadFileContent(IBrowserFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                return await reader.ReadToEndAsync();
            }
        }

        private List<string> GetWords(string content)
        {
            // Split the content into words using a whitespace delimiter
            return content.Split(new[] { ' ', '\t', '\n', '\r', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(word => word.ToLower())
                .ToList();
        }

        private Dictionary<string, int> CountWordFrequencies(List<string> words)
        {
            var wordFrequencies = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (wordFrequencies.ContainsKey(word))
                {
                    wordFrequencies[word]++;
                }
                else
                {
                    wordFrequencies[word] = 1;
                }
            }

            return wordFrequencies;
        }

        private decimal CalculateTermFrequency(string word)
        {
            var totalFrequency = selectedFiles.Sum(file => file.WordFrequencies.GetValueOrDefault(word, 0));
            return (decimal)totalFrequency / selectedFiles.Count;
        }

        private decimal CalculateInverseDocumentFrequency(string word)
        {
            var documentFrequency = selectedFiles.Count(file => file.WordFrequencies.ContainsKey(word));
            return (decimal)Math.Log((selectedFiles.Count + 1) / (double)(documentFrequency + 1)) + 1;
        }

        private double CalculateSentenceDistance(string sentence1, string sentence2)
        {
            var wordFrequencies1 = GetWordFrequencies(sentence1);
            var wordFrequencies2 = GetWordFrequencies(sentence2);

            var distinctWordsList = distinctWords.ToList();
            var frequencyList1 = distinctWordsList.Select(word => wordFrequencies1.GetValueOrDefault(word, 0)).ToList();
            var frequencyList2 = distinctWordsList.Select(word => wordFrequencies2.GetValueOrDefault(word, 0)).ToList();

            var sumOfSquares = frequencyList1.Zip(frequencyList2, (f1, f2) => Math.Pow(f1 - f2, 2)).Sum();
            return Math.Sqrt(sumOfSquares);
        }

        private Dictionary<string, int> GetWordFrequencies(string sentence)
        {
            var words = GetWords(sentence);
            return CountWordFrequencies(words);
        }
    }
}
