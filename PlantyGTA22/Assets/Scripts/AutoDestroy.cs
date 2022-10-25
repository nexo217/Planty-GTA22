using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float Time;
    public bool onlyDisable;

    // Start is called before the first frame update
    void Start()
    {
        if (!onlyDisable)
        {
            Destroy(gameObject, Time);
        }
        else
        {
            Invoke("Disable", Time);
        }
    }

    void Disable()
    {
        gameObject.SetActive(false);        
    }
}
