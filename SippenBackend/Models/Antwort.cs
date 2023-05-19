namespace SippenBackend.Models
{
    public class Antwort
    {
        public int AntwortId { get; set; }
        public int FrageId { get; set; }
        public string? AntwortText { get; set; }

        public Frage? Frage { get; set; }
    }
}
