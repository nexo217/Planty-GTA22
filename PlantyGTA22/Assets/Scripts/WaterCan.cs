using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterCan : MonoBehaviour
{
    public GameObject WaterPS;
    public GameObject CameraHolder;
    public float waterFill = 10;
    public float waterConsumption = 0.001f;

    public Slider waterCanSlider;

    GameObject WaterFx;
    bool instantiated;
    public bool watering;

    private void Start()
    {
        waterCanSlider.maxValue = waterFill;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        waterCanSlider.value = waterFill;

        if(waterFill > 0)
        {
            if (CameraHolder.transform.localRotation.x > 0.3)
            {
                if (!instantiated)
                {
                    WaterFx = Instantiate(WaterPS, transform);
                    watering = true;
                    instantiated = true;
                }
                waterFill -= waterConsumption;
            }
            if (CameraHolder.transform.localRotation.x < 0.3)
            {
                if (WaterFx != null)
                {
                    WaterFx.transform.SetParent(null);
                    WaterFx.GetComponent<ParticleSystem>().Stop();
                    Destroy(WaterFx, 5);
                    watering = false;
                    instantiated = false;
                }
            }
        }
    }
}
