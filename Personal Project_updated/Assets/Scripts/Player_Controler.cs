using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controler : MonoBehaviour
{
    private float horizontal_Input;
    private float speed = 10f;
    private float Run_Anim_Speed;
    public float jumpForce;
    public float gravityModfier;
    private int way = 1;

    public GameObject player;
    private Rigidbody playerRB;
    private Animator playerAnim;
    private bool gameOver = false;
    private bool is_Ground;

    //public 

    //public Canvas inventory_Slots;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModfier;
        playerAnim = GetComponent<Animator>();

        //inventory_Slots = GetComponent<Canvas>();
     
    }

    // Update is called once per frame
    //void Update()
    void FixedUpdate()
    //void LateUpdate()
    {
        /*
         * 
        if (Input.GetKeyDown(KeyCode.I))
        {
            Instantiate(inventory_Slots, new Vector3(0, 0, 0), inventory_Slots.transform.rotation);
            //Instantiate(ore_block, new Vector3(x, y, z), ore_block.transform.rotation);
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            Destroy(inventory_Slots);
        }
        */

        horizontal_Input = way * Input.GetAxis("Horizontal");
        if (!gameOver)
        {
            //transform.Translate(Vector3.forward  * speed * 0.01f * horizontal_Input);
            transform.Translate(Vector3.forward * Time.deltaTime * speed * horizontal_Input);



            // On key down start animation
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Run_Anim_Speed = 1;
            }

            //On key up stop algorithm
            else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                Run_Anim_Speed = 0;
            }
            playerAnim.SetFloat("Speed_f", Run_Anim_Speed);

            // Turning algorithm
            if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && player.transform.rotation.eulerAngles.y == 90)
            {
                player.transform.eulerAngles = Vector3.up * (-90);
                way = -1;
            }
            else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && player.transform.rotation.eulerAngles.y == 270)
            {
                player.transform.eulerAngles = Vector3.up * (90);
                way = 1;
            }



            //Jumping
            if (Input.GetKeyDown(KeyCode.Space))// && is_Ground)
            {
                playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                playerAnim.SetTrigger("Jump_trig");
                //is_Ground = false;
            }

            //Crouching & looking down
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                playerAnim.SetBool("Crouch_b", true);
                //camera_Control.transform.position -= new Vector3(0,5,0);
            }
            else if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                playerAnim.SetBool("Crouch_b", false);
                //camera_Control.transform.position += new Vector3(0, 5, 0);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        is_Ground = true;

        if (other.gameObject.CompareTag("Hazzards"))
        {
            playerAnim.SetBool("Death_b", true);
            //playerAnim.SetTrigger("Jump_trig");
            playerAnim.SetInteger("DeathType_int", 1);
            gameOver = true;
            Debug.Log("Game Over!");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 0 * horizontal_Input);
    }



}
