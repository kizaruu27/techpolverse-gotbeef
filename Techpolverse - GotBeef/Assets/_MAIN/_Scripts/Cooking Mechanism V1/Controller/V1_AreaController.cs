using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum AreaStatus
{
    Raw, Great, Perfect, OverCook
}

public class V1_AreaController : MonoBehaviour
{
    [FormerlySerializedAs("_CookingManager")] public V1_CookingManager v1CookingManager;
    public AreaStatus _AreaStatus;
    bool OnArea;

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Handle" && v1CookingManager.isPlay)
            StartCoroutine(OnColliderBehaviour(other, true));
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Handle" && v1CookingManager.isPlay)
            StartCoroutine(OnColliderBehaviour(other, false));
    }

    public IEnumerator OnColliderBehaviour(Collider2D col, bool status)
    {
        OnArea = status;

        yield return new WaitForEndOfFrame();

        if (OnArea)
        {
            switch (_AreaStatus)
            {
                case AreaStatus.Perfect:
                    v1CookingManager.GenerateStatusResult = AreaStatus.Perfect;
                    break;
                case AreaStatus.Great:
                    v1CookingManager.GenerateStatusResult = AreaStatus.Great;
                    break;
                case AreaStatus.Raw:
                    v1CookingManager.GenerateStatusResult = AreaStatus.Raw;
                    break;
                case AreaStatus.OverCook:
                    v1CookingManager.GenerateStatusResult = AreaStatus.OverCook;
                    break;
            }
        }
    }
}
