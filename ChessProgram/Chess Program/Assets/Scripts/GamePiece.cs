using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    public Renderer rend;
    public bool selected = false;
    public GameManager gameManager;
    public void Start()
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


