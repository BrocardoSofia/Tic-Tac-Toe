using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text[] buttonList;

    void Awake()
    {
        setGameControllerReferenceOnButtons();
    }

    void setGameControllerReferenceOnButtons()
    {
        for(int i=0; i<buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().setGameControllerReference(this);
        }
    }

    public string getPlayerSide()
    {
        return "?";
    }

    public void endTurn()
    {
        Debug.Log("EndTurn is not implemented!");
    }
}
