using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    bool isCutting = false;
    Vector2 previousPos;
    GameObject currentBladeTrail;
    Camera cam;
    public float cuttingVelocity = .001f;
    public GameObject bladeTrailPrefab;
    Rigidbody2D rb;
    CircleCollider2D circleCollider;


    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            stopCutting();
        }
        if (isCutting)
        {
            updateCut();
        }

    }

    void updateCut()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

        float velocity = (newPosition - previousPos).magnitude / Time.deltaTime;
        if (velocity > cuttingVelocity)
        {
            circleCollider.enabled = true;
        }
        else
        {
            circleCollider.enabled = false;
        }
        previousPos = newPosition;
    }
    

    void startCutting()
    {
        isCutting = true;
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
        previousPos = cam.WorldToScreenPoint(Input.mousePosition);
        circleCollider.enabled = false;
    }

    void stopCutting()
    {
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        circleCollider.enabled = false;
        Destroy(currentBladeTrail, 2f);
        

    }
}
