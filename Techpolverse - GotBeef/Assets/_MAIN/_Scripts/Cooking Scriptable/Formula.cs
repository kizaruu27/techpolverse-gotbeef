using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Formula", menuName = "Assets/Formula")]
public class Formula : ScriptableObject
{
    public List<MFormula> Formulas;
}

[System.Serializable]
public class MFormula
{
    public string formulaName;
    public Sprite formulaSprite;
}
