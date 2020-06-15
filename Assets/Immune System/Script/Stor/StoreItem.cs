using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour
{
	[SerializeField] private Text _txtPlayerName;
	[SerializeField] private Text _txtPrice;
	[SerializeField] private Text _txtDescription;
	[SerializeField] private Image _imgItem;
    [SerializeField] private Button _btnBuy;
	[SerializeField] private Button _useButton;
	[SerializeField] private UiHighlighter _highlighter;

     private StoreItemModel itemData;
    public void Setup(StoreItemModel item)
    {
        this.itemData = item;
        SetupUi(item);
    }

    private void SetupUi(StoreItemModel item)
    {
        if (item == null)
            return;

        _txtPrice.text  = item.price + "";
        _imgItem.sprite = item.itemImage;
		_txtPlayerName.text = item.itemName.ToString();
		_txtDescription.text = item.itemDescription;


		if (PlayerAchivedDataHandler.instance.IsThisPlayerShipAlreadyPurchasedByPlayer(item.itemType) == true){
			_useButton.gameObject.SetActive(true);
			_btnBuy.gameObject.SetActive(false);
		}
		else
		{
			_btnBuy.gameObject.SetActive(true);
			_useButton.gameObject.SetActive(false);
		}
		SetSelectedItemAppearance();
	}

	void SetSelectedItemAppearance()
	{
		if (_highlighter == null)
			return;
		//_highlighter.SetHighlightSprite(this.itemData.itemImage);

		if (GameDataHandler.instance.GetCurrentPlayer() == this.itemData.itemType)
		{
			_highlighter.ShowHighlight();
			_useButton.GetComponentInChildren<Text>().text = "Selected Item";
			_useButton.interactable = false;
		}
		else
			_highlighter.HideHighlight();
	}

    public void OnBuyButtonClicked()
    {
         StorePanel.instance.BuyButtonClicked(itemData);
    }
	public void OnUseButtonClicked()
	{
		StorePanel.instance.UseButtonClicked(itemData);
	}
}
