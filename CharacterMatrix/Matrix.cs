namespace CharacterMatrix;

public class Matrix : IMatrix
{
    private readonly char[,] _characters;
    private readonly int _rowCount;
    private readonly int _columnCount;

    public Matrix(int columnCount) : this(columnCount, 25)
    {
    }

    public Matrix(int columnCount, int rowCount)
    {
        _columnCount = columnCount;
        _rowCount = rowCount;
        _characters = new char[_columnCount, _rowCount];
        Clear();
    }

    public int ColumnCount =>
        _columnCount;

    public int RowCount =>
        _rowCount;

    public void Clear()
    {
        for (var y = 0; y < _rowCount; y++)
            for (var x = 0; x < _columnCount; x++)
                _characters[x, y] = ' ';
    }

    public void SetAt(int posX, int posY, char c) =>
        _characters[posX, posY] = c;

    public char GetAt(int posX, int posY) =>
        _characters[posX, posY];

    public void ScrollUp()
    {
        for (var y = 1; y < _rowCount; y++)
            for (var x = 0; x < _columnCount; x++)
                _characters[x, y - 1] = _characters[x, y];

        var lastRow = _rowCount - 1;

        for (var x = 0; x < _columnCount; x++)
            _characters[x, lastRow] = ' ';
    }

    public void InsertAt(int posX, int posY)
    {
        for (var y = _rowCount - 1; y > posY; y--)
            for (var x = _columnCount - 1; x >= 0; x--)
                _characters[x, y] = GetPreviousCharacter(x, y);

        for (var x = _columnCount - 1; x > posX; x--)
            _characters[x, posY] = GetPreviousCharacter(x, posY);

        _characters[posX, posY] = ' ';
    }

    public void DeleteAt(int posX, int posY)
    {
        for (var x = posX; x < _columnCount; x++)
            _characters[x, posY] = GetNextCharacter(x, posY);

        posY++;

        if (posY >= _rowCount - 1)
            return;

        for (var y = posY; y < _rowCount; y++)
            for (var x = 0; x < _columnCount; x++)
                _characters[x, y] = GetNextCharacter(x, y);
    }

    private char GetPreviousCharacter(int x, int y)
    {
        if (x <= 0 && y <= 0)
            return ' ';

        x--;

        if (x < 0 && y > 0)
        {
            x = _columnCount - 1;
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
        if (x >= _columnCount - 1 && y >= _rowCount - 1)
            return ' ';

        x++;

        if (x >= _columnCount && y < _rowCount - 1)
        {
            x = 0;
            y++;
        }
        else if (x >= _columnCount)
        {
            x = 0;
            y = _rowCount - 1;
        }

        return _characters[x, y];
    }
}