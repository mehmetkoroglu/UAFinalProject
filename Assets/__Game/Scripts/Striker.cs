using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Striker : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform missilePlace;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                GameObject missleClone = Instantiate(missilePrefab, missilePlace.position, Quaternion.identity);
                missleClone.GetComponent<Missile>().target = hit.point;
            }
        }
    }

}
