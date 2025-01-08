using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.BasicsDataStructure.DataStructure
{
    public class Queues
    {
        /// <summary>
        /// Kuyruk, FIFO (First In, First Out) prensibine göre çalışan bir veri yapısıdır.
        /// Yani, ilk eklenen eleman ilk çıkar. Kuyruk, genellikle görev yönetimi ve işlem
        /// sıralama gibi durumlarda kullanılır. Kuyruk, eleman ekleme ve çıkarma işlemlerinde hızlıdır.
        /// </summary>
        public void QueuesStructure()
        {
            // Kuyruk tanımlama  
            Queue<string> queue = new Queue<string>();

            // Eleman ekleme  
            queue.Enqueue("A"); // Kuyruğa "A" ekliyoruz  
            queue.Enqueue("B"); // Kuyruğa "B" ekliyoruz  
            queue.Enqueue("C"); // Kuyruğa "C" ekliyoruz  

            // Elemanları çıkarma  
            Console.WriteLine("Kuyruk Elemanları (FIFO):");
            while (queue.Count > 0) // Kuşak boşalana kadar döngü  
            {
                Console.WriteLine(queue.Dequeue()); // En öndeki elemanı çıkarıp yazdırıyoruz  
            }
        }
    }
}
