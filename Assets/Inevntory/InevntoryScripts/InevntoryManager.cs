using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InevntoryManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    static InevntoryManager instance;

    public Inevntory myBag;
    public GameObject slotGrid;
    public Slot slotPrefab;
    public Text itemfromation;

    [SerializeField] private GameObject InventoryPanel;
    private RectTransform panel_rect_transform;
    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;
    }

    private void OnEnable()
    {
        RefreshItem();
        instance.itemfromation.text = "";
    }

    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemfromation.text = itemDescription;
    }

    public static void CreateNewItem(Item item)
    {
        Slot newItme = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItme.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItme.slotItem = item;
        newItme.slotImage.sprite = item.itemimage;
        newItme.slotNum.text = item.itemHeld.ToString();
    }

    public static void RefreshItem()
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < instance.myBag.itemList.Count; i++)
        {
            CreateNewItem(instance.myBag.itemList[i]);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        panel_rect_transform = InventoryPanel.GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        panel_rect_transform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }
}
