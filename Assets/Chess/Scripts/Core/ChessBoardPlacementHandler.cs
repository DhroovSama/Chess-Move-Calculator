using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core
{
    public sealed class ChessBoardPlacementHandler : MonoBehaviour
    {
        [SerializeField] private GameObject[] _rowsArray;
        [SerializeField] private GameObject _highlightPrefab;

        private GameObject[,] _chessBoard;
        private ChessPiece[,] boardState = new ChessPiece[8, 8];

        internal static ChessBoardPlacementHandler Instance;

        private void Awake()
        {
            Instance = this;
            GenerateArray();
        }

        private void GenerateArray()
        {
            _chessBoard = new GameObject[8, 8];
            for (var i = 0; i < 8; i++)
            {
                for (var j = 0; j < 8; j++)
                {
                    _chessBoard[i, j] = _rowsArray[i].transform.GetChild(j).gameObject;
                }
            }
        }

        internal GameObject GetTile(int row, int column)
        {
            if (IsInsideBoard(row, column))
            {
                return _chessBoard[row, column];
            }
            else
            {
                Debug.LogError($"Invalid tile position: ({row}, {column})");
                return null;
            }
        }

        internal void Highlight(int row, int column)
        {
            var tile = GetTile(row, column)?.transform;
            if (tile != null)
            {
                Instantiate(_highlightPrefab, tile.position, Quaternion.identity, tile);
            }
        }

        internal void HighlightRed(int row, int column)
        {
            var tile = GetTile(row, column)?.transform;
            if (tile != null)
            {
                var highlight = Instantiate(_highlightPrefab, tile.position, Quaternion.identity, tile);
                // Assuming the highlight prefab has a Renderer component
                var renderer = highlight.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = Color.red;
                }
            }
        }

        internal void ClearHighlights()
        {
            foreach (var tile in _chessBoard)
            {
                if (tile.transform.childCount > 0)
                {
                    for (int i = tile.transform.childCount - 1; i >= 0; i--)
                    {
                        var child = tile.transform.GetChild(i);
                        if (child.CompareTag("Highlight"))
                        {
                            Destroy(child.gameObject);
                        }
                    }
                }
            }
        }

        internal void RegisterPiece(ChessPiece piece)
        {
            boardState[piece.Row, piece.Column] = piece;
        }

        internal ChessPiece[,] GetBoardState()
        {
            return boardState;
        }

        private bool IsInsideBoard(int row, int column)
        {
            return row >= 0 && row < 8 && column >= 0 && column < 8;
        }
    }
}
