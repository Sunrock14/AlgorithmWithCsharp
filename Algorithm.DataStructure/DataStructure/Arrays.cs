namespace Algorithm.BasicsDataStructure.DataStructure;

public class Arrays
{
    /// <summary>
    /// Diziler, aynı türdeki verilerin sabit boyutlu bir koleksiyonudur.
    /// Bellekte ardışık olarak depolanır ve her bir eleman, dizinin başlangıç 
    /// adresine bir offset eklenerek erişilir.Diziler, hızlı erişim sağlar, 
    /// ancak boyutları sabittir ve oluşturulduktan sonra değiştirilemez.
    /// </summary>
    public void ArrayStructure()
    {
        // Dizi tanımlama ve başlatma  
        int[] numbers = { 1, 2, 3, 4, 5 };

        // Dizi elemanlarına erişim  
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}
