using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static IEnumerable<T[]> GetRows<T>(this T[,] array)
    {
        T[] temp = new T[array.GetLength(0)];

        for (int y = 0; y < array.GetLength(1); y++)
        {
            for (int x = 0; x < array.GetLength(0); x++)
            {
                temp[x] = array[x, y];
            }

            yield return temp;
        }
    }

    public static IEnumerable<T[]> GetColumns<T>(this T[,] array)
    {
        T[] temp = new T[array.GetLength(1)];

        for (int x = 0; x < array.GetLength(0); x++)
        {
            for (int y = 0; y < array.GetLength(1); y++)
            {
                temp[y] = array[x, y];
            }

            yield return temp;
        }
    }

    public static IEnumerable<T[]> GetDiagonals<T>(this T[,] array)
    {
        //Assuming every game would be with square field
        //Might fix later to work with nonsquare sizes
        var length = array.GetLength(0);

        T[][] temp = new T[2][];
        temp[0] = new T[length];
        temp[1] = new T[length];

        for (int i = 0; i < length; i++)
        {
            temp[0][i] = array[i, i];
            temp[1][i] = array[length - i - 1, i];
        }

        yield return temp[0];
        yield return temp[1];
    }

    public static bool IsOdd(this uint number)
    {
        return number % 2 != 0;
    }
}
