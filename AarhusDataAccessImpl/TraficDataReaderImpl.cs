using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess;

namespace AarhusDataAccessImpl
{
    public class TraficDataReaderImpl : ITraficDataReader
    {
        public const string AarhusFixpointsUrl = "http://www.odaa.dk/api/action/datastore_search?resource_id=c3097987-c394-4092-ad1d-ad86a81dbf37";
        public const string AarhusTraficMeasurementsUrl = "http://www.odaa.dk/api/action/datastore_search?resource_id=b3eeb0ff-c8a8-4824-99d6-e0a3747c8b0d";
        private readonly IHttpJsonClient _client;

        public TraficDataReaderImpl(IHttpJsonClient client)
        {
            _client = client;
        }


        public async Task<IList<TraficInfo>> SearchForTrafic(double lat, double lng, int radiusInMeters)
        {
            var fixPointsData = await _client.LoadJson<FixPointsJsonData>(AarhusFixpointsUrl);
            var traficData = await _client.LoadJson<TraficJsonData>(AarhusTraficMeasurementsUrl);
            if (!fixPointsData.Success || !traficData.Success)
                return new TraficInfo[0];
            var resultsInArea = fixPointsData.Result.Records.Where(x => FilterOnPosition(x, lat, lng, radiusInMeters));

            return CombineTraficdataWithFixpoints(traficData, resultsInArea);
        }

        private static List<TraficInfo> CombineTraficdataWithFixpoints(TraficJsonData traficData, IEnumerable<FixPointRecord> resultsInArea)
        {
            var info = new List<TraficInfo>();
            var traficDictionary = traficData.Result.Records.ToDictionary(x => x.Report_Id);
            foreach (var record in resultsInArea)
            {
                if (!traficDictionary.ContainsKey(record.Report_Id))
                    continue;

                var traficRecord = traficDictionary[record.Report_Id];
                if (!traficRecord.Status.Equals(TraficRecord.StatusOk))
                    continue;

                info.Add(new TraficInfo
                         {
                             StartPosition = new Position {Latitude = record.Point_1_lat, Longitude = record.Point_1_lng},
                             EndPosition = new Position {Latitude = record.Point_2_lat, Longitude = record.Point_2_lng},
                             AverageSpeed = traficRecord.AvgSpeed,
                             CarCount = traficRecord.VehicleCount,
                             RecordTime = traficRecord.TimeStamp
                         });
            }
            return info;
        }

        private bool FilterOnPosition(FixPointRecord fixPointRecord, double centerx, double centery, int radiusInMeters)
        {
            var x = fixPointRecord.Point_1_lat;
            var y = fixPointRecord.Point_1_lng;
            var x1 = fixPointRecord.Point_2_lat;
            var y1 = fixPointRecord.Point_2_lng;
            var distanceInMetersForPoint1 = DistanceInKM(centerx, centery, x, y) * 1000;
            var distanceInMetersForPoint2 = DistanceInKM(centerx, centery, x1, y1) * 1000;
            return radiusInMeters >= distanceInMetersForPoint1 ||  radiusInMeters >= distanceInMetersForPoint2;
        }

        private double DistanceInKM(double lat1, double lon1, double lat2, double lon2)
        {
            var p = Math.PI/180.0; // Math.PI / 180
            var a = 0.5 - Math.Cos((lat2 - lat1)*p)/2 +
                    Math.Cos(lat1*p)*Math.Cos(lat2*p)*
                    (1 - Math.Cos((lon2 - lon1)*p))/2;

            return 12742*Math.Asin(Math.Sqrt(a)); // 2 * R; R = 6371 km
        }

        private static bool IsInCirkle(double centerx, double centery, int radius, double x, double y)
        {
            var position = Math.Pow(x - centerx, 2) + Math.Pow(y - centery, 2);
            var isInCirkle = position <= Math.Pow(radius, 2);
            return isInCirkle;
        }
    }
}