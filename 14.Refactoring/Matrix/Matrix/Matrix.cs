namespace Matrix
{
    using System;
    using System.Text;

    public class Matrix
    {
        public const int MatrixMaxSize = 100;
        public const int MatrixMinSize = 1;
        private readonly int[,] matrix;
        private int length;

        public Matrix(int length)
        {
            this.Length = length;
            this.matrix = new int[length, length];
        }

        private enum Direction
        {
            RightDown = 0,
            Down = 1,
            LeftDown = 2,
            Left = 3,
            LeftUp = 4,
            Up = 5,
            RightUp = 6,
            Right = 7
        }

        public int Length
        {
            get
            {
                return this.length;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Matrix length must be greather than 0!");
                }

                if (value > 100)
                {
                    throw new ArgumentOutOfRangeException("Matrix length must be less than 100!");
                }

                this.length = value;
            }
        }

        public void FillMatrix()
        {
            int curNumber = 1;

            Position position = new Position(0, 0, Direction.RightDown);
            Position currentPosition = position;

            bool hasEmptyPosition = true;

            while (hasEmptyPosition)
            {
                this.matrix[position.Row, position.Col] = curNumber;
                curNumber++;

                currentPosition = this.MovePosition(position);

                if (!this.IsPositionAvailable(this.matrix, currentPosition))
                {
                    currentPosition = this.GetNextAvailablePosition(this.matrix, position);
                }

                if (this.IsSamePosition(position, currentPosition))
                {
                    currentPosition = this.FindEmptyPosition(this.matrix, position);

                    if (this.IsSamePosition(position, currentPosition))
                    {
                        hasEmptyPosition = false;
                    }
                }

                position = currentPosition;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < this.length; row++)
            {
                for (int col = 0; col < this.length; col++)
                {
                    result.AppendFormat("{0,3}", this.matrix[row, col]);
                }

                if (row < this.length - 1)
                {
                    result.AppendLine();
                }
            }

            return result.ToString();
        }

        private Position MovePosition(Position position)
        {
            switch (position.Direction)
            {
                case Direction.RightDown:
                    position.Row += 1;
                    position.Col += 1;
                    break;
                case Direction.Down:
                    position.Row += 1;
                    break;
                case Direction.LeftDown:
                    position.Row += 1;
                    position.Col -= 1;
                    break;
                case Direction.Left:
                    position.Col -= 1;
                    break;
                case Direction.LeftUp:
                    position.Row -= 1;
                    position.Col -= 1;
                    break;
                case Direction.Up:
                    position.Row -= 1;
                    break;
                case Direction.RightUp:
                    position.Row -= 1;
                    position.Col += 1;
                    break;
                case Direction.Right:
                    position.Col += 1;
                    break;
            }

            return position;
        }

        private bool IsPositionAvailable(int[,] arr, Position position)
        {
            if (position.Row < arr.GetLength(0) &&
                position.Row >= 0 &&
                position.Col < arr.GetLength(1) &&
                position.Col >= 0 &&
                arr[position.Row, position.Col] == 0)
            {
                return true;
            }

            return false;
        }

        private Position GetNextAvailablePosition(int[,] matrix, Position position)
        {
            Position currentPosition;
            var directions = Enum.GetValues(typeof(Direction));

            for (int i = 0; i < directions.Length; i++)
            {
                position.Direction++;

                if ((int)position.Direction >= directions.Length)
                {
                    position.Direction = 0;
                }

                currentPosition = this.MovePosition(position);

                if (this.IsPositionAvailable(matrix, currentPosition))
                {
                    return currentPosition;
                }
            }

            return position;
        }

        private bool IsSamePosition(Position position1, Position position2)
        {
            if (position1.Row != position2.Row ||
                position1.Col != position2.Col)
            {
                return false;
            }

            return true;
        }

        private Position FindEmptyPosition(int[,] matrix, Position position)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        position.Row = i;
                        position.Col = j;
                        return position;
                    }
                }
            }

            return position;
        }

        private struct Position
        {
            public int Row;
            public int Col;
            public Direction Direction;

            public Position(int row, int col, Direction direction)
            {
                this.Row = row;
                this.Col = col;
                this.Direction = direction;
            }
        }
    }
}
