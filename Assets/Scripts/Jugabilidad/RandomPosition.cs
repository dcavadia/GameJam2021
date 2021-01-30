using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{

    //PIEZAS
    [Header("Piezas")]
    public GameObject[] bodyParts;

    //LOCATIONS
    [Header("Piezas")]
    public GameObject[] hidingLocations;

    static System.Random random = new System.Random();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
        //    Organizar();
        }
    }

    // FUNCION PARA ORGANIZAR
    public void Organizar()
    {
        List<int> vals = GenerateRandom(10);
        int index = 0;

        foreach (GameObject part in bodyParts)
        {
            int position = vals[index];
            Instantiate(part, hidingLocations[position].transform.position, hidingLocations[position].transform.rotation);
            index++;
        }

    }

    public static List<int> GenerateRandom(int count)
    {
        // generate count random values.
        HashSet<int> candidates = new HashSet<int>();
        while (candidates.Count < count)
        {
            // May strike a duplicate.
            candidates.Add(random.Next());
        }

        // load them in to a list.
        List<int> result = new List<int>();
        result.AddRange(candidates);

        // shuffle the results:
        int i = result.Count;
        while (i > 1)
        {
            i--;
            int k = random.Next(i + 1);
            int value = result[k];
            result[k] = result[i];
            result[i] = value;
        }
        return result;
    }
}
