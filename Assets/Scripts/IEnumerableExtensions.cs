using System;
using System.Collections.Generic;

public static class IEnumerableExtensions
{
    public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
    {
        foreach (T item in enumeration)
        {
            action(item);
        }
    }

    public static int Count<T>(this IEnumerable<T> enumeration)
    {
        int count = 0;
        foreach (T item in enumeration)
        {
            count++;
        }
        return count;
    }
}
