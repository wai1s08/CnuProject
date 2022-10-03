using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public Inevntory MyEquip;

    public static int Totalhp;

    public int Hathp;
    public int SwordHp;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Totalhp = Hathp + SwordHp;

        if (MyEquip.itemList[0] != null)
        {
            //Debug.Log(hp);
            Hathp = MyEquip.itemList[0].hp;
        }
        else
        {
            Hathp = 0;
        }


        if (MyEquip.itemList[1] != null)
        {
            //Debug.Log(hp);
            SwordHp = MyEquip.itemList[1].hp;
        }
        else
        {
            SwordHp = 0;
        }

    }
}
