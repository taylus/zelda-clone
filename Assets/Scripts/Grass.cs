using UnityEngine;

[RequireComponent(typeof(Animator), typeof(BoxCollider2D))]
public class Grass : Breakable
{
    public AudioClip GrassCutSound;

    public override void Start()
    {
        base.Start();
    }

    public override void Break()
    {
        base.Break();
        if (GrassCutSound != null) AudioSource.PlayClipAtPoint(GrassCutSound, transform.position);
        StartCoroutine(InactivateAfter(0.7f));
    }
}
