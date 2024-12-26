namespace Cryptography.App.Services.Historicals;

/// <summary>
/// Tarihçesi
/// Vigenère şifrelemesi, kriptografi tarihindeki en önemli polialfabetik şifreleme
/// yöntemlerinden biridir. İlk olarak 16. yüzyılda geliştirilmiş ve uzun yıllar 
/// boyunca "kırılamaz şifreleme yöntemi" olarak kabul edilmiştir.
/// 
/// Vigenère şifrelemesi, ilk olarak 1553 yılında Giovanni Battista Bellaso
/// tarafından tanıtılmıştır. Bellaso, bu yöntemi "anahtar kelime" kullanarak geliştirmiştir
/// ve bu yöntem, modern Vigenère şifrelemesinin temelini oluşturur.
/// Ancak, bu yöntem Bellaso'nun adıyla değil, daha sonra bu yöntemi popülerleştiren
/// başka bir kişiyle anılmıştır.
/// 
/// 1586 yılında Fransız diplomat ve kriptograf Blaise de Vigenère, Bellaso'nun yöntemini daha 
/// da geliştirmiş ve bu yöntemi tanıtmıştır.Vigenère, bu yöntemi "polialfabetik şifreleme"
/// olarak tanımlamış ve şifreleme işlemini daha sistematik hale getirmiştir.Bu nedenle,
/// yöntem onun adıyla anılmaya başlanmıştır.
/// 
/// Teorisi
/// 
/// Vigenère şifrelemesi, polialfabetik bir şifreleme yöntemidir. Bu, her harfin farklı bir
/// alfabe ile şifrelendiği anlamına gelir. Şifreleme işlemi, bir anahtar kelime (key)
/// kullanılarak gerçekleştirilir. Anahtar kelimenin her harfi, düz metindeki (plaintext)
/// harfleri belirli bir miktarda kaydırmak için kullanılır.
/// 
/// Vigenère şifrelemesi, Sezar şifrelemesine benzer şekilde çalışır, ancak her harf için 
/// farklı bir kaydırma değeri kullanılır. Şifreleme işlemi şu şekilde tanımlanır:
/// Ci​ = (Pi​+Ki​) mod26
/// Ci : Şifrelenmiş harf (Ciphertext)
/// Pi : Düz metindeki harf (Plaintext)
/// Ki : Anahtar kelimenin ilgili harfi (Key)
/// mod26 : Alfabenin 26 harfli olduğu varsayımıyla, kaydırma işlemini alfabe sınırları içinde tutar.
/// 
/// Şifre Çözme Teorisi:
/// Şifre çözme işlemi, şifreleme işleminin tersidir. Şifrelenmiş metni (ciphertext) ve anahtar kelimeyi kullanarak düz metni (plaintext) elde ederiz:
/// Pi=(Ci−Ki+26) mod26 
/// </summary>
public class VigenereCipher
{
    private static string key = "YourVigenereKey";
    public static string VigenereEncrypt(string plaintext)
    {
        string result = "";
        int keyIndex = 0;
        int keyLength = key.Length;

        foreach (char c in plaintext)
        {
            if (char.IsLetter(c))
            {
                char offset = char.IsUpper(c) ? 'A' : 'a';
                char keyChar = char.IsUpper(c) ?
                    char.ToUpper(key[keyIndex % keyLength]) :
                    char.ToLower(key[keyIndex % keyLength]);

                int shift = keyChar - offset;

                result += (char)((c - offset + shift) % 26 + offset);
                keyIndex++;
            }
            else
            {
                result += c;
            }
        }

        return result;
    }
    public static string VigenereDecrypt(string ciphertext)
    {
        string result = "";
        int keyIndex = 0;
        int keyLength = key.Length;

        foreach (char c in ciphertext)
        {
            if (char.IsLetter(c))
            {
                char offset = char.IsUpper(c) ? 'A' : 'a';
                char keyChar = char.IsUpper(c) ?
                    char.ToUpper(key[keyIndex % keyLength]) :
                    char.ToLower(key[keyIndex % keyLength]);

                int shift = keyChar - offset;

                result += (char)((c - offset - shift + 26) % 26 + offset);
                keyIndex++;
            }
            else
            {
                result += c;
            }
        }

        return result;
    }
}
