using UnityEngine;

namespace Chess.Scripts.Core
{
    public class ChessPiece : MonoBehaviour
    {
        [SerializeField]
        private int row;
        [SerializeField]
        private int column;

        private void OnMouseDown()
        {
            Debug.Log("yo");

            // Clear any previous highlights
            ChessBoardPlacementHandler.Instance.ClearHighlights();            

            // Highlight this piece's possible moves
            HighlightPossibleMoves();
        }

        private void HighlightPossibleMoves()
        {
            // Get the row and column from ChessPlayerPlacementHandler
            var placementHandler = GetComponent<ChessPlayerPlacementHandler>();
            if (placementHandler == null)
            {
                Debug.LogError("ChessPlayerPlacementHandler component not found on this GameObject.");
                return;
            }

            row = placementHandler.row;
            column = placementHandler.column;

            // Highlight the tile the piece is on
            ChessBoardPlacementHandler.Instance.Highlight(row, column);

            // TODO: Implement move calculation logic based on piece type
        }
    }
}
