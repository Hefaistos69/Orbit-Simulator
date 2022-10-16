using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public GameObject SateliteView;

    [HideInInspector] public bool LeanIsCalled = false;
    [HideInInspector] public GameObject SateliteViewPanel;

    [SerializeField] private float fSmoothSpeed = 0.125f;

    private bool Fixed = false;
    

    private void LateUpdate()
    {
        float distance = Vector3.Distance(SateliteView.transform.position, transform.position);
        if (distance < 4f && !Fixed)
            Fixed = true;
        else if (distance > 20f)
            Fixed = false;

        if(!Fixed)
        {
            

            Vector3 desirePosition = SateliteView.transform.position;
            Quaternion desireRotation = SateliteView.transform.rotation;
            Vector3 SmoothPosition = Vector3.Lerp(transform.position, desirePosition, fSmoothSpeed * 1 / distance * Time.deltaTime);
            Quaternion SmoothRotation = Quaternion.Lerp(transform.rotation, desireRotation, fSmoothSpeed * 1 / distance * Time.deltaTime);
            transform.position = SmoothPosition;
            transform.rotation = SmoothRotation;
        }
        else 
        {
            if (LeanIsCalled)
            {
                LeanTween.moveLocalX(SateliteViewPanel, 0f, 0.5f);
                LeanIsCalled = false;
            }
            transform.position = SateliteView.transform.position;
            transform.rotation = SateliteView.transform.rotation;
        }

    }

    
}
