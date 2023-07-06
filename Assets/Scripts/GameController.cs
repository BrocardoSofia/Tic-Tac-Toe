using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player
{
    public Image panel;
    public Text text;
}

[System.Serializable]
public class PlayerColor
{
    public Color panelColor;
    public Color textColor;
}

public class GameController : MonoBehaviour
{
    public Text[] buttonList;
    private string playerSide;

    public GameObject gameOverPanel;
    public Text gameOverText;

    private int moveCount; //to count the moves, so if it hits 9 it means that all the buttons are full

    public GameObject restartButton;

    //the visual of the player side
    public Player playerX;
    public Player playerO;
    public PlayerColor inactivePlayerColor;
    public PlayerColor activePlayerColor;

    void Awake()
    {
        resetGame();
    }

    void setGameControllerReferenceOnButtons()
    {
        for(int i=0; i<buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().setGameControllerReference(this);
        }
    }

    //reset the game components
    public void resetGame()
    {
        gameOverPanel.SetActive(false);
        setGameControllerReferenceOnButtons();
        playerSide = "X";//start player side
        moveCount = 0;//no moves made
        resetButtons();//reset all the buttons for the game
        restartButton.SetActive(false);//deactivate the restart button
    }

    private void resetButtons()
    {
        //disable all the buttons
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = true;
            buttonList[i].text = "";
        }
    }

    public string getPlayerSide()
    {
        return playerSide;
    }

    public void endTurn()
    {
        moveCount++;

        //evaluate if the game continues or ended on a win or a draw
        if ((buttonList[0].text == playerSide) && (buttonList[1].text == playerSide) && (buttonList[2].text == playerSide))
        {
            //if the top row equals the player side
            gameOver(playerSide + " Wins!");
        }
        else if((buttonList[3].text == playerSide) && (buttonList[4].text == playerSide) && (buttonList[5].text == playerSide))
        {
            //if the second row equals the player side
            gameOver(playerSide + " Wins!");
        }
        else if ((buttonList[6].text == playerSide) && (buttonList[7].text == playerSide) && (buttonList[8].text == playerSide))
        {
            //if the third row equals the player side
            gameOver(playerSide + " Wins!");
        }
        else if ((buttonList[0].text == playerSide) && (buttonList[3].text == playerSide) && (buttonList[6].text == playerSide))
        {
            //if the first column equals the player side
            gameOver(playerSide + " Wins!");
        }
        else if ((buttonList[1].text == playerSide) && (buttonList[4].text == playerSide) && (buttonList[7].text == playerSide))
        {
            //if the second column equals the player side
            gameOver(playerSide + " Wins!");
        }
        else if ((buttonList[2].text == playerSide) && (buttonList[5].text == playerSide) && (buttonList[8].text == playerSide))
        {
            //if the third column equals the player side
            gameOver(playerSide + " Wins!");
        }
        else if ((buttonList[0].text == playerSide) && (buttonList[4].text == playerSide) && (buttonList[8].text == playerSide))
        {
            //if the diagonal column equals the player side
            gameOver(playerSide + " Wins!");
        }
        else if ((buttonList[6].text == playerSide) && (buttonList[4].text == playerSide) && (buttonList[2].text == playerSide))
        {
            //if the diagonal column equals the player side
            gameOver(playerSide + " Wins!");
        }
        else if(moveCount >= 9)
        {
            gameOver("It's a draw!");
        }
        else
        {
            changePlayerSide();//the game continues
        }
    }

    //game over function
    //this function can be call if a player wins or it's a draw
    void gameOver(string gameOverString)
    {
        //disable all the buttons
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }

        //display the WIN panel
        gameOverPanel.SetActive(true);
        gameOverText.text = gameOverString;

        //the restart button appears
        restartButton.SetActive(true);
    }

    //changes the player side on the board
    void changePlayerSide()
    {
        if (playerSide == "X")
            playerSide = "O";
        else
            playerSide = "X";
    }
}
