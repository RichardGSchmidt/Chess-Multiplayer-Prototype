using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public Texture backgroundTexture;


    void OnGUI()
    {
        //Display background texture
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);


        //Buttons n stuff
        if (GUI.Button(new Rect(Screen.width * .25f, Screen.height * .40f, Screen.width * .5f, Screen.height * .1f), "Start Hotseat Game."))
        {
            //Start New Game
            SceneManager.LoadScene("Hotseat");
        }
        //nest the load Game button inside an if statement here that determines whether saves exist, if not grey out
        if (GUI.Button(new Rect(Screen.width * .25f, Screen.height * .55f, Screen.width * .5f, Screen.height * .1f), "Play Online"))
        {
            SceneManager.LoadScene("PhotonChess");
        }

        if (GUI.Button(new Rect(Screen.width * .25f, Screen.height * .70f, Screen.width * .5f, Screen.height * .1f), "Load From Save(OOC)"))
        {
            /*///Load file scripting here.*/
        }

        if (GUI.Button(new Rect(Screen.width * .25f, Screen.height * .85f, Screen.width * .5f, Screen.height * .1f), "Exit"))
        {
            //Exit the game
            Application.Quit();
        }
    }




}