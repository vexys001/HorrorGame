using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSmoking : MonoBehaviour
{
    public GameObject CigaretteGO;
    public Transform ItemHolder;
    public MonoBehaviour[] CameraEffects;

    private bool _isSmoking;

    private float timer;
    private float SmokingDuration = 7;

    private bool _VFXActive;
    private float VFXStart;
    private float VFXtimer;
    private float VFXDuration;

    // Start is called before the first frame update
    void Start()
    {
        _isSmoking = false;
        _VFXActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !_isSmoking)
        {
            //Start smoking
            SmokingManager.Instance.StartSmoking();
            _isSmoking = true;

            //Placing the cigarette
            CigaretteGO.transform.parent = ItemHolder;

            CigaretteGO.transform.localPosition = Vector3.zero;
            CigaretteGO.transform.localRotation = Quaternion.Euler(0, 0, 180);

            VFXStart = Random.Range(1, 2f);
            VFXDuration = Random.Range(2, 4.99f);
        }

        if (_isSmoking)
        {
            timer += Time.deltaTime;

            VFXtimer += Time.deltaTime;

            if (timer >= SmokingDuration)
            {
                _isSmoking = false;
                
                timer = 0;
                VFXtimer = 0;

                _VFXActive = false;

                //Remove Cigarette
                CigaretteGO.transform.SetParent(null);
                CigaretteGO.transform.position = new Vector3(100, 100, 100);

                SmokingManager.Instance.StopSmoking();
            }
            else if (VFXtimer >= VFXStart + VFXDuration && _VFXActive)
            {
                //_VFXActive = false;
                foreach (MonoBehaviour effect in CameraEffects)
                {
                    effect.enabled = false;
                }
            }
            else if (VFXtimer >= VFXStart && !_VFXActive)
            {
                _VFXActive = true;
                float random;
                float probability = 0.75f;

                foreach (MonoBehaviour effect in CameraEffects)
                {
                    random = Random.Range(0, 1f);
                    Debug.Log($"{random} so ");
                    if (random <= probability)
                    {
                        Debug.Log($"{effect.name} activated");
                        probability *= 0.5f;
                        effect.enabled = true;
                    }
                }
            }
        }
    }
}
