using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobbyPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            Debug.Log("Player!");
            GameManager.Instance.AddPoint(1);
            Destroy(this.gameObject);
        }
    }
}
