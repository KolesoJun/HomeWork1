using UnityEngine;

public class Exploder : MonoBehaviour
{
    public void ExplodeForRadius(Transform objectExplode, float radius, float force)
    {
        Collider[] hits = Physics.OverlapSphere(objectExplode.position, radius);

        foreach (var hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                float forceCurrent = Mathf.MoveTowards(force, 0, hits.Length);
                hit.attachedRigidbody.AddForce((hit.transform.position - objectExplode.position) * forceCurrent, ForceMode.Impulse);
            }
        }
    }
}
