using System.Collections.Generic;

using UnityEngine;

using UnityLog = UnityEngine.Debug;

namespace Freyja.Logger
{
    /// <summary>
    ///     <para>
    ///         A versatile logging class for Unity applications, providing features like prefix-based categorization,
    ///         configurable log levels, contextual logging, and formatted output
    ///     </para>
    /// </summary>
    public class Logger
    {
        #region Constructors

        /// <summary>
        ///     <para>Initializes a new instance of the <see cref="Logger"/> class.</para>
        /// </summary>
        /// <param name="prefix">The prefix to be added to log messages.</param>
        private Logger(string prefix)
        {
            _prefix = prefix;
        }

        #endregion

        #region Privates

        /// <summary>
        ///     <para>The prefix to be added to log messages.</para>
        /// </summary>
        private readonly string _prefix;


        /// <summary>
        ///     <para>A dictionary to store existing Logger instances, indexed by their prefix.</para>
        /// </summary>
        private static readonly Dictionary<string, Logger> Loggers = new Dictionary<string, Logger>();

        #endregion

        #region Properties

        /// <summary>
        ///     <para>Indicates whether logging is enabled for this Logger instance.</para>
        /// </summary>
        public bool IsEnable { get; set; } = true;

        /// <summary>
        ///     <para>Indicates whether warning logs are enabled for this Logger instance.</para>
        /// </summary>
        public bool EnableLogWarning { get; set; } = true;

        /// <summary>
        ///     <para>Indicates whether error logs are enabled for this Logger instance.</para>
        /// </summary>
        public bool EnableLogError { get; set; } = true;

        #endregion

        #region Methods

        /// <summary>
        ///     <para>Adds a new Logger instance to the Loggers dictionary, or returns an existing one if it already exists.</para>
        ///     <para>This method ensures that only one Logger instance exists for a given prefix, promoting efficient resource management and avoiding unnecessary object creation.</para>
        /// </summary>
        /// <param name="prefix">The prefix to be used for the Logger instance.</param>
        /// <returns>The Logger instance associated with the specified prefix.</returns>
        public static Logger AddLog(string prefix)
        {
            if (!Loggers.ContainsKey(prefix))
            {
                Loggers[prefix] = new Logger(prefix);
            }

            return Loggers[prefix];
        }

        #region Log

        /// <summary>
        ///     <para>Logs a message to the Unity Console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        public void Log(object message)
        {
            if (IsEnable)
            {
                UnityLog.Log($"[{_prefix}] {message}");
            }
        }

        /// <summary>
        ///     <para>Logs a message to the Unity Console.</para>
        /// </summary>
        /// <param name="context">Object to which the message applies.</param>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        public void Log(Object context, object message)
        {
            if (IsEnable)
            {
                var name = context.GetType().Name;
                UnityLog.Log($"[{_prefix}] [{name}] {message}");
            }
        }

        /// <summary>
        ///     <para>Logs a formatted message to the Unity Console.</para>
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public void LogFormat(string format, params object[] args)
        {
            if (IsEnable)
            {
                UnityLog.LogFormat(format, args);
            }
        }

        /// <summary>
        ///     <para>Logs a formatted message to the Unity Console.</para>
        /// </summary>
        /// <param name="context">Object to which the message applies.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public void LogFormat(Object context, string format, params object[] args)
        {
            if (IsEnable)
            {
                UnityLog.LogFormat(context, format, args);
            }
        }

        #endregion

        #region Warning

        /// <summary>
        ///     <para>Logs a warning message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        public void LogWarning(object message)
        {
            if (IsEnable && EnableLogWarning)
            {
                UnityLog.LogWarning($"[{_prefix}] {message}");
            }
        }

        /// <summary>
        ///     <para>Logs a warning message to the console.</para>
        /// </summary>
        /// <param name="context">Object to which the message applies.</param>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        public void LogWarning(Object context, object message)
        {
            if (IsEnable && EnableLogWarning)
            {
                var name = context.GetType().Name;
                UnityLog.LogWarning($"[{_prefix}] [{name}] {message}", context);
            }
        }

        /// <summary>
        ///     <para>Logs a formatted warning message to the Unity Console.</para>
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public void LogWarningFormat(string format, params object[] args)
        {
            if (IsEnable && EnableLogWarning)
            {
                UnityLog.LogWarningFormat(format, args);
            }
        }

        /// <summary>
        ///     <para>Logs a formatted warning message to the Unity Console.</para>
        /// </summary>
        /// <param name="context">Object to which the message applies.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public void LogWarningFormat(Object context, string format, params object[] args)
        {
            if (IsEnable && EnableLogWarning)
            {
                UnityLog.LogWarningFormat(context, format, args);
            }
        }

        #endregion

        #region Error

        /// <summary>
        ///     <para>Logs an error message to the console.</para>
        /// </summary>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        public void LogError(object message)
        {
            if (IsEnable && EnableLogError)
            {
                UnityLog.LogError($"[{_prefix}] {message}");
            }
        }

        /// <summary>
        ///     <para>Logs an error message to the console.</para>
        /// </summary>
        /// <param name="context">Object to which the message applies.</param>
        /// <param name="message">String or object to be converted to string representation for display.</param>
        public void LogError(Object context, object message)
        {
            if (IsEnable && EnableLogError)
            {
                var name = context.GetType().Name;
                UnityLog.LogError($"[{_prefix}] [{name}] {message}", context);
            }
        }

        /// <summary>
        ///     <para>Logs a formatted error message to the Unity console.</para>
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public void LogErrorFormat(string format, params object[] args)
        {
            if (IsEnable && EnableLogError)
            {
                UnityLog.LogErrorFormat(format, args);
            }
        }

        /// <summary>
        ///     <para>Logs a formatted error message to the Unity console.</para>
        /// </summary>
        /// <param name="context">Object to which the message applies.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public void LogErrorFormat(Object context, string format, params object[] args)
        {
            if (IsEnable && EnableLogError)
            {
                UnityLog.LogErrorFormat(context, format, args);
            }
        }

        #endregion

        #endregion
    }
}