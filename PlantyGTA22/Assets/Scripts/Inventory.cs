using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("SeedItem Change")]
    [SerializeField] Image SeedItemCanvasLogo;
    [SerializeField] Text SeedItemCanvasText;
    [SerializeField] bool LoopItems = true;
    [SerializeField, Tooltip("These strings must have the same order as the logos.")] string[] SeedItemName;
    [SerializeField, Tooltip("These logos must have the same order as the strings.")] Sprite[] SeedItemLogos;
    [SerializeField, Tooltip("These prefabs must have the same order as the strings and logos.")] public GameObject[] SeedItemPrefabs;
    [SerializeField] public int SeedItemIdInt;
    int MaxSeedItems;
    int ChangeSeedItemInt;
    [HideInInspector] public bool DefiniteHide;
    bool SeedItemChangeLogo;

    private void Start()
    {
        Color OpacityColor = SeedItemCanvasLogo.color;
        OpacityColor.a = 0;
        SeedItemCanvasLogo.color = OpacityColor;
        SeedItemChangeLogo = false;
        DefiniteHide = false;
        MaxSeedItems = SeedItemLogos.Length - 1;
        ChangeSeedItemInt = SeedItemIdInt;
        SeedItemCanvasLogo.sprite = SeedItemLogos[SeedItemIdInt];
        StartCoroutine(ItemChangeObject());
    }
    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            SeedItemIdInt++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            SeedItemIdInt--;
        }

        if (SeedItemIdInt < 0) 
            SeedItemIdInt = LoopItems ? MaxSeedItems : 0;
        if (SeedItemIdInt > MaxSeedItems) 
            SeedItemIdInt = LoopItems ? 0 : MaxSeedItems;


        if (SeedItemIdInt != ChangeSeedItemInt)
        {
            ChangeSeedItemInt = SeedItemIdInt;
            StartCoroutine(ItemChangeObject());
        }
    }

    IEnumerator ItemChangeObject()
    {
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < (MaxSeedItems + 1); i++)
        {
            
        }
        if (!SeedItemChangeLogo) StartCoroutine(ItemLogoChange());
    }

    IEnumerator ItemLogoChange()
    {
        SeedItemChangeLogo = true;
        yield return new WaitForSeconds(0.5f);
        SeedItemCanvasLogo.sprite = SeedItemLogos[SeedItemIdInt];
        SeedItemCanvasText.text = SeedItemName[SeedItemIdInt];
        yield return new WaitForSeconds(0.1f);
        SeedItemChangeLogo = false;
    }

    private void FixedUpdate()
    {
        if (SeedItemChangeLogo)
        {
            Color OpacityColor = SeedItemCanvasLogo.color;
            OpacityColor.a = Mathf.Lerp(OpacityColor.a, 0, 20 * Time.deltaTime);
            SeedItemCanvasLogo.color = OpacityColor;
        }
        else
        {
            Color OpacityColor = SeedItemCanvasLogo.color;
            OpacityColor.a = Mathf.Lerp(OpacityColor.a, 1, 6 * Time.deltaTime);
            SeedItemCanvasLogo.color = OpacityColor;
        }
    }
}
