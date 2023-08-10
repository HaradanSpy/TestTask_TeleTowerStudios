using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrolling : MonoBehaviour
{
    [Header("Main")]
    [Tooltip("True - ����� ������ ��������")]
    public bool startMove;
    [Tooltip("�������� ������ ���������")]
    public float characterSpeed_Walk = 1.5f;
    [Tooltip("�������� ���� ���������")]
    public float characterSpeed_Run = 3.5f;
    [Tooltip("������ ���������� �����")]
    public List<PatrollPoint> points = new List<PatrollPoint> ();

    private float _targetSpeed;
    private int _currentPointId;

    [Header("Character")]
    [Tooltip("NavMeshAgent ���������")]
    public NavMeshAgent agent;
    [Tooltip("Animator ���������")]
    public Animator characterAnimator;

    public void StartMove() 
    {
        startMove = true;
        characterAnimator.SetBool("StartMove", true);
        SetDestinationPoint();
    }
    private void Update()
    {
        if (startMove)
        {
            if (agent.remainingDistance < agent.stoppingDistance) // ��������� ���������� �� ��������� ���������� �����
            {
                _currentPointId++;
                if (_currentPointId >= points.Count) _currentPointId = 0;
                SetDestinationPoint();
            }
            agent.speed= Mathf.Lerp(agent.speed, _targetSpeed, 2.5f * Time.deltaTime); // ������� ��������� �������� �������� ���������
        }
    }
    void SetDestinationPoint() 
    {
        if(points[_currentPointId].type == 1)
        {
            characterAnimator.SetFloat("MoveSpeed", 1); // ���
            _targetSpeed = characterSpeed_Run;        
        }
        else
        {
            characterAnimator.SetFloat("MoveSpeed", 0.4f); // ������
            _targetSpeed = characterSpeed_Walk;
        }
        agent.SetDestination(points[_currentPointId].transform.position);
    }
}
//if (_currentPointId == 0 || _currentPointId == 2 || _currentPointId == 3 || _currentPointId == 5 || _currentPointId == 6)