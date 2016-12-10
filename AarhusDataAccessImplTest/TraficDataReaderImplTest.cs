using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AarhusDataAccessImpl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AarhusDataAccessImplTest
{
    [TestClass]
    public class TraficDataReaderImplTest
    {
        [TestMethod]
        public void TestLoadOfData()
        {
            var httpJsonClientStub = new HttpJsonClientStub();
            var reportId = 1;
            var timeStamp = DateTime.Now;
            httpJsonClientStub.Add(CreateTraficTestData(new TraficRecord(){Report_Id = reportId, TimeStamp = timeStamp, Status = TraficRecord.StatusOk}));
            httpJsonClientStub.Add(CreateFixpointTestData(new FixPointRecord(){Report_Id = reportId, Point_1_lat = 9, Point_1_lng = 9, Point_2_lat = 22, Point_2_lng = 22}));

            var dataReader = new TraficDataReaderImpl(httpJsonClientStub);
            var traficInfos = dataReader.SearchForTrafic(9, 9, 2000).Result;
            Assert.AreEqual(timeStamp, traficInfos.Single().RecordTime);
        }

        private static FixPointsJsonData CreateFixpointTestData(params FixPointRecord[] fixPointRecords)
        {
            return new FixPointsJsonData(){Success = true, Result = new FixPointResult(){Records = fixPointRecords}};
        }

        private static TraficJsonData CreateTraficTestData(params TraficRecord[] traficRecords)
        {
            return new TraficJsonData(){Success = true, Result = new TraficResult(){Records = traficRecords}};
        }
    }

    public class HttpJsonClientStub : IHttpJsonClient
    {
        private readonly IList<Object> _elements = new List<object>();

        public Task<T> LoadJson<T>(string url) where T : class
        {
            return Task.FromResult(_elements.Single(x => x is T) as T);
        }

        public void Add(Object data)
        {
            _elements.Add(data);
        }
    }
}
