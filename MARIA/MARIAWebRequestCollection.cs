using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARIA
{
    public partial class MARIAWebRequestCollection
    {
        private Dictionary<string, MARIAWebRequest> AvailableWebRequests { get; set; }
        public MARIAWebRequestCollection()
        {
            this.AvailableWebRequests = new Dictionary<string, MARIAWebRequest>();
        }
        public StatusObject AddWebRequest(string NewWebRequestName, MARIAWebRequest NewWebRequest)
        {
            StatusObject SO = new StatusObject();
            try
            {
                this.AvailableWebRequests.Add(NewWebRequestName, NewWebRequest);
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "WEBREQUESTMANAGER_ADDWEBREQUEST");
            }
            return SO;
        }
        /// <summary>
        /// This function will execute all the web requests in the order they were inserted
        /// </summary>
        /// <returns></returns>
        public StatusObject ExecuteSequential()
        {
            StatusObject SO = new StatusObject();
            try
            {
                foreach (KeyValuePair<string, MARIAWebRequest> AvailableWebRequest in this.AvailableWebRequests)
                {
                    AvailableWebRequest.Value.Execute();
                }
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "WEBREQUESTCOLLECTION_EXECUTESEQUENTIAL");
            }
            return SO;
        }
        /// <summary>
        /// This function will execute all the webrequests listed in the web request collection in parallel
        /// </summary>
        /// <param name="Iterations"></param>
        /// <returns></returns>
        public StatusObject ExecuteParallel(int Iterations)
        {
            StatusObject SO = new StatusObject();
            try
            {
                List<int> IterationList = new List<int>();
                for (int i = 0; i < Iterations; i++)
                {
                    IterationList.Add(i);
                }
                Parallel.ForEach(IterationList, (Iteration) => {
                    Parallel.ForEach(this.AvailableWebRequests, (AvailableWebRequest) =>
                    {
                        Console.WriteLine(AvailableWebRequest.Key);
                        AvailableWebRequest.Value.Execute();
                    });
                });
            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "WEBREQUESTCOLLECTION_EXECUTEPARALLEL");
            }
            return SO;
        }
    }
}
