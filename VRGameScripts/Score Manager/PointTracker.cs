using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTracker : MonoBehaviour
{
    public int pointValue = 50;
    
    void OnTriggerEnter(Collider collider)
    {
        ScoreManager.instance.score += pointValue;
    }
}
