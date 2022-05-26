using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Coloring : MonoBehaviour
{
    private MeshRenderer Color;

    public int test;

    public Material ColorMaterial;
    // Start is called before the first frame update
    void Start()
    {

        Color = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Coloring")
        {
            Color.material = ColorMaterial;      
        }
        

    }

    void OnPointerEnter(PointerEventData eventData)
    {
        test += 1;
    }

}

