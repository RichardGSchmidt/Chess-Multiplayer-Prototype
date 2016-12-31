using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    string nameOfPiece;

    public enum PlayerColor { white, black };
    public PlayerColor playerColor;

    public bool selected;
    public bool firstmove;
    public bool isKing;
    public int value;

    [HideInInspector]
    public GameManager gameManager;
    [HideInInspector]
    public Renderer rend;


    public MovementMap movementMap;

    virtual public void Start()
    {
        gameManager = GameObject.FindWithTag("Board").GetComponent<GameManager>();
        rend = GetComponent<Renderer>();
    }
    public void OnMouseDown()
    {
        selected = true;
        gameManager.SetSelection(this);
    }

    public void Deselect()
    {
        selected = false;
    }

    virtual public MovementMap GetMovementMap()
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


