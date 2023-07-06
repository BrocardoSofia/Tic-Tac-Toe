using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text[] buttonList;
    private string playerSide;

    public GameObject gameOverPanel;
    public Text gameOverText;

    private int moveCount; //to count the moves, so if it hits 9 it means that all the buttons are full

    public GameObject restartButton;

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

    public void resetGame()
    {
        gameOverPanel.SetActive(false);
        setGameControllerReferenceOnButtons();
        playerSide = "X";
        moveCount = 0;
        resetButtons();
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
            changePlayerSide();
        }
    }

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
    }

    void changePlayerSide()
    {
        if (playerSide == "X")
            playerSide = "O";
        else
            playerSide = "X";
    }
}
