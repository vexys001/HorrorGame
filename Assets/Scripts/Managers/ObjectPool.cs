using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public enum ObjectType { Enemy, Ring }

    [SerializeField] public Stack<GameObject> PooledObjects = new Stack<GameObject>();
    public ObjectType _objType;

    //public UIManager UiMngr;

    private void Awake()
    {
        int count = transform.childCount;

        for (int i = 0; i < count; i++)
        {
            AddObject(transform.GetChild(i).gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddObject(GameObject obj)
    {
        PooledObjects.Push(obj);

        obj.gameObject.transform.SetParent(gameObject.transform);
        obj.SendMessage("StartIdle");

        obj.transform.localPosition = Vector3.zero;
        obj.transform.localRotation = Quaternion.identity;

        /*if (_objType == ObjectType.Ring)
        {
            UiMngr.SetAmmoText(this.Count().ToString());
        }*/
    }

    public GameObject RemoveObject()
    {
        if (PooledObjects.Count > 0)
        {
            GameObject temp = PooledObjects.Pop();

            /*if (_objType == ObjectType.Ring)
            {
                UiMngr.SetAmmoText(this.Count().ToString());
            }*/

            return temp;
        }
        else return null;
    }

    public int Count()
    {
        return PooledObjects.Count;
    }
}
