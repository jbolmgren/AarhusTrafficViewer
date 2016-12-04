using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public interface ITraficDataReader
    {
        Task<IList<TraficInfo>> SearchForTrafic(double lat, double lng, int radiusInMeters);
    }

    public class TraficInfo
    {
        public Position StartPosition { get; set; }
        public Position EndPosition { get; set; }
        public int AverageSpeed { get; set; }
        public int CarCount { get; set; }
        public DateTime RecordTime { get; set; }
    }

    public class Position
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}