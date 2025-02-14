using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoConfigogLog
{
    public class LoggingClass
    {
        public void Start()
        {
            TraceSource tc = new TraceSource("Petrers Log for demo");
            tc.Switch = new SourceSwitch("peters", SourceLevels.All.ToString());

#if DEBUG
            tc.Listeners.Add(new ConsoleTraceListener());
#endif
            tc.Listeners.Add(new TextWriterTraceListener("log.txt") { Filter = new EventTypeFilter(SourceLevels.Error)});
            tc.Listeners.Add(new XmlWriterTraceListener("log.xml"));

            tc.Listeners.Add(new EventLogTraceListener("Application"));


            tc.TraceEvent(TraceEventType.Information, 17337, "INFORTION");
            tc.TraceEvent(TraceEventType.Warning, 17337, "Warning");
            tc.TraceEvent(TraceEventType.Error, 17337, "Error");
            tc.TraceEvent(TraceEventType.Critical, 17337, "CRITICAL");


            tc.Close();
        }
    }
}
