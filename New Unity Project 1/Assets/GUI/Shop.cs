using UnityEngine;

public class Shop : MonoBehaviour
{
    Towerplacement towerplacement;

    public GameObject towerhoverprefab;
    public static bool towerplacementactive = false;


    public void PurchaseStandardTower ()
    {
        Debug.Log("Purchased");
        Instantiate(towerhoverprefab);
        towerplacementactive = true;

    }
    public void PurchaseRocketTower()
    {
        Debug.Log("Purchased rocket tower");
        Instantiate(towerhoverprefab);
        towerplacementactive = true;
    }



}
