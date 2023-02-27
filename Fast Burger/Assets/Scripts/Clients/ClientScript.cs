using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClientScript : MonoBehaviour
{
    public enum Behaviour
    {
        Order,
        Think,
        Wait,
        Judge,
        React,
        GetOut,
    }
    public Behaviour behaviour;

    Animator anim;
    NavMeshAgent agent;

    Transform orderPoint;
    Transform lookPoint;
    Transform exitPoint;

    public bool thinking;
    public bool judging;
    [Space]
    public Renderer face;
    public Texture[] expressions;
    public int satisfaction;

    void Start()
    {
        behaviour = Behaviour.Order;

        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();

        orderPoint = GameObject.Find("Client Point").transform;
        lookPoint = GameObject.Find("Client Look").transform;
        exitPoint = GameObject.Find("Client Despawn").transform;
    }

    void Update()
    {
        switch(behaviour)
        {
            case Behaviour.Order:
                Order();
                break;
            case Behaviour.Think:
                Think();
                break;
            case Behaviour.Wait:
                Wait();
                break;
            case Behaviour.Judge:
                Judge();
                break;
            case Behaviour.React:
                React();
                break;
            case Behaviour.GetOut:
                GetOut();
                break;
        }

        anim.SetFloat("Speed", agent.velocity.magnitude);
    }

    void Order()
    {
        agent.SetDestination(orderPoint.position);

        if(Vector3.Distance(transform.position, orderPoint.position) <= 0.05f)
        {
            behaviour = Behaviour.Think;
        }
    }

    void Think()
    {
        thinking = true;
        anim.SetBool("Think", true);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation((lookPoint.position - transform.position)), .05f);
    }

    void Wait()
    {
        thinking = false;
        anim.SetBool("Think", false);
        
    }

    void Judge()
    {
        anim.SetBool("Judge", true);
        anim.SetBool("React", false);

        face.material.mainTexture = expressions[0];
    }

    void React()
    {
        anim.SetBool("Judge", false);
        anim.SetBool("React", true);
        anim.SetInteger("Satisfaction", satisfaction);
        face.material.mainTexture = expressions[satisfaction];
    }

    void GetOut()
    {
        agent.SetDestination(exitPoint.position);

        if (Vector3.Distance(transform.position, exitPoint.position) <= 1f)
        {
            Destroy(gameObject);
        }
    }
}
