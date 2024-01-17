using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Controller : MonoBehaviour
{

    //public GameObject player;
    //private Color Inventory_transparancy = new Color(1f, 1f, 1f, 1f);
    private Vector3 inventory_Start_pos = new Vector3(0,0,0);
    private float inventory_Offset =125;

    private bool inventory_Switch = false;
    // Start is called before the first frame update
    void Start()
    {
        inventory_Start_pos = this.transform.position;
        this.GetComponent<Image>().material.color = new Color(1f, 1f, 1f, 1f);

    }

    // Update is called once per frame
    void Update()
    {          
       if (Input.GetKeyDown(KeyCode.I) && !inventory_Switch)
       {
            this.transform.position = inventory_Start_pos;
            //this.GetComponent<Image>().material.color = new Color(1f, 1f, 1f, 0f);
            inventory_Switch = true;
       }
       else if (Input.GetKeyDown(KeyCode.I) && inventory_Switch)
       {
            this.transform.position = inventory_Start_pos + new Vector3(0, inventory_Offset, 0);
            inventory_Switch = false;
            //this.GetComponent<Image>().material.color = new Color(1f, 1f, 1f, 1f);
        }
       
    }
}
