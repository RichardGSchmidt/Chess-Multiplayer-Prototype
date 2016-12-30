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


public class BoardTiles {

    Vector3[,]transformGrid = new Vector3[8,8];

    void Start()
    {
        //filling the transformGrid array
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                transformGrid[x, y] = new Vector3(-3.5f+x, -3.5f+y, 0);
            }
        }
    }

    public bool CheckIfOnMap(Vector3 reference)
    {
        //checks to make sure it's inside the coordinate system of the board.
        if ((reference.x < -4f || reference.y < -4f) || (reference.x > 4 || reference.y > 4))
        {
            return false;
        }
        else return true;
    }
    

    

}

public class TilePresets
{
    public Vector3 position;
    private float topBoundary;
    private float bottomBoundary;
    private float leftBoundary;
    private float rightBoundary;
    public TilePresets[,] tilePresets;

    public TilePresets(Vector3 passed)
    {
        position = passed;
        topBoundary = position.y + .5f;
        bottomBoundary = position.y - 5f;
        leftBoundary = position.x + .5f;
        rightBoundary = position.x - .5f;
    }

    public bool isInBoundarys(Vector3 reference)
    {
        bool bowl = false;
        if ((reference.y < topBoundary)&&(reference.y> bottomBoundary)
            &&(reference.x > leftBoundary)&&reference.x < leftBoundary)
        {
            bowl = true;
        }
        return bowl;
    }





}