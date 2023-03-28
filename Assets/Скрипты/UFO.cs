using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    public Rigidbody body;
    public float angularPower = 5;
    public float impulseMovePower = 20;

    public Transform target;

    public float attackTimer = 0;
    public float attaclDelayMin = 1;
    public float attaclDelayMax = 7;

    void Start ()
    {
        Player.enemies.Add(this);
        target = GameObject.FindGameObjectWithTag("Player").transform;
        attackTimer = Random.Range(1f, 2f);

    }

    void Update()
    {
        if (target != null)
        {
            TurnTo(target.position);

            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attackTimer = Random.Range(attaclDelayMin, attaclDelayMax);
                MoveImpulseTo(target.position);
            }
        }
    }

    void MoveImpulseTo(Vector3 position)
    {
        // Целевое направление
        Vector3 direction = position - transform.position;
        Vector3 force = direction.normalized * impulseMovePower;
        body.AddForce(force, ForceMode.Impulse);
    }

    void TurnTo(Vector3 position)
    {
        // Целевое направление
        Vector3 direction = position - transform.position;
        // Текущее направление взгляда
        Vector3 facing = transform.forward;
        // Угол между этими величинами
        float angle = Vector3.SignedAngle(facing, direction, Vector3.up);

        // Направление вращения по/против часовой
        // или без вращения
        float sign = Mathf.Sign(angle);
        // Модуль (величина) текущего угла между
        // целевой точкой и направление взгляда
        float angleAbs = Mathf.Abs(angle);

        Vector3 force;
        if (angleAbs >= 4)
        {
            // Если угол большой 
            //нужно поворачиваться к цели
            force = sign * Vector3.up * angularPower
                * angleAbs / 45;
        }
        else
        {
            // Если угол маленький
            // нужно затормозить вращение
            force = -body.angularVelocity * angularPower;
        }
        body.AddTorque(force, ForceMode.Acceleration);
    }

    void OnDestroy()
    {
        Player.enemies.Remove(this);
    }
}
