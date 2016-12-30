using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GamePiece selected = null;
    public void SetSelection(GamePiece newSelection)
    {
        if (selected != null)
        {
            selected.selected = false;  //deselects if no selection availble
        }
        selected = newSelection;
    }
}
