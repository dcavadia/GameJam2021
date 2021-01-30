using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class AstronomicalBodiesGenerator : MonoBehaviour
{

   

    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject AstronomicalBodyPrefab;


    public int MinDistance = 100;
    public int MaxDistance = 200;
    public int Count = 10;
    public Vector3 Speed = new Vector3 (0, 0 , 0.001f);
    public int DistanceCheckInterval = 30;


    private List<GameObject> bodies = new List<GameObject>();

    private DateTime lastDistanceCheckTime = DateTime.Now;



    // Start is called before the first frame update
    void Start()
    {
        // UnityEngine.Random random = new UnityEngine.Random();
        //System.Random random = new SystemRandom();
        for ( int i = 0; i < Count; i++)
        {
            

            GameObject body = Instantiate(AstronomicalBodyPrefab, RandomizeLocation_Sphere(false), Quaternion.identity);
            bodies.Add(body);
            
        }
    }

    
    
    /*
     * 
     */
    Vector3 RandomizeLocation_Sphere(bool inFront)
    {
        
        double x = UnityEngine.Random.value - 0.5;
        double y = UnityEngine.Random.value - 0.5;
        double z = UnityEngine.Random.value - 0.5;

        double mag = Math.Sqrt(x * x + y * y + z * z);
        x /= mag; y /= mag; z /= mag;

        double d = UnityEngine.Random.Range(MinDistance, MaxDistance);
        x *= d;
        y *= d;
        z *= d;

        if (inFront)
        {
            z = Math.Abs(z);
        }

        Vector3 position = new Vector3((float)x, (float)y, (float)z);
       
        
        return position;
    }


    /*
    Vector3 RandomizeLocation_Cylinder()

    {

        Vector3 position = Vector3.back;
        double x, y, z, mag, d;

        switch ( BodiesPosition)
        {
            case Position.FrontAndRear:
                x = UnityEngine.Random.value - 0.5;
                y = UnityEngine.Random.value - 0.5;
                z = UnityEngine.Random.value - 0.5;

                mag = Math.Sqrt(z * z);
               z /= mag;

                d = UnityEngine.Random.Range(MinDistance, MaxDistance);
                x *= d;
                y *= d;
                z *= d;
                // Instantiate at position (0, 0, 0) and zero rotation.
                position = new Vector3((float)x, (float)y, (float)z);

                break;
            case Position.Around:

                x = UnityEngine.Random.value - 0.5;
                y = UnityEngine.Random.value - 0.5;
                z = UnityEngine.Random.value - 0.5;

                mag = Math.Sqrt(x * x + y * y );
                x /= mag; y /= mag; 

                d = UnityEngine.Random.Range(MinDistance, MaxDistance);
                x *= d;
                y *= d;
                z *= d;
                // Instantiate at position (0, 0, 0) and zero rotation.
                position = new Vector3((float)x, (float)y, (float)z);

                break;
        }


        return position;
    }
    */

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject body  in bodies)
        {
            body.transform.localPosition -=  Speed;
        }

        TimeSpan ts = DateTime.Now - lastDistanceCheckTime;

        if (ts.TotalSeconds > DistanceCheckInterval)
        {
            lastDistanceCheckTime = DateTime.Now;

            for (int i = 0; i < bodies.Count; i++)
            {
                GameObject body = bodies[i];

                float magnitude = body.transform.localPosition.magnitude;
                if (magnitude > MaxDistance)
                {
                    body.transform.localPosition = RandomizeLocation_Sphere(true);
                    //body.transform.localPosition = - Speed.normalized * (MaxDistance - MinDistance);
                }
                else if ( magnitude < MinDistance)
                {
                    Vector3 localPosition = body.transform.localPosition;

                    float x = localPosition.x;
                    float y = localPosition.y;
                    float z = localPosition.z;

                    float dif = MinDistance - magnitude;


                    float speedMag = Speed.magnitude;

                    Vector2 aux = new Vector2(x, y);
                    magnitude = aux.magnitude;


                    //float newMag = magnitude + dif;
                    float newMag = magnitude + speedMag;
                    float multiplier = newMag / magnitude;
                    

                    x *= multiplier;
                    y *= multiplier;
                    localPosition = new Vector3(x, y, z);

                    body.transform.localPosition = localPosition;
                }
            }
        }
    }
}
