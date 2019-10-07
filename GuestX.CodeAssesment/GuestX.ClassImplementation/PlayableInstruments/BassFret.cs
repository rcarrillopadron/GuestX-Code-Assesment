namespace GuestX.ClassImplementation
{
    class BassFret : Fret
    {
        public BassFret(Note string1, Note string2, Note string3, Note string4)
        {
            Add(Count + 1, string1);
            Add(Count + 1, string2);
            Add(Count + 1, string3);
            Add(Count + 1, string4);
        }
    }
}