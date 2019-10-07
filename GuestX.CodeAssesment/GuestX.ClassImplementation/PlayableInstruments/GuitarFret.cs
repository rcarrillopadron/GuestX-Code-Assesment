namespace GuestX.ClassImplementation
{
    class GuitarFret : BassFret
    {
        public GuitarFret(Note string1, Note string2, Note string3, Note string4, Note string5, Note string6) : base(string1, string2, string3, string4)
        {
            Add(Count + 1, string5);
            Add(Count + 1, string6);
        }
    }
}