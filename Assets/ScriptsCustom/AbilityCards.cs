using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AbilityCards : MonoBehaviour
{
    public int abilityCost;

    [SerializeField] protected TextMeshProUGUI abilityCostText;

    private void Start()
    {
        abilityCost = Random.Range(1, 5); // Randomly assign a cost between 1 and 4 for testing purposes.

        if (abilityCostText != null)
        {
            abilityCostText.text = abilityCost.ToString();
        }
    }

}
