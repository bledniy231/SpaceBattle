using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour {

    public float growSpeed = 0.2f;
    public float size = 5;
    public float maxSize = 9;

    private void Update()
    {
        size = transform.localScale.x;

        if (size <= maxSize)
        {
            size += growSpeed * Time.deltaTime;
            transform.localScale = new Vector3(size, size, size);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Spaceship spaceship = other.GetComponent<Spaceship>();
        if (spaceship != null)
        {
            spaceship.Kill();
        }

        UFO ufo = other.GetComponent<UFO>();
        if (ufo != null)
        {
            Destroy(ufo.gameObject);
        }
    }
}
