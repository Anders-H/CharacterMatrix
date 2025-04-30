using CharacterMatrix;

namespace CharacterMatrixTests;

[TestClass]
public sealed class MatrixTests
{
    [TestMethod]
    public void CanClear()
    {
        var matrix = new Matrix(3);
        matrix.SetAt(0, 0, 'A');
        Assert.IsTrue(matrix.GetAt(0, 0) == 'A');
        matrix.Clear();
        Assert.IsTrue(matrix.GetAt(0, 0) == ' ');
    }

    [TestMethod]
    public void CanSetAt()
    {
        var matrix = new Matrix(3);
        Assert.IsTrue(matrix.GetAt(0, 0) == ' ');
        matrix.SetAt(0, 0, 'A');
        Assert.IsTrue(matrix.GetAt(0, 0) == 'A');
    }

    [TestMethod]
    public void CanScrollUp()
    {
        var matrix = new Matrix(3);
        matrix.SetAt(0, 0, 'A');
        matrix.SetAt(0, 1, 'B');
        matrix.SetAt(0, 2, 'C');
        matrix.SetAt(0, 22, 'D');
        matrix.SetAt(0, 23, 'E');
        matrix.SetAt(0, 24, 'F');
        Assert.IsTrue(matrix.GetAt(0, 0) == 'A');
        Assert.IsTrue(matrix.GetAt(0, 1) == 'B');
        Assert.IsTrue(matrix.GetAt(0, 2) == 'C');
        Assert.IsTrue(matrix.GetAt(0, 3) == ' ');
        Assert.IsTrue(matrix.GetAt(0, 21) == ' ');
        Assert.IsTrue(matrix.GetAt(0, 22) == 'D');
        Assert.IsTrue(matrix.GetAt(0, 23) == 'E');
        Assert.IsTrue(matrix.GetAt(0, 24) == 'F');
        matrix.ScrollUp();
        Assert.IsTrue(matrix.GetAt(0, 0) == 'B');
        Assert.IsTrue(matrix.GetAt(0, 1) == 'C');
        Assert.IsTrue(matrix.GetAt(0, 2) == ' ');
        Assert.IsTrue(matrix.GetAt(0, 3) == ' ');
        Assert.IsTrue(matrix.GetAt(0, 21) == 'D');
        Assert.IsTrue(matrix.GetAt(0, 22) == 'E');
        Assert.IsTrue(matrix.GetAt(0, 23) == 'F');
        Assert.IsTrue(matrix.GetAt(0, 24) == ' ');
    }

    [TestMethod]
    public void CanInsertAt()
    {
        var matrix = new Matrix(3);
        matrix.SetAt(0, 0, 'A');
        matrix.SetAt(1, 0, 'B');
        matrix.SetAt(2, 0, 'C');
        matrix.InsertAt(0, 0);
        Assert.IsTrue(matrix.GetAt(0, 0) == ' ');
        Assert.IsTrue(matrix.GetAt(1, 0) == 'A');
        Assert.IsTrue(matrix.GetAt(2, 0) == 'B');
        matrix.SetAt(0, 0, 'A');
        matrix.SetAt(1, 0, 'B');
        matrix.SetAt(2, 0, 'C');
        matrix.InsertAt(1, 0);
        Assert.IsTrue(matrix.GetAt(0, 0) == 'A');
        Assert.IsTrue(matrix.GetAt(1, 0) == ' ');
        Assert.IsTrue(matrix.GetAt(2, 0) == 'B');
        matrix.SetAt(0, 0, 'A');
        matrix.SetAt(1, 0, 'B');
        matrix.SetAt(2, 0, 'C');
        matrix.InsertAt(2, 0);
        Assert.IsTrue(matrix.GetAt(0, 0) == 'A');
        Assert.IsTrue(matrix.GetAt(1, 0) == 'B');
        Assert.IsTrue(matrix.GetAt(2, 0) == ' ');
    }
}