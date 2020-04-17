using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreItem : MonoBehaviour
{
    [SerializeField] private Text _txtPrice;
    [SerializeField] private Image _imgItem;
    [SerializeField] private Button _btnBuy;

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
    }

    public void OnBuyButtonClicked()
    {
         StorePanel.instance.BuyButtonClicked(itemData);
    }
    public void OnInfoButtonClicked()
    {
        StorePanel.instance.ShowItemInfo(itemData);
    }
   /* void SetImageGraphicsFromResourceFolder(Image imageContainer, string imageName)
    {
        if(imageContainer != null && imageName != null)
        {
            if (Resources.Load<Sprite>(imageName) != null)
            {
               // _imgItem.sprite = Resources.Load<Sprite>(itemClass.itemImage);
            }
        }
    } */

}
