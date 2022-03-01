using UnityEngine;

public class ColorsGame
{
    private static Color[] colors = new Color[]
    {
        new Color(0.27f, 0.20f, 1.00f),
        //new Color(0.52f, 1.52f, 2.19f),
        new Color(2.41f, 1.96f, 0.15f),
        //new Color(2.31f, 0.76f, 0.60f),
        new Color(1.11f, 0.30f, 0.81f)
    };

    public static Color GetRandomColor()
    {
        return colors[Random.Range(0, colors.Length)];
    }
}
