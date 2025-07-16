using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    //reference to player
    public PlayerController Bean;
    // Start is called before the first frame updatedd
    void Start()
    {
        // grab fer to player 
        Bean = GameObject.Find("Bean").GetComponent<PlayerController>();

    }


    private void OnTriggerEnter(Collider other)
    {
        // if the player collides  with coin, increase points and destroy
        if (other.name == "Bean")
        {
            Bean.coincount++;
            Destroy(this.gameObject);
        }
    }
}
