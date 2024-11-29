using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum nodeState
{
    Available,
    Current,
    Completed
}

public class MazeCell : MonoBehaviour
{
    [SerializeField] private GameObject _leftWall;
    [SerializeField] private GameObject _rightWall;
    [SerializeField] private GameObject _topWall;
    [SerializeField] private GameObject _bottomWall;

    [SerializeField] private GameObject _unvisitedBlock;

    public bool IsVisited { get; private set; }

    public void Visit()
    {
        IsVisited = true;
        _unvisitedBlock.SetActive(false);
    }

    public void ClearLeftWall()
    {
        _leftWall.SetActive(false);
    }

    public void ClearRightWall()
    {
        _rightWall.SetActive(false);
    }

    public void ClearTopWall()
    {
        _topWall.SetActive(false);
    }

    public void ClearBottomWall()
    {
        _bottomWall.SetActive(false);
    }
}
