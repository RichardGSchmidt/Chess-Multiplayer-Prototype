using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private GamePiece selected = null;
    private BoardManager boardManager;
    private bool selectionStatus;
    private bool turn;

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

    public bool GetTurn()
    {
        return turn;
    }


    private void Start()
    {
        boardManager = FindObjectOfType<BoardManager>();
        turn = true;
    }
    

    private void OnGUI()
    {
        GUI.Box(new Rect(Screen.height * .01f, Screen.width * .01f, Screen.width * .15f, Screen.height * .1f), "Turn: " + WhosTurn());
    }

    public void Update()
    {
    }

    public bool RequestMove(GamePiece piece, IntVector2 location, bool player)
    {
        if (player == turn)
        {
            //if space occupied check attack
            //execute and return if true
            return true;
            //if space not check move
        }

        else return false;
    }
  }
    