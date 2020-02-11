using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField]
    private List<Gun> guns = new List<Gun>();

    private Transform cameraTransform;
    private Gun currentGun;
    private GameObject currentGunPrefab;

    private void Start() {
        cameraTransform = Camera.main.transform;
        currentGunPrefab = Instantiate(guns[0].gunPrefab, transform);
        currentGun = guns[0];
    }

    private void Update()
    {
        CheckForShooting();
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Destroy(currentGunPrefab);
            currentGunPrefab = Instantiate(guns[0].gunPrefab, transform);
            currentGun = guns[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Destroy(currentGunPrefab);
            currentGunPrefab = Instantiate(guns[1].gunPrefab, transform);
            currentGun = guns[1];
        }
    }

    private void CheckForShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentGun.OnMouseDown(cameraTransform);
        }
        if (Input.GetMouseButton(0)) {
            currentGun.OnMouseHold(cameraTransform);
        }
    }
}
