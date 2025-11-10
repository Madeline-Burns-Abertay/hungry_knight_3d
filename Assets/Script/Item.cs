using UnityEngine;
using System;
using System.Collections;

public class Item : MonoBehaviour
{
    public int heathPoints = 2;
    public int hungryUpPoints = 5;

    public AudioSource source;
    public AudioClip pickUpSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUpItem(other));
        }
    }
    IEnumerator PickUpItem(Collider playerObject)
    {
        //Take the Player script
        Player player = playerObject.GetComponent<Player>();

        //On Audio pickup for one second
        source.PlayOneShot(pickUpSound, 0.3f);

        yield return new WaitForSeconds(0.3f);

        //Add hungry
        player.hungry += hungryUpPoints;
        //Check if current player's hungry greate maxhungry
        if (player.hungry > player.maxHungry)
        {
            player.hungry = player.maxHungry;
        }
        Destroy(gameObject);
    }
}
