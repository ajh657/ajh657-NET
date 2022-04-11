namespace AJH657NETBlazor.Util
{
    public static class ArrayUtil
    {
        public static T[,] Make2DArray<T>(this T[] input, int height, int width)
        {
            var output = new T[height, width];
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    output[i, j] = input[i * width + j];
                }
            }
            return output;
        }
    }
}
