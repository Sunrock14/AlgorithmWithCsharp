using System.Collections;
using System.Runtime.ConstrainedExecution;

namespace Algorithm.BasicsDataStructure.DataStructure;

public class HashTables
{
    /// <summary>
    /// HashTable, anahtar-değer çiftlerini depolamak için kullanılan bir veri yapısıdır. 
    /// Anahtarlar, veriye hızlı erişim sağlamak için bir hash fonksiyonu kullanılarak bir 
    /// hash koduna dönüştürülür. Bu yapı, verilerin hızlı bir şekilde eklenmesi, silinmesi 
    /// ve erişilmesi için idealdir. Ancak, HashTable'lar sıralı değildir ve anahtarların 
    /// benzersiz olması gerekir.
    /// 
    /// Özellikler:
    ///Hızlı Erişim: Anahtarlar kullanılarak verilere O(1) zaman karmaşıklığı ile erişilir.
    ///Dinamik Boyut: HashTable, eleman ekledikçe otomatik olarak boyutunu ayarlayabilir.
    ///Anahtarların Benzersizliği: Her anahtar, tablodaki diğer anahtarlarla çakışmamalıdır.
    /// </summary>
    public void HashTablesStructure()
    {
        // HashTable tanımlama  
        Hashtable hashtable = new Hashtable();

        // Eleman ekleme  
        hashtable["A"] = 1; // Anahtar "A", değer 1  
        hashtable["B"] = 2; // Anahtar "B", değer 2  
        hashtable["C"] = 3; // Anahtar "C", değer 3  

        // Elemanları yazdırma  
        Console.WriteLine("HashTable Elemanları:");
        foreach (DictionaryEntry entry in hashtable)
        {
            // Her bir anahtar-değer çiftini yazdırıyoruz  
            Console.WriteLine($"Anahtar: {entry.Key}, Değer: {entry.Value}");
        }

        // Belirli bir anahtara erişim  
        if (hashtable.ContainsKey("B")) // "B" anahtarının var olup olmadığını kontrol ediyoruz  
        {
            Console.WriteLine($"Anahtar 'B' için değer: {hashtable["B"]}"); // "B" anahtarının değerini yazdırıyoruz  
        }

        // Eleman silme  
        hashtable.Remove("A"); // "A" anahtarını ve ona karşılık gelen değeri siliyoruz  
        Console.WriteLine("Anahtar 'A' silindikten sonra HashTable:");
        foreach (DictionaryEntry entry in hashtable)
        {
            Console.WriteLine($"Anahtar: {entry.Key}, Değer: {entry.Value}"); // Güncellenmiş tabloyu yazdırıyoruz  
        }
    }
}
