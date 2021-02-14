// "recordId": "FqwhCwAAAAAHAAAAALeEH3YBAAA=",
// "healthDataSource": 0,
// "appType": 1,
// "timeZone": "+0100",
// "startTime": 1606846560000,
// "deviceCode": 186756118,
// "endTime": 1606846620000,
// "type": 7,
// "samplePoints": [
//     {
//         "unit": "0",
//         "startTime": 1606846560000,
//         "endTime": 1606846620000,
//         "value": "89.0",
//         "key": "DATA_POINT_DYNAMIC_HEARTRATE"
//     }
// ],
// "version": 1606869697935
using System;
using System.Collections.Generic;

namespace ReadHuaweiHealth
{
    public class HealthData
    {
        public string recordId { get; set; }
        public int healthDataSource { get; set; }
        public int appType { get; set; }
        public string timeZone { get; set; }
        public DateTime startTime { get; set; }
        public int deviceCode { get; set; }
        public DateTime endTime { get; set; }
        public int type { get; set; }
        public List<samplePoints> samplePoints { get; set; }
        public DateTime version { get; set; }
    }

    public class samplePoints
    {
        public string unit { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string value { get; set; }
        public string key { get; set; }
    }
}