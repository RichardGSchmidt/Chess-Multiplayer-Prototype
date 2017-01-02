using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//to be used to handle turns in hotseat
//need pull the logic handling turns out of the raw
//game manager logic to support networked multiplayer
public class TurnManager : MonoBehaviour {

    bool turn;
	// Use this for initialization
	void Start ()
    {
        turn = true;	
	}
	
	// Move mouse handling over to this function instead of on the game manager maybe?
	void Update ()
    {
		
	}
}
