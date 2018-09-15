using UnityEngine;

public class Blade : MonoBehaviour {

    private Rigidbody2D rb;
    private Vector3 lastMousePos, mouseVelo;

    private Collider2D col;

    public Camera cam;
    public float minVelo = 0.1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void Update ()
    {
        col.enabled = IstMouseMoving();
        
        // Keep blade object as mouse position
        SetBladeToMouse();
	}

    private void SetBladeToMouse()
    {
        rb.position = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private bool IstMouseMoving()
    {
        // Position an der sich die Maus befindet
        Vector3 curMousePos = transform.position;

        //Debug.Log("Last Mouse Position = " + lastMousePos);

        // Strecke die die Maus zurücklegt
        float traveled = (lastMousePos - curMousePos).magnitude;

        lastMousePos = curMousePos;

        if (traveled > minVelo)
            return true;
        else
            return false;
    }
}
