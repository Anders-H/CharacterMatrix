namespace CharacterMatrix;

public class Matrix
{
    private readonly char[,] _characters;
    public readonly int RowCount = 25;
    public int ColumnCount;

    public Matrix(int columnCount)
    {
        ColumnCount = columnCount;
        _characters = new char[ColumnCount, RowCount];
        Clear();
    }

    public void Clear()
    {
        for (var y = 0; y < RowCount; y++)
            for (var x = 0; x < ColumnCount; x++)
                _characters[x, y] = ' ';
    }

    public void SetAt(int posX, int posY, char c) =>
        _characters[posX, posY] = c;

    public char GetAt(int posX, int posY) =>
        _characters[posX, posY];

    public void ScrollUp()
    {
        for (var y = 1; y < RowCount; y++)
            for (var x = 0; x < ColumnCount; x++)
                _characters[x, y - 1] = _characters[x, y];

        var lastRow = RowCount - 1;
        const char zeroChar = (char)0;

        for (var x = 0; x < ColumnCount; x++)
            _characters[x, lastRow] = zeroChar;
    }

    public void InsertAt(int posX, int posY)
    {
        for (var y = RowCount - 1; y > posY; y--)
            for (var x = ColumnCount - 1; x >= 0; x--)
                _characters[x, y] = GetPreviousCharacter(x, y);

        for (var x = ColumnCount - 1; x > posX; x--)
            _characters[x, posY] = GetPreviousCharacter(x, posY);

        _characters[posX, posY] = ' ';
    }

    public void DeleteAt(int posX, int posY)
    {
        for (var x = posX; x < ColumnCount; x++)
            _characters[x, posY] = GetNextCharacter(x, posY);

        posY++;

        if (posY >= RowCount - 1)
            return;

        for (var y = posY; y < RowCount; y++)
            for (var x = 0; x < ColumnCount; x++)
                _characters[x, y] = GetNextCharacter(x, y);
    }

    private char GetPreviousCharacter(int x, int y)
    {
        if (x <= 0 && y <= 0)
            return ' ';

        x--;

        if (x < 0 && y > 0)
        {
            x = ColumnCount - 1;
            y--;
        }
        else if (x < 0)
        {
            x = 0;
        }

        return _characters[x, y];
    }

    private char GetNextCharacter(int x, int y)
    {
        if (x >= ColumnCount - 1 && y >= RowCount - 1)
            return ' ';

        x++;

        if (x >= ColumnCount && y < RowCount - 1)
        {
            x = 0;
            y++;
        }
        else if (x >= ColumnCount)
        {
            x = 0;
            y = RowCount - 1;
        }

        return _characters[x, y];
    }
}