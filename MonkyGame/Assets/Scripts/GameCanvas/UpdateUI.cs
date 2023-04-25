using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateUI : MonoBehaviour
{
    [SerializeField] private GameObject ObjectPrefab;
    private TextMeshProUGUI UIText;
    private int count;

    private void Awake()
    {
        UIText = GetComponent<TextMeshProUGUI>();
        count = ObjectPrefab.GetComponent<CollectObject>().peanutCount;
    }

    private void LateUpdate()
    {
        count = ObjectPrefab.GetComponent<CollectObject>().peanutCount;
        UIText.text = count.ToString();
    }
}
