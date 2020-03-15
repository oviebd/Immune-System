using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryController : MonoBehaviour {

	public static BoundaryController instance;

    [SerializeField] private Camera _mainCamera;

    [SerializeField] private GameObject _leftWall;
	[SerializeField] private GameObject _rightWall;
	[SerializeField] private GameObject _topWall;
	[SerializeField] private GameObject _bottomWall;


	void Awake()
	{
		if (instance == null)
			instance = this;
	}

    private void Start()
    {
       Invoke( "ResetBoundaryPositions",0.3f);
    }

    public  Vector2 GetLeftWallPosition()
	{
		return _leftWall.gameObject.transform.position;
	}
	public Vector2 GetRightWallPosition()
	{
		return _rightWall.gameObject.transform.position;
	}
	public Vector2 GetBottomWallPosition()
	{
		return _bottomWall.gameObject.transform.position;
	}
	public Vector2 GetTopWallPosition()
	{
		return _topWall.gameObject.transform.position;
	}

    void ResetBoundaryPositions()
    {
        float heightOffset = 0.5f; 
        
        Vector3 worldPosWidth = GetWidthInWorldSpace();
        Vector3 worldPosHeight = GetHeightInWorldPosition();


        _topWall.gameObject.transform.localScale  = new Vector2(worldPosWidth.x *2, _topWall.transform.localScale.y);
        _topWall.gameObject.transform.position    = new Vector3(_topWall.gameObject.transform.position.x, worldPosHeight.y, _topWall.gameObject.transform.position.z);


        Vector3 bottomPos = _bottomWall.transform.position;
        _bottomWall.transform.localScale = new Vector2(worldPosWidth.x * 2, _bottomWall.transform.localScale.y);
        _bottomWall.transform.position   = new Vector3(bottomPos.x, ( worldPosHeight.y * (-1)),bottomPos.z);

        Vector3 leftPos = _leftWall.transform.position;
        _leftWall.transform.localScale = new Vector2(_leftWall.transform.localScale.x, worldPosHeight.y*2);
        _leftWall.transform.position   = new Vector3(worldPosWidth.x * (-1) , leftPos.y,leftPos.z);

        Vector3 rightPos = _rightWall.transform.position;
        _rightWall.transform.localScale = new Vector2(_rightWall.transform.localScale.x, worldPosHeight.y * 2);
        _rightWall.transform.position   = new Vector3(worldPosWidth.x, rightPos.y,rightPos.z);

    }

    
    public Vector3 GetWidthInWorldSpace()
    {
        Vector2 widthVec = new Vector2(Screen.width, 0f);
        Vector3 worldPosWidth = _mainCamera.ScreenToWorldPoint(new Vector3(widthVec.x, widthVec.y, _mainCamera.nearClipPlane));

        return worldPosWidth;
    }

    public Vector3 GetHeightInWorldPosition()
    {
        Vector2 heightVec = new Vector2(0, Screen.height);
        Vector3 worldPosHeight = _mainCamera.ScreenToWorldPoint(new Vector3(heightVec.x, heightVec.y, _mainCamera.nearClipPlane));

        return worldPosHeight;
    }


}
