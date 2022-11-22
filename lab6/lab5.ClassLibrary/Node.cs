namespace lab5.ClassLibrary;

public class Node
{
    public int vertexNumber;
      
    // Adjacency list that shows the
    // vertexNumber of child vertex
    // and the weight of the edge
    public List<Pair> children;
      
    public Node(int vertexNumber)
    {
        this.vertexNumber = vertexNumber;
        children = new List<Pair>();
    }
      
    // Function to Add the child for
    // the given node
    public void Add_child(int vNumber, int length)
    {
        Pair p = new Pair(vNumber, length);
        children.Add(p);
    }
}