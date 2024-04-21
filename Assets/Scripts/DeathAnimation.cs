using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();
    }

    public void Die()
    {
        if (animator != null)
        {
            animator.SetTrigger("TrDie");
        }
    }
}
