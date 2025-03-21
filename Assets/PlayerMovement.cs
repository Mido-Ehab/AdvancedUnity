using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal"); // Left/Right movement
        float y = Input.GetAxis("Vertical");   // Forward/Backward movement

        // Update Blend Tree parameters
        animator.SetFloat("x", x);
        animator.SetFloat("y", y);
    }
}