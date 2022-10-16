using UnityEngine;

public class OverviewPanelScript : MonoBehaviour
{
    private void Awake()
    {
       LeanTween.moveLocalX(gameObject, 0f, 1f);   
    }
}
