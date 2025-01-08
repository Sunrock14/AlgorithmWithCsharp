namespace Algorithm.Cryptography.CryptographyAlgorithm.Historicals;

public class CeaserCipher
{
    /*
     * Tarihçesi
     * 
     * Sezar şifrelemesi, M.Ö. 1. yüzyılda Julius Caesar tarafından askeri iletişimde kullanılmıştır. 
     * Caesar, düşmanlarının mesajlarını okuyamaması için bu yöntemi geliştirmiştir. 
     * Şifreleme yöntemi oldukça basit olduğu için günümüzde kriptografi açısından güvenli kabul edilmez.
     * Ancak, tarihteki ilk şifreleme yöntemlerinden biri olması nedeniyle önemlidir.
     * Sezar şifrelemesi, bir metindeki her harfi belirli bir sayı kadar kaydırarak şifreleme yapar.
     * Örneğin, bir harfi 3 birim sağa kaydırarak şifreleme yapılırsa, "A" harfi "D" olur.
     * Şifre çözme işlemi ise bu kaydırmayı tersine çevirerek yapılır.
     * 
     * Teorisi
     * Sezar şifrelemesi, bir simetrik şifreleme yöntemidir. 
     * Şifreleme ve şifre çözme işlemleri aynı anahtar (kaydırma miktarı) ile yapılır. 
     * Şifreleme işlemi şu şekilde tanımlanabilir:
     * Şifreleme Formülü:
     * 
     * C=(P+K)mod26
     * C: Şifrelenmiş harf (Ciphertext)
     * P: Orijinal harf (Plaintext)
     * K: Kaydırma miktarı (Key)
     * 26: Alfabenin harf sayısı (İngilizce için)
     * 
     * Şifre Çözme Formülü:
     * 
     * P=(C−K)mod26      
     * Bu formüller, harflerin alfabetik sırasına göre bir sayı ile temsil edilmesiyle çalışır (örneğin, A=0, B=1, ..., Z=25).
     */

    const int Shift = 3;

    public static string CeaserEncrypt(string plaintext)
    {
        string result = "";
        foreach (char c in plaintext)
        {
            if (char.IsLetter(c))
            {
                char offset = char.IsUpper(c) ? 'A' : 'a';
                result += (char)((c + Shift - offset) % 26 + offset);
            }
            else
            {
                result += c; // Harf değilse olduğu gibi ekle  
            }
        }
        return result;
    }
    public static string CeaserDecrypt(string ciphertext)
    {
        string result = "";
        foreach (char c in ciphertext)
        {
            if (char.IsLetter(c))
            {
                char offset = char.IsUpper(c) ? 'A' : 'a';
                result += (char)((c - Shift - offset + 26) % 26 + offset);
            }
            else
            {
                result += c; // Harf değilse olduğu gibi ekle  
            }
        }
        return result;
    }
}
