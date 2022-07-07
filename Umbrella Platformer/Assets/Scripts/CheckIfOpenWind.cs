using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CheckIfOpenWind : MonoBehaviour
{

    public MovementController mc;
    Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        col = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mc.isOpen) {
            col.enabled = true;
        } else {
            col.enabled = false;
        }
    }
}
