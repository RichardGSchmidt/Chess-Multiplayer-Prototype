using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//to be used to handle turns in hotseat
//registers as two seperate entities and handles turns for both of them
//starting point to getting the code reconstructed to make
//sense as multiplayer code

// turn manager may be a bad name for this
public class TurnManager : MonoBehaviour
{

    bool turn;
    bool selectionStatus;

    void Start()
    {
        turn = true;
    }

    // Move mouse handling over to this function instead of on the game manager maybe?
    // Have mouse commands send requests to the game manager, but the manager only responds if the client has turn
    // rights.
    // This essentially is the player controller, so the gamemanager needs to be reconstructed to match more
    // player control driven design.

    private void Update()
    {
    
    }


}
/*
void OldUpdate ()
    {
        if (!selectionStatus)
        {
            #region When Leftclick and Nothing is Selected
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 areaClicked = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (boardManager.board.OnGameBoard(areaClicked))
                {
                    //convert mouse location into game grid location
                    IntVector2 locationClicked = boardManager.board.GetGridReference(areaClicked);
                    BoardTile tileHolder = boardManager.board.spot[locationClicked.x, locationClicked.y];
                    //if an object at the clicked location exists and is the same color, select the object;
                    if ((tileHolder.occupied) && (turn == tileHolder.pieceonTile.color))
                    {
                        boardManager.board.spot[locationClicked.x, locationClicked.y].pieceonTile.selected = true;
                        selected = boardManager.board.spot[locationClicked.x, locationClicked.y].pieceonTile;
                        selectionStatus = true;
                    }
                }
            }
            #endregion
        }
        else if (selectionStatus)
        {
            #region When Leftclick and Something is Selected
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 areaClicked = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (areaClicked != null && (boardManager.board.OnGameBoard(areaClicked)))
                {
                    //convert mouse location into game grid location
                    IntVector2 locationClicked = boardManager.board.GetGridReference(areaClicked);

                    //temp holder for the tile clicked
                    BoardTile tileHolder = boardManager.board.spot[locationClicked.x, locationClicked.y];
                    //if an object at the clicked location exists and is the same color, select the object;
                    if ((tileHolder.occupied))
                    {
                        if (tileHolder.pieceonTile.color == turn)
                        {
                            boardManager.board.spot[locationClicked.x, locationClicked.y].pieceonTile.selected = true;
                            selected = boardManager.board.spot[locationClicked.x, locationClicked.y].pieceonTile;
                            selectionStatus = true;
                        }
                        //if an enemy was clicked test attack and if possible attack
                        else if (boardManager.AttackIsValid(selected, tileHolder.pieceonTile))
                        {
                            boardManager.MoveTo(selected, locationClicked);
                            NextTurn();
                        }
                    }
                    //if there was an on grid click without an object present

                    //move to
                    else if (boardManager.MoveIsValid(selected, locationClicked.x, locationClicked.y))
                    {
                        boardManager.MoveTo(selected, locationClicked);
                        NextTurn();
                    }

                    //or unselect
                    else
                    {
                        selectionStatus = false;
                        selected.selected = false;
                        selected = null;
                    }




                }
                //if click is off screen unselect
                else
                {
                    selectionStatus = false;
                    selected.selected = false;
                    selected = null;
                }

            }
            #endregion
        }
    }



    */