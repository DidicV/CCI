namespace CCI.Model
{
    public class UploadedFile
    {
        public string Name { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public Dictionary<string, int> WordFrequencies { get; set; } = new();
    }
}
