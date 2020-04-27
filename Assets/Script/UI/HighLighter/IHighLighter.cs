using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHighLighter 
{
    void SetHighlightProperties(Sprite sprite, Color outLineColor);
    void ShowHighlight();
    void HideHighlight();
}
