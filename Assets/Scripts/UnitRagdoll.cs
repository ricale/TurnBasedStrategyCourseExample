using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRagdoll : MonoBehaviour
{
    [SerializeField] private Transform ragdollRootBorn;

    public void Setup(Transform originalRootBorn)
    {
        MatchAllChildTransform(originalRootBorn, ragdollRootBorn);
        ApplyExplosionToRagdoll(ragdollRootBorn, 300f, transform.position, 10f);
    }

    private void MatchAllChildTransform(Transform root, Transform clone)
    {
        foreach(Transform child in root)
        {
            Transform cloneChild = clone.Find(child.name);
            if(cloneChild != null)
            {
                cloneChild.position = child.position;
                cloneChild.rotation = child.rotation;
                MatchAllChildTransform(child, cloneChild);
            }
        }
    }

    private void ApplyExplosionToRagdoll(
        Transform root,
        float explosionForce,
        Vector3 explosionPosition,
        float explosionRange)
    {
        foreach(Transform child in root)
        {
            if(child.TryGetComponent<Rigidbody>(out Rigidbody childRigidbody))
            {
                childRigidbody.AddExplosionForce(
                    explosionForce,
                    explosionPosition,
                    explosionRange
                );
            }
            ApplyExplosionToRagdoll(
                child,
                explosionForce,
                explosionPosition,
                explosionRange
            );
        }
    }
}
