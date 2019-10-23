using UnityEngine;

public class RotationController : MonoBehaviour {

    public ColorPalleteManager colorPalleteManager;
    public GameObject colorCirclePrefab;
    public int numberOfCircles;
    public float radius;
    public float rotationSpeed;
    public Sprite mainCircleSprite;
    public Sprite mainCWCirlceSprite;
    public Sprite mainACWCircleSprite;

	Vector2 intialTouchPosition;
	Vector2 currentTouchPosition;
	float angle;
	float rotatingAngle;
    float gapBetweenCircles;


    void Start () {
        gapBetweenCircles = 360f / numberOfCircles;
	}
	
	void Update () {
        //InputManager();
        RotationInput();
    }

    public void IncreaseSize()
    {
        transform.localScale = new Vector3(transform.localScale.x + 0.2f, transform.localScale.y + 0.2f, transform.localScale.z);
    }

    //void InputManager()
    //{

    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        intialTouchPosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y) - new Vector2(transform.position.x, transform.position.y);
    //    }

    //    if (Input.GetMouseButton(0))
    //    {

    //        currentTouchPosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y) - new Vector2(transform.position.x, transform.position.y);

    //        angle = Vector2.SignedAngle(intialTouchPosition, currentTouchPosition);

    //        //With Slerp Effect
    //        //transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.AngleAxis(angle + rotatingAngle, transform.forward),1f * Time.deltaTime);

    //        //Without Slerp Effect
    //        transform.rotation = Quaternion.AngleAxis(angle + rotatingAngle, transform.forward);
    //    }

    //    if (Input.GetMouseButtonUp(0))
    //    {

    //        if (transform.eulerAngles.z > 180f)
    //        {
    //            rotatingAngle = Quaternion.Angle(Quaternion.identity, transform.localRotation);
    //            rotatingAngle = -rotatingAngle;
    //        }
    //        else if (transform.eulerAngles.z < 180f)
    //        {
    //            rotatingAngle = Quaternion.Angle(Quaternion.identity, transform.localRotation);
    //        }

    //    }
    //}

    void RotationInput()
    {
        if (Input.GetMouseButton(0))
        {
            if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x > 0f)
            {
                transform.RotateAround(transform.position, Vector3.forward, 10 * rotationSpeed * Time.deltaTime);
                GetComponent<SpriteRenderer>().sprite = mainACWCircleSprite;

            }
            else
            {
                transform.RotateAround(transform.position, Vector3.forward, -10 * rotationSpeed * Time.deltaTime);
                GetComponent<SpriteRenderer>().sprite = mainCWCirlceSprite;

            }

        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = mainCircleSprite;
        }
    }
}
