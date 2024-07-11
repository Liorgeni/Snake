using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    
    public static Fruit instance;


    private void Awake()
    {
        instance = this;
    }

    public BoxCollider2D gridArea;


    private void Start()
    {
        RandomizePosition();
    }

    public void RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

       transform.position = new Vector3( Mathf.Round(x), Mathf.Round(y), 0.0f);
    }
}
