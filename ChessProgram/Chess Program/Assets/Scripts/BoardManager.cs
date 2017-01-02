using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this object is represents the entire board
public class BoardManager : MonoBehaviour
{
    public BoardGrid board;
    public GamePiece[] gamePieces;
    public bool selectionStatus;



    public void Start()
    {
        board = new BoardGrid();
        LayOutBoardForPlay();
        selectionStatus = false;
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
                    board.spot[x,y].SetPiece((Instantiate(toInstantiate, board.spot[x, y].position, Quaternion.identity)));
                }
                else if(y==6)
                {
                    GamePiece toInstantiate = gamePieces[3];
                    board.spot[x, y].SetPiece((Instantiate(toInstantiate, board.spot[x, y].position, Quaternion.identity)));
                }
                if ((x == 0 && y == 0) ||(x==7&&y==0))
                {
                    GamePiece toInstantiate = gamePieces[11];
                    board.spot[x, y].SetPiece((Instantiate(toInstantiate, board.spot[x, y].position, Quaternion.identity)));
                }
                if ((x == 0 && y == 7) || (x == 7 && y == 7))
                {
                    GamePiece toInstantiate = gamePieces[5];
                    board.spot[x, y].SetPiece((Instantiate(toInstantiate, board.spot[x, y].position, Quaternion.identity)));
                }
                if ((x == 1 && y == 0) || (x == 6 && y == 0))
                {
                    GamePiece toInstantiate = gamePieces[8];
                    board.spot[x, y].SetPiece((Instantiate(toInstantiate, board.spot[x, y].position, Quaternion.identity)));
                }
                if ((x == 1 && y == 7) || (x == 6 && y == 7))
                {
                    GamePiece toInstantiate = gamePieces[2];
                    board.spot[x, y].SetPiece((Instantiate(toInstantiate, board.spot[x, y].position, Quaternion.identity)));
                }
                if ((x == 2 && y == 0) || (x == 5 && y == 0))
                {
                    GamePiece toInstantiate = gamePieces[6];
                    board.spot[x, y].SetPiece((Instantiate(toInstantiate, board.spot[x, y].position, Quaternion.identity)));
                }
                if ((x == 2 && y == 7) || (x == 5 && y == 7))
                {
                    GamePiece toInstantiate = gamePieces[0];
                    board.spot[x, y].SetPiece((Instantiate(toInstantiate, board.spot[x, y].position, Quaternion.identity)));
                }
                if (x == 3 && y == 7)
                {
                    GamePiece toInstantiate = gamePieces[4];
                    board.spot[x, y].SetPiece((Instantiate(toInstantiate, board.spot[x, y].position, Quaternion.identity)));
                }
                if (x == 3 && y == 0)
                {
                    GamePiece toInstantiate = gamePieces[10];
                    board.spot[x, y].SetPiece((Instantiate(toInstantiate, board.spot[x, y].position, Quaternion.identity)));
                }
                if (x==4 && y ==0)
                {
                    GamePiece toInstantiate = gamePieces[7];
                    board.spot[x, y].SetPiece((Instantiate(toInstantiate, board.spot[x, y].position, Quaternion.identity)));
                }
                if (x==4 && y == 7)
                {
                    GamePiece toInstantiate = gamePieces[1];
                    board.spot[x, y].SetPiece((Instantiate(toInstantiate, board.spot[x, y].position, Quaternion.identity)));
                }
                if(board.spot[x,y].pieceonTile != null)
                {
                    board.spot[x, y].pieceonTile.transform.SetParent(GameObject.FindGameObjectWithTag("Board").transform);
                }
            }
        }
    }

    //logic for checking if a move is valid
    public bool MoveIsValid (GamePiece piece, int xLoc, int yLoc)
    {

        if (piece.movementMap.TotalMovementAxis.diagonals)
        {            
            // piece being moved has x, y location
            // with movement providing an x,y offset.
            // Therefor if ratio of the difference is 
            // the absolute value of one the path is on
            // a diagonal. and the rest of this script aplies

            if((piece.location.y-yLoc!=0)&&((Mathf.Abs((piece.location.x - xLoc)/(piece.location.y-yLoc))) == 1))
            {
                piece.boxCollider.enabled = false;
                RaycastHit2D hit = Physics2D.Raycast(piece.transform.position, board.spot[xLoc,yLoc].position, 20, 8);
                piece.boxCollider.enabled = true;
                if (hit.collider == null)
                {
                    return true;
                }
            }
            
        }

        if (piece.movementMap.TotalMovementAxis.xyAxis)
        {
            if (piece.location.y == yLoc || piece.location.x == xLoc)
            {
                piece.boxCollider.enabled = false;
                RaycastHit2D hit = Physics2D.Raycast(piece.transform.position, board.spot[xLoc, yLoc].position, 20, 8);
                piece.boxCollider.enabled = true;
                if (hit.collider == null)
                {
                    return true;
                }
            }
        }

        if (piece.movementMap.CanMoveIfEmpty.Length > 0)
        {
            for (int i = 0; i < piece.movementMap.CanMoveIfEmpty.Length; i++)
            {
                if ((piece.movementMap.CanMoveIfEmpty[i].x == xLoc - piece.location.x)&& (piece.movementMap.CanMoveIfEmpty[i].y == yLoc - piece.location.y))
                {
                    return true;
                }
            }
        }

        if ((piece.firstmove)&&(piece.firstmove&&piece.movementMap.CanMoveIfFirstMoveAndClear.Length > 0))
        {
            
             for (int i = 0; i < piece.movementMap.CanMoveIfFirstMoveAndClear.Length; i++)
             {
                if ((piece.movementMap.CanMoveIfFirstMoveAndClear[i].x == xLoc - piece.location.x) && (piece.movementMap.CanMoveIfFirstMoveAndClear[i].y == yLoc - piece.location.y))
                {
                    piece.boxCollider.enabled = false;
                    RaycastHit2D hit = Physics2D.Raycast(piece.transform.position, board.spot[xLoc,yLoc].position, 20, 8);
                    piece.boxCollider.enabled = true;
                    if (hit.collider == null)
                    
                    {         
                        return true;
                    }
                
                }
             }
        }

        return false;

    }

    //logic for checking validity of an attack
    public bool AttackIsValid(GamePiece pieceToBeMoved, GamePiece pieceOnTile)
    {
        pieceToBeMoved.boxCollider.enabled = false;
        pieceOnTile.boxCollider.enabled = false;
        if (pieceToBeMoved.movementMap.TotalMovementAxis.diagonals)
        {
            // piece being moved has x, y location
            // with movement providing an x,y offset.
            // Therefor if ratio of the difference is 
            // the absolute value of one the path is on
            // a diagonal. first part is divide by zero
            // prevention.

            if ((pieceToBeMoved.location.y!=pieceOnTile.location.y)&&(Mathf.Abs((pieceToBeMoved.location.x - pieceOnTile.location.x) / (pieceToBeMoved.location.y - pieceOnTile.location.y)) == 1))
            {
                RaycastHit2D hit = Physics2D.Raycast(pieceToBeMoved.transform.position, pieceOnTile.transform.position, 20, 8);
                if (hit.collider == null)
                {
                    pieceToBeMoved.boxCollider.enabled = true;
                    pieceOnTile.boxCollider.enabled = true;
                    return true;
                }
            }

        }

        if (pieceToBeMoved.movementMap.TotalMovementAxis.xyAxis)
        {
            if (pieceToBeMoved.location.y == pieceOnTile.location.y || pieceToBeMoved.location.x == pieceOnTile.location.x)
            {
                RaycastHit2D hit = Physics2D.Raycast(pieceToBeMoved.transform.position, pieceOnTile.transform.position, 20, 8);
                if (hit.collider == null)
                {
                    pieceToBeMoved.boxCollider.enabled = true;
                    pieceOnTile.boxCollider.enabled = true;
                    return true;
                }
            }
        }

        if (pieceToBeMoved.movementMap.CanMoveIfEmpty.Length > 0)
        {
            for (int i = 0; i < pieceToBeMoved.movementMap.CanMoveIfEmpty.Length; i++)
            {
                if ((pieceToBeMoved.movementMap.CanMoveIfEmpty[i].x == pieceOnTile.location.x - pieceToBeMoved.location.x) && (pieceToBeMoved.movementMap.CanMoveIfEmpty[i].y == pieceOnTile.location.y - pieceToBeMoved.location.y))
                {
                    pieceToBeMoved.boxCollider.enabled = true;
                    pieceOnTile.boxCollider.enabled = true;
                    return true;
                }
            }
        }

        if (pieceToBeMoved.movementMap.CanMoveIfEnemy.Length > 0)
        {
            if (pieceToBeMoved.movementMap.CanMoveIfEnemy.Length > 0)
            {
                for (int i = 0; i < pieceToBeMoved.movementMap.CanMoveIfEnemy.Length; i++)
                {
                    if ((pieceToBeMoved.movementMap.CanMoveIfEnemy[i].x == pieceOnTile.location.x - pieceToBeMoved.location.x) && (pieceToBeMoved.movementMap.CanMoveIfEnemy[i].y == pieceOnTile.location.y - pieceToBeMoved.location.y))
                    {
                        pieceToBeMoved.boxCollider.enabled = true;
                        pieceOnTile.boxCollider.enabled = true;
                        return true;
                    }
                }
            }
        }
        pieceToBeMoved.boxCollider.enabled = true;
        pieceOnTile.boxCollider.enabled = true;
        return false;

    }

    //clears spot if filled and moves to
    public void MoveTo(GamePiece pieceToBeMoved, IntVector2 refToMoveTo)
    {
        if (pieceToBeMoved.firstmove) pieceToBeMoved.firstmove = false;
        if (board.spot[refToMoveTo.x,refToMoveTo.y].pieceonTile!=null)
        {
            board.spot[refToMoveTo.x, refToMoveTo.y].pieceonTile.DestroySelf();
        }
        board.spot[refToMoveTo.x, refToMoveTo.y].SetPiece(pieceToBeMoved);

    }

    public void ClearBoardofPieces()
    {

    }

    public void PlacePiece()
    {

    }


}



