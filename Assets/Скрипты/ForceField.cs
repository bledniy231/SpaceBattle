using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour {

    public string tag;

    public Animator animator;

    public AudioSource audioSource;

    public AudioClip hitSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>() != null)
        {
            audioSource.PlayOneShot(hitSound);
            animator.SetTrigger("blink" + tag);
        }
    }
}
