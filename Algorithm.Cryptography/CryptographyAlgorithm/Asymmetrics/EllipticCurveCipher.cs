//ChatGPT Created!

//using System.Numerics;

//namespace Cryptography.App.Services.Asymmetrics;

///// <summary>
///// Eliptik eğri üzerindeki bir noktayı temsil eden sınıf.
///// Bir nokta (x,y) koordinatları ile tanımlanır veya sonsuzluk noktası olabilir.
///// </summary>
//public class Point
//{
//    public BigInteger X { get; set; }  // X koordinatı
//    public BigInteger Y { get; set; }  // Y koordinatı
//    public bool IsInfinity { get; set; }  // Sonsuzluk noktası kontrolü

//    // Normal nokta constructor'ı
//    public Point(BigInteger x, BigInteger y)
//    {
//        X = x;
//        Y = y;
//        IsInfinity = false;
//    }

//    // Sonsuzluk noktası constructor'ı
//    public Point()
//    {
//        IsInfinity = true;
//    }
//}

///// <summary>
///// Eliptik Eğri şifreleme işlemlerini gerçekleştiren ana sınıf.
///// y² = x³ + ax + b formundaki eğriyi mod p üzerinde tanımlar.
///// </summary>
//public class EllipticCurve
//{
//    private readonly BigInteger a;  // Eğri parametresi a
//    private readonly BigInteger b;  // Eğri parametresi b
//    private readonly BigInteger p;  // Sonlu cisim modülüsü
//    private readonly Point G;       // Üreteç nokta (base point)
//    private readonly BigInteger n;  // Üreteç noktanın derecesi (order)

//    public EllipticCurve()
//    {
//        // secp256k1 eğrisi parametreleri (Bitcoin'in kullandığı eğri)
//        a = 0;
//        b = 7;
//        // p: 2^256 - 2^32 - 977
//        p = BigInteger.Parse("115792089237316195423570985008687907853269984665640564039457584007908834671663");
//        // G: Üreteç nokta koordinatları
//        G = new Point(
//            BigInteger.Parse("55066263022277343669578718895168534326250603453777594175500187360389116729240"),
//            BigInteger.Parse("32670510020758816978083085130507043184471273380659243275938904335757337482424")
//        );
//        // n: Üreteç noktanın derecesi
//        n = BigInteger.Parse("115792089237316195423570985008687907852837564279074904382605163141518161494337");
//    }

//    /// <summary>
//    /// Modüler aritmetikte çarpma işleminin tersini hesaplar.
//    /// a * x ≡ 1 (mod m) denklemini çözer.
//    /// Extended Euclidean algoritmasını kullanır.
//    /// </summary>
//    private BigInteger ModInverse(BigInteger a, BigInteger m)
//    {
//        BigInteger m0 = m;
//        BigInteger y = 0, x = 1;

//        while (a > 1)
//        {
//            BigInteger q = a / m;
//            BigInteger t = m;

//            m = a % m;
//            a = t;
//            t = y;

//            y = x - q * y;
//            x = t;
//        }

//        if (x < 0)
//            x += m0;

//        return x;
//    }

//    /// <summary>
//    /// Eliptik eğri üzerinde iki noktayı toplar.
//    /// Geometrik olarak, iki noktadan geçen doğrunun eğriyi kestiği üçüncü noktanın x-eksenine göre yansımasını bulur.
//    /// </summary>
//    private Point AddPoints(Point P1, Point P2)
//    {
//        if (P1.IsInfinity) return P2;  // P1 sonsuzsa sonuç P2'dir
//        if (P2.IsInfinity) return P1;  // P2 sonsuzsa sonuç P1'dir

//        BigInteger slope;
//        if (P1.X == P2.X && P1.Y == P2.Y)
//        {
//            // Nokta kendisiyle toplanıyor (point doubling)
//            if (P1.Y == 0)
//                return new Point();  // Dikey teğet durumu

