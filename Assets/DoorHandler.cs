using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    [SerializeField] private GameObject target; // Assign this in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the "Player" tag
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.SetTarget(target); // Assign the Target to the Player
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.ClearTarget(); // Reset the Target when the player leaves
            }
        }
    }
}
