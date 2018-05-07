using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{

    private Shader m_material;
    private Renderer rend;
    private Color originalMaterial;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        originalMaterial = rend.material.color;
    }

    public void StartFlash()
    {
        StartCoroutine(Flasher());
    }

    IEnumerator Flasher()
    {
        for (int i = 0; i < 10; i++)
        {
            rend.material.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            rend.material.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
        rend.material.color = originalMaterial;
    }
}
