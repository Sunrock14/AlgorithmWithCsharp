using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.BasicsDataStructure.DataStructure
{
    /// <summary>
    /// Bağlı listeler, her bir elemanın (düğüm) bir sonraki düğümün adresini
    /// içerdiği dinamik bir veri yapısıdır. Bu yapı, eleman ekleme ve silme
    /// işlemlerinin daha verimli yapılmasını sağlar. Bağlı listeler, dizilere
    /// göre daha fazla bellek kullanabilir, ancak boyutları dinamik olarak değiştirilebilir.
    /// </summary>
    public class LinkedLists
    {
        public void LinkedListsStructure()
        {
            // Bağlı liste tanımlama  
            LinkedList<string> linkedList = new LinkedList<string>();

            // Eleman ekleme  
            linkedList.AddLast("A"); // Bağlı listeye "A" ekliyoruz  
            linkedList.AddLast("B"); // Bağlı listeye "B" ekliyoruz  
            linkedList.AddLast("C"); // Bağlı listeye "C" ekliyoruz  

            // Elemanları yazdırma  
            Console.WriteLine("Bağlı Liste Elemanları:");
            foreach (var item in linkedList)
            {
                Console.WriteLine(item); // Her bir elemanı yazdırıyoruz  
            }

        }
    }
}
