using System;

namespace AarhusDataAccessImpl
{
    public class TraficJsonData
    {
        public bool Success { get; set; }
        public TraficResult Result { get; set; }
    }


    public class TraficResult
    {
        public TraficRecord[] Records { get; set; }
    }

    public class TraficRecord
    {
        public static string StatusOk = "OK";

        public int Report_Id { get; set; }
        public string Status { get; set; }
        public int AvgSpeed { get; set; }
        public int VehicleCount { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}