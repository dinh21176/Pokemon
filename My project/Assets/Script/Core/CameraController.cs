
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //ROOM CAMERA
    [SerializeField] private float speed;
    private float currentPosX;
    private Vector3 velocity = Vector3.zero;

    //FOLLOW PLAYER
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float CameraSpeed;
    private float lookAhead;


    private void Update()
    {
        //ROOM CAMERA
        //transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), ref velocity,speed);

        //FOLLOW PLAYER
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * CameraSpeed);
    }
    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosX = _newRoom.position.x;
    }
}
