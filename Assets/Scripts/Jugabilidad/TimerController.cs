using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    // [SerializeField] float limit = 3000.0f;
    // [Header("Random SetUp")]
    // [SerializeField] bool randomTime = false;
    // [SerializeField] timeRange range = default;
    public void StartCount()
    {
        Debug.Log("START COUNTER");
    }
}


[System.Serializable]
public class timeRange{
    [SerializeField] float minTime = default;
    [SerializeField] float maxTime = default;
}