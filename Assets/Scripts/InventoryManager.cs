using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject bag;
    private bool isOpened;
    private void Start()
    {
        isOpened = false;
        bag = GameObject.Find("ItemParent");
        //GameObject.Find("ItemParent").SetActive(false);
    }

    private void OnButtonClick()
    {
        if (isOpened == false)
        {
            bag.SetActive(true);
            isOpened = true;
        }
        else if (isOpened == true)
        {
            bag.SetActive(false);
            isOpened = false;
        }
    }
}
