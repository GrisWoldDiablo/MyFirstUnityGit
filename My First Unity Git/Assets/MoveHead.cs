using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Limit
{
    public float top;
    public float bottom;
}

public class MoveHead : MonoBehaviour
{
    [SerializeField] private Limit limit;
    [SerializeField] private Vector3 currentEuler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xDir = Input.GetAxis("Mouse X");
        float yDir = Input.GetAxis("Mouse Y");
        transform.Rotate(-yDir, xDir, 0.0f);
        currentEuler = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
        if (transform.rotation.eulerAngles.x < 360+limit.top && transform.rotation.eulerAngles.x > 360 + -90.0f)
        {
            transform.rotation = Quaternion.Euler(limit.top, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        else if (transform.rotation.eulerAngles.x > limit.bottom && transform.rotation.eulerAngles.x < 90.0f)
        {
            transform.rotation = Quaternion.Euler(limit.bottom, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0.0f);

    }
}
