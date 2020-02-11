using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Automatic Gun", menuName = "Guns/Manual")]
public class Manual : Gun
{
    public override void OnMouseDown(Transform cameraPos)
    {
        RaycastHit whatIHit;
        if (Physics.Raycast(cameraPos.position, cameraPos.forward, out whatIHit, Mathf.Infinity))
        {
            IDamageble damageble = whatIHit.collider.GetComponent<IDamageble>();
            if (damageble != null)
            {
                float normalizedDistance = whatIHit.distance / maxRange;
                if (normalizedDistance <= 1)
                {
                    damageble.DealDamage(Mathf.RoundToInt(Mathf.Lerp(maxDamage, minDamage, normalizedDistance)));
                    Debug.Log(whatIHit.collider.name);
                }
            }
        }
    }
}