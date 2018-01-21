using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    // ----------- Public variables ----------- //
    public Text[] textsRaw;
    public Dictionary<string, Text> texts;
    // ---------------------------------------- //

    private void Awake()
    {
        // The purpose of this loop allows for future addtions to text on the screen
        // For example, to access the Timer text in another script, just says texts["Timer"] and this returns the timer text gameobject
        texts = new Dictionary<string, Text>();

        for (int i = 0; i < textsRaw.Length; i++)
        {
            texts.Add(textsRaw[i].name, textsRaw[i]); // Adds every text in textsRaw to the dictionary texts (be sure to add the Text GameObject to the textsRaw array)
        }
    }

    // ----------- Empties the text ------------ //
    public void EmptyText(string name)
    {
        if (texts.ContainsKey(name))
            texts[name].text = "";
    }
    // ----------------------------------------- //

    // -------------- Updates a text --------------- //
    public void UpdateText(string name, string newText)
    {
        if (texts.ContainsKey(name))
            texts[name].text = newText;
    }
    // --------------------------------------------- //
}
