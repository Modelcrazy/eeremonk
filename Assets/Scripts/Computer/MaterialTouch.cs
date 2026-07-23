using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class MaterialTouch : MonoBehaviour
{
    public Material touchMaterial;
    public string handTag = "FC";

    private Material originalMaterial;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        originalMaterial = rend.material;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(handTag))
        {
            rend.material = touchMaterial;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(handTag))
        {
            rend.material = originalMaterial;
        }
    }
}