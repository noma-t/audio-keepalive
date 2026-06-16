using NAudio.CoreAudioApi;
using NAudio.Wave;
using System.Linq;
using System.Threading;

class TinyToneProvider : ISampleProvider
{
    public WaveFormat WaveFormat { get; } = WaveFormat.CreateIeeeFloatWaveFormat(44100, 1);
    double phase = 0;

    public int Read(float[] buffer, int offset, int count)
    {
        for (int i = 0; i < count; i++)
        {
            buffer[offset + i] = (float)(1e-5 * System.Math.Sin(phase));
            phase += 2 * System.Math.PI * 1000.0 / 44100.0;
        }
        return count;
    }
}

class P
{
    static string LoadDeviceName()
    {
        var envPath = System.IO.Path.Combine(
            System.AppContext.BaseDirectory, ".env");
        if (System.IO.File.Exists(envPath))
        {
            foreach (var line in System.IO.File.ReadAllLines(envPath))
            {
                var parts = line.Split('=', 2);
                if (parts.Length == 2 && parts[0].Trim() == "DEVICE_NAME")
                    return parts[1].Trim();
            }
        }
        return "サウンドバー";
    }

    static void Main()
    {
        var DEVICE_NAME = LoadDeviceName();

        while (true)
        {
            try
            {
                var device = new MMDeviceEnumerator()
                    .EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active)
                    .FirstOrDefault(d => d.FriendlyName.Contains(DEVICE_NAME));

                if (device == null)
                {
                    Thread.Sleep(5000);
                    continue;
                }

                using var output = new WasapiOut(device, AudioClientShareMode.Shared, false, 100);
                output.Init(new TinyToneProvider());
                output.Play();

                while (output.PlaybackState == PlaybackState.Playing)
                    Thread.Sleep(1000);

            }
            catch
            {
                Thread.Sleep(5000);
            }
        }
    }
}
