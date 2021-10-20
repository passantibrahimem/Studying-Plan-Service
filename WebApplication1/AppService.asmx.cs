using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Script.Serialization;
using StudyingplanApp.Enums;
using System.Globalization;

namespace StudyingplanApp
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetStudyingPlan(string _startingDate, List<int> arrofWorkDays, int noOfSessions, string StartingChapter)
        {

            List<string> sessions = GetSessionDates(_startingDate, noOfSessions, arrofWorkDays);
            return new JavaScriptSerializer().Serialize(sessions);
        }
        public string GetDaysperChapter(List<int> arrofWorkDays, int noOfSessions, string StartingChapter)
        {
            string output = string.Empty;
            int k = 0;
            int _startingChapter = Convert.ToInt32(StartingChapter);
            // to get the studying days for every chapter
            for (int i = _startingChapter; i <= 30; i++)
            {
                output +=  "For Chapter" + " " + _startingChapter + " " + "{";
                for (int j = 0; j < noOfSessions; j++)
                {
                    if ( k == arrofWorkDays.Count )
                    {
                        k = 0;
                    }
                    WeekEnum day = (WeekEnum)arrofWorkDays[k];
                    output +=  day + ",";
                    k++;
                }
                output=output.Substring(0, output.Length - 1);
                output += "}";
                _startingChapter += 1;
            }
            // if start chapter isn't the first chapter
            _startingChapter = Convert.ToInt32(StartingChapter) - 1;

            for (int i = _startingChapter ; i >= 1; i--)
            {
                output += "For Chapter" + " " + _startingChapter + " " + "{";
                {
                    for (int j = 0; j < noOfSessions; j++)
                    {
                        if (k == arrofWorkDays.Count)
                        {
                            k = 0;
                        }
                        WeekEnum day = (WeekEnum)arrofWorkDays[k];
                        output += day + ",";
                        k++;
                    }
                }
                output = output.Substring(0, output.Length - 1);
                output += "}";
                _startingChapter -= 1;

            }
            return new JavaScriptSerializer().Serialize(output);
        }
        private List<string> GetSessionDates(string startingDate, decimal noOfSessions, List<int> arrofWorkDays)
        {

            List<string> dates = new List<string>();
            DateTime expirydate;
            int startDay;
           // if (arrofWorkDays.Count > 0)
           // {
                noOfSessions = Math.Ceiling((noOfSessions * 30) / arrofWorkDays.Count);
                DateTime _startDate = Convert.ToDateTime(startingDate);
                dates.Add(_startDate.ToString("dd / MM / yyyy"));
                for (int i = 0; i < noOfSessions; i++)
                {
                    startDay = arrofWorkDays[0];
                    for (int j = 1; j < arrofWorkDays.Count; j++)
                    {
                        expirydate = _startDate.AddDays(arrofWorkDays[j] - startDay);
                        _startDate = expirydate;
                        startDay = arrofWorkDays[j];
                        dates.Add(expirydate.ToString("dd / MM / yyyy"));
                    }
                    expirydate = _startDate.AddDays(7 - (arrofWorkDays[arrofWorkDays.Count - 1]) + arrofWorkDays[0]);
                    _startDate = expirydate;
                    dates.Add(expirydate.ToString("dd / MM / yyyy"));
                }
          //  }
        
            
            return dates;
        }
    }
}
