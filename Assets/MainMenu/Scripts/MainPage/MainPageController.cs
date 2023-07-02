using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPageController : MonoBehaviour
{
    private GameObject newGameButton;
    private GameObject continueButton;
    private GameObject optionsButton;
    private GameObject profileButton;
    private GameObject quitButton;


    void Start()
    {
        newGameButton = GameObject.Find("New Game");
        continueButton = GameObject.Find("Continue");
        optionsButton = GameObject.Find("Option");
        profileButton = GameObject.Find("Profile");
        quitButton = GameObject.Find("Quit");
    }

    public void newGameButtonOnClick() {
        if (newGameButton != null) {
            //start new game
            Debug.Log("Start New Game");
        }
    }

    public void continueButtonOnClick() {
        if (newGameButton != null) {
            //continue game
            Debug.Log("Continue Game");
        }
    }

    public void profileButtonOnClick() {
        if (profileButton != null) {
            //go to profile page
            Debug.Log("Go to profile");
        }
    }

    public void optionsButtonOnClick() {
        if (optionsButton != null) {
            //open options
            Debug.Log("Go to options");
        }
    }

    public void quitButtonOnClick() {
        if (quitButton != null) {
            //quit from the game
            Debug.Log("Quit from the game");
        }
    }
}
