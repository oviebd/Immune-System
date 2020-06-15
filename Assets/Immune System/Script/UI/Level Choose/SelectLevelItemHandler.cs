using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelItemHandler : MonoBehaviour
{
    [SerializeField] private GameObject parentObj;
    [SerializeField] private GameObject itemPrefab;

    public void Setup()
    {
        DestroyAllItems();
        
        List<SelectLevelItemModel> items = GenerateLevelItemsData( GameDataHandler.instance.getMaxLevelNumber() );

        if (items == null)
            return;

        for (int i = 0; i < items.Count; i++)
        {
            SelectLevelItem item = InstantiateObject(itemPrefab, parentObj);
            if (item != null)
            {
                item.Setup(items[i]);
            }
        }
    }

    private SelectLevelItem InstantiateObject(GameObject obj, GameObject parentObj)
    {
        GameObject newObj = InstantiatorHelper.instance.InstantiateCanvasUIObject(obj, parentObj);
        newObj.transform.parent = parentObj.transform;
        if (newObj.GetComponent<SelectLevelItem>() != null)
        {
            return newObj.GetComponent<SelectLevelItem>();
        }
        return null;
    }

    private List<SelectLevelItemModel> GenerateLevelItemsData(int maxLevel)
    {
        List<SelectLevelItemModel> dataList = new List<SelectLevelItemModel>();
        
        for ( int i = 0; i < maxLevel; i++){
            SelectLevelItemModel data = new SelectLevelItemModel();
            
            data.levelNumber = i + 1;
            data.levelDescription = GetLevelDetailsFromLevelNumber(data.levelNumber);

            dataList.Add(data);
        }
        return dataList;
    }

    private string GetLevelDetailsFromLevelNumber(int levelNumber)
    {
        string details = "";
        switch (levelNumber)
        {
            case 1:
                details = "Pharynx";
                break;
            case 2:
                details = "Lymph nodes";
                break;
            case 3:
                details = "Lungs";
                break;
            case 4:
                details = "Heart";
                break;
            case 5:
                details = "Spleen";
                break;
            case 6:
                details = "Liver";
                break;
        }

        return details;
    }

    private void DestroyAllItems()
    {
        SelectLevelItem[] items = FindObjectsOfType<SelectLevelItem>();
        for (int i = 0; i < items.Length; i++)
        {
            Destroy(items[i].gameObject);
        }
    }
}
