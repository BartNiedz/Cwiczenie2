namespace WolneLekturyCwiczenia.Models
{
    public class Audiobooks
    {
        public string kind { get; set; }
        public string full_sort_key { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string cover_color { get; set; }
        public string author { get; set; }
        public string cover { get; set; }
        public string epoch { get; set; }
        public string href { get; set; }
        public bool has_audio { get; set; }
        public string genre { get; set; }
        public string simple_thumb { get; set; }
        public string slug { get; set; }
        public string cover_thumb { get; set; }
        public object liked { get; set; }
    }
}
