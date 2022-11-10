using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class Shoot : MonoBehaviour
{
    private bool grabbing;
    private bool gripped;
    private bool charged;
    public float await;
    public GameObject prefab;
    public GameObject positionReference;
    private GameObject newObject;
    Vector3 velosity;
    Vector3 lastposition;
    public InputActionReference gripInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float grip = gripInput.action.ReadValue<float>();
        if (grip > 0.7 && !gripped && !charged)
        {
            gripped = true;
            StartCoroutine(Summon());
        }

        if (grip < 0.7 && charged)
        {
            Drop();
            gripped = false;
        }
    }

    private void FixedUpdate()
    {
        velosity = transform.position - lastposition;
        lastposition = transform.position;
    }

    public IEnumerator Summon()
    {
        
        float counter = 0;
        while (counter < await)
        {
            counter += Time.deltaTime;
            yield return null;
            float grip = gripInput.action.ReadValue<float>();
            if (grip < 0.7)
            {
                gripped = false;
                yield break;
            }
        }
        newObject = Instantiate(prefab, positionReference.transform);
        newObject.transform.localPosition = Vector3.zero;
        charged = true;

    }

    public void Drop()
    {
        charged = false;
        newObject.transform.SetParent(null);
        newObject.GetComponent<Rigidbody>().isKinematic = false;
        newObject.GetComponent<Rigidbody>().velocity = velosity * 10000 * Time.fixedDeltaTime;
    }

}
