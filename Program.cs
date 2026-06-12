using System.IO;
using System.Media;
using System.Threading;

class P {
    static void Main() {
        const int rate = 8000;
        const int dataLen = rate * 2 * 10;
        var ms = new MemoryStream();
        var w = new BinaryWriter(ms);
        w.Write(new char[]{'R','I','F','F'});
        w.Write(36 + dataLen);
        w.Write(new char[]{'W','A','V','E','f','m','t',' '});
        w.Write(16); w.Write((short)1); w.Write((short)1);
        w.Write(rate); w.Write(rate * 2);
        w.Write((short)2); w.Write((short)16);
        w.Write(new char[]{'d','a','t','a'});
        w.Write(dataLen);
        w.Write(new byte[dataLen]);
        ms.Position = 0;
        var player = new SoundPlayer(ms);
        player.PlayLooping();
        Thread.Sleep(-1);
    }
}
