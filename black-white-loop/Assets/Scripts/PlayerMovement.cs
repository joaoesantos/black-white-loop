using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private float playerVelocity;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 newMovement = new Vector3(inputX * playerVelocity,
            inputY * playerVelocity , 0f);

        _animator.SetBool("isWalking", newMovement != Vector3.zero);
        gameObject.transform.Translate(newMovement * Time.deltaTime);
        
        Rotate();
    }
    
    private void Rotate()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 target = Camera.main.ScreenToWorldPoint(mousePos);
   
        Vector3 relative = target - transform.position;

        float rotz = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
    }
}
