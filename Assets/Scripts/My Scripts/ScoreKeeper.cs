using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private TextMeshProUGUI textMesh;

    public int GetScore()
    {
        return score;
    }
    private void SetScore(int increment)
    {
        score += increment;
        if (textMesh == null)
        {
            Debug.LogWarning($"Score Textmesh has no Reference!");
            return;
        }
        textMesh.text = $"Score: {score}";
    }
    private void ResetScore()
    {
        score = 0;
    }
    public void Awake()
    {
        GearPickup.OnPickupEvent += SetScore;
        SetScore(0);
    }
    public void OnDestroy()
    {
        GearPickup.OnPickupEvent -= SetScore;
    }
}
