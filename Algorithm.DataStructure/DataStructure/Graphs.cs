namespace Algorithm.BasicsDataStructure.DataStructure;
/// <summary>
/// Graf, düğümler (veya noktalar) ve bu düğümleri birbirine bağlayan
/// kenarlardan (veya bağlantılardan) oluşan bir veri yapısıdır. 
/// Graf, birçok gerçek dünya problemini modellemek için kullanılır, 
/// örneğin sosyal ağlar, yol haritaları, ağ iletişimi ve daha fazlası. 
/// Graf yapıları, yönlendirilmiş (directed) ve yönlendirilmemiş (undirected) 
/// olarak ikiye ayrılır.
/// 
/// Yönlendirilmiş Graf: Kenarların bir yönü vardır. Yani, bir düğümden diğerine 
/// giden bir yol vardır, ancak ters yönde bir yol olmayabilir.
/// 
/// Yönlendirilmemiş Graf: Kenarların yönü yoktur. Yani, bir düğümden diğerine
/// giden bir yol varsa, ters yönde de bir yol vardır.
/// 
/// Graf Temel Terimleri:
/// Düğüm(Vertex) : Grafın temel birimi.
/// Kenar(Edge): Düğümleri birbirine bağlayan bağlantı.
///  Ağırlıklı Graf: Kenarların bir ağırlığı (değeri) vardır.
/// Bağlantılı Graf: Her düğüm, diğer düğümlerle bir şekilde bağlantılıdır.
/// </summary>
public class Graphs
{
    // Düğüm listesini tutan bir sözlük (dictionary)  
    private Dictionary<int, List<int>> adjacencyList;

    // Yapıcı metod  
    public Graphs()
    {
        adjacencyList = new Dictionary<int, List<int>>();
    }

    // Düğüm ekleme  
    public void AddVertex(int vertex)
    {
        // Eğer düğüm yoksa, yeni bir liste oluştur  
        if (!adjacencyList.ContainsKey(vertex))
        {
            adjacencyList[vertex] = new List<int>();
        }
    }

    // Kenar ekleme (yönlendirilmemiş)  
    public void AddEdge(int vertex1, int vertex2)
    {
        // Her iki düğümü de ekleyelim  
        AddVertex(vertex1);
        AddVertex(vertex2);

        // Düğümler arasında kenar ekleyelim  
        adjacencyList[vertex1].Add(vertex2);
        adjacencyList[vertex2].Add(vertex1); // Yönlendirilmemiş olduğu için  
    }

    // Grafı yazdırma  
    public void PrintGraph()
    {
        foreach (var vertex in adjacencyList)
        {
            Console.Write(vertex.Key + " -> ");
            foreach (var edge in vertex.Value)
            {
                Console.Write(edge + " ");
            }
            Console.WriteLine();
        }
    }

    public void GraphsMain()
    {
        // Graf oluşturma  
        Graphs graph = new Graphs();

        // Düğümler ve kenarlar ekleme  
        graph.AddEdge(1, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(2, 4);
        graph.AddEdge(3, 4);
        graph.AddEdge(4, 5);

        // Grafı yazdırma  
        Console.WriteLine("Graf:");
        graph.PrintGraph();
    }
}
