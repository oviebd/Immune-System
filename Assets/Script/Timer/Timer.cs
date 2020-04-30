using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _time;

    private ITimer _iTimer;
    private float _startTime;
    private bool _isTimerOn = false;
    private float _pauseStartTime;
    private float _totalPauseTime;


    #region Public APi
    public void StartTimer(float time)
    {
        this._time = time;
        _isTimerOn = true;
        ResetTimer();
    }

    public void PauseTimer()
    {
        _isTimerOn = false;
        _pauseStartTime = Time.time;
    }

    public void ResumeTimer()
    {
        _totalPauseTime = Time.time - _pauseStartTime;
        _isTimerOn = true;

    }

    #endregion Public APi


    private void ResetTimer()
    {
        _startTime = Time.time;
        _totalPauseTime = 0.0f;
    }

    private void Update()
    {
        //Debug.Log(GetElapsedTime());
        if( GetElapsedTime() >= _time && _isTimerOn == true)
        {
            OnTimerComplete();
        }
    }
    private float GetElapsedTime()
    {
        return Mathf.Abs(Time.time - _startTime - _totalPauseTime) ;
       
    }

   
    private void OnTimerComplete()
    {
        //Debug.Log("Timer complete : Time : " + GetElapsedTime());
       
        if ( GetTimer() != null)
        {
            GetTimer().OnTimeCompleted();
        }

        ResetTimer();
    }

    private ITimer GetTimer()
    {
        if (_iTimer == null)
            _iTimer = this.gameObject.GetComponent<ITimer>();

        return _iTimer;
    }
  
}
