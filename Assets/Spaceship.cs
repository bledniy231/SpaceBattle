using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {

    [Tooltip("Тело нашего корябля")]
    public Rigidbody rbody;

    [Tooltip("Мощность двигателя")]
    public float enginePower = 5;

    [Tooltip("Мощность двигателя")]
    public float impulsePower = 30;

    [Tooltip("Заряд двигателя (от 0 до 1)")]
    public float impulseBattery = 0;

    [Tooltip("Скорость зарядки двигателя")]
    public float impulseBatteryChargeSpeed = 1;

    [Tooltip("Максимальная скорость")]
    public float maxSpeed = 20;

    void Start()
    {
        Player.spaceship = this;
    }

    void OnDestroy()
    {
        Player.spaceship = null;
    }

    void Update ()
    {
        // Если нажата клавиша W и S НЕ нажата
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            // Полный вперед!
            Move(1);
        }

        // Если нажата клавиша S и W НЕ нажата
        if (!Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            // Полный назад!
            Move(-1);
        }

        // Если нажаты клавиши S и W
        // Стабилизровать движение
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            // Стоп машина!
            StopMoving();
        }

        // Если нажата клавиша A
        if (Input.GetKey(KeyCode.A))
        {
            // Лево руля!
            Turn(-1);
        }

        // Если нажата клавиша D
        if (Input.GetKey(KeyCode.D))
        {
            // Право руля!
            Turn(1);
        }

        // Если не нажата ни A ни D
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            // Стабилизировать поворот
            StopTurn();
        }


        if (Input.GetKey(KeyCode.Space))
        {
            if (impulseBattery < 1)
            {
                impulseBattery += impulseBatteryChargeSpeed * Time.deltaTime;
            }
            impulseBattery = Mathf.Clamp(impulseBattery, 0, 1);
        }


        if (Input.GetKeyUp(KeyCode.Space))
        {
            Jump();
        }
        
    }

    void StopMoving()
    {
        if (rbody.velocity.magnitude > 0)
        {
            Vector3 force = -rbody.velocity * enginePower;
            rbody.AddForce(force, ForceMode.Acceleration);
        }
    }

    // direction == 1 - движение вперед
    // direction == -1 - движение назад
    void Move(int direction)
    {
        if (rbody.velocity.magnitude <= maxSpeed)
        {
            // Придание ускорение вперед/назад нашему телу
            Vector3 force = transform.forward * enginePower * direction;
            rbody.AddForce(force, ForceMode.Acceleration);
        }
    }

    // direction == 1 - по часовой
    // direction == -1 - против часовой
    void Turn(int direction)
    {
        if (rbody.angularVelocity.magnitude <= maxSpeed)
        {
            // Придание ускорение вращения по/против часовой стрелки
            Vector3 force = Vector3.up * enginePower * direction;
            rbody.AddTorque(force, ForceMode.Acceleration);
        }
    }


    void StopTurn()
    {
        if (rbody.angularVelocity.magnitude > 0)
        {
            // Придание ускорение вращения по/против часовой стрелки
            Vector3 force = -rbody.angularVelocity * enginePower;
            rbody.AddTorque(force, ForceMode.Acceleration);
        }
    }
    void Jump()
    {
        Vector3 force = transform.forward * impulsePower * impulseBattery;
        rbody.AddForce(force, ForceMode.Impulse);
        impulseBattery = 0;
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
