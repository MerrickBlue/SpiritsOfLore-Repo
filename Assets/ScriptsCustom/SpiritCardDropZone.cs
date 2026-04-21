using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CardFanUI;

public class SpiritCardDropZone : UIDropHandler
{
    [SerializeField] protected TextMeshProUGUI spiritPowerText;
    protected int spiritPower = 0;
    protected int maxSpiritPower = 12;

    public override void OnDrop(UnityEngine.EventSystems.PointerEventData eventData)
    {
        var cardComponent = eventData.pointerDrag.GetComponent<AbilityCards>();

        if (spiritPower + cardComponent.abilityCost > maxSpiritPower)
        {
            Debug.Log("Cannot add more spirit power. Maximum reached.");
            return;
        }

        if (cardComponent != null)
        {
            spiritPower += cardComponent.abilityCost;
            if (spiritPowerText != null)
            {
                spiritPowerText.text = spiritPower.ToString() + "/12";
            }
        }


        base.OnDrop(eventData);

        //Once the card dropped as in the previous script we can attach to this drop zone and:
        //Disable the dragging.
        //Add it's value to the total spirit power.
        var dragged = eventData.pointerDrag.transform;
        var dragNote = dragged.GetComponent<UIDragCard>();

        //Disable the dragging.
        dragNote.enabled = false;

        dragged.SetParent(this.transform);
        dragged.rotation = Quaternion.identity; // Reset rotation to default when dropped in the zone.
    }
}
