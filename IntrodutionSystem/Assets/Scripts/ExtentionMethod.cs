using System.Collections.Generic;

static class ExtentionMethod
{
    public static Queue<string> GetRows(this string content, Queue<string> rows)
    {
        foreach (string row in content.Split('\n'))
        {
            rows.Enqueue(row);
        }

        return rows;
    }
}