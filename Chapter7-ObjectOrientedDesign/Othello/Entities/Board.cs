using Othello.Enums;
using System.Text;

namespace Othello.Entities
{
    public class Board
    {
        const int NUMBER_OF_ROWS = 8;
        const int NUMBER_OF_COLUMNS = 8;

        public Board()
        {
            Pieces = new Piece[NUMBER_OF_ROWS, NUMBER_OF_COLUMNS];
        }

        public Piece[,] Pieces { get; set; }

        private int whiteCount = 0;
        private int blackCount = 0;

        public void InitializeBoard()
        {
            for (int row = 0; row < NUMBER_OF_ROWS; row++)
            {
                for (int column = 0; column < NUMBER_OF_COLUMNS; column++)
                {
                    if ((row == 3 && column == 3) || (row == 4 && column == 4))
                    {
                        Pieces[row, column] = new Piece(PieceColorEnum.Black);
                    }
                    else if ((row == 3 && column == 4) || (row == 4 && column == 3))
                    {
                        Pieces[row, column] = new Piece(PieceColorEnum.White);
                    }
                    else
                    {
                        Pieces[row, column] = new Piece(PieceColorEnum.Empty);
                    }
                }
            }

            whiteCount = 0;
            blackCount = 0;
        }

        /// <summary>
        /// Attempts to insert a piece in the row and column defined, using the informed color
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="color"></param>
        /// <returns>True if the movement was valid and the piece was placed, otherwise returns False</returns>
        public bool PlacePiece(int row, int column, PieceColorEnum color)
        {
            if (Pieces[row, column].Color != PieceColorEnum.Empty)
            {
                return false;
            }

            // check neighbors, if no neighbor has a color it won't allow to place the piece
            if (!IsThereAnyNeighborWithColors(row, column, out List<Neighbor> neighbors))
            {
                return false;
            }

            // also need to check for a valid movement. If I'm player of black pieces,
            // I can only place a piece in a spot where there are white pieces surrounded by black pieces including the spot I want to place the piece
            if (!IsThereAnyNeighborWithAnOppositeColor(neighbors, color, out List<Neighbor> neighborsWithOppositeColors))
            {
                return false;
            }

            // check for a chain of opposite colors until find a piece of the same based on the neighbors with opposite colors,
            // if there is a chain like that the piece is allowed to be placed an the pieces in the chain need to be switched
            bool canInsertPiece = false;
            foreach (var neighbor in neighborsWithOppositeColors)
            {
                neighbor.Direction.GetRowAndColumnDisplacement(row, column, out int rowAfterDisplacement, out int columnAfterDisplacement);
                canInsertPiece |= CheckChainOfPiecesAndSwitchNeighborColors(rowAfterDisplacement, columnAfterDisplacement, color, neighbor.Direction);
            }

            if (canInsertPiece)
            {
                Pieces[row, column].SetColor(color);
            }

            return canInsertPiece;
        }

        /// <summary>
        /// Return the Pieces of the boards as string, Empty spots return as -, Black pieces as B and White as W
        /// </summary>
        /// <returns></returns>
        public string GetBoardPiecesAsString()
        {
            StringBuilder boardPieces = new();

            for (int row = 0; row < NUMBER_OF_ROWS; row++)
            {
                if (row != 0)
                {
                    boardPieces.Append("| ");
                }

                for (int column = 0; column < NUMBER_OF_COLUMNS; column++)
                {
                    boardPieces.Append(Pieces[row, column].Color.ToShortString());
                }
            }

            return boardPieces.ToString();
        }

