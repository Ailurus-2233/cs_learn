namespace cs_learn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new int[][] { new int[] {1, 2, 3}, new int[] {2,3}, new int[] {3,4,5,6} };
            var b = new int[3, 3, 3];
            Console.WriteLine(a.Length);
            Console.WriteLine(b.Rank);
        }

        // [Flags]
        enum Color:uint
        {
            Yellow  = 0x01, //0
            Red     = 0x02, //1
            Blue    = 0x04  //2
        }
    }
}