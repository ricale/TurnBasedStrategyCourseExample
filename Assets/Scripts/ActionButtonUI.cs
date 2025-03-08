using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ActionButtonUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextMeshPro;
    [SerializeField] private Button button;

    public void SetBaseAction(BaseAction baseAction)
    {
        TextMeshPro.text = baseAction.GetActionName().ToUpper();

        button.onClick.AddListener(() => {
            UnitActionSystem.Instance.SetSelectedAction(baseAction);
        });
    }
}
