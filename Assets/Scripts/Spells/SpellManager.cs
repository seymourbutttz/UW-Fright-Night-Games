using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{

    public static SpellManager instance; //this instance of the spell manager

    private void Awake()
    {
        instance = this;
    }

    public Spells activeSpell; //active spell to place

    public Transform indicator; //placement indicator
    public bool isPlacing; //true when placing an object

    public LayerMask whatIsPlacement;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlacing)
        {
            indicator.position = GetGridPosition(); //assigns indicator position to mouse position

            if(Input.GetMouseButtonDown(0)) //places spell after mouse click
            {
                isPlacing = false;
                Instantiate(activeSpell, indicator.position, activeSpell.transform.rotation); //generates a copy of spell
                indicator.gameObject.SetActive(false); //removes indicator once spell is placed
            }
        }
    }

    public void StartSpellPlacement(Spells spellToPlace)
    {
        activeSpell = spellToPlace; //the active spell
        isPlacing = true; //starting to place something

        Destroy(indicator.gameObject);
        Spells placeSpell = Instantiate(activeSpell); //creates a copy of the meteor shower so we can see where it will be placed
        placeSpell.GetComponent<MeteorShower>().enabled = false;
        indicator = placeSpell.transform;
        
    }

    //gets mouse position
    public Vector3 GetGridPosition()
    {
        Vector3 location = Vector3.zero;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //assigns ray from camera to mous pos
        Debug.DrawRay(ray.origin, ray.direction * 200f, Color.red); //draws ray on screen

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 200f, whatIsPlacement))
        {
            location = hit.point; //point where raycast hits the world
        }
        location.y = 0f;

        return location;

    }
}
