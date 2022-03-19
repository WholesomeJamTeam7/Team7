using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlWall : MonoBehaviour
{
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AxisMovementController();
    }

    void AxisMovementController()
    {
        Vector3 currentMovement = Vector3.zero;
        currentMovement.x = Input.GetAxis("Horizontal");
        //currentMovement.y = Input.GetAxis("Vertical");
        transform.Translate(currentMovement * speed * Time.deltaTime);
    }

}
 
