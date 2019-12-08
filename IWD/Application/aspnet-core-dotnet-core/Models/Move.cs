public class Move
{
    public int Column { get; set; }
    public int Row { get; set; }

    public Move(int column, int row)
    {
        Column = column;
        Row = row;
    }
}