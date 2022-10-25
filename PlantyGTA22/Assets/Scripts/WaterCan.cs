using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCan : MonoBehaviour
{
    public GameObject WaterPS;
    public GameObject CameraHolder;

    GameObject WaterFx;
    bool instantiated;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(CameraHolder.transform.localRotation.x);

        if (CameraHolder.transform.localRotation.x > 0.3)
        {
            if (!instantiated)
            {
                WaterFx = Instantiate(WaterPS, transform);
                instantiated = true;
            }
        }
        if (CameraHolder.transform.localRotation.x < 0.3)
        {
            if(WaterFx != null)
            {
                WaterFx.transform.SetParent(null);
                WaterFx.GetComponent<ParticleSystem>().Stop();
                Destroy(WaterFx, 5);
                instantiated = false;
            }
        }
    }
}
