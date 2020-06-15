using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomHorizontalViewPager : PanelBase
{
    [SerializeField] private Image _image;
    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _prevButton;

    [SerializeField] private GameObject _indicatorPanel;
    [SerializeField] private GameObject _indicatorPrefab;
    [SerializeField] private Sprite _notSelectedIndicator;
    [SerializeField] private Sprite _selectedIndicator;

    [SerializeField] private List<Sprite> _imageList;
    [SerializeField] private List<Image> _indicatorImageList;


    private int _currentImageIndex = 0;


    private void Start()
    {
        _currentImageIndex = 0;
        CreateIndicatorList();
        ChangeState();
    }

    public void SetImageList(List<Sprite> _images)
    {
        _currentImageIndex = 0;
        this._imageList = _images;
        CreateIndicatorList();
        ChangeState();
    }

    private void SetMainImage()
    {
        if(_currentImageIndex >= 0 && _currentImageIndex < _imageList.Count)
        {
            _image.sprite = _imageList[_currentImageIndex];
        }
    }

    private void UpdateButtonGraphics()
    {
        _prevButton.interactable = true;
        _nextButton.interactable = true;

        if (_currentImageIndex <= 0)
        {
            _prevButton.interactable = false;
        }
        if (_currentImageIndex >= (_imageList.Count-1) )
        {
            _nextButton.interactable = false;
        }
    }

    private void ChangeState()
    {
        SetMainImage();
        UpdateButtonGraphics();
        SetIndicator();
    }

    public void OnClickPreviousButton()
    {
        _currentImageIndex = _currentImageIndex - 1;
        if(_currentImageIndex <= 0)
        {
            _currentImageIndex = 0;
        }
        ChangeState();
    }

    public void OnClickNextButton()
    {
        _currentImageIndex = _currentImageIndex + 1;
        if (_currentImageIndex >= (_imageList.Count -1))
        {
            _currentImageIndex = _imageList.Count -1;
        }
        ChangeState();
    }

    #region Indicator

    private void SetIndicator()
    {
        if (_indicatorImageList == null)
            return;

        for (int i = 0; i < _indicatorImageList.Count; i++)
        {
            if (i == _currentImageIndex)
                _indicatorImageList[i].sprite = _selectedIndicator;
            else
                _indicatorImageList[i].sprite = _notSelectedIndicator;
        }
    }

    private void CreateIndicatorList()
    {
        _indicatorImageList = new List<Image>();
        for (int i = 0; i < _imageList.Count; i++)
        {
            GameObject indicatorObj = Instantiate(_indicatorPrefab, _indicatorPanel.transform);
            indicatorObj.transform.parent = _indicatorPanel.transform;

            if (indicatorObj.GetComponent<Image>() != null)
                _indicatorImageList.Add(indicatorObj.GetComponent<Image>());
        }
    }

    #endregion Indicator

}
