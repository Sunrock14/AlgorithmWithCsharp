using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;

namespace Cryptography.App.Services;
/// <summary>
/// Tarihçesi
/// 
/// Hill şifreleme yöntemi, 1929 yılında Lester S.Hill tarafından geliştirilmiştir.
/// Bu yöntem, bir metni şifrelemek için matris çarpımını kullanan ilk şifreleme algoritmalarından biridir.
/// Hill şifreleme, blok şifreleme yöntemlerinden biridir ve genellikle sabit boyutlu bloklar üzerinde çalışır
/// (örneğin, 2x2 veya 3x3 matrisler).
/// 
/// Teorisi
/// 1.Anahtar Matrisi
/// Anahtar Matrisi: Hill şifrelemede, bir anahtar matrisi (örneğin, 2x2 veya 3x3 boyutunda) kullanılır.
/// Bu matris, şifreleme ve şifre çözme işlemlerinde kullanılır. 
/// Anahtar matrisi, modüler aritmetik kullanılarak terslenebilir olmalıdır.
/// 
/// 2.Şifreleme
/// Metin, bloklara ayrılır (örneğin, 2 harf veya 3 harf blokları).
/// Her blok, bir vektör olarak temsil edilir.
/// Şifreleme işlemi, şu formülle gerçekleştirilir: C=(K*P) mod26
/// C: Şifrelenmiş metin vektörü  
/// K: Anahtar matrisi  
/// P: Düz metin vektörü  
/// mod 26: İngiliz alfabesindeki harf sayısı (0-25 arası harfler)  
/// 
/// 3.Şifre Çözme:
/// P=(K^−1⋅C) mod26
/// </summary>
public class HillCipher
{
    private readonly int[,] _keyMatrix = { { 3, 3 }, { 2, 5 } }; // Örnek anahtar matrisi  
    private readonly int _mod = 26;

    public HillCipher(/*int[,]? keyMatrix*/)
    {
        //_keyMatrix = keyMatrix;
        if (!IsInvertible(_keyMatrix)) // terslenebilir olduğunu kontrol et
        {
            throw new ArgumentException("Bu matrix terslenebilir değildir.");
        }
    }

    public string Encrypt(string plaintext)
    {
        plaintext = NormalizeText(plaintext);
        int blockSize = _keyMatrix.GetLength(0);
        var blocks = CreateBlocks(plaintext, blockSize);

        return string.Concat(blocks.Select(block => EncryptBlock(block)));
    }

    public string Decrypt(string ciphertext)
    {
        int blockSize = _keyMatrix.GetLength(0);
        var blocks = CreateBlocks(ciphertext, blockSize);

        var inverseKeyMatrix = InverseMatrix(_keyMatrix);
        return string.Concat(blocks.Select(block => DecryptBlock(block, inverseKeyMatrix)));
    }

    private string EncryptBlock(int[] block)
    {
        int[] result = MultiplyMatrixVector(_keyMatrix, block);
        return string.Concat(result.Select(num => (char)(num + 'A')));
    }

    private string DecryptBlock(int[] block, int[,] inverseKeyMatrix)
    {
        int[] result = MultiplyMatrixVector(inverseKeyMatrix, block);
        return string.Concat(result.Select(num => (char)(num + 'A')));
    }

    private int[] MultiplyMatrixVector(int[,] matrix, int[] vector)
    {
        int size = matrix.GetLength(0);
        int[] result = new int[size];

        for (int i = 0; i < size; i++)
        {
            result[i] = 0;
            for (int j = 0; j < size; j++)
            {
                result[i] += matrix[i, j] * vector[j];
            }
            result[i] %= _mod;
            if (result[i] < 0) result[i] += _mod;
        }

        return result;
    }

    private int[,] InverseMatrix(int[,] matrix)
    {
        int size = matrix.GetLength(0);
        int determinant = Determinant(matrix);
        int determinantInverse = ModInverse(determinant, _mod);

        int[,] adjugate = AdjugateMatrix(matrix);
        int[,] inverse = new int[size, size];

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                inverse[i, j] = (adjugate[i, j] * determinantInverse) % _mod;
                if (inverse[i, j] < 0) inverse[i, j] += _mod;
            }
        }

        return inverse;
    }

    private int Determinant(int[,] matrix)
    {
        // Only supports 2x2 matrices for simplicity  
        if (matrix.GetLength(0) == 2)
        {
            return (matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0]) % _mod;
        }
        throw new NotImplementedException("Determinant calculation for larger matrices is not implemented.");
    }

    private int ModInverse(int a, int m)
    {
        a %= m;
        for (int x = 1; x < m; x++)
        {
            if ((a * x) % m == 1) return x;
        }
        throw new ArgumentException("No modular inverse exists.");
    }

    private int[,] AdjugateMatrix(int[,] matrix)
    {
        // Only supports 2x2 matrices for simplicity  
        if (matrix.GetLength(0) == 2)
        {
            return new int[,]
            {
                { matrix[1, 1], -matrix[0, 1] },
                { -matrix[1, 0], matrix[0, 0] }
            };
        }
        throw new NotImplementedException("Adjugate calculation for larger matrices is not implemented.");
    }

    /// <summary>
    /// Matrisin terslebilir olduğunu kontrol eder.
    /// </summary>
    /// <param name="matrix"></param>
    /// <returns></returns>
    private bool IsInvertible(int[,] matrix)
    {
        int determinant = Determinant(matrix);
        return Gcd(determinant, _mod) == 1;
    }

    private int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    /// <summary>
    /// Metin büyük karakterlere çevirir. Sadece harfleri alır
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    private string NormalizeText(string text)
    {
        return new string(text.ToUpper().Where(char.IsLetter).ToArray());
    }

    private int[][] CreateBlocks(string text, int blockSize)
    {
        int paddedLength = (int)Math.Ceiling((double)text.Length / blockSize) * blockSize;
        text = text.PadRight(paddedLength, 'X');

        int[][] blocks = new int[text.Length / blockSize][];
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i] = new int[blockSize];
            for (int j = 0; j < blockSize; j++)
            {
                blocks[i][j] = text[i * blockSize + j] - 'A';
            }
        }

        return blocks;
    }
}  