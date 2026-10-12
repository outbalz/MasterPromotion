using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CShopPanelController : MonoBehaviour
{
	#region inspector
	[SerializeField] private CItemDataSO _item;
	[SerializeField] private Image _itemImage;
	[SerializeField] private Text _nameText;
	[SerializeField] private Text _priceText;
	[SerializeField] private Button _purchaseButton;
    #endregion

    private void Awake()
    {
        if(_itemImage == null || _nameText == null || _priceText == null || _purchaseButton == null)
		{
			Debug.LogWarning("Missing UI element");
		}

		_purchaseButton.onClick.AddListener(OnPurchaseButtonClick);
    }

    public void InitializeShopPanel(CItemDataSO item)
    {
        _item = item;
		_itemImage.sprite = item.ItemSprite;
		_nameText.text = item.ItemName;
		_priceText.text = $"{item.ItemPrice}$";
	}

	private void OnPurchaseButtonClick()
	{
		CInventoryManager.AddToInventory(_item, 1);
	}
}
