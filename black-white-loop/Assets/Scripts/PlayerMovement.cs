using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject player;

    [SerializeField] private float playerVelocity;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 newMovement = new Vector3(inputX * playerVelocity,
            inputY * playerVelocity , 0f);
        
        gameObject.transform.Translate(newMovement * Time.deltaTime);
    }
}
