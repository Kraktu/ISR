using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayResource : MonoBehaviour
{
    [SerializeField] Resource resource;
    TextMeshProUGUI resourceNbrTMP;
    void Start()
    {
        resourceNbrTMP = transform.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        resourceNbrTMP.text = resource.GetResourceNumber().GetFormatedBigDouble();
    }
}
