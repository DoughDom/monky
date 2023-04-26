using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateUI : MonoBehaviour
{
    [SerializeField] private GameObject PeanutPrefab;
    [SerializeField] private GameObject GoalPrefab;
    private TextMeshProUGUI UIText;
    private int count;
    private int totalCount;

    private void Awake()
    {
        UIText = GetComponent<TextMeshProUGUI>();
        count = PeanutPrefab.GetComponent<CollectObject>().peanutCount;
        totalCount = GoalPrefab.GetComponent<Goal>().totalPeanuts;
    }

    private void LateUpdate()
    {
        count = PeanutPrefab.GetComponent<CollectObject>().peanutCount;
        UIText.text = (count.ToString() + "/" + totalCount.ToString());
    }
}
