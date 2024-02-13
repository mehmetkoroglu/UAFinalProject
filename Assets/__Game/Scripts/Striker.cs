using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Striker : MonoBehaviour
{
    [SerializeField] private GameObject misslePrefab;
    [SerializeField] private Transform misslePlace;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                GameObject missleClone = Instantiate(misslePrefab, misslePlace.position, Quaternion.identity);
                missleClone.GetComponent<Missle>().target = hit.point;
            }
        }
    }
   
}
