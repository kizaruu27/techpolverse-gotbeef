using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpDialog : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI dialogMessage;

    public void SetActivePopUpDialog(string _title, string _dialogMessage)
    {
        this.gameObject.SetActive(true);

        title.text = _title;
        dialogMessage.text = _dialogMessage;
    }

}
