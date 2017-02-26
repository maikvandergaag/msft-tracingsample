using Microsoft.ApplicationInsights.Extensibility;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AppInsightLog {
    public static class AppTrace {
        private static TraceSource traceSource { get; set; }

        static AppTrace() {
            traceSource = new TraceSource("TraceLogging");
            traceSource.Switch.Level = (SourceLevels)Enum.Parse(typeof(SourceLevels), ConfigurationManager.AppSettings["TraceSwitch"], true);
            TelemetryConfiguration.Active.InstrumentationKey = ConfigurationManager.AppSettings["InstrumentationKey"];
        }

        public static void Verbose(string message, int id = 16, [CallerMemberName]string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber]int lineNumber = 0) {
            traceSource.TraceEvent(TraceEventType.Verbose, id, Format(message, memberName, filePath, lineNumber));
        }

        public static void Error(string message, int id = 2, [CallerMemberName]string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber]int lineNumber = 0) {
            traceSource.TraceEvent(TraceEventType.Error, id, Format(message, memberName, filePath, lineNumber));
        }

        public static void Information(string message, int id = 8, [CallerMemberName]string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber]int lineNumber = 0) {
            traceSource.TraceEvent(TraceEventType.Information, id, Format(message, memberName, filePath, lineNumber));
        }

        public static void Critical(string message, int id = 1, [CallerMemberName]string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber]int lineNumber = 0) {
            traceSource.TraceEvent(TraceEventType.Critical, id, Format(message, memberName, filePath, lineNumber));
        }

        public static void Warning(string message, int id = 4, [CallerMemberName]string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber]int lineNumber = 0) {
            traceSource.TraceEvent(TraceEventType.Warning, id, Format(message, memberName, filePath, lineNumber));
        }

        public static void Start(string service, int id = 256, [CallerMemberName]string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber]int lineNumber = 0) {
            traceSource.TraceEvent(TraceEventType.Start, id, Format("Starting - " + service, memberName, filePath, lineNumber));
        }

        public static void Stop(string service, int id = 512, [CallerMemberName]string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber]int lineNumber = 0) {
            traceSource.TraceEvent(TraceEventType.Stop, id, Format("Stoping - " + service, memberName, filePath, lineNumber));
        }

        private static string Format(string message, string memberName, string filePath, int lineNumber) {
            return $"Message: {message}, MemberName: {memberName}, FilePath: {filePath}, LineNumber: {lineNumber}";
        }
    }
}
