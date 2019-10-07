using System.Collections.Generic;

namespace GuestX.ClassImplementation
{
    class BassFretsConfiguration : IInstrumentConfiguration<BassFret>
    {
        // I don't know what octave is, but let's assume is 3
        private const int DefaultOctave = 3;
        
        public IDictionary<int, BassFret> CreateFrets()
        {
            return new Dictionary<int, BassFret>
            {
                [0] = new BassFret(
                    new Note(DefaultOctave, Tone.E),
                    new Note(DefaultOctave, Tone.A),
                    new Note(DefaultOctave, Tone.D),
                    new Note(DefaultOctave, Tone.G)
                ),
                [1] = new BassFret(
                    new Note(DefaultOctave, Tone.F),
                    new Note(DefaultOctave, Tone.ASharp),
                    new Note(DefaultOctave, Tone.DSharp),
                    new Note(DefaultOctave, Tone.GSharp)
                ),
                [2] = new BassFret(
                    new Note(DefaultOctave, Tone.FSharp),
                    new Note(DefaultOctave, Tone.B),
                    new Note(DefaultOctave + 1, Tone.E),
                    new Note(DefaultOctave + 1, Tone.A)
                )
            };
        }
    }
}