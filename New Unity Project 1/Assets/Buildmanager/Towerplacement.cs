using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towerplacement : MonoBehaviour
{
    public GameObject prefab;
    Vector3 size = new Vector3(1f, 1f, 1f);
    // Update is called once per frame

    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
           if (Shop.towerplacementactive)
            {


                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 pz = hit.point;
                    prefab.transform.position = pz;
                    pz.y += 0.5f;
                    GameObject hitObject = hit.collider.gameObject;
                    if (hitObject.gameObject.tag == "Buildablesurface")
                    {
                        Collider[] objs;
                        objs = Physics.OverlapBox(pz, size);
                        if (objs.Length > 1)
                        {
                            Debug.Log("NonBuildable surface");
                            return;
                        }
                        Destroy(FindObjectOfType<TowerHover>().gameObject);
                        Instantiate(prefab, pz, transform.rotation);
                        Shop.towerplacementactive = false;
                        Debug.Log("Hit Buildablesurface");
                    }
                }
            }
        }

    }
}