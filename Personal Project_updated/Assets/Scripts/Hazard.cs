using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public GameObject player;
    private Animator playerAnim;

    private void Start()
    {
        playerAnim = player.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other){
        //Destroy(other.gameObject);
        //playerAnim.SetBool("Death_b", true);
        //playerAnim.SetTrigger("Jump_trig");
        //playerAnim.SetInteger("DeathType_int", 1);
    }
}
