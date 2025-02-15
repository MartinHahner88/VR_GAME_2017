using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VibrationsV3 : MonoBehaviour
{
    
    SteamVR_Controller.Device deviceR;
    public SteamVR_TrackedObject trackedObjR;
    SteamVR_Controller.Device deviceL;
    public SteamVR_TrackedObject trackedObjL;

	public bool vibrate;

	void Start () {
		deviceR = SteamVR_Controller.Input((int)trackedObjR.index);
		deviceL = SteamVR_Controller.Input((int)trackedObjL.index);

		vibrate = true;
	}

	void rumbleController()
	{

		StartCoroutine(LongVibration(2.5f, 3999));

	}

	IEnumerator LongVibration(float length, float strength)
	{
		for (float i = 0; i < length; i += Time.deltaTime)
		{
			deviceR.TriggerHapticPulse((ushort)Mathf.Lerp(0, 3999, strength));
			deviceL.TriggerHapticPulse((ushort)Mathf.Lerp(0, 3999, strength));
			yield return null;
		}
	}

	// Update is called once per frame
	void Update () {

		if (vibrate == true) {
			rumbleController ();

			vibrate = false;
		}
	}
}
