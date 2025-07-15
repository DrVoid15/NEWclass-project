using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameManager Manager;


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Bean")
        {
            // end the game
            Manager.endGame();

        }    

        
    }

}