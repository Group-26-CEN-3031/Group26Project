using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_by_boundry : MonoBehaviour
{

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }

}
