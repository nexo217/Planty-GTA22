using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePlant : MonoBehaviour
{
    public LayerMask hitLayer;
    public GameObject plant;
    public Transform debugTransform;
    public Camera cam;
    public bool canPlant;
    public bool canEarn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canPlant && Input.GetMouseButtonDown(1) && debugTransform.transform.localPosition.z < 2.6)
        {
            Plant();
        }

        if(canEarn && Input.GetMouseButtonDown(0))
        {
            debugTransform.GetComponent<EarnPlant>().Earn();
        }


        Vector2 screenCenterPoint = new Vector2(Screen.width / 2, Screen.height / 2);
        Ray ray = cam.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 4f, hitLayer))
        {
            debugTransform.position = raycastHit.point;
        }
    }

        

    public void Plant()
    {
        GameObject Plant = Instantiate(plant, debugTransform.transform.position, debugTransform.transform.rotation);
    }
}
