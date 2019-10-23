using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorEffectForWall : MonoBehaviour {

    public Image leftWall;
    public Image rightWall;

	void Start () {
        SetColors();
	}

    void SetColors()
    {
        int _randomStartPoint = Random.Range(0, 360);
        int _oppPoint = _randomStartPoint + 180;

        if(_oppPoint > 360)
        {
            int diff = 360 - _oppPoint;
            _oppPoint = 0 + diff;
        }
        else
        {
            _oppPoint = _randomStartPoint + 180;
        }

        float _leftColorPoint = (1.0f / 360.0f) * (float)_randomStartPoint;
        float _rightColorPoint = (1.0f / 360.0f) * (float)_oppPoint;

        leftWall.color = Random.ColorHSV(_leftColorPoint, _leftColorPoint, 0.5f, 0.5f, 0.7f, 0.7f);
        rightWall.color = Random.ColorHSV(_rightColorPoint, _rightColorPoint, 0.5f, 0.5f, 0.7f, 0.7f);
    }

}
