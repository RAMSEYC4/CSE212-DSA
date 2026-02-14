public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        // If the value already exists, do nothing
        if (value == Data)
            return;

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2

        // If we found the value, return true
        if (value == Data)
            return true;

        // If the value is less than current data, search left
        if (value < Data)
        {
            if (Left is null)
                return false;
            return Left.Contains(value);
        }

        // If the value is greater than current data, search right
        else
        {
            if (Right is null)
                return false;
            return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // TODO Start Problem 4

        // Get the height of left and right subtrees
        int leftHeight = (Left is null) ? 0 : Left.GetHeight();
        int rightHeight = (Right is null) ? 0 : Right.GetHeight();

        // Return 1 + the maximum of the two heights
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}