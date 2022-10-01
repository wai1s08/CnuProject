using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemOnDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    static InevntoryManager instance;

    public Inevntory myBag;

    public Inevntory MyEquip;

    public int currentItemID; // 當前物品ID

    public string currentItemType;

    public Transform originalParent;

    public Slot slot;


    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        currentItemID = originalParent.GetComponent<Slot>().slotID;
        currentItemType = originalParent.GetComponent<Slot>().itemtype;

        transform.SetParent(transform.parent.parent.parent.parent.parent.parent);
        transform.position = eventData.position;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;

        Debug.Log("格子" + eventData.pointerCurrentRaycast.gameObject.name);

        Debug.Log(currentItemType);

        Debug.Log("格子" + eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().itemEquip);


    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            //如果射線 = item Image
            if (eventData.pointerCurrentRaycast.gameObject.name == "item Image")
            {
                //物品互換
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;

                //臨時變量 = 背包當前物品格的ID
                var temp = myBag.itemList[currentItemID];

                // 我的背包目前物品格的ID = 我現在滑鼠射線那格的物品格ID
                myBag.itemList[currentItemID] = myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID];

                //回傳
                myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = temp;

                //
                eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
                eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);
                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }


            if (eventData.pointerCurrentRaycast.gameObject.name == "Slot(Clone)")
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

                myBag.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = myBag.itemList[currentItemID];

                if (eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().slotID != currentItemID)
                {
                    myBag.itemList[currentItemID] = null;
                }

                GetComponent<CanvasGroup>().blocksRaycasts = true;
                return;
            }

            if (eventData.pointerCurrentRaycast.gameObject.name == "EquipemptySlot(Clone)")
            {
                transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
                transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;

                // 我的背包目前物品格的ID = 我現在滑鼠射線那格的物品格ID
                MyEquip.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().equipID] = myBag.itemList[currentItemID];

                if(eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().equipID != currentItemID)
                {
                    myBag.itemList[currentItemID] = null;
                }



                return;

            }

        }


        //其他位子都復原
        transform.SetParent(originalParent);
        transform.position = originalParent.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }


}


//if (eventData.pointerCurrentRaycast.gameObject.GetComponent<Slot>().itemEquip == true)
//    {
//        transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
//        transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;

//        //臨時變量 = 背包當前物品格的ID
//        var Equiptemp = myBag.itemList[currentItemID];

//        // 我的背包目前物品格的ID = 我現在滑鼠射線那格的物品格ID
//        myBag.itemList[currentItemID] = MyEquip.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().equipID];

//        //回傳
//        MyEquip.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().slotID] = Equiptemp;

//        eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
//        eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);
//        GetComponent<CanvasGroup>().blocksRaycasts = true;
//        return;
//    }



//我裝備欄目前射線的 equipID = 我的背包當前物品的 slotID
//MyEquip.itemList[eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Slot>().equipID] = myBag.itemList[currentItemID];