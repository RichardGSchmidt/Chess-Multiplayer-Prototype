using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
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
        boardManager = FindObjectOfType<BoardManager>();
        selected = false;
    }
    public void Update()
    {
        if (selected)
        {
            rend.material.color = Color.green;
        }
        else
        {
            rend.material.color = Color.white;
        }
    }

    public void DestroySelf()
    {
        Destroy (gameObject);
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
public class IntVector2
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


