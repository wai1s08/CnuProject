using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipManager : MonoBehaviour
{
    public Inevntory MyEquip;

    public static int Totalhp;

    public int Hathp;
    public int SwordHp;

    public PlayerHealth playerHealth;


    void Start()
    {
        Totalhp = Hathp + SwordHp;
        Hat();
        Sword();
    }

    // Update is called once per frame
    void Update()
    {
        
        Totalhp = Hathp + SwordHp;
        Hat();
        Sword();
    }

    void Hat()
    {
        if (MyEquip.itemList[0] != null)
        {
            //PlayerHealth.Instance.TestEquipHP(Hathp);
            Hathp = MyEquip.itemList[0].hp;
        }
        else
        {
            Hathp = 0;
        }
    }

    void Sword()
    {
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
