namespace GuestX.ClassImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var bass = new Bass();
            bass.Play(1, 1);

            var guitar = new Guitar();
            guitar.Play(1, 1);
        }
    }
}