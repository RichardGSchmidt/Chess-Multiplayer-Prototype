using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this object is represents the entire board
public class BoardManager : MonoBehaviour
{
    BoardGrid board;
    public GamePiece[] gamePieces;


    public void Start()
    {
        board = new BoardGrid();
        LayOutBoardForPlay();

        
    }

    public void LoadBoard(BoardGrid boardToBeLoaded)
    {
        board = boardToBeLoaded;
    }

    public void LayOutBoardForPlay()
    {
        for (int x = 0; x < board.spot.GetLength(0); x++)
        {
            for (int y = 0; y < board.spot.GetLength(1); y++)
            {
                if (y == 1)
                {
                    GamePiece toInstantiate = gamePieces[9];
                    board.spot[x,y].MoveToPosition((Instantiate(toInstantiate, board.spot[x, y].position, Quaternion.identity)));
                }
                else if(y==6)
                {
                    GamePiece toInstantiate = gamePieces[3];
                    board.spot[x, y].MoveToPosition((Instantiate(toInstantiate, board.spot[x, y].position, Quaternion.identity)));
                }
                if ((x == 0 && y == 0) ||(x==7&&y==0))
                {
                    GamePiece toInstantiate = gamePieces[11];
                    board.spot[x, y].MoveToPosition((Instantiate(toInstantiate, board.spot[x, y].position, Quaternion.identity)));
                }
                if ((x == 0 && y == 7) || (x == 7 && y == 7))
                {
                    GamePiece toInstantiate = gamePieces[5];
                    board.spot[x, y].MoveToPosition((Instantiate(toInstantiate, board.spot[x, y].position, Quaternion.identity)));
                }
                if ((x == 1 && y == 0) || (x == 6 && y == 0))
                {
                    GamePiece toInstantiate = gamePieces[8];
                    board.spot[x, y].MoveToPosition((Instantiate(toInstantiate, board.spot[x, y].position, Quaternion.identity)));
                }
                if ((x == 1 && y == 7) || (x == 6 && y == 7))
                {
                    GamePiece toInstantiate = gamePieces[2];
                    board.spot[x, y].MoveToPosition((Instantiate(toInstantiate, board.spot[x, y].position, Quaternion.identity)));
                }
                if ((x == 2 && y == 0) || (x == 5 && y == 0))
                {
                    GamePiece toInstantiate = gamePieces[6];
                    board.spot[x, y].MoveToPosition((Instantiate(toInstantiate, board.spot[x, y].position, Quaternion.identity)));
                }
                if ((x == 2 && y == 7) || (x == 5 && y == 7))
                {
                    GamePiece toInstantiate = gamePieces[0];
                    board.spot[x, y].MoveToPosition((Instantiate(toInstantiate, board.spot[x, y].position, Quaternion.identity)));
                }
                if (x == 3 && y == 7)
                {
                    GamePiece toInstantiate = gamePieces[4];
                    board.spot[x, y].MoveToPosition((Instantiate(toInstantiate, board.spot[x, y].position, Quaternion.identity)));
                }
                if (x == 3 && y == 0)
                {
                    GamePiece toInstantiate = gamePieces[10];
                    board.spot[x, y].MoveToPosition((Instantiate(toInstantiate, board.spot[x, y].position, Quaternion.identity)));
                }
                if (x==4 && y ==0)
                {
                    GamePiece toInstantiate = gamePieces[7];
                    board.spot[x, y].MoveToPosition((Instantiate(toInstantiate, board.spot[x, y].position, Quaternion.identity)));
                }
                if (x==4 && y == 7)
                {
                    GamePiece toInstantiate = gamePieces[1];
                    board.spot[x, y].MoveToPosition((Instantiate(toInstantiate, board.spot[x, y].position, Quaternion.identity)));
                }
                if(board.spot[x,y].pieceonTile != null)
                {
                    board.spot[x, y].pieceonTile.transform.SetParent(GameObject.FindGameObjectWithTag("Board").transform);
                }
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

public class BoardGrid {

    public enum PlayerTurn { White, Black }
    PlayerTurn playerTurn = PlayerTurn.White;
    public BoardTile[,] spot = new BoardTile[8, 8];

    public BoardGrid()
    {
        spot = new BoardTile[8,8];
        //filling the transformGrid array
        for (int x = 0; x < spot.GetLength(0); x++)
        {
            for (int y = 0; y < spot.GetLength(1); y++)
            {
                spot[x, y] = new BoardTile(new Vector3(-3.5f+x, -3.5f+y, 0));
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