using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//to be used to handle turns in hotseat
//registers as two seperate entities and handles turns for both of them
//starting point to getting the code reconstructed to make
//sense as multiplayer code

public class TurnManager : MonoBehaviour
{

    bool turn;
	
	void Start ()
    {
        turn = true;	
	}
	
	// Move mouse handling over to this function instead of on the game manager maybe?
    // Have mouse commands send requests to the game manager, but the manager only responds if the client has turn
    // rights.
    // This essentially is the player controller, so the gamemanager needs to be reconstructed to match more
    // player control driven design.
	void Update ()
    {
		
	}
}
