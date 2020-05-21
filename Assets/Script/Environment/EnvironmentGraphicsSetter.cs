using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGraphicsSetter : MonoBehaviour
{
    public static EnvironmentGraphicsSetter instance;

	[SerializeField] private PlaySound _playSound;
	[SerializeField] private GameObject _backgroundParent;

	private GameObject _currentBackground;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void SetBackground( int levelNum)
    {
		GameEnvironmentDataModel environmentData = GameEnvironmentDataHandler.instance.GetEnvironmentData(levelNum);

		if (_playSound != null && environmentData.audioClip != null)
			_playSound.PlayAudioWithClip(environmentData.audioClip);

		SetBackgroundImage(environmentData);
    }

	private void SetBackgroundImage(GameEnvironmentDataModel environmentData)
	{
		if (_backgroundParent != null && environmentData.backgroundImage != null)
		{
			GameObject[] backgrounds = GameObject.FindGameObjectsWithTag(GameEnum.GameTags.Background.ToString());
			foreach (GameObject background in backgrounds)
			{
				Destroy(background);
			}
			InstantiatorHelper.instance.InstantiateObject(environmentData.backgroundImage);
		}
	}
}
