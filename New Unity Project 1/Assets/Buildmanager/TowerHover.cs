using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHover : MonoBehaviour {

    Vector3 size = new Vector3(1f, 1f, 1f);
    public Color colorcanplace = Color.green;
    public Color colorcannotplace = Color.red;
    Renderer rend;
    void Start()
    {

          rend =  GetComponent<Renderer>();
    }
    // Update is called once per frame
    void Update ()
    {
        Ray raytemp = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hittemp;
        Physics.Raycast(raytemp, out hittemp);
        GameObject hitObject = hittemp.collider.gameObject;
        Vector3 pztemp = hittemp.point;
        if (hitObject.tag == "Buildablesurface")
        {
            Collider[] objs;
            objs = Physics.OverlapBox(pztemp, size);
            if (objs.Length > 1)
            {
               rend.material.color = colorcannotplace;
            }
            else
            {
                rend.material.color = colorcanplace;
            }
        }
        else
        {
            rend.material.color = colorcannotplace;
        }
        gameObject.transform.position = new Vector3(pztemp.x,pztemp.y+0.002f,pztemp.z);
        print(gameObject.transform.position);
    }
}
