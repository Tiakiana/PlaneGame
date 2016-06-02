using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    public float size;
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, size);
    }
}
