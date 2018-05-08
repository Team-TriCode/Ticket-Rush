using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageFlash : MonoBehaviour
{
    private Shader m_material;
    private Renderer rend;
    private Color originalMaterial;
    [SerializeField]
    private Image canvasFlash;

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
        Color color = canvasFlash.GetComponent<Image>().color;
        color.a = 0.3f;
        canvasFlash.color = color;
        yield return new WaitForSeconds(0.05f);
        color.a = 0;
        canvasFlash.color = color;

        for (int i = 0; i < 7; i++)
        {
            rend.material.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            rend.material.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
        rend.material.color = originalMaterial;
    }
}
