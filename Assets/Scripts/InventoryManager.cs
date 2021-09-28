using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject bag;
    private bool isOpened;

    public Image imageComponent;
    public Sprite firstSprite, secondSprite;
    private void Start()
    {
        isOpened = false;
    }

    public void OpenBag()
    {
        if (isOpened == false)
        {
            bag.SetActive(true);
            isOpened = true;
            imageComponent.sprite = secondSprite;
        }
        else if (isOpened == true)
        {
            bag.SetActive(false);
            isOpened = false;
            imageComponent.sprite = firstSprite;
        }
    }

}
