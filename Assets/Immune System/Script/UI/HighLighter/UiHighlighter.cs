using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Outline))]
public class UiHighlighter : MonoBehaviour,IHighLighter
{
    [SerializeField] private Image _mainImage;
    [SerializeField] private Color _highlightedColor;
    [SerializeField] private Sprite _highlightedSprite;

    private bool _initialVal_IsComponentActive;
    private Color _initVal_ComponentColor;
    private Sprite _initVal_HighlightSprite;

    private Outline _outline;

    void Awake()
    {
        SetUpInitValues();
    }

	Outline GetOutline()
	{
		if(_outline == null)
			_outline = this.gameObject.GetComponent<Outline>();
		return _outline;
	}

	Image GetMainImage()
	{
		if(_mainImage == null)
			_mainImage = this.gameObject.GetComponent<Image>();
		return _mainImage;
	}
    void SetUpInitValues()
    {
        if(GetOutline() != null)
        {
			GetOutline().enabled = false;
        }
        
        if(GetMainImage() != null)
        {
            _initialVal_IsComponentActive = GetMainImage().isActiveAndEnabled;
            _initVal_ComponentColor = GetMainImage().color;
            _initVal_HighlightSprite = GetMainImage().sprite;
        }

    }

	public void SetHighlightColor(Color outLineColor)
	{
		_highlightedColor = outLineColor;
	}
	public void SetHighlightSprite(Sprite sprite)
	{
		_highlightedSprite = sprite;
	}

    public void ShowHighlight()
    {
        if (GetOutline() != null && _highlightedColor != null)
        {
			GetOutline().effectColor = _highlightedColor;
			GetMainImage().sprite = _highlightedSprite;
			GetMainImage().color = Color.white;

			GetOutline().enabled = true;
            GetMainImage().enabled = true;
        }
        
    }

    public void HideHighlight()
    {
        if (GetOutline() != null && _highlightedColor != null)
        {
            GetMainImage().enabled = _initialVal_IsComponentActive;
            GetOutline().enabled = false;

            GetMainImage().sprite = _initVal_HighlightSprite;
            GetMainImage().color = _initVal_ComponentColor;
        }
    }
}
