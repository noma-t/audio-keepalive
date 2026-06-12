using NAudio.Wave;
using System;
using System.Threading;

class TinyToneProvider : ISampleProvider {
    public WaveFormat WaveFormat { get; } = WaveFormat.CreateIeeeFloatWaveFormat(44100, 1);
    double phase = 0;

    public int Read(float[] buffer, int offset, int count) {
        for (int i = 0; i < count; i++) {
            buffer[offset + i] = (float)(1e-5 * Math.Sin(phase)); // -100dB、完全に聴こえない
            phase += 2 * Math.PI * 1000.0 / 44100.0;
        }
        return count;
    }
}

class P {
    static void Main() {
        using var output = new WasapiOut();
        output.Init(new TinyToneProvider());
        output.Play();
        Thread.Sleep(Timeout.Infinite);
    }
}
