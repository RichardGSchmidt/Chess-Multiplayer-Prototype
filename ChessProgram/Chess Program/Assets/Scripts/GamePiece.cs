using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    string nameOfPiece;

    public enum PlayerColor {White,Black};
    public PlayerColor pieceColor;
    public BoardTile ownerTile;


    public BoxCollider2D boxCollider;
    public bool selected;
    public bool firstmove;
    public bool isKing;
    public int value;
    public IntVector2 location;

    [HideInInspector]
    public GameManager gameManager;
    [HideInInspector]
    public Renderer rend;
    public BoardManager boardManager;


    public MovementMap movementMap;

    public void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        gameManager = GameObject.FindWithTag("Board").GetComponent<GameManager>();
        rend = GetComponent<Renderer>();
        boardManager = GameObject.FindObjectOfType<BoardManager>();
        selected = false;
    }

    public void Update()
    {
        if (selected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 areaClicked = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (boardManager.board.OnGameBoard(areaClicked))
                {
                    IntVector2 locationClicked = boardManager.board.GetGridReference(areaClicked);
                    if (boardManager.board.spot[locationClicked.x, locationClicked.y].occupied
                        &&(boardManager.board.spot[locationClicked.x, locationClicked.y].pieceonTile.pieceColor != boardManager.board.colorsTurn))
                    {
                        if(boardManager.AttackIsValid(this, boardManager.board.spot[locationClicked.x, locationClicked.y].pieceonTile))
                        {
                            boardManager.MoveTo(this, location);
                            if (pieceColor == PlayerColor.White)
                            {
                                boardManager.board.colorsTurn = PlayerColor.Black;
                            }
                            else if (pieceColor == PlayerColor.Black)
                            {
                                boardManager.board.colorsTurn = PlayerColor.White;
                            }
                        }
                    }
                    else if (boardManager.MoveIsValid(this, locationClicked.x, locationClicked.y))
                    {
                        boardManager.MoveTo(this, location);
                        if (pieceColor == PlayerColor.White)
                        {
                            boardManager.board.colorsTurn = PlayerColor.Black;
                        }
                        else if (pieceColor == PlayerColor.Black)
                        {
                            boardManager.board.colorsTurn = PlayerColor.White;
                        }
                    }
                }
                selected = false;
                boardManager.selectionStatus = false;
                
            }
            if (Input.GetMouseButtonDown(1))
            {
                selected = false;
                boardManager.selectionStatus = false;
            }
        }

        else if (!boardManager.selectionStatus)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 areaClicked = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (boardManager.board.OnGameBoard(areaClicked))
                {
                    IntVector2 locationClicked = boardManager.board.GetGridReference(areaClicked);
                    if ((boardManager.board.spot[locationClicked.x, locationClicked.y].occupied)
                        &&(boardManager.board.spot[locationClicked.x, locationClicked.y].pieceonTile.pieceColor 
                        == boardManager.board.colorsTurn))
                    {
                        selected = true;
                        boardManager.selectionStatus = true;
                    }
                }
            }
        }

        
    }



    public MovementMap GetMovementMap()
    {
        return movementMap;
    }


    public void OnMouseEnter()
    {
        //if can move and same color
        rend.material.color = Color.green;
    }
    public void OnMouseExit()
    {
        rend.material.color = Color.white;
    }
}

// stores the possible movements a piece can make in their positive direction.
[System.Serializable]
public class MovementMap
{
    public DirectionsOfMovement TotalMovementAxis; //provide directions of movement for queens
                                                //rooks and bishops
    public IntVector2[] CanMoveIfEnemy; //used for pawns and knights
    public IntVector2[] CanMoveIfEmpty; //useful for knights, also used for pawns
    public IntVector2[] CanMoveIfFirstMoveAndClear; //pawn first move and castling
}

[System.Serializable]
public struct IntVector2
{
    public int x;
    public int y;
    
}

[System.Serializable]
public struct DirectionsOfMovement
{
    public bool xyAxis;
    public bool diagonals;
}


