using System;
using System.Collections.Generic;

public static class Arrays
{
    public static double[] MultiplesOf(double number, int length)
    {
        // 1. Create array
        // 2. Loop through and multiply
        // 3. Return array
        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    public static void RotateListRight(List<int> data, int amount)
    {
        // 1. Calculate split index
        // 2. Grab the end of the list
        // 3. Move it to the front
        int splitIndex = data.Count - amount;
        List<int> lastPart = data.GetRange(splitIndex, amount);
        data.RemoveRange(splitIndex, amount);
        data.InsertRange(0, lastPart);
    }
}