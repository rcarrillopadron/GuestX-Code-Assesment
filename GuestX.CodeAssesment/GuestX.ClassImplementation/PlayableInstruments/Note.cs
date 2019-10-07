using System;

namespace GuestX.ClassImplementation
{
    class Note
    {
        public Note(int octave, Tone tone)
        {
            if (octave <= 0 || octave > 8) 
                throw new ArgumentOutOfRangeException(nameof(octave), octave, "Octave is not valid");


            Octave = octave;
            Tone = tone;
        }

        public int Octave { get; set; }
        public Tone Tone { get; set; }

        public override int GetHashCode()
        {
            // Maybe the frequency in hz?
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Octave} - {Tone}";
        }
    }
}