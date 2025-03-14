using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectedVisual : MonoBehaviour
{
    [SerializeField] private Unit unit;
    // Start is called before the first frame update
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelctedUnitChanged;
        UpdateVisual();
    }

    private void UnitActionSystem_OnSelctedUnitChanged(object sender, EventArgs empty)
    {
        UpdateVisual();
    }

    private void UpdateVisual() {
        Unit selcectedUnit = UnitActionSystem.Instance.GetSelectedUnit();
        if(unit == selcectedUnit)
        {
            meshRenderer.enabled = true;
        } else
        {
            meshRenderer.enabled = false;
        }
    }

    private void Oestroy()
    {
        UnitActionSystem.Instance.OnSelectedUnitChanged -= UnitActionSystem_OnSelctedUnitChanged;
    }
}