//Object Container for the entire board and it's layout
//serialized in order to save it's state to a file.

public class BoardGrid {

    public BoardTile[,] spot = new BoardTile[8, 8];

    public BoardGrid()
    {
        spot = new BoardTile[8,8];
        //filling the transformGrid array
        for (int x = 0; x < spot.GetLength(0); x++)
        {
            for (int y = 0; y < spot.GetLength(1); y++)
            {
                IntVector2 gridReference = new IntVector2();
                gridReference.x = x;
                gridReference.y = y;
                spot[x, y] = new BoardTile(new Vector3(-3.5f+x, -3.5f+y, 0),gridReference);
            }
        }
    }

    public bool OnGameBoard(Vector3 reference)
    {
        //checks to make sure it's inside the coordinate system of the board.
        if ((reference.x < -4f || reference.y < -4f) || (reference.x > 4 || reference.y > 4))
        {
            return false;
        }
        else return true;
    }

    public IntVector2 GetGridReference(Vector3 rawInput)
    {
        IntVector2 referenceVector = new IntVector2();
        //casting to int automatically truncates in C#
        referenceVector.x = (int)(rawInput.x + 4);
        referenceVector.y = (int)(rawInput.y + 4);
        return referenceVector;

    }
    

    

}

//object container for an actual tile piece

