using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPalleteManager : MonoBehaviour {

    public int numberOfAvaliableColors;
    public int numberOfDifferentColors;
    public float minHue;
    public float maxHue;
    public float minSat;
    public float maxSat;
    public float minValue;
    public float maxValue;


    Color[] colorPallete;

    [SerializeField]
    Color[] avaliableColorPallete;

    void Start () {

        colorPallete = new Color[numberOfDifferentColors];
        avaliableColorPallete = new Color[numberOfAvaliableColors];

        InitColorPlatte();
        TriadricColors();

    }

    void InitColorPlatte() {
        int _colorGap = 360 / numberOfDifferentColors;
        int _randomColorPoint = Random.Range(0, 360);

        for (int i = 0; i < numberOfDifferentColors; i++)
        {
            _randomColorPoint = CalculateColorPointForTriadriColors(_randomColorPoint, _colorGap);
            float _colorRangeValue = ConvertToColorRange(_randomColorPoint);
            colorPallete[i] = Random.ColorHSV(_colorRangeValue, _colorRangeValue, 0.5f, 0.5f, 0.7f, 0.7f);
        }
    }

    void TriadricColors()
    {
        int _gap = numberOfDifferentColors / numberOfAvaliableColors;//Both have to be Odd
        int _randomStartPoint = Random.Range(0, numberOfDifferentColors);

        for (int i = 0; i < numberOfAvaliableColors; i++)
        {
            avaliableColorPallete[i] = colorPallete[_randomStartPoint];
            _randomStartPoint += _gap;
            if(_randomStartPoint > numberOfDifferentColors - 1)
            {
                int diff = _randomStartPoint - (numberOfDifferentColors - 1);
                _randomStartPoint = diff;
            }
        }
    }

    float ConvertToColorRange(int value)
    {
        float result = 0.0f;

        result = (1.0f / 360.0f) * (float)value;

        return result;
    }

    int CalculateColorPointForTriadriColors(int point, int gap)
    {
        int result = 0;

        if(point + gap > 360)
        {
            int diff = 360 - point;
            result = 0 + diff;
        }
        else
        {
            result = point + gap;
        }

        return result;
    }

    
    public Color GetRandomColor()
    {
        return avaliableColorPallete[Random.Range(0, numberOfAvaliableColors)];
    }

    public void ChangeColors()
    {
        TriadricColors();
    }

    public Color[] getAvaliableColors()
    {
        return avaliableColorPallete;
    }
}
