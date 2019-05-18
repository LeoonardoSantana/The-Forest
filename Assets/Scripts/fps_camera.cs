using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class fps_camera : MonoBehaviour
{
	public float speed = 3.5f;
    public float gravity = 10f;
    private CharacterController controller;
    public Text countText;
    public Text winText;
    public Camera fpsCamera;
	private int count;
	public Button inicio;


	

	// Start is called before the first frame update
	void Start()
	{
		controller = GetComponent<CharacterController>();
		count = 0;
		setCounText();
		winText.text = "";	
	}
	
	// Update is called once per frame
	void Update()
	{
		if(count == 10){
			winText.text = "¡Has limpiado todo el bosque!";
		}
		
		float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float zMov = Input.GetAxisRaw("Jump");

        Vector3 diretion = new Vector3(h, zMov*5, v);
        Vector3 velocity = diretion * speed;
        velocity = Camera.main.transform.TransformDirection(velocity);
        velocity.y -= gravity;
        controller.Move(velocity * Time.deltaTime);
		
		/*h = horizontalSpeed * Input.GetAxis("Mouse X");
		v = verticalSpeed * Input.GetAxis("Mouse Y");
		
		transform.Rotate(0,h,0);
		fpsCamera.transform.Rotate(v,0,0);
		
		if(Input.GetKey(KeyCode.A)){
			transform.Translate(-0.2f,0,0);
		}else{
			if(Input.GetKey(KeyCode.D)){
				transform.Translate(0.2f,0,0);
			}else{
				if(Input.GetKey(KeyCode.S)){
					transform.Translate(0,0,-0.2f);
				}else{
					if(Input.GetKey(KeyCode.W)){
						transform.Translate(0,0,0.2f);
					}
				}
			}
		}*/
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Trash"))
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			setCounText();
		}
	}
	
	void setCounText()
	{
		countText.text = "Basura Recogida:  " + count.ToString() + "/10";
	}
}
