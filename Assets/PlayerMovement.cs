using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private TwoBoneIKConstraint RightHandBone;
    [SerializeField] private TwoBoneIKConstraint LeftHandBone;
    [SerializeField] private GameObject Target; // Assigned dynamically by the Door

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

    public void SetTarget(GameObject newTarget)
    {
        Target = newTarget;
        RightHandBone.weight = 1; // Activate IK
    }

    public void ClearTarget()
    {
        Target = null;
        RightHandBone.weight = 0; // Deactivate IK
    }

    private void LateUpdate()
    {
        if (Target != null)
        {
            RightHandBone.data.target.position = Target.transform.position;
        }
    }
}
