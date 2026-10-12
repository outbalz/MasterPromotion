using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CShopManager : MonoBehaviour
{
	#region inspector
	[SerializeField] private CShopPanelController[] _shopPanels;
	[SerializeField] private CItemDatabaseSO _itemDB;
    #endregion

    private void Awake()
    {
        if(_itemDB == null)
        {
            Debug.LogWarning("Missing itemDB");
            enabled = false;
            return;
        }

        if(_shopPanels == null || _shopPanels.Length == 0 || _shopPanels[1] == null)
        {
            Debug.LogWarning("Missing ShopPanel");
            enabled = false;
            return;
        }

        SetUPShopPanel();
    }

    private void SetUPShopPanel()
    {
        for (int i = 0; i < _shopPanels.Length; i++)
        {
            _shopPanels[i].InitializeShopPanel(_itemDB.GetRandomItem());
        }
    }

    public void OnRerollButtonClick()
    {
        SetUPShopPanel();
    }

}
