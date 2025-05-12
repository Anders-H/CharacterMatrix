namespace CharacterMatrix;

public interface IMatrix
{
    int ColumnCount { get; }
    int RowCount { get; }
    void Clear();
    void SetAt(int posX, int posY, char c);
    char GetAt(int posX, int posY);
    void ScrollUp();
    void InsertAt(int posX, int posY);
    void DeleteAt(int posX, int posY);
}