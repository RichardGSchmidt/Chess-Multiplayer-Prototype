using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GamePiece selected = null;
    public void SetSelection(GamePiece newSelection)
    {
        if (selected != null)
        {
            //deselects if no selection availble
            selected.selected = false;  
        }
        selected = newSelection;
    }

    private Vector3 mouseLocation;
    public GamePiece target = null; 
    public void Update()
    {
        if (selected != null && Input.GetMouseButtonDown(0))
        {
            //gets position of click and saves it to a Vector3
            mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition); //gets position of click

        }

        target = null;
    }
}
