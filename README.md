---

# **Chess Game Simulation**

This is a fully functional chess moves calculator. It’s designed with clean and modular code, making it easy to extend and customize. The game handles chess piece movement dynamically, highlights possible moves in real time, and tracks the board state efficiently. 

---

## **Features**
- **Smart Movement Logic**: Each chess piece has its own movement rules powered by the **Strategy Pattern**—making the code flexible and easy to maintain.
- **Real-Time Highlights**: The game highlights valid moves in **green** and potential captures in **red**, giving clear feedback as you play.
- **Efficient Board Management**: The chessboard is managed with a **2D grid system**, ensuring smooth interactions and fast lookups for moves.

---

## **How It Works**

This game uses modern design patterns to keep things clean and organized:

- **Strategy Pattern**: Each piece type (Pawn, Rook, Knight, etc.) has its own movement logic encapsulated in a separate class.
- **Singleton Pattern**: The chessboard manager is a single instance that tracks tiles, pieces, and interactions across the game.

This setup ensures that adding new features or tweaking existing ones is as simple as possible.

---

## **Getting Started**

### **What You’ll Need**
- Unity 2020.3.X or later.
- A little knowledge of Unity and C#.

### **Steps to Run**
1. Clone this repo:
   ```bash
   git clone https://github.com/DhroovSama/Chess-Move-Calculator.git
   ```
2. Open the project in Unity.
3. Load the main scene (`GameScene`) and hit play.
4. Click on any chess piece to see its valid moves and potential captures highlighted on the board.

---

## **Code Overview**

Here’s a quick look at how things are structured:

1. **`ChessPiece.cs`**:
   - Represents each piece on the board.
   - Decides where the piece can move using its assigned movement strategy.
   - Highlights moves dynamically based on the board state.

2. **`ChessBoardPlacementHandler.cs`**:
   - Handles the chessboard tiles and manages the state of all pieces.
   - Clears old highlights, shows new ones, and ensures the board stays consistent.

3. **Movement Strategies**:
   - Each piece type (Pawn, Knight, etc.) has its own strategy class (e.g., `KnightMoveStrategy`) that encapsulates its unique movement rules.

4. **`ChessPlayerPlacementHandler`**:
   - Manages the position of a piece and syncs it with the board dynamically.

---

## **Preview**

![Chess Game Preview](https://drive.google.com/uc?id=1Wid--s78Hu5cJoFqQIx5G9L3FPop3kLB)  
*A chess game built with Unity, featuring real-time highlights and modular movement logic.*
