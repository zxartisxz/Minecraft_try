using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining_Blocks : MonoBehaviour
{
    private bool triggered_Collision = false;
    private bool triggered_Cube_Resize = false;
    private Vector3 scale_change = new Vector3(0.3f, 0.3f, 0.3f);
    private Vector3 player_Possition_Offset;
    private BoxCollider ore_Box_Collider;
    public GameObject player;
    private float z_offset = -2f;
    private Color start_Color;
    //public float red, green, blue;

    // Start is called before the first frame update
    void Start()
    {
        ore_Box_Collider = GetComponent<BoxCollider>();
        player_Possition_Offset = new Vector3(0, player.GetComponent<BoxCollider>().size.y / 3, z_offset);
        var block_renderer = gameObject.GetComponent<Renderer>();
        start_Color = gameObject.GetComponent<Renderer>().material.color;


    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (triggered_Cube_Resize)
        {
            // Cube mocves towards player after resizing
            
            transform.position = Vector3.MoveTowards(transform.position,
                player.transform.position + player_Possition_Offset, Time.deltaTime * 3);
           
            gameObject.tag = "Mined_ore";
            if (Vector3.Distance(transform.position, player.transform.position + player_Possition_Offset) < 0.6f)
            {
                Destroy(gameObject);
                //Debug.Log("Should destroy gameobject now 2");
                //Debug.Log();
            }
        }
    }

    private void OnMouseOver()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < 5f)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0.69f, 1.8f, 1.33f);
            //gameObject.GetComponent<Renderer>().material.color = new Color(red, green, blue);
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("Primarry key pressed!");
                Destroy(ore_Box_Collider);
                triggered_Collision = false;
                gameObject.transform.localScale = scale_change;
                triggered_Cube_Resize = true;
            }
        } 
        //if (Input.GetMouseButtonDown(0) && triggered_Collision)
    }
    private void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material.color = start_Color;
    }


    // When player touches object, it is ready to be destroyed.
    private void OnTriggerEnter(Collider other) 
    {
        //dDebug.Log("Trigered box");
        if (other.gameObject.CompareTag("Player"))
        {
            triggered_Collision = true;
            //Debug.Log("If statement true");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            triggered_Collision = false;
           
            //Debug.Log("If statement true");

        }
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        
        //if (collision.gameObject.tag == "Mined_ore") //dont work!
        if (collision.gameObject.tag == "Player") 
            {
            Debug.Log(" On Collision Enter happened");
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
    */


}
