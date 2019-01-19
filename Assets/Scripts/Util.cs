using UnityEngine;

public static class Util
{
    /// <summary>
    /// The inverse of the "Pixels Per Unit" value at which the game's graphics were imported.
    /// </summary>
    public const float GameUnitsPerPixel = 1 / 16f;

    /// <summary>
    /// Rounds the given value to the nearest multiple of the given value.
    /// E.g. (1.3, 0.5) => 1.5
    /// </summary>
    public static float RoundToNearestMultipleOf(float value, float multipleOf)
    {
        return Mathf.Round(value / multipleOf) * multipleOf;
    }

    /// <summary>
    /// Returns the given value rounded to the nearest pixel using the given
    /// world-units-per-pixel ratio.
    /// </summary>
    public static float PixelClamp(float value, float unitsPerPixel = GameUnitsPerPixel)
    {
        return RoundToNearestMultipleOf(value, unitsPerPixel);
    }

    /// <summary>
    /// Returns the given vector with coordinates rounded to the nearest pixel
    /// using the given world-units-per-pixel ratio.
    /// </summary>
    public static Vector2 PixelClamp(Vector2 value, float unitsPerPixel = GameUnitsPerPixel)
    {
        return new Vector2(PixelClamp(value.x, unitsPerPixel), PixelClamp(value.y, unitsPerPixel));
    }

    /// <summary>
    /// Returns the given vector with coordinates rounded to the nearest pixel
    /// using the given world-units-per-pixel ratio.
    /// </summary>
    public static Vector3 PixelClamp(Vector3 value, float unitsPerPixel = GameUnitsPerPixel)
    {
        return new Vector3(PixelClamp(value.x, unitsPerPixel), PixelClamp(value.y, unitsPerPixel), PixelClamp(value.z, unitsPerPixel));
    }
}
