using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.BasicsDataStructure.DataStructure
{
    public class Stacks
    {
        /// <summary>
        /// Yığın, LIFO (Last In, First Out) prensibine göre çalışan bir veri yapısıdır.
        /// Yani, son eklenen eleman ilk çıkar. Yığın, genellikle fonksiyon çağrıları ve
        /// geri dönüşlerde kullanılır. Yığın, eleman ekleme ve çıkarma işlemlerinde hızlıdır.
        /// </summary>
        public void StacksStructure()
        {
            // Yığın tanımlama  
            Stack<int> stack = new Stack<int>();

            // Eleman ekleme  
            stack.Push(1); // Yığına 1 ekliyoruz  
            stack.Push(2); // Yığına 2 ekliyoruz  
            stack.Push(3); // Yığına 3 ekliyoruz  

            // Elemanları çıkarma  
            Console.WriteLine("Yığın Elemanları (LIFO):");
            while (stack.Count > 0) // Yığın boşalana kadar döngü  
            {
                Console.WriteLine(stack.Pop()); // En üstteki elemanı çıkarıp yazdırıyoruz  
            }
        }
    }
}
