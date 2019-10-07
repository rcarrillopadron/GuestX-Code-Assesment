using System;
using System.Collections.ObjectModel;

namespace GuestX.ClassImplementation
{
    abstract class PlayableInstrument<TFret, TInstrumentConfiguration> 
        where TFret : Fret 
        where TInstrumentConfiguration : IInstrumentConfiguration<TFret>, new()
    {
        private ReadOnlyDictionary<int, TFret> Frets { get; }
        
        protected PlayableInstrument()
        {
            var fretsConfiguration = new TInstrumentConfiguration();
            Frets = new ReadOnlyDictionary<int, TFret>(fretsConfiguration.CreateFrets());
        }

        public void Play(int fredNumber, int stringNumber)
        {
            var fret = Frets[fredNumber];
            Note note = fret[stringNumber];
            Console.WriteLine($"[{typeof(TFret).Name}] {note.ToString()}");
        }
    }
}