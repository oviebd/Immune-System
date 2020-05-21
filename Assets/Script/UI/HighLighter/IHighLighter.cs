using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHighLighter 
{
	void SetHighlightSprite(Sprite sprite);
	void SetHighlightColor(Color color);
	void ShowHighlight();
    void HideHighlight();
}
