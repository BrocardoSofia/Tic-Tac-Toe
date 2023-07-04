using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    //variables
    public Button button;
    public Text buttonText;

    private GameController gameController;

    /**
     * Set the text and disable the button
    */
    public void setSpace()
    {
        buttonText.text = gameController.getPlayerSide(); //change the text in the button
        button.interactable = false; //disable the button
        gameController.endTurn();
    }

    public void setGameControllerReference(GameController controller)
    {
        gameController = controller;
    }

}