public class BoardTile
{
    public GamePiece pieceonTile;
    public Vector3 position;
    public bool occupied;
    public IntVector2 gridReference;
    private float topBoundary;
    private float bottomBoundary;
    private float leftBoundary;
    private float rightBoundary;
    

    //create a new empty board tile
    public BoardTile(Vector3 passed, IntVector2 refNumbers)
    {
        position = passed;
        topBoundary = position.y + .5f;
        bottomBoundary = position.y - 5f;
        leftBoundary = position.x + .5f;
        rightBoundary = position.x - .5f;
        gridReference = refNumbers;
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

    //called before move on original object
    public void LeavePosititon()
    {
        pieceonTile = null;
        occupied = false;
    }

    public bool MoveIsValid(GamePiece incomingPiece)
    {
        bool validMove = false;
        if (!occupied)
        {
            validMove = true;
        }
        else if(pieceonTile.color != incomingPiece.color)
        {
            validMove = true;
        }
        return validMove;
    }

    public void SetPiece(GamePiece pieceSent)
    {
        if (pieceSent.ownerTile != null)
        {
            pieceSent.ownerTile.LeavePosititon();
        }
        pieceSent.location = gridReference;
        pieceSent.transform.position = position;
        pieceSent.ownerTile = this;
        occupied = true;
        pieceonTile = pieceSent;
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