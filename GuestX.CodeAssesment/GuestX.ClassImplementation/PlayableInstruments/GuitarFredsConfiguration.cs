using System.Collections.Generic;

namespace GuestX.ClassImplementation
{
    class GuitarFredsConfiguration : IInstrumentConfiguration<GuitarFret>
    {
        private const int DefaultOctave = 4;

        public IDictionary<int, GuitarFret> CreateFrets()
        {
            var bassFrets = new BassFretsConfiguration().CreateFrets();
            var firstBassFret = bassFrets[0];
            var secondBassFret = bassFrets[1];
            return new Dictionary<int, GuitarFret>
            {
                [0] = new GuitarFret(
                    firstBassFret[1],
                    firstBassFret[2],
                    firstBassFret[3],
                    firstBassFret[4],
                    new Note(DefaultOctave, Tone.B),
                    new Note(DefaultOctave, Tone.E)
                ),
                [1] = new GuitarFret(
                    secondBassFret[1],
                    secondBassFret[2],
                    secondBassFret[3],
                    secondBassFret[4],
                    new Note(DefaultOctave, Tone.C),
                    new Note(DefaultOctave, Tone.F)
                )
            };
        }
    }
}