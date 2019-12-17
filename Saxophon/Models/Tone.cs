using Saxophon.Resources;

namespace Saxophon.Models
{
    public class Tone : ITone
    {
        public Notes note { get; set; }
        public Shifts shift { get; set; }
        public Durations duration { get; set; }
        public int octave { get; set; }
    }
}