//            // Eğim = (3x²+a)/(2y)
//            slope = (3 * BigInteger.Pow(P1.X, 2) + a) * ModInverse(2 * P1.Y, p) % p;
//        }
//        else
//        {
//            // Farklı noktalar toplanıyor (point addition)
//            if (P1.X == P2.X)
//                return new Point();  // Dikey doğru durumu

//            // Eğim = (y2-y1)/(x2-x1)
//            slope = ((P2.Y - P1.Y) * ModInverse((P2.X - P1.X + p) % p, p)) % p;
//        }

//        // Yeni X koordinatı: x3 = λ² - x1 - x2
//        BigInteger x3 = (BigInteger.Pow(slope, 2) - P1.X - P2.X) % p;
//        if (x3 < 0) x3 += p;

//        // Yeni Y koordinatı: y3 = λ(x1 - x3) - y1
//        BigInteger y3 = (slope * (P1.X - x3) - P1.Y) % p;
//        if (y3 < 0) y3 += p;

//        return new Point(x3, y3);
//    }

//    /// <summary>
//    /// Bir noktayı skaler ile çarpar (nokta çarpımı).
//    /// Double-and-add algoritmasını kullanır.
//    /// k * P = P + P + ... + P (k kere)
//    /// </summary>
//    private Point ScalarMult(Point P, BigInteger k)
//    {
//        if (k == 0) return new Point();  // k=0 ise sonuç sonsuzluk noktası
//        if (k == 1) return P;            // k=1 ise sonuç noktanın kendisi

//        Point Q = ScalarMult(P, k / 2);  // Recursive olarak k/2 ile çarp
//        Q = AddPoints(Q, Q);             // Sonucu kendisiyle topla

//        if (k % 2 == 1)                  // k tek sayıysa bir P daha ekle
//            Q = AddPoints(Q, P);

//        return Q;
//    }

//    /// <summary>
//    /// Yeni bir açık/özel anahtar çifti oluşturur.
//    /// Özel anahtar: rastgele bir d sayısı
//    /// Açık anahtar: Q = dG (G'nin d katı)
//    /// </summary>
//    public (Point publicKey, BigInteger privateKey) GenerateKeyPair()
//    {
//        // Rastgele özel anahtar oluştur
//        byte[] privateKeyBytes = new byte[32];
//        new Random().NextBytes(privateKeyBytes);
//        BigInteger privateKey = new BigInteger(privateKeyBytes);
//        privateKey = privateKey % (n - 1) + 1;

//        // Açık anahtarı hesapla: Q = dG
//        Point publicKey = ScalarMult(G, privateKey);

//        return (publicKey, privateKey);
//    }

//    /// <summary>
//    /// Bir mesajı şifreler.
//    /// Mesaj bir eğri noktası olarak temsil edilmelidir.
//    /// ElGamal şifreleme yöntemini kullanır:
//    /// C1 = kG
//    /// C2 = M + kQ (Q = alıcının açık anahtarı)
//    /// </summary>
//    public (Point C1, Point C2) Encrypt(Point message, Point publicKey)
//    {
//        // Rastgele k değeri seç
//        byte[] kBytes = new byte[32];
//        new Random().NextBytes(kBytes);
//        BigInteger k = new BigInteger(kBytes) % (n - 1) + 1;

//        // C1 = kG hesapla
//        Point C1 = ScalarMult(G, k);

//        // C2 = M + kQ hesapla
//        Point kP = ScalarMult(publicKey, k);
//        Point C2 = AddPoints(message, kP);

//        return (C1, C2);
//    }

//    /// <summary>
//    /// Şifrelenmiş mesajı çözer.
//    /// ElGamal şifre çözme:
//    /// M = C2 - dC1 (d = özel anahtar)
//    /// </summary>
//    public Point Decrypt(Point C1, Point C2, BigInteger privateKey)
//    {
//        // dC1 hesapla
//        Point dC1 = ScalarMult(C1, privateKey);
//        // Çıkarma işlemi için noktanın tersini al (y koordinatını negatifleme)
//        dC1.Y = -dC1.Y;
//        if (dC1.Y < 0) dC1.Y += p;

//        // M = C2 - dC1
//        return AddPoints(C2, dC1);
//    }
//}

