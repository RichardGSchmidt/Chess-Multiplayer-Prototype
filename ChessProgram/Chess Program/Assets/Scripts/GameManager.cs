using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GamePiece selected = null;
    public BoardManager boardManager;
    public bool selectionStatus;
    public GamePiece.PlayerColor PlayerTurn;
    public void Start()
    {
        PlayerTurn = GamePiece.PlayerColor.White;
        boardManager = FindObjectOfType<BoardManager>();
        selectionStatus = false;
    }

    public void Update()
    {

        if (!selectionStatus)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 areaClicked = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (boardManager.board.OnGameBoard(areaClicked))
                {
                    //convert mouse location into game grid location
                    IntVector2 locationClicked = boardManager.board.GetGridReference(areaClicked);
                    BoardTile tileHolder = boardManager.board.spot[locationClicked.x,locationClicked.y];  
                    //if an object at the clicked location exists and is the same color, select the object;
                    if ((tileHolder.occupied)&&(PlayerTurn.ToString() == tileHolder.pieceonTile.pieceColor.ToString()))
                    {
                        boardManager.board.spot[locationClicked.x, locationClicked.y].pieceonTile.selected = true;
                        selected = boardManager.board.spot[locationClicked.x, locationClicked.y].pieceonTile;
                        selectionStatus = true;
                    }
                }
            }
        }
        else if (selectionStatus)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 areaClicked = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (boardManager.board.OnGameBoard(areaClicked))
                {
                    //convert mouse location into game grid location
                    IntVector2 locationClicked = boardManager.board.GetGridReference(areaClicked);

                    //temp holder for the tile clicked
                    BoardTile tileHolder = boardManager.board.spot[locationClicked.x, locationClicked.y];
                    //if an object at the clicked location exists and is the same color, select the object;
                    if ((tileHolder.occupied))
                    {
                        if (tileHolder.pieceonTile.pieceColor == boardManager.board.colorsTurn)
                        {
                            boardManager.board.spot[locationClicked.x, locationClicked.y].pieceonTile.selected = true;
                            selected = boardManager.board.spot[locationClicked.x, locationClicked.y].pieceonTile;
                            selectionStatus = true;
                        }
                        //if an enemy was clicked test attack and if possible attack
                        else if (boardManager.AttackIsValid(selected, tileHolder.pieceonTile))
                        {
                            boardManager.MoveTo(selected, locationClicked);
                            selectionStatus = false;
                            if(PlayerTurn == GamePiece.PlayerColor.White)
                            {
                                PlayerTurn = GamePiece.PlayerColor.Black;
                            }
                            else
                            {
                                PlayerTurn = GamePiece.PlayerColor.White;
                            }
                            selected = null;
                        }
                    }
                    //if there was an on grid click without an object present
                    else if (boardManager.MoveIsValid(selected, locationClicked.x, locationClicked.y))
                    {
                        boardManager.MoveTo(selected, locationClicked);
                        selectionStatus = false;
                        if (PlayerTurn == GamePiece.PlayerColor.White)
                        {
                            PlayerTurn = GamePiece.PlayerColor.Black;
                        }
                        else
                        {
                            PlayerTurn = GamePiece.PlayerColor.White;
                        }
                        selected = null;
                    }

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
        }
    }
  }
    