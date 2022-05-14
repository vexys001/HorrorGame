using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSmoking : MonoBehaviour
{
    public GameObject CigaretteGO;
    public Transform ItemHolder;
    private bool _isSmoking;

    private float timer;
    private float SmokingDuration = 15;

    // Start is called before the first frame update
    void Start()
    {
        _isSmoking = false;
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
            CigaretteGO.transform.localRotation = Quaternion.Euler(0,0, 180);
        }

        if (_isSmoking)
        {
            timer += Time.deltaTime;

            if(timer >= SmokingDuration)
            {
                _isSmoking = false;
                timer = 0;

                //Remove Cigarette
                CigaretteGO.transform.SetParent(null);
                CigaretteGO.transform.position = new Vector3(100,100,100);

                SmokingManager.Instance.StopSmoking();
            }
        }
    }
}
