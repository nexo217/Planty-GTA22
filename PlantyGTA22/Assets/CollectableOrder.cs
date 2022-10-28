using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableOrder : MonoBehaviour
{
    public List<GameObject> Collectables = new List<GameObject>();
    int currentCollectable;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in Collectables)
        {
            item.gameObject.SetActive(false);
        }

        Collectables[currentCollectable].SetActive(true);
    }

    public void NextCollectable()
    {
        Collectables[currentCollectable].SetActive(false);
        currentCollectable++;
        Collectables[currentCollectable].SetActive(true);
    }
}
