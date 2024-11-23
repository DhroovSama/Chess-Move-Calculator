using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core
{
    public class KingMoveStrategy : IMoveStrategy
    {
        public List<Vector2Int> GetPossibleMoves(int row, int column, ChessPiece[,] boardState, Team team)
        {
            var moves = new List<Vector2Int>();
            Vector2Int[] moveOffsets = {
                new Vector2Int(-1, 0),  // Up
                new Vector2Int(1, 0),   // Down
                new Vector2Int(0, -1),  // Left
                new Vector2Int(0, 1),   // Right
                new Vector2Int(-1, -1), // Up Left
                new Vector2Int(-1, 1),  // Up Right
                new Vector2Int(1, -1),  // Down Left
                new Vector2Int(1, 1)    // Down Right
            };

            foreach (var offset in moveOffsets)
            {
                int targetRow = row + offset.x;
                int targetCol = column + offset.y;

                if (IsInsideBoard(targetRow, targetCol))
                {
                    ChessPiece targetPiece = boardState[targetRow, targetCol];
                    if (targetPiece == null || targetPiece.Team != team)
                    {
                        moves.Add(new Vector2Int(targetRow, targetCol));
                    }
                }
            }

            return moves;
        }

        private bool IsInsideBoard(int row, int column)
        {
            return row >= 0 && row < 8 && column >= 0 && column < 8;
        }
    }
}
