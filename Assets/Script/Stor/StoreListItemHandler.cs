using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreListItemHandler : MonoBehaviour
{
    [SerializeField] private GameObject parentObj;
    [SerializeField] private GameObject itemPrefab;

    [SerializeField] private List<StoreItemScriptable> storeItemList;

    public void Setup()
    {
        List<StoreItemModel> items = GetStoreItemListFromScriptableList(storeItemList);

        if (items == null)
            return;

        for (int i = 0; i < items.Count; i++)
        {
            StoreItem storeItem = InstantiateObject(itemPrefab, parentObj);
            if(storeItem != null)
            {
                storeItem.Setup(items[i]);
            }
        }
    }

    private StoreItem InstantiateObject(GameObject obj, GameObject parentObj)
    {
        GameObject newObj = Instantiate(obj, parentObj.transform.position, parentObj.transform.rotation);
        newObj.transform.parent = parentObj.transform;
        if (newObj.GetComponent<StoreItem>() != null)
        {
            return newObj.GetComponent<StoreItem>();
        }
        return null;
    }

    private List<StoreItemModel> GetStoreItemListFromScriptableList(List<StoreItemScriptable> scriptableList)
    {
        List<StoreItemModel> itemList = new List<StoreItemModel>();

        if (scriptableList == null)
            return itemList;

        for (int i = 0; i < scriptableList.Count; i++)
        {
            StoreItemModel item = new StoreItemModel();
            item.itemName = scriptableList[i].name;
            item.itemName = scriptableList[i].itemName;
            item.itemImage = scriptableList[i].itemImage;
            item.isPurchased = scriptableList[i].isPurchased;
            item.price = scriptableList[i].price;
            item.playerId = scriptableList[i].playerId;

            itemList.Add(item);
        }
        return itemList;
    }
}
