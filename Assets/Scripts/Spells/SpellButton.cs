using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellButton : MonoBehaviour
{
    public Spells spellToPlace;
    
    public void SelectSpell()
    {
        //Debug.Log("pressed");

        SpellManager.instance.StartSpellPlacement(spellToPlace);
    }
}
