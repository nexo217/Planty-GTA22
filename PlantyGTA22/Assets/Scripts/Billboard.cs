using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera Camera;
    public bool useStaticBillboard;

    private void Start()
    {
        Camera = GameObject.Find("Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!useStaticBillboard)
        {
            transform.LookAt(Camera.transform);
        }
        else
        {
            transform.rotation = Camera.transform.rotation;
        }

        transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
    }
}
