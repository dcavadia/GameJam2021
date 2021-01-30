using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{

    //PIEZAS
    [Header("Piezas")]
    public GameObject pieza1;
    public GameObject pieza2;
    public GameObject pieza3;
    public GameObject pieza4;
    public GameObject pieza5;


    //LOCATIONS
    [Header("Piezas")]
    public GameObject location1;
    public GameObject location2;
    public GameObject location3;
    public GameObject location4;
    public GameObject location5;
    public GameObject location6;
    public GameObject location7;
    public GameObject location8;
    public GameObject location9;
    public GameObject location10;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Organizar();
        }
    }

    // FUNCION PARA ORGANIZAR
    void Organizar()
    {
        int cont = 0;
        while (cont < 5)
        {
            int random = Random.Range(1, 10);

            //........................PIEZA 1....................................
            if (cont == 0)
            {
                if(random == 1)
                {
                    GameObject Pieza1 = Instantiate(pieza1, location1.transform.position, location1.transform.rotation);
                }else if(random == 2)
                {
                    GameObject Pieza1 = Instantiate(pieza1, location2.transform.position, location2.transform.rotation);
                }else if(random == 3)
                {
                    GameObject Pieza1 = Instantiate(pieza1, location3.transform.position, location3.transform.rotation);
                }
                else if (random == 4)
                {
                    GameObject Pieza1 = Instantiate(pieza1, location4.transform.position, location4.transform.rotation);
                }
                else if (random == 5)
                {
                    GameObject Pieza1 = Instantiate(pieza1, location5.transform.position, location5.transform.rotation);
                }
                else if (random == 6)
                {
                    GameObject Pieza1 = Instantiate(pieza1, location6.transform.position, location6.transform.rotation);
                }
                else if (random == 7)
                {
                    GameObject Pieza1 = Instantiate(pieza1, location7.transform.position, location7.transform.rotation);
                }
                else if (random == 8)
                {
                    GameObject Pieza1 = Instantiate(pieza1, location8.transform.position, location8.transform.rotation);
                }
                else if (random == 9)
                {
                    GameObject Pieza1 = Instantiate(pieza1, location9.transform.position, location9.transform.rotation);
                }
                else if (random == 10)
                {
                    GameObject Pieza1 = Instantiate(pieza1, location10.transform.position, location10.transform.rotation);
                }
            }

            //..................PIEZA 2..................................................

            if (cont == 1)
            {
                if (random == 1)
                {
                    GameObject Pieza2 = Instantiate(pieza2, location1.transform.position, location1.transform.rotation);
                }
                else if (random == 2)
                {
                    GameObject Pieza2 = Instantiate(pieza2, location2.transform.position, location2.transform.rotation);
                }
                else if (random == 3)
                {
                    GameObject Pieza2 = Instantiate(pieza2, location3.transform.position, location3.transform.rotation);
                }
                else if (random == 4)
                {
                    GameObject Pieza2 = Instantiate(pieza2, location4.transform.position, location4.transform.rotation);
                }
                else if (random == 5)
                {
                    GameObject Pieza2 = Instantiate(pieza2, location5.transform.position, location5.transform.rotation);
                }
                else if (random == 6)
                {
                    GameObject Pieza2 = Instantiate(pieza2, location6.transform.position, location6.transform.rotation);
                }
                else if (random == 7)
                {
                    GameObject Pieza2 = Instantiate(pieza2, location7.transform.position, location7.transform.rotation);
                }
                else if (random == 8)
                {
                    GameObject Pieza2 = Instantiate(pieza2, location8.transform.position, location8.transform.rotation);
                }
                else if (random == 9)
                {
                    GameObject Pieza2 = Instantiate(pieza2, location9.transform.position, location9.transform.rotation);
                }
                else if (random == 10)
                {
                    GameObject Pieza2 = Instantiate(pieza2, location10.transform.position, location10.transform.rotation);
                }
            }

            //..................PIEZA 3..................................................

            if (cont == 2)
            {
                if (random == 1)
                {
                    GameObject Pieza3 = Instantiate(pieza3, location1.transform.position, location1.transform.rotation);
                }
                else if (random == 2)
                {
                    GameObject Pieza3 = Instantiate(pieza3, location2.transform.position, location2.transform.rotation);
                }
                else if (random == 3)
                {
                    GameObject Pieza3 = Instantiate(pieza3, location3.transform.position, location3.transform.rotation);
                }
                else if (random == 4)
                {
                    GameObject Pieza3 = Instantiate(pieza3, location4.transform.position, location4.transform.rotation);
                }
                else if (random == 5)
                {
                    GameObject Pieza3 = Instantiate(pieza3, location5.transform.position, location5.transform.rotation);
                }
                else if (random == 6)
                {
                    GameObject Pieza3 = Instantiate(pieza3, location6.transform.position, location6.transform.rotation);
                }
                else if (random == 7)
                {
                    GameObject Pieza3 = Instantiate(pieza3, location7.transform.position, location7.transform.rotation);
                }
                else if (random == 8)
                {
                    GameObject Pieza3 = Instantiate(pieza3, location8.transform.position, location8.transform.rotation);
                }
                else if (random == 9)
                {
                    GameObject Pieza3 = Instantiate(pieza3, location9.transform.position, location9.transform.rotation);
                }
                else if (random == 10)
                {
                    GameObject Pieza3 = Instantiate(pieza3, location10.transform.position, location10.transform.rotation);
                }
            }

            //..................PIEZA 4..................................................

            if (cont == 3)
            {
                if (random == 1)
                {
                    GameObject Pieza4 = Instantiate(pieza4, location1.transform.position, location1.transform.rotation);
                }
                else if (random == 2)
                {
                    GameObject Pieza4 = Instantiate(pieza4, location2.transform.position, location2.transform.rotation);
                }
                else if (random == 3)
                {
                    GameObject Pieza4 = Instantiate(pieza4, location3.transform.position, location3.transform.rotation);
                }
                else if (random == 4)
                {
                    GameObject Pieza4 = Instantiate(pieza4, location4.transform.position, location4.transform.rotation);
                }
                else if (random == 5)
                {
                    GameObject Pieza4 = Instantiate(pieza4, location5.transform.position, location5.transform.rotation);
                }
                else if (random == 6)
                {
                    GameObject Pieza4 = Instantiate(pieza4, location6.transform.position, location6.transform.rotation);
                }
                else if (random == 7)
                {
                    GameObject Pieza4 = Instantiate(pieza4, location7.transform.position, location7.transform.rotation);
                }
                else if (random == 8)
                {
                    GameObject Pieza4 = Instantiate(pieza4, location8.transform.position, location8.transform.rotation);
                }
                else if (random == 9)
                {
                    GameObject Pieza4 = Instantiate(pieza4, location9.transform.position, location9.transform.rotation);
                }
                else if (random == 10)
                {
                    GameObject Pieza4 = Instantiate(pieza4, location10.transform.position, location10.transform.rotation);
                }
            }

            //..................PIEZA 5..................................................

            if (cont == 4)
            {
                if (random == 1)
                {
                    GameObject Pieza5 = Instantiate(pieza5, location1.transform.position, location1.transform.rotation);
                }
                else if (random == 2)
                {
                    GameObject Pieza5 = Instantiate(pieza5, location2.transform.position, location2.transform.rotation);
                }
                else if (random == 3)
                {
                    GameObject Pieza5 = Instantiate(pieza5, location3.transform.position, location3.transform.rotation);
                }
                else if (random == 4)
                {
                    GameObject Pieza5 = Instantiate(pieza5, location4.transform.position, location4.transform.rotation);
                }
                else if (random == 5)
                {
                    GameObject Pieza5 = Instantiate(pieza5, location5.transform.position, location5.transform.rotation);
                }
                else if (random == 6)
                {
                    GameObject Pieza5 = Instantiate(pieza5, location6.transform.position, location6.transform.rotation);
                }
                else if (random == 7)
                {
                    GameObject Pieza5 = Instantiate(pieza5, location7.transform.position, location7.transform.rotation);
                }
                else if (random == 8)
                {
                    GameObject Pieza5 = Instantiate(pieza5, location8.transform.position, location8.transform.rotation);
                }
                else if (random == 9)
                {
                    GameObject Pieza5 = Instantiate(pieza5, location9.transform.position, location9.transform.rotation);
                }
                else if (random == 10)
                {
                    GameObject Pieza5 = Instantiate(pieza5, location10.transform.position, location10.transform.rotation);
                }
            }


            cont = cont + 1;
        }

        
    }
}
