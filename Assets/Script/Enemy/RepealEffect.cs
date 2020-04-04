using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepealEffect : MonoBehaviour
{
    [SerializeField] private float _radious = 2.0f;
    [SerializeField] private float _repealMagnitudeForce = 7.0f;
    private bool isWaitForMadeValZero = false;
    [SerializeField] private bool _isInteractableWithPlayer = false;

    private void Start()
    {
        isWaitForMadeValZero = false;
    }
    void Update()
    {
       ExplosionDamage();
    }
    void ExplosionDamage()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(gameObject.transform.position, _radious);
        if (hitColliders.Length <= 1)
            return;

        for(int i= 0;i< hitColliders.Length; i++)
        {
            GameObject collidedObj = hitColliders[i].gameObject;
            if (collidedObj != this.gameObject && CanAddForce(collidedObj))
            {
                ForceObj(hitColliders[i].gameObject);
            }
        }
    }

    bool CanAddForce(GameObject collidedObj)
    {
        if (_isInteractableWithPlayer)
        {
            if (collidedObj.tag == GameEnum.GameTags.Enemy.ToString() ||
                collidedObj.tag == GameEnum.GameTags.Player.ToString())
                return true;
        }
        else
        {
            if (collidedObj.tag == GameEnum.GameTags.Player.ToString())
                return true;
        }
        return false;
    }

    void ForceObj(GameObject otherObj)
    {
        
        var force = transform.position - otherObj.transform.position;
        force.Normalize();
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(force * _repealMagnitudeForce);
        if(isWaitForMadeValZero == false)
        {
            isWaitForMadeValZero = true;
            Invoke("madeVelZero", 2.0f);
        }
       
    }

    void madeVelZero()
    {
        isWaitForMadeValZero = false;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }



}
