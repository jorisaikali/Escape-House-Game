using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    // Gets the float value on a given axis "axisName"
    public float getPlayerAxis(string axisName)
    {
        return Input.GetAxis(axisName);
    }

    // Returns true if the key "key" is pressed, otherwise false
    public bool getPlayerKeyDown(string key)
    {
        if (Input.GetKeyDown(key))
        {
            return true;
        }

        return false;
    }

    // Returns true if the button "button" is pressed, otherwise false
    public bool getPlayerButtonDown(string button)
    {
        if (Input.GetButtonDown(button))
        {
            return true;
        }

        return false;
    }
	
}
