using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    //variables
    public Button button;
    public string playerSide;

    /**
     * Set the text and disable the button
    */
    public void setSpace()
    {
        buttonText.GetComponentInChildren<Text>().text = playerSide; //change the text in the button
        button.interactable = false; //disable the button
    }

}
