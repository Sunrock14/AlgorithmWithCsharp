using System.Reflection.Emit;

namespace Cryptography.App.Services;

/// <summary>
/// Tarihçe
/// Atbash şifreleme, tarihte bilinen en eski şifreleme yöntemlerinden biridir 
/// ve İbranice alfabesi için geliştirilmiştir. 
/// Bu yöntem, M.Ö. 500'lü yıllarda Babil sürgünü sırasında Yahudi bilginler tarafından kullanılmıştır. 
/// Atbash, aslında bir monoalfabetik şifreleme yöntemidir, yani her harf yalnızca 
/// bir başka harfe dönüştürülür.Atbash şifrelemesi, İbranice alfabesindeki harflerin
/// ters çevrilmesi prensibine dayanır.Örneğin, İbranice'de ilk harf olan "א" (Alef),
/// son harf olan "ת" (Tav) ile değiştirilir. Bu yöntem, İbranice metinlerde gizlilik
/// sağlamak veya dini metinlerde sembolik anlamlar oluşturmak için kullanılmıştır.
/// 
/// Teori 
/// Atbash şifrelemesi, bir harfi şu şekilde dönüştürür:
/// C=(Z−P)+A
/// C: Şifrelenmiş harf (Ciphertext)
/// P: Orijinal harf (Plaintext)
/// Z: Alfabenin son harfinin ASCII değeri (örneğin, İngilizce için 'Z' = 90)
/// A: Alfabenin ilk harfinin ASCII değeri (örneğin, İngilizce için 'A' = 65)
/// </summary>
public class AtbashCipher
{
    //Şifrelemek ve şifre çözmek için aynı method kullanılır 
    //Teknik olarak verilen harfi alfabedeki tersine çevirir
    public static string AtbashEncryptAndDecrypt(string input)
    {
        string result = "";
        input = input.ToUpper();
        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                result += (char)('Z' - (c - 'A'));
            }
            else
            {
                // Harf değilse olduğu gibi ekle  
                result += c;
            }
        }
        return result;
    }
}
