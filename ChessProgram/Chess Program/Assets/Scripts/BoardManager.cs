using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}


//this object comprises of the entire board itself
public class Board
{
    public BoardGrid boardTiles = new BoardGrid();
}



//Object Container for the entire board
public class BoardGrid {

   BoardTile[,]spot = new BoardTile[8,8];  //spot will be the actual tile you are refering to.

    public BoardGrid()
    {
        //filling the transformGrid array
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                spot[x, y].position = new Vector3(-3.5f+x, -3.5f+y, 0);
            }
        }
    }

    public bool CheckIfOnGrid(Vector3 reference)
    {
        //checks to make sure it's inside the coordinate system of the board.
        if ((reference.x < -4f || reference.y < -4f) || (reference.x > 4 || reference.y > 4))
        {
            return false;
        }
        else return true;
    }
    

    

}

//object container for an actual tile piece
public class BoardTile
{
    public GamePiece pieceonTile;
    public Vector3 position;
    public bool occupied;
    private float topBoundary;
    private float bottomBoundary;
    private float leftBoundary;
    private float rightBoundary;
    public BoardTile[,] tilePresets;

    //create a new empty board tile
    public BoardTile(Vector3 passed)
    {
        position = passed;
        topBoundary = position.y + .5f;
        bottomBoundary = position.y - 5f;
        leftBoundary = position.x + .5f;
        rightBoundary = position.x - .5f;
        occupied = false;
    }

    //create a new occupied board tile
    public BoardTile(Vector3 passed, GamePiece newPiece)
    {
        {
            occupied = true;
            pieceonTile = newPiece;
            pieceonTile.transform.position = position;
        }
    }

    public void LeavePosititon()
    {
        pieceonTile = null;
        occupied = false;
    }

    public void MoveToPosition(GamePiece incomingPiece)
    {
        pieceonTile = incomingPiece;
        occupied = true;
    }

    public bool MoveIsValid(GamePiece incomingPiece)
    {
        bool validMove = false;
        if (!occupied)
        {
            validMove = true;
        }
        else if(pieceonTile.playerColor != incomingPiece.playerColor)
        {
            validMove = true;
        }
        return validMove;
    }

    public bool CheckIfOnTile(Vector3 reference)
    {
        bool onTile = false;
        if ((reference.y < topBoundary)&&(reference.y> bottomBoundary)
            &&(reference.x > leftBoundary)&&reference.x < leftBoundary)
        {
            onTile = true;
        }
        return onTile;
    }





}