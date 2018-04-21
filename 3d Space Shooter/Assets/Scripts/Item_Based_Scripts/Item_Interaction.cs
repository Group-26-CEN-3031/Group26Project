using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Interaction : MonoBehaviour {

    public Item item;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            bool wasPickedUp = Inventory.instance.Add(item);

            if (wasPickedUp)
            {
                Debug.Log("we Interacted with: " + item.name);
                Destroy(gameObject);
            }
        }
    }
}
