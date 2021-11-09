using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RelHPosition { LEFT, CENTER, RIGHT }
public enum RelVPosition { UP, CENTER, DOWN }

public static class ExtensionMethods
{
    #region Rect Methods

    public static bool IsInside(this Rect rect, Rect otherRect)
    {
        return rect.xMin >= otherRect.xMin
            && rect.xMax <= otherRect.xMax
            && rect.yMin >= otherRect.yMin
            && rect.yMax <= otherRect.yMax;
    }

    public static string PrintRectMinMax(this Rect rect)
    {
        return "xMin: " + rect.xMin + " xMax: " + rect.xMax + "\nyMin: " + rect.yMin + " yMax: " + rect.yMax;
    }

    // Assuming rect can fit inside otherRect
    public static RelHPosition GetRelHPosition(this Rect rect, Rect otherRect)
    {
        if (rect.xMax > otherRect.xMax)
            return RelHPosition.RIGHT;
        if (rect.xMin < otherRect.xMin)
            return RelHPosition.LEFT;

        return RelHPosition.CENTER;
    }

    // Assuming rect can fit inside otherRect
    public static RelVPosition GetRelVPosition(this Rect rect, Rect otherRect)
    {
        if (rect.yMax > otherRect.yMax)
            return RelVPosition.UP;
        if (rect.yMin < otherRect.yMin)
            return RelVPosition.DOWN;

        return RelVPosition.CENTER;
    }

    public static Rect GetEnclosingSquareRect(this Rect rect)
    {
        float sideLength = rect.width > rect.height ? rect.width : rect.height;
        Rect squareRect = new Rect(rect);
        squareRect.height = sideLength;
        squareRect.width = sideLength;
        return squareRect;
    }

    public static Rect EncloseInside(this Rect rect, Rect outerRect, float padding, out float scaleRatio)
    {
        float outerHeight = outerRect.height * padding;
        float outerWidth = outerRect.width * padding;

        float heightRatio = rect.height / outerHeight;
        float widthRatio = rect.width / outerWidth;

        scaleRatio = heightRatio > widthRatio ? heightRatio : widthRatio;

        Rect enclosedRect = new Rect(0, 0, rect.width / scaleRatio, rect.height / scaleRatio);
        enclosedRect.center = outerRect.center;
        return enclosedRect;
    }

    #endregion

    public static Rect GetRectEnclosingTransforms(this Transform[] transforms)
    {
        float xMin = Mathf.Infinity, xMax = Mathf.NegativeInfinity;
        float yMin = Mathf.Infinity, yMax = Mathf.NegativeInfinity;

        foreach(Transform tr in transforms)
        {
            xMin = xMin < tr.position.x ? xMin : tr.position.x;
            xMax = xMax > tr.position.x ? xMax : tr.position.x;
            yMin = yMin < tr.position.y ? yMin : tr.position.y;
            yMax = yMax > tr.position.y ? yMax : tr.position.y;
        }

        return Rect.MinMaxRect(xMin, yMin, xMax, yMax);
    }

    public static float GetDifferenceMagnitude(this Color baseColor, Color otherColor)
    {
        //Color.RGBToHSV(baseColor, out float bH, out float bS, out float bV);
        //Color.RGBToHSV(otherColor, out float oH, out float oS, out float oV);
        //return Mathf.Abs(bV - oV);
        return (Mathf.Abs(baseColor.r - otherColor.r) + Mathf.Abs(baseColor.g - otherColor.g) + Mathf.Abs(baseColor.b - otherColor.b)) / 3;
    }

    public static Color ToGrayscale(this Color color)
    {
        return new Color(0.299f * color.r, 0.587f * color.g, 0.114f * color.b);
    }
}
