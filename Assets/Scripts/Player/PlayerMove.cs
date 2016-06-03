using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using CnControls;

public class PlayerMove : MonoBehaviour
{

	public float moveSpeed;

	//	private Image bgImage;
	//	private Button joystickImage;
	//	private Vector3 inputVector;

	void Update()
	{
		
		if (CnInputManager.GetAxis("Horizontal") < 0) {
			transform.rotation = Quaternion.Euler(0, -90, 0);
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		}

		if (CnInputManager.GetAxis("Vertical") < 0) {
			transform.rotation = Quaternion.Euler(0, 180, 0);
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		}
		if (CnInputManager.GetAxis("Vertical") > 0) {
			transform.rotation = Quaternion.Euler(0, 0, 0);
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		}
		if (CnInputManager.GetAxis("Horizontal") > 0) {
			transform.rotation = Quaternion.Euler(0, 90, 0);
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		}
			
	}

	//	void Start()
	//	{
	//		bgImage = GetComponent<Image>();
	//		joystickImage = transform.GetChild(0).GetComponent<Image>();
	//	}
	//
	//	public virtual void OnPointerDown(PointerEventData ped)
	//	{
	//
	//	}
	//
	//	public virtual void OnPointerUp(PointerEventData ped)
	//	{
	//		OnDrag(ped);
	//	}
	//
	//	public virtual void OnDrag(PointerEventData ped)
	//	{
	//
	//	}
}
