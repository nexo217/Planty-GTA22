using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog2 : MonoBehaviour
{
    public float speed;
    private float plantCount = 0;
    private float oldPlantCount = 0;
    bool checkPlant = true;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Nebelverdrangswert", 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (checkPlant)
        {
            for (int i = 0; i < plantCount - oldPlantCount; i++)
            {
                this.gameObject.transform.Translate(Vector3.down * speed, Space.World);
            }

            oldPlantCount = plantCount;

            StartCoroutine("Check");
        }
    }

    IEnumerator Check()
    {
        checkPlant = false;
        yield return new WaitForSeconds(5);
        plantCount = PlayerPrefs.GetInt("Nebelverdrangswert", 0);
        checkPlant = true;
    }
}
