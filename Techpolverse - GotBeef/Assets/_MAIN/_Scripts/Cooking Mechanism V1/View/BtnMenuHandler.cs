using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BtnMenuHandler : MonoBehaviour
{
    [Header("Components")]
    public int _btnIndex;
    public Image _image;
    [FormerlySerializedAs("_FlowManager")] [Header("Flow Manager")]
    public V1_FlowManager v1FlowManager;

    private void Start()
    {
        v1FlowManager = FindObjectOfType<V1_FlowManager>();
    }

    public void SetMenuIndex()
    {
        // Debug.Log($"Button Index: {_btnIndex}");
        v1FlowManager.ShowFoodDescription(_btnIndex);
    }
}
