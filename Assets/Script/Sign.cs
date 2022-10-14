using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sign : MonoBehaviour
{
    public GameObject diadialogBox;
    public Text dialogBoxText;
    public string signText;
    private bool isPlayerInSign;

    public GameObject warn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isPlayerInSign)
        {
            dialogBoxText.text = signText;

            diadialogBox.SetActive(true);

            warn.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            isPlayerInSign = true;
            //warn.SetActive(true);
            
        }
    }
    


    void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerInSign = false;
        diadialogBox.SetActive(false);

        //warn.SetActive(false);
    }

}
