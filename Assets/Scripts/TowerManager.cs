using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public static TowerManager instance;

    private void Awake()
    {
        instance = this;
    }

    public Tower activeTower;

    public Transform indicator;
    public bool isPlacing;
    public GameObject noPlace;

    public LayerMask whatIsPlacement, whatIsObstacle;

    public float topSafePercent = 15f;

    [HideInInspector]
    public Tower selectedTower;

    public GameObject selectedTowerEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlacing)
        {
            UIController.instance.CloseTowerUpgradePanel(); //closes upgrade tower panel and deselects active tower
            indicator.position = GetGridPosition();

            RaycastHit hit;
            if(Input.mousePosition.y < Screen.height - (Screen.height * (1f - (topSafePercent/ 100f))))
            {
                indicator.gameObject.SetActive(false);
            } else if (Physics.Raycast(indicator.position + new Vector3(0f, -2f, 0f), Vector3.up, out hit, 10f, whatIsObstacle))
            {
                //indicator.gameObject.SetActive(false);
                indicator.gameObject.GetComponent<Tower>().noPlaceModel.SetActive(true);
                indicator.gameObject.GetComponent<Tower>().rangeModel.SetActive(false);
                indicator.gameObject.GetComponent<Tower>().noPlaceModel.transform.localScale = new Vector3(activeTower.range, 1f, activeTower.range);
            }
            else
            {
                if (indicator.gameObject.GetComponent<Tower>().noPlaceModel.activeSelf)
                {
                    indicator.gameObject.GetComponent<Tower>().noPlaceModel.SetActive(false);
                    indicator.gameObject.GetComponent<Tower>().rangeModel.SetActive(true);
                }
                indicator.gameObject.SetActive(true);

                UIController.instance.notEnoughMoneyWarning.SetActive(MoneyManager.instance.currentMoney < activeTower.cost);

                if (Input.GetMouseButtonDown(0))
                {
                    if (MoneyManager.instance.SpendMoney(activeTower.cost))
                    {

                        isPlacing = false;

                        Instantiate(activeTower, indicator.position, activeTower.transform.rotation);

                        indicator.gameObject.SetActive(false);

                        UIController.instance.notEnoughMoneyWarning.SetActive(false);

                        AudioManager.instance.PlaySFX(8);
                    }
                }else if (Input.GetMouseButtonDown(1))
                {
                    isPlacing = false;
                    indicator.gameObject.SetActive(false);//removes indicator once spell is placed
                    UIController.instance.notEnoughMoneyWarning.SetActive(false); //removes not enough money warning if active
                }
            }
        }
    }

    public void StartTowerPlacement(Tower towerToPlace)
    {
        activeTower = towerToPlace;

        isPlacing = true;

        Destroy(indicator.gameObject);
        Tower placeTower = Instantiate(activeTower);
        placeTower.enabled = false;
        placeTower.GetComponent<Collider>().enabled = false;
        indicator = placeTower.transform;

        placeTower.rangeModel.SetActive(true);
        placeTower.rangeModel.transform.localScale = new Vector3(placeTower.range, 1f, placeTower.range);
    }

    public Vector3 GetGridPosition()
    {
        Vector3 location = Vector3.zero;


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 200f, Color.red);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 200f,  whatIsPlacement))
        {
            location = hit.point;
        }

        location.y = 0f;

        return location;
    }

    public void MoveTowerSelectionEffect()
    {
        if(selectedTower != null & !isPlacing)
        {
            selectedTowerEffect.transform.position = selectedTower.transform.position;
            selectedTowerEffect.SetActive(true);
        }
    }
}
