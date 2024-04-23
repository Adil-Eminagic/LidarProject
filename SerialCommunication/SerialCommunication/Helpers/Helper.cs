
using SerialCommunication.Structures;

namespace SerialCommunication.Helpers
{
    public class Helper
    {
        public static void AddByteToByteArray(ref byte?[] byteArray, byte byteToAdd)
        {
            byte?[] resultArray = new byte?[byteArray.Length + 1];
            for (int i = 0; i < byteArray.Length; i++)
            {
                resultArray[i] = byteArray[i];
            }
            resultArray[byteArray.Length] = byteToAdd;
            byteArray = resultArray;
        }

        public static void ConvertToFrameOnReceived(ref byte[] byteArray, ref List<LiDARFrame> dARFrames)
        {
            for (int i = 0; i < byteArray.Length; i++)
            {
                if (byteArray.Length > 46) // because frame consist of 47 bytes
                {
                    if (byteArray[i] == 84 && byteArray.Length - i > 46) //checks start of package (header) and are all bytes in same turn
                    {
                        var lidarFrame = new LiDARFrame();
                        lidarFrame.header = byteArray[i++];//adds each byte or two bytes to each attribute in structure
                        lidarFrame.ver_len = byteArray[i++];
                        lidarFrame.speed = (ushort)(byteArray[i++] + byteArray[i++] * 256);
                        lidarFrame.start_angle = (ushort)(byteArray[i++] + byteArray[i++] * 256);
                        lidarFrame.points = new List<LidarPoint>();

                        for (int j = 0; j < 12; j++)
                        {
                            LidarPoint lidarPoint = new LidarPoint();
                            lidarPoint.distance = (ushort)(byteArray[i++] + byteArray[i++] * 256);
                            lidarPoint.intensity = byteArray[i++];
                            lidarFrame.points.Add(lidarPoint);
                        }
                        lidarFrame.end_angle = (ushort)(byteArray[i++] + byteArray[i++] * 256);
                        lidarFrame.timestamp = (ushort)(byteArray[i++] + byteArray[i++] * 256);
                        lidarFrame.crc8 = byteArray[i];

                        

                        dARFrames.Add(lidarFrame);

                    }
                }
            }
        }
    }

    
}
