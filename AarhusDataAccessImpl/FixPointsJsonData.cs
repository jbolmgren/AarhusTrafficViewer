namespace AarhusDataAccessImpl
{
    public class FixPointsJsonData
    {
        public bool Success { get; set; }
        public FixPointResult Result { get; set; }
    }

    public class FixPointResult
    {
        public FixPointRecord[] Records { get; set; }
    }

    public class FixPointRecord
    {
        public int Report_Id { get; set; }
        public double Point_1_lat { get; set; }
        public double Point_1_lng { get; set; }
        public double Point_2_lat { get; set; }
        public double Point_2_lng { get; set; }
        public int Distance_in_meters { get; set; }
    }
}