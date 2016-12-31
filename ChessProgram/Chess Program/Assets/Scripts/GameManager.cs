using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GamePiece selected = null;
    public BoardManager boardman;

    public void Start()
    {
       
    }

    //public void GotClicked(GamePiece pieceClicked)
    //{
    //    if (selected == null|| selected.playerColor.ToString() == boardman.board.playerTurn.ToString())
    //    {
    //        selected = pieceClicked;
    //    }
    //    else
    //    {
    //        if (boardman.AttackIsValid(selected, pieceClicked))
    //        {
    //            IntVector2 refToMoveTo = pieceClicked.location;
    //            boardman.MoveTo(selected, refToMoveTo);

    //        }
    //    }
    //}

    public void SetSelection(GamePiece newSelection)
    {
        selected = newSelection;
    }

    private Vector3 mouseLocation;
    public GamePiece target = null;
    
}
