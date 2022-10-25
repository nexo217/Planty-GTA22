using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public GameObject[] PlantsTypes;
    public int currentType;
    public bool canEarn;
    public GameObject ViewpointObject;
    Viewpoint viewpoint;


    // Start is called before the first frame update
    void Start()
    {
        viewpoint = Instantiate(ViewpointObject, transform.position, transform.rotation).GetComponent<Viewpoint>();
        PlantsTypes[currentType].SetActive(true);
        Invoke("Evolve", Random.Range(6, 10));
    }

    public void Evolve()
    {
        if(PlantsTypes.Length > 0 && PlantsTypes.Length > currentType +1)
        {
            PlantsTypes[currentType].SetActive(false);


            PlantsTypes[currentType + 1].SetActive(true);
            currentType += 1;
            Invoke("Evolve", Random.Range(6, 10));

            if (PlantsTypes.Length < currentType + 2)
            {
                canEarn = true;
            }
        }
    }

    public void DestroyPlant()
    {
        viewpoint.DestroyUI();
        Destroy(gameObject);
    }
}
