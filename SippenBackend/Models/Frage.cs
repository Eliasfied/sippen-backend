namespace SippenBackend.Models
{
    public class Frage
    {
        public int FrageId { get; set; }
        public string? FrageText { get; set; }
        public int SchwierigkeitsgradId { get; set; }
        public int KategorieId { get; set; }
        public int? Strafe { get; set; }

        public Schwierigkeitsgrad? Schwierigkeitsgrad { get; set; }
        public Kategorie? Kategorie { get; set; }
    }
}
