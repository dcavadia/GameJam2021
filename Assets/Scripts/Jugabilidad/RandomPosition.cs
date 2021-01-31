using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{

    //PIEZAS
    [Header("Piezas")]
    public GameObject[] bodyParts;

    //LOCATIONS
    [Header("Locaciones")]
    public GameObject[] hidingLocations;

    /*public*/ List<int> randomPositions = new List<int>();

    public System.Random random = new System.Random();

    void Update()
    {

    }

    // FUNCION PARA ORGANIZAR
    public void Organizar()
    {
        int index = 0 ;
        List<int> listPositions = GenerateRandom();

        foreach (GameObject part in bodyParts)
        {
            int position = listPositions[index];
            Instantiate(part, hidingLocations[position].transform.position, hidingLocations[position].transform.rotation);
            index++;
        }

    }

    //GENERA 10 NUMEROS AL AZAR SIN REPETICION
    public List<int> GenerateRandom()
    {
        var set = new HashSet<int>();
        var nums = new List<int>();
        int i = 0;

        while (i < 10)
        {
            int num;
            do
            {
                num = Random.Range(0, 10);
            } while (!set.Add(num));
            set.Add(num);
            randomPositions.Add(num);
            i++;
        }

        return randomPositions;
    }

}
