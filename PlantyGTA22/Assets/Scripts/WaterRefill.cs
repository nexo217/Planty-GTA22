using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRefill : MonoBehaviour
{
    public WaterCan waterCan;
    public float fillAmount = 0.1f;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "GameController" && waterCan.waterFill < 10)
        {
            waterCan.waterFill += fillAmount;
        }
    }
}
