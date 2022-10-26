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
    
    [Header("Flow Manager")]
    public V1_FlowManager v1FlowManager;

    [Header("Description Panel")] 
    public GameObject descriptionPanel;

    public string foodName;
    public string orderValue;

    private void Start()
    {
        v1FlowManager = FindObjectOfType<V1_FlowManager>();
        // descriptionPanel = GameObject.Find("");
    }

    public void SetMenuIndex()
    {
        // Debug.Log($"Button Index: {_btnIndex}");
        v1FlowManager.ShowFoodDescription(_btnIndex);
    }

    public void OnClickSetFood()
    {
        GameFlow.instance.foodName = foodName;
        GameFlow.instance.orderValue = orderValue;
        GameFlow.instance.foodIndex = _btnIndex;
    }
}
