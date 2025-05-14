// Marcos Acedo 006884833 Team StrawHat //
// This code is an adaptation of the CollectibleItem Script found in "Unity In Action" By Joseph Hocking //
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollectibleItem : MonoBehaviour
{
    [SerializeField] string Rupee;
    [SerializeField] AudioClip pickupSound;
    [SerializeField] [Range(0, 1)] float volume = 0.8f;

    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.playOnAwake = false;
            audioSource.spatialBlend = 0f; 
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Item Collected: {Rupee} by {other.name}");
        Managers.Inventory.AddItem(Rupee);

        if (pickupSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(pickupSound, volume);
        }

        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        Destroy(gameObject, pickupSound != null ? pickupSound.length : 0);
    }
}
