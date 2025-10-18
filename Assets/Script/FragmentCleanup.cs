// Limpieza de fragmento: se añade a cada fragmento creado
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentCleanup : MonoBehaviour {
    public float Lifetime = 5f;
    Rigidbody rb;

    public void Init(float lifetime, Rigidbody rigidbodyRef) {
        Lifetime = lifetime;
        rb = rigidbodyRef;
        StartCoroutine(CleanupRoutine());
    }

    private IEnumerator CleanupRoutine() {
        if (Lifetime <= 0f) {
            Destroy(gameObject);
            yield break;
        }

        float toKinematic = Mathf.Max(0f, Lifetime - 1f);
        yield return new WaitForSeconds(toKinematic);
        if (rb != null) rb.isKinematic = true;
        yield return new WaitForSeconds(Lifetime - toKinematic);
        if (gameObject != null) Destroy(gameObject);
    }
}
