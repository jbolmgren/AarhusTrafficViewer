using Microsoft.VisualStudio.TestTools.UnitTesting;
using AarhusDataAccessImpl;

namespace AarhusDataAccessImplTest
{
    [TestClass]
    public class UnitTest1
    {
        private string FixPointData = "{ 	\"success\": true, 	\"result\": {	\"records\": [{	\"POINT_1_STREET\": null,	\"POINT_1_LAT\": \"56.16389697427008\",	\"POINT_1_NAME\": \"3193\",	\"POINT_1_CITY\": null,	\"POINT_2_NAME\": \"3192\",	\"POINT_2_LNG\": \"10.194526468751974\",	\"POINT_2_STREET\": null,	\"NDT_IN_KMH\": 60,	\"POINT_2_POSTAL_CODE\": null,	\"POINT_2_COUNTRY\": \"Denmark\",	\"RBA_ID\": 182224,	\"ORGANISATION\": \"COWI\",	\"DURATION_IN_SEC\": 49,	\"POINT_2_LAT\": \"56.16929516572502\",	\"POINT_1_POSTAL_CODE\": null,	\"POINT_2_STREET_NUMBER\": null,	\"POINT_2_CITY\": null,	\"ROAD_TYPE\": \"MAJOR_ROAD\",	\"POINT_1_LNG\": \"10.18616224669654\",	\"REPORT_ID\": 180952,	\"POINT_1_COUNTRY\": \"Denmark\",	\"DISTANCE_IN_METERS\": 810,	\"REPORT_NAME\": \"AAR_BT_0145 3193 3192\",	\"POINT_1_STREET_NUMBER\": null,	\"_id\": 79	},	{	\"POINT_1_STREET\": \"\u00c5by Ringvej\",	\"POINT_1_LAT\": \"56.17124851709378\",	\"POINT_1_NAME\": \"Viborgvej\",	\"POINT_1_CITY\": \"Aarhus\",	\"POINT_2_NAME\": \"Paludan M\u00fcllers Vej\",	\"POINT_2_LNG\": \"10.178543744697558\",	\"POINT_2_STREET\": \"Hasle Ringvej\",	\"NDT_IN_KMH\": 65,	\"POINT_2_POSTAL_CODE\": \"8210\",	\"POINT_2_COUNTRY\": \"Denmark\",	\"RBA_ID\": 1811,	\"ORGANISATION\": \"BLIP Systems A/S\",	\"DURATION_IN_SEC\": 82,	\"POINT_2_LAT\": \"56.17636991803806\",	\"POINT_1_POSTAL_CODE\": \"8210\",	\"POINT_2_STREET_NUMBER\": \"60\",	\"POINT_2_CITY\": \"Aarhus\",	\"ROAD_TYPE\": \"STREET\",	\"POINT_1_LNG\": \"10.156836627140033\",	\"REPORT_ID\": 1164,	\"POINT_1_COUNTRY\": \"Denmark\",	\"DISTANCE_IN_METERS\": 1471,	\"REPORT_NAME\": \"Viborgvej->Paludan M\u00fcllers vej\",	\"POINT_1_STREET_NUMBER\": \"100\",	\"_id\": 450	}],	\"_links\": {	\"start\": \"/api/action/datastore_search?resource_id=c3097987-c394-4092-ad1d-ad86a81dbf37\",	\"next\": \"/api/action/datastore_search?offset=100&resource_id=c3097987-c394-4092-ad1d-ad86a81dbf37\"	},	\"total\": 2 	} }";

        private string TraficData = "{ 	\"success\": true, 	\"result\": {	\"records\": [{	\"status\": \"OK\",	\"avgMeasuredTime\": 76,	\"TIMESTAMP\": \"2016-11-25T20:18:00\",	\"medianMeasuredTime\": 76,	\"avgSpeed\": 44,	\"vehicleCount\": 10,	\"_id\": 330,	\"REPORT_ID\": 181331	},	{	\"status\": \"OK\",	\"avgMeasuredTime\": 78,	\"TIMESTAMP\": \"2016-10-05T09:29:00\",	\"medianMeasuredTime\": 78,	\"avgSpeed\": 67,	\"vehicleCount\": 17,	\"_id\": 450,	\"REPORT_ID\": 1164	}],	\"_links\": {	\"start\": \"/api/action/datastore_search?resource_id=b3eeb0ff-c8a8-4824-99d6-e0a3747c8b0d\",	\"next\": \"/api/action/datastore_search?offset=100&resource_id=b3eeb0ff-c8a8-4824-99d6-e0a3747c8b0d\"	},	\"total\": 2 	} }";

        [TestMethod]
        public void TestParsingTraficData()
        {
            var traficData = new JsonConverterImpl().Deserialize<TraficJsonData>(TraficData);

        }
    }
}