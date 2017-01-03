using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GamePiece selected = null;
    public BoardManager boardManager;
    public bool selectionStatus;
    public bool turn;

    private void NextTurn()
    {
        if (selected != null)
        {
            selected.selected = false;
        }
        selectionStatus = false;
        selected = null;
        turn = !turn;
    }

    private string WhosTurn()
    {
        string colorOfPlayer = "Black";
        if (turn) colorOfPlayer = "White";
        return colorOfPlayer;
    }


    private void Start()
    {
        
        boardManager = FindObjectOfType<BoardManager>();
        selectionStatus = false;
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(Screen.height * .01f, Screen.width * .01f, Screen.width * .15f, Screen.height * .1f), "Turn: " + WhosTurn());
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
                    if ((tileHolder.occupied)&&(turn == tileHolder.pieceonTile.color))
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
                if (areaClicked!=null&&(boardManager.board.OnGameBoard(areaClicked)))
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
        }
    }
  }
    