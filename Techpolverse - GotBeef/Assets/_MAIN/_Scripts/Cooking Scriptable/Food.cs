using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Food", menuName = "Assets/Foods")]
public class Food : ScriptableObject
{
    public string foodName;
    public Sprite foodSprite;
    [TextArea]
    public string foodDescription;
    public string[] formulas;
    public Image[] formulaImages;
    public string orderValue;
}
