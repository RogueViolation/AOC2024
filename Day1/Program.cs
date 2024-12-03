namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = [3,4,2,1,3,3]; int[] arr2 = [4,3,5,3,9,3]; int[] diff = new int[arr1.Length >= arr2.Length ? arr2.Length : arr1.Length];
            arr1 = [.. arr1.OrderDescending()];
            arr2 = [.. arr2.OrderDescending()];
            for (int i = 0; i < (arr1.Length >= arr2.Length ? arr2.Length : arr1.Length); i++)
            {
                diff[i] = Math.Abs(arr1[i] - arr2[i]);
            }
            Console.WriteLine(diff.Sum());
        }
    }
}
