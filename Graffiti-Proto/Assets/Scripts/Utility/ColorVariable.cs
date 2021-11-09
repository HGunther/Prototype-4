using UnityEngine;

[CreateAssetMenu]
public class ColorVariable : ScriptableObject
{
    [SerializeField] Color color;

    public Color Value
    {
        get { return color; }
    }

    public void SetColor(Color color)
    {
        this.color = color;
    }
}
