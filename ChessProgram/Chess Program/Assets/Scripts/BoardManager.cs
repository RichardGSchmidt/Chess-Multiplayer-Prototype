using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this object is represents the entire board
public class BoardManager : MonoBehaviour
{
    BoardGrid board;


    public BoardManager()
    {
        board = new BoardGrid();
    }

    public BoardManager(BoardGrid boardToBeLoaded)
    {
        board = boardToBeLoaded;
    }

    public void LayOutBoardForPlay(BoardGrid bord)
    {
        for (int x = 0; x < board.spot.GetLength(0); x++)
        {
            for (int y = 0; y < board.spot.GetLength(1); y++)
            {

            }
        }
    }

    public void ClearBoardofPieces()
    {

    }

    public void PlacePiece()
    {

    }

    public void RemovePiece()
    {

    }

}



//Object Container for the entire board and it's layout
//serialized in order to save it's state to a file.

[System.Serializable]
public class BoardGrid {

    public enum PlayerTurn { White, Black }
    PlayerTurn playerTurn = PlayerTurn.White;
    public BoardTile[,]spot = new BoardTile[8,8];  //spot will be the actual tile you are refering to.

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
//serialized to be able to save this data to file
[System.Serializable]
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