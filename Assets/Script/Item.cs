using UnityEngine;

public class Item : MonoBehaviour
{
    public int heathPoints = 2;
    public int hungryUpPoints = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
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
}
