using Saxophon.Resources;

namespace Saxophon.Models
{
    public interface ITone
    {
        Notes note { get; set; }
        Shifts shift { get; set; }
        Durations duration { get; set; }
        int octave { get; set; }

    }
}