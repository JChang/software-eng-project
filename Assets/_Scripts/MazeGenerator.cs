using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private MazeCell _mazeCellPrefab;

    public int _mazeWidth;
    public int _mazeLength;

    public MazeCell[,] _mazeGrid;

    [SerializeField] private int _scaleFactor = 25;

    void OnEnable()
    {
        SceneManager.sceneLoaded += resetDimensions;
    }

    private void resetDimensions(Scene scene, LoadSceneMode loadSceneMode)
    {
        _mazeLength = _mazeLength + Mathf.FloorToInt(GameManager.Instance.Score / _scaleFactor);
        _mazeWidth = _mazeWidth + Mathf.FloorToInt(GameManager.Instance.Score / _scaleFactor);
        Debug.Log($"maze length: {_mazeLength}, score {GameManager.Instance.Score}");
    }

    IEnumerator Start()
    {
        _mazeLength = _mazeLength + Mathf.FloorToInt(GameManager.Instance.Score / _scaleFactor);
        _mazeWidth = _mazeWidth + Mathf.FloorToInt(GameManager.Instance.Score / _scaleFactor);

        _mazeGrid = new MazeCell[_mazeWidth, _mazeLength];

        float cellWidth = 5f;
        float cellLength = 5f;

        for (int x = 0; x < _mazeWidth; x++)
        {
            for (int y = 0; y < _mazeLength; y++)
            {
                _mazeGrid[x, y] = Instantiate(_mazeCellPrefab, new Vector3(x * cellWidth, y * cellLength, 0), Quaternion.identity);
            }
        }

        yield return GenerateMaze(null, _mazeGrid[0, 0]);
    }

    private IEnumerator GenerateMaze(MazeCell prevCell, MazeCell currCell)
    {
        currCell.Visit();
        ClearWalls(prevCell, currCell);

        yield return new WaitForSeconds(0.05f);

        MazeCell nextCell;

        do
        {
            nextCell = NextUnvisitedCell(currCell);

            if (nextCell != null)
            {
                yield return GenerateMaze(currCell, nextCell);
            }
        } while (nextCell != null);
    }

    private MazeCell NextUnvisitedCell(MazeCell currCell)
    {
        var unvisitedCells = GetUnvisitedCells(currCell);

        return unvisitedCells.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
    }

    private IEnumerable<MazeCell> GetUnvisitedCells(MazeCell currCell)
    {
        int x = Mathf.RoundToInt(currCell.transform.position.x / 5f);
        int y = Mathf.RoundToInt(currCell.transform.position.y / 5f);

        if (x + 1 < _mazeWidth)
        {
            var cellToRight = _mazeGrid[x + 1, y];

            if (cellToRight.IsVisited == false)
            {
                yield return cellToRight;
            }
        }

        if (x - 1 >= 0)
        {
            var cellToLeft = _mazeGrid[x - 1, y];

            if (cellToLeft.IsVisited == false)
            {
                yield return cellToLeft;
            }
        }

        if (y + 1 < _mazeLength)
        {
            var cellToTop = _mazeGrid[x, y + 1];

            if (cellToTop.IsVisited == false)
            {
                yield return cellToTop;
            }
        }

        if (y - 1 >= 0)
        {
            var cellToBottom = _mazeGrid[x, y - 1];

            if (cellToBottom.IsVisited == false)
            {
                yield return cellToBottom;
            }
        }
    }

    private void ClearWalls(MazeCell prevCell, MazeCell currCell)
    {
        if (prevCell == null)
        {
            return;
        }

        if (prevCell.transform.position.x < currCell.transform.position.x)
        {
            prevCell.ClearRightWall();
            currCell.ClearLeftWall();
            return;
        }

        if (prevCell.transform.position.x > currCell.transform.position.x)
        {
            prevCell.ClearLeftWall();
            currCell.ClearRightWall();
            return;
        }

        if (prevCell.transform.position.y < currCell.transform.position.y)
        {
            prevCell.ClearTopWall();
            currCell.ClearBottomWall();
            return;
        }

        if (prevCell.transform.position.y > currCell.transform.position.y)
        {
            prevCell.ClearBottomWall();
            currCell.ClearTopWall();
            return;
        }
    }
}