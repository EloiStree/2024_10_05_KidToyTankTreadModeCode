using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicKillDozerMoveMono : MonoBehaviour
{


    [Range(-1,1)]
    [SerializeField]
    private float m_moveForwardPercent = 0;
    public float m_speedPerSecondForward = 5.0f; 
    public float m_speedPerSecondBackward = 1.0f; 


    [Range(-1,1)]
    [SerializeField]
    private float m_rotateLeftRightPercent = 0;
    public float m_rotationSpeed = 40f; // Vitesse de rotation

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        MoveKillDozerForward();
        RotateKillDozerLeftToRight();
    }


    /// <summary>
    /// It allows to move the killdozer forward or backward in percentage.
    ///
    /// </summary>
    /// <param name="percentBackForward11">This is a percentage between -1 and 1</param>
    public void SetPercentBackForwardTo(float percentBackForward11)
    {

        if (percentBackForward11 < -1f) { 
            percentBackForward11 = -1f;
        }

        if (percentBackForward11 > 1f) { 
            percentBackForward11 = 1f;
        }

        m_moveForwardPercent = percentBackForward11;
    }


    public void SetToLeftDirectionWithPercent(float percent) { 
    
        SetPercentLeftRightTo(-percent);
    }

    public void SetToRightDirectionWithPercent(float percent) { 
    
        SetPercentLeftRightTo(percent);
    }

    /// <summary>
    /// It allows to rotate the killdozer left or right in percentage.
    /// </summary>
    /// <param name="percentLeftRight11">This is a percentage between -1 and 1 </param>
    public void SetPercentLeftRightTo(float percentLeftRight11)
    {
        if (percentLeftRight11 < -1f) { 
            percentLeftRight11 = -1f;
        }
        if (percentLeftRight11 > 1f) { 
            percentLeftRight11 = 1f;
        }

        m_rotateLeftRightPercent = percentLeftRight11;
    }

    public void RotateKillDozerLeftToRight() {

        transform.Rotate(Vector3.up * (m_rotationSpeed * Time.deltaTime * m_rotateLeftRightPercent), Space.Self);
    }

    public void MoveKillDozerForward() {
        
        float speed = 0f;
        if (m_moveForwardPercent > 0)
            speed = m_speedPerSecondForward;
        else if (m_moveForwardPercent < 0)
            speed = m_speedPerSecondBackward;
        transform.Translate(Vector3.forward
            * speed
            * Time.deltaTime
            * m_moveForwardPercent);
    }

}
