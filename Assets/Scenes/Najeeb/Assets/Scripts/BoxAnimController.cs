using UnityEngine;

public class BoxAnimController : MonoBehaviour
{

    Animator animator;
    private int AnimHash_Up;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        AnimHash_Up = Animator.StringToHash("up");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))


        {
            animator.SetTrigger(AnimHash_Up);
        }
    }
}
