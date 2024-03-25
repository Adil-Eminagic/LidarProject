
namespace SerialCommunication.Structures
{
    public struct LiDARFrame
    {
        public byte header;
        public byte ver_len;
        public ushort speed;
        public ushort start_angle;
        public List<LidarPoint> points;
        public ushort end_angle;
        public ushort timestamp;
        public byte crc8;
    }
}
