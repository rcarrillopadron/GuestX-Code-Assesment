namespace GuestX.ClassImplementation.Couting
{
    internal class VowelCounter
    {
        public void Count(string[] input, int everyNumberOfWords, int vowels, int lines)
        {
            for (int i = 0; i < input.Length; i++)
            {
                bool matchesLine = (i + 1) % lines == 0;
                if (matchesLine)
                {
                    string line = input[i];
                    string[] words = line.Split(" ");
                }
            }
        }

        public static readonly string[] Input = {

            "I pledge allegiance to the Flag of the United States of America,",
            "and to the Republic for which it stands, one Nation under God,",
            "indivisible, with liberty and justice for all, should be rendered",
            "by standing at attention facing the flag with the right hand over",
            "the heart. When not in uniform men should remove any non-religious",
            "headdress with their right hand and hold it at the left shoulder,",
            "the hand being over the heart. Persons in uniform should remain",
            "silent, face the flag, and render the military salute."
        };
    }
}