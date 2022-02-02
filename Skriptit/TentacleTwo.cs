using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleTwo : MonoBehaviour
{
    [SerializeField] int length;
    [SerializeField] LineRenderer lineRend;
    [SerializeField] Vector3[] segmentPoses;
    [SerializeField] Vector3[] segmentV;

    [SerializeField] Transform targetDir;
    [SerializeField] float targetDist;
    [SerializeField] float smoothSpeed;

    [SerializeField] float wiggleSpeed;
    [SerializeField] float wiggleMagnitude;
    [SerializeField] Transform wiggleDir;

    [SerializeField] Transform[] bodyParts;


    private void Start()
    {
        lineRend.positionCount = length;
        lineRend = GetComponent<LineRenderer>();
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];

        //ResetPos();
    }
    void Update()
    {

        wiggleDir.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);


        segmentPoses[0] = targetDir.position;

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            Vector3 targetPos = segmentPoses[i - 1] + (segmentPoses[i] - segmentPoses[i - 1]).normalized * targetDist;
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], targetPos, ref segmentV[i], smoothSpeed);
            //bodyParts[i - 1].transform.position = segmentPoses[i];

        }
        lineRend.SetPositions(segmentPoses);

    }

    //private void ResetPos()
    //{
       // segmentPoses[0] = targetDir.position;
       // for (int i = 1; i < length; i++)
       // {
        //    segmentPoses[i] = segmentPoses[i - 1] + targetDir.right * targetDist;
     //   }
      //  lineRend.SetPositions(segmentPoses);

  // }

}
