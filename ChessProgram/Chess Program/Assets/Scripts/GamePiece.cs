using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    public bool selected = false;
    public GameManager gameManager;
    public void Start()
    {
        gameManager = GameObject.FindWithTag("Board").GetComponent<GameManager>();
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

}