        /// <summary>
        /// Check for a chain of pieces with opposite colors until find a piece with the same color,
        /// if there is a chain like that the piece is allowed to be placed an the pieces with opposite colors in the chain will be switched.
        /// As soon as the code finds a piece with the same color as the piece attempting to be placed, in the return of the recursive calls the pieces with opposite colors are already switched.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="color"></param>
        /// <param name="direction"></param>
        /// <param name="rowLimit"></param>
        /// <param name="columnLimit"></param>
        /// <returns></returns>
        private bool CheckChainOfPiecesAndSwitchNeighborColors(int row, int column, PieceColorEnum color, DirectionEnum direction)
        {
            bool canSwitchNeighborsColorAndPlaceNewPiece = false;
            Piece currentPiece = Pieces[row, column];

            // Found a piece in the chain of pieces with the same color of the one attempting to be inserted, that means we can switch the other neigbors colors and insert the piece
            if (currentPiece?.Color == color)
            {
                canSwitchNeighborsColorAndPlaceNewPiece = true;
            }

            // Stop condition
            direction.GetRowAndColumnLimit(NUMBER_OF_ROWS, NUMBER_OF_COLUMNS, out int? rowLimit, out int? columnLimit);
            if (canSwitchNeighborsColorAndPlaceNewPiece || (rowLimit.HasValue && row == rowLimit.Value) || (columnLimit.HasValue && column == columnLimit.Value))
            {
                return canSwitchNeighborsColorAndPlaceNewPiece;
            }

            direction.GetRowAndColumnDisplacement(row, column, out int rowAfterDisplacement, out int columnAfterDisplacement);

            //If found one piece of the same color of the target piece, the other pieces can have its color switched
            bool result = CheckChainOfPiecesAndSwitchNeighborColors(rowAfterDisplacement, columnAfterDisplacement, color, direction);
            if (result && currentPiece != null)
            {
                currentPiece.SwitchColor();
            }
            return result;
        }

        /// <summary>
        /// It checks the top, bottom, left and right neighbors checking if any of them has a color
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        private bool IsThereAnyNeighborWithColors(int row, int column, out List<Neighbor> neighbors)
        {
            bool thereIsAnyNeighborWithColor = false;
            neighbors = GetNeighborsOfaSpot(row, column);
            foreach (var neighbor in neighbors)
            {
                if (neighbor?.Piece.Color != PieceColorEnum.Empty)
                {
                    thereIsAnyNeighborWithColor = true;
                }
            }

            return thereIsAnyNeighborWithColor;
        }

        private List<Neighbor> GetNeighborsOfaSpot(int row, int column)
        {
            List<Neighbor> neighbors = new(8);

            foreach (DirectionEnum direction in (DirectionEnum[])Enum.GetValues(typeof(DirectionEnum)))
            {
                Neighbor? neighbor = GetNeighbor(row, column, direction);
                if (neighbor != null)
                {
                    neighbors.Add(neighbor);
                }
            }

            return neighbors;
        }

        private Neighbor? GetNeighbor(int row, int column, DirectionEnum direction)
        {
            direction.GetRowAndColumnDisplacement(row, column, out int rowAfterDisplacement, out int columnAfterDisplacement);
            Func<bool> condition = direction.GetStopCondition(rowAfterDisplacement, columnAfterDisplacement, NUMBER_OF_ROWS, NUMBER_OF_COLUMNS);

            return condition() ? new Neighbor(Pieces[rowAfterDisplacement, columnAfterDisplacement], direction) : null;
        }

        /// <summary>
        /// Check for a valid movement. If I'm player of black pieces, 
        /// I can only place a piece in a spot where there are white pieces surrounded by black pieces including the spot I want to place the piece
        /// </summary>
        /// <param name="neighbors"></param>
        /// <param name="color"></param>
        /// <param name="neighborsWithOppositeColor"></param>
        /// <returns></returns>
        private bool IsThereAnyNeighborWithAnOppositeColor(List<Neighbor> neighbors, PieceColorEnum color, out List<Neighbor> neighborsWithOppositeColor)
        {
            neighborsWithOppositeColor = new List<Neighbor>(neighbors.Count);
            bool thereIsAnyNeighborWithOppositeColor = false;
            PieceColorEnum oppositeColor = color.GetOppositeColor();

            foreach (var neighbor in neighbors)
            {
                if (neighbor.Piece.Color == oppositeColor)
                {
                    thereIsAnyNeighborWithOppositeColor = true;
                    neighborsWithOppositeColor.Add(neighbor);
                }
            }

            return thereIsAnyNeighborWithOppositeColor;
        }
    }
}
