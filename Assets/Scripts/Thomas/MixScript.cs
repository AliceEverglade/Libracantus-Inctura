using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixScript : MonoBehaviour
{
    public GameObject dropLocation;

    public GameObject extract;

    public GameObject red;
    public GameObject green;
    public GameObject yellow;

    public GameObject redPrefab;
    public GameObject greenPrefab;
    public GameObject yellowPrefab;

    [SerializeField] private float mix;

    void Update()
    {
        switch (mix)
        {
            case 3:
                extract = yellowPrefab;
                Instantiate(extract, dropLocation.transform.position, Quaternion.identity);
                mix = 0;
                extract.transform.position = dropLocation.transform.position;
                break;

            case 5:
                extract = greenPrefab;
                Instantiate(extract, dropLocation.transform.position, Quaternion.identity);
                mix = 0;
                extract.transform.position = dropLocation.transform.position;
                break;

            case 6:
                extract = redPrefab;
                Instantiate(extract, dropLocation.transform.position, Quaternion.identity);
                mix = 0;
                extract.transform.position = dropLocation.transform.position;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Red"))
        {
            mix = mix + 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag.Equals("Green"))
        {
            mix = mix + 2;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag.Equals("Yellow"))
        {
            mix = mix + 4;
            Destroy(collision.gameObject);
        }
    }
}
