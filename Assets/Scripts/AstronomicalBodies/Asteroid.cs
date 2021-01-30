
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : AstronomicalBody
{
    // Start is called before the first frame update
    void Start()
    {
        /*
        var list = GetComponents(typeof(Component));
        for (int i = 0; i < list.Length; i++)
        {
            Debug.Log(list[i].name + list[i].GetType().ToString());
        }

        //return;

        MeshFilter meshFilter = GameObject.FindObjectOfType<MeshFilter>();
        Mesh mesh = meshFilter.mesh;

        for ( int i = 0; i < mesh.vertices.Length; i++)
        {
            Vector3 vector = mesh.vertices[i];
            double d = UnityEngine.Random.value;
            double s = (UnityEngine.Random.value > 0.5 ? 1 : -1) ;
            float m = (float) (d * s * .5);

            vector.x *= m;
            vector.y *= m;
            vector.z *= m;
        }

        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
