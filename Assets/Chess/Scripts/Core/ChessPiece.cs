using UnityEngine;
using System.Collections.Generic;

namespace Chess.Scripts.Core
{
    public class ChessPiece : MonoBehaviour
    {
        [SerializeField] private PieceType pieceType;
        [SerializeField] private Team team;

        private ChessPlayerPlacementHandler placementHandler;
        private IMoveStrategy moveStrategy;

        public int Row => placementHandler.row; 
        public int Column => placementHandler.column; 
        public Team Team => team;

        private void Start()
        {
            placementHandler = GetComponent<ChessPlayerPlacementHandler>();
            if (placementHandler == null)
            {
                Debug.LogError("ChessPlayerPlacementHandler not found on this GameObject!");
                return;
            }

            InitializeMoveStrategy();
            ChessBoardPlacementHandler.Instance.RegisterPiece(this);
        }

        private void InitializeMoveStrategy()
        {
            switch (pieceType)
            {
                case PieceType.Pawn:
                    moveStrategy = new PawnMoveStrategy();
                    break;
                case PieceType.Rook:
                    moveStrategy = new RookMoveStrategy();
                    break;
                case PieceType.Knight:
                    moveStrategy = new KnightMoveStrategy();
                    break;
                case PieceType.Bishop:
                    moveStrategy = new BishopMoveStrategy();
                    break;
                case PieceType.Queen:
                    moveStrategy = new QueenMoveStrategy();
                    break;
                case PieceType.King:
                    moveStrategy = new KingMoveStrategy();
                    break;
                default:
                    Debug.LogError("Unknown piece type.");
                    break;
            }
        }

        private void OnMouseDown()
        {
            ChessBoardPlacementHandler.Instance.ClearHighlights();
            HighlightPossibleMoves();
        }

        private void HighlightPossibleMoves()
        {
            var boardState = ChessBoardPlacementHandler.Instance.GetBoardState();
            var possibleMoves = moveStrategy.GetPossibleMoves(Row, Column, boardState, team);

            foreach (var move in possibleMoves)
            {
                int targetRow = move.x;
                int targetColumn = move.y;
                var targetPiece = boardState[targetRow, targetColumn];

                if (targetPiece != null && targetPiece.Team != team)
                {
                    ChessBoardPlacementHandler.Instance.HighlightRed(targetRow, targetColumn);
                }
                else
                {
                    ChessBoardPlacementHandler.Instance.Highlight(targetRow, targetColumn);
                }
            }
        }

        public bool IsEnemy(ChessPiece otherPiece)
        {
            return otherPiece != null && this.team != otherPiece.team;
        }
    }
}
