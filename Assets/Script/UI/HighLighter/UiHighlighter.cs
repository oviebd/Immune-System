using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Outline))]
public class UiHighlighter : MonoBehaviour,IHighLighter
{
    [SerializeField] private Image _imageForHighlight;
    [SerializeField] private Color _highlightedColor;
    [SerializeField] private Sprite _highlightedSprite;

    private bool _initialVal_IsComponentActive;
    private Color _initVal_ComponentColor;
    private Sprite _initVal_HighlightSprite;

    private Outline _outline;

    void Start()
    {
        _outline = this.gameObject.GetComponent<Outline>();
        if(_imageForHighlight == null)
            _imageForHighlight = this.gameObject.GetComponent<Image>();

        SetUpInitValues();
    }

    void SetUpInitValues()
    {
        if(_outline != null)
        {
            _outline.enabled = false;
        }
        
        if(_imageForHighlight != null)
        {
            _initialVal_IsComponentActive = _imageForHighlight.isActiveAndEnabled;
            _initVal_ComponentColor = _imageForHighlight.color;
            _initVal_HighlightSprite = _imageForHighlight.sprite;
        }

    }

    public void SetHighlightProperties(Sprite sprite, Color outLineColor)
    {
        _highlightedSprite = sprite;
        if(_outline!=null)
            _outline.effectColor = outLineColor;

    }

    public void ShowHighlight()
    {
        if (_outline != null && _highlightedColor != null)
        {
            _imageForHighlight.sprite = _highlightedSprite;
            _imageForHighlight.color = Color.white;
            _outline.enabled = true;
            _imageForHighlight.enabled = true;
        }
        
    }

    public void HideHighlight()
    {
        if (_outline != null && _highlightedColor != null)
        {
            _imageForHighlight.enabled = _initialVal_IsComponentActive;
            _outline.enabled = false;

            _imageForHighlight.sprite = _initVal_HighlightSprite;
            _imageForHighlight.color = _initVal_ComponentColor;
        }
    }
}
