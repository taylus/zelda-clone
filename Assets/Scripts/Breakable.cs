using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class Breakable : MonoBehaviour
{
    protected Animator animator;

    public virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

    public virtual void Break()
    {
        animator.SetBool("broken", true);
    }

    protected IEnumerator InactivateAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}
