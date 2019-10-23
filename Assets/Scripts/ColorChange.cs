using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChange : MonoBehaviour {

    public Text[] colorText;

    public DifficultyController mainDifficultyController;
    public ColorPalleteManager mainColorPalleteManager;

    void RevertColorChange()
    {
        mainDifficultyController.RevertColorChange();
    }

    void SelectColors()
    {
        Color[] _colors = mainColorPalleteManager.getAvaliableColors();
        for(int i=0; i<mainColorPalleteManager.numberOfAvaliableColors; i++)
        {
            colorText[i].color = _colors[i];
        }

        _colors = null;
    }

}
