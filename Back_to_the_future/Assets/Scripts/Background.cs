using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    float length, startPositionX, startPositionY;
    public GameObject camera;
    public bool isSky = false;

    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startPositionX = transform.position.x;
        startPositionY = transform.position.y;

        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = camera.transform.position.x * (1 - parallaxEffect);
        float dist = camera.transform.position.x * parallaxEffect;
        float distY = camera.transform.position.y * parallaxEffect * 0.85f;

        transform.position = new Vector3(startPositionX + dist, !isSky? startPositionY + distY : transform.position.y, transform.position.z);

        if (temp > startPositionX + length)
            startPositionX += length;
        else if (temp < startPositionX - length)
            startPositionX -= length;
    }
}
