using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core
{
    public class KnightMoveStrategy : IMoveStrategy
    {
        public List<Vector2Int> GetPossibleMoves(int row, int column, ChessPiece[,] boardState, Team team)
        {
            var moves = new List<Vector2Int>();

            Vector2Int[] moveOffsets = {
                new Vector2Int(-2, -1), new Vector2Int(-2, 1),
                new Vector2Int(-1, -2), new Vector2Int(-1, 2),
                new Vector2Int(1, -2), new Vector2Int(1, 2),
                new Vector2Int(2, -1), new Vector2Int(2, 1)
            };

            foreach (var offset in moveOffsets)
            {
                int targetRow = row + offset.x;
                int targetCol = column + offset.y;

                if (IsInsideBoard(targetRow, targetCol))
                {
                    var targetPiece = boardState[targetRow, targetCol];
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
