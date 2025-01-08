namespace Algorithm.BasicsDataStructure.DataStructure;

/// <summary>
/// Küme, benzersiz elemanlardan oluşan bir koleksiyondur.
/// Kümeler, aynı elemandan birden fazla kez bulunamaz ve
/// genellikle matematiksel kümeleri temsil etmek için kullanılır.
/// Küme veri yapıları, eleman ekleme, silme ve arama işlemlerinde
/// hızlı erişim sağlar. C# dilinde küme yapısı için genellikle 
/// HashSet<T> sınıfı kullanılır.
/// 
/// Benzersizlik: Küme, her elemanın yalnızca bir kez bulunmasına izin verir.
/// Hızlı Erişim: Eleman ekleme, silme ve arama işlemleri genellikle O(1) zaman karmaşıklığına sahiptir.
/// Sırasız: Küme elemanları belirli bir sırada depolanmaz.
/// </summary>
public class Sets
{
    public void SetsStructure()
    {
        // HashSet tanımlama  
        HashSet<int> set = new HashSet<int>();

        // Eleman ekleme  
        set.Add(1); // Küme 1 ekleniyor  
        set.Add(2); // Küme 2 ekleniyor  
        set.Add(3); // Küme 3 ekleniyor  
        set.Add(2); // Küme 2 tekrar eklenmeye çalışılıyor, ancak küme benzersizdir  

        // Elemanları yazdırma  
        Console.WriteLine("Küme Elemanları:");
        foreach (var item in set)
        {
            Console.WriteLine(item); // Küme elemanlarını yazdırıyoruz  
        }

        // Eleman kontrolü  
        if (set.Contains(2)) // 2 elemanının kümede olup olmadığını kontrol ediyoruz  
        {
            Console.WriteLine("Küme 2 elemanını içeriyor.");
        }

        // Eleman silme  
        set.Remove(1); // Kümeden 1 elemanını siliyoruz  
        Console.WriteLine("1 elemanı silindikten sonra Küme Elemanları:");
        foreach (var item in set)
        {
            Console.WriteLine(item); // Güncellenmiş küme elemanlarını yazdırıyoruz  
        }

        // Küme boyutunu yazdırma  
        Console.WriteLine($"Küme Boyutu: {set.Count}"); // Küme eleman sayısını yazdırıyoruz 
    }
}
