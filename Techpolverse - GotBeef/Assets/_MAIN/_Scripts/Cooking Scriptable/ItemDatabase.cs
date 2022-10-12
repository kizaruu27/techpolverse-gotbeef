using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Database", menuName = "Assets/Database/Item Database")]
public class ItemDatabase : ScriptableObject
{
    public List<Food> foodList;
    public Formula FormulasList;
}
