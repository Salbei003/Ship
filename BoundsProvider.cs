using UnityEngine;

public struct BoundsProvider
{
    private static Vector2 GetSpriteBound(GameObject obj)
    {
        return new Vector2(obj.transform.GetComponent<SpriteRenderer>().bounds.size.x, obj.transform.GetComponent<SpriteRenderer>().bounds.size.y);
    }
    public static Vector2 GetXPoints(GameObject obj)
    {
        return new Vector2
        (SystemSettings.minPointX + GetSpriteBound(obj).x / 2, SystemSettings.maxPointX - GetSpriteBound(obj).x / 2);
    }
}
