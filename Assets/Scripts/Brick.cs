using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int hits = 2;
    public int points = 10;
    public Vector3 rotator;
    public Material hitMaterial;

    Material _origMaterial;
    Renderer _renderer;
    void Start()
    {
        // transform.Rotate(rotator * (transform.position.x + transform.position.y) * 0.1f);
        _renderer = GetComponent<Renderer>();
        _origMaterial = _renderer.sharedMaterial;
    }

    void Update()
    {
        // transform.Rotate(rotator * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision) {
        hits--;
        GameManager.Instance.Score += points;
        _renderer.sharedMaterial = hitMaterial;
        Invoke("RestoreMaterial", 0.05f);
        if (hits <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void RestoreMaterial()
    {
        _renderer.sharedMaterial = _origMaterial;
    }
}
