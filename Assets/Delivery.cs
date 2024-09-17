using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackColor = new Color32(1, 1, 1, 1);


    [SerializeField] float destroyDelay = 0.5f;
    bool hasPack;

    SpriteRenderer spriteRenderer;
     void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
            if (other.tag == "Pack" && !hasPack)
            {
                Debug.Log("Pack picked up");
                hasPack = true;
                spriteRenderer.color = hasPackColor;
                Destroy(other.gameObject, destroyDelay);
            }

        if (other.tag == "Customer" && hasPack)
        {
            Debug.Log("Pack delivered");
            hasPack = false;
            spriteRenderer.color = noPackColor;
        }
    }
}
