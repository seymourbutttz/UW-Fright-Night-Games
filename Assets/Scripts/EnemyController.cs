using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    [HideInInspector]
    public float speedMod = 1f;

    private Path thePath;
    private int currentPoint;
    private bool reachedEnd;

    public float timeBetweenAttacks, damagePerAttack;
    private float attackCounter;

    private Castle theCastle;

    private int selectedAttackPoint;

    public bool isFlying;
    public float flyHeight;


    public void Setup(Castle newCastle, Path newPath)
    {
        theCastle = newCastle;
        thePath = newPath;
    }

    void Start()
    {
        if (thePath == null){ thePath = findPath(); }

        if (theCastle == null){ theCastle = findCastle(); }

        attackCounter = timeBetweenAttacks;

        if(isFlying)
        {
            transform.position += Vector3.up * flyHeight;
            currentPoint = thePath.points.Length - 1;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (LevelManager.instance.levelActive)
        {
            if (reachedEnd == false)
            {
                transform.LookAt(thePath.points[currentPoint]);

                if (!isFlying)
                {
                    transform.position = moveToPoint(transform.position, thePath.points[currentPoint].position, false, moveSpeed * Time.deltaTime * speedMod);

                    checkReachedEnd(transform.position, thePath.points[currentPoint].position, false, moveSpeed, flyHeight);
                } else
                {
                    transform.position = moveToPoint(transform.position, thePath.points[currentPoint].position, true, moveSpeed * Time.deltaTime * speedMod);

                    checkReachedEnd(transform.position, thePath.points[currentPoint].position, true, moveSpeed, flyHeight);
                }
            }
            else
            {
                if (!isFlying)
                {
                    transform.position = moveToPoint(transform.position, theCastle.attackPoints[selectedAttackPoint].position, false, moveSpeed * Time.deltaTime * speedMod);
                    
                    checkReachedEnd(transform.position, thePath.points[currentPoint].position, false, moveSpeed);
                } else
                {
                    transform.position = moveToPoint(transform.position, theCastle.attackPoints[selectedAttackPoint].position,true, moveSpeed * Time.deltaTime * speedMod,flyHeight);

                    checkReachedEnd(transform.position, thePath.points[currentPoint].position, true, moveSpeed, flyHeight);
                }

                attackCounter -= Time.deltaTime;
                if (attackCounter <= 0)
                {
                    attackCounter = timeBetweenAttacks;

                    theCastle.TakeDamage(damagePerAttack);
                }
            }
        }
    }

    private Vector3 moveToPoint(Vector3 _nextPoint, Vector3 _previousPoint, bool _isFlying, float speed, float _flyHeight = 0)
    {
        if (_isFlying)
        {
            return Vector3.MoveTowards(_nextPoint, _previousPoint + (Vector3.up * _flyHeight), speed);
        }
        else
        {
            return Vector3.MoveTowards(_nextPoint, _previousPoint, speed);
        }
    }

    private float distanceToPoint(Vector3 _pointA, Vector3 _pointB, bool _isFlying, float speed, float _flyHeight = 0)
    {
        if (_isFlying)
        {
            return Vector3.Distance(_pointA, _pointB + (Vector3.up * _flyHeight));
        }
        else
        {
            return Vector3.Distance(_pointA, _pointB);
        }
    }

    private void checkReachedEnd(Vector3 _pointA, Vector3 _pointB, bool _isFlying, float _speed, float _flyHeight = 0)
    {
        if (distanceToPoint(_pointA, _pointB, false, _speed, _flyHeight) < .01f)
        {
            currentPoint = currentPoint + 1;
            if (currentPoint >= thePath.points.Length)
            {
                reachedEnd = true;

                selectedAttackPoint = Random.Range(0, theCastle.attackPoints.Length);
            }
        }
        else if(distanceToPoint(_pointA, _pointB, true, _speed, _flyHeight) < .01f)
        {
            currentPoint = currentPoint + 1;
            if (currentPoint >= thePath.points.Length)
            {
                reachedEnd = true;

                selectedAttackPoint = Random.Range(0, theCastle.attackPoints.Length);
            }
        }
    }

    private Path findPath()
    {
        return FindObjectOfType<Path>();
    }

    private Castle findCastle()
    {
        return FindObjectOfType<Castle>();
    }
    
}
