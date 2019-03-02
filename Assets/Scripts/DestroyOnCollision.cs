using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public enum Event { Enter, Exit };

    public Event        eventType;
    public string[]     tags;
    public GameObject   effect;
    public bool         accountForInvulnerability = false;

    InvulnerabilityController   ivc;

    private void Start()
    {
        ivc = GetComponent<InvulnerabilityController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (eventType == Event.Exit) return;
        if (accountForInvulnerability)
        {
            if (ivc)
            {
                if (ivc.enabled) return;
            }
            InvulnerabilityController otherIvc = collision.gameObject.GetComponent<InvulnerabilityController>();
            if (otherIvc)
            {
                if (otherIvc.enabled) return;
            }
        }

        foreach (var s in tags)
        {
            if (s == collision.tag)
            {
                Destroy(gameObject);

                if (effect)
                {
                    Instantiate(effect, transform.position, transform.rotation);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (eventType == Event.Enter) return;

        if ((ivc) && (accountForInvulnerability))
        {
            if (ivc.enabled) return;
        }

        foreach (var s in tags)
        {
            if (s == collision.tag)
            {
                Destroy(gameObject);

                if (effect)
                {
                    Instantiate(effect, transform.position, transform.rotation);
                }
            }
        }
    }
}
