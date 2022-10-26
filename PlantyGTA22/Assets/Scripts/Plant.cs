using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public GameObject[] PlantsTypes;
    public GameObject[] Spawnpoints;
    public GameObject Fruit;
    int currentType;
    [HideInInspector] public float waterGot;
    bool watered;
    bool watered1;
    [HideInInspector] public bool canEarn;
    public GameObject ViewpointPrefab;
    Viewpoint viewpoint;
    bool finishedGrowing;

    [Header("Parameter")]
    public float maxGrowTime;
    //maxGrowTime divided with PlantsTypes.Length
    float growTimePerType;
    public int fruitCount;
    public float fruitGrowTime;
    public float waterNeeded;

    // Start is called before the first frame update
    void Start()
    {
        growTimePerType = maxGrowTime / PlantsTypes.Length;
     
        viewpoint = Instantiate(ViewpointPrefab, transform.position, transform.rotation).GetComponent<Viewpoint>();
        viewpoint.PointText = "Pour!";
        PlantsTypes[currentType].SetActive(true);
    }

    private void Update()
    {
        if(waterGot > waterNeeded && !watered && !watered1)
        {
            watered = true;
            watered1 = true;
        }
        if (watered == true)
        {
            Invoke("Evolve", growTimePerType);
            viewpoint.PointText = "Grows";
            watered = false;
        }
    }

    public void Evolve()
    {
        if(PlantsTypes.Length > 0 && PlantsTypes.Length > currentType +1)
        {
            PlantsTypes[currentType].SetActive(false);
            currentType += 1;
            PlantsTypes[currentType].SetActive(true);
            
            
            

            //Restarts this Progress
            Invoke("Evolve", growTimePerType);
        }

        //if finished
        if (PlantsTypes.Length < currentType + 2)
        {
            if(!finishedGrowing)
            {
                Invoke("SpawnFruits", fruitGrowTime);              
                finishedGrowing = true;
            }
        }
    }

    List<GameObject> fruits = new List<GameObject>();
    GameObject fruit;

    void SpawnFruits()
    {
        for (int i = 0; i < fruitCount; i++)
        {
            fruit = Instantiate(Fruit, Spawnpoints[i].transform.position, Spawnpoints[i].transform.rotation);
            fruits.Add(fruit);
            canEarn = true;
            viewpoint.PointText = "Earn Fruits!";
        }
    }


    public void DestroyPlant()
    {
        for(int i = 0;i < fruits.Count; i++)
        {
            Destroy(fruits[i]);
        }
        viewpoint.DestroyUI();
        Destroy(gameObject);
    }
}
