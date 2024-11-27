# Freyja Logger

A versatile logging library for Unity applications, offering:

* **Prefix-based Categorization:** Organize your logs by prefixing them with specific identifiers.
* **Configurable Log Levels:**: Control the verbosity of your logs by enabling or disabling log levels (info, warning, error).
* **Contextual Logging:**: Log messages with additional context information, such as the object that triggered the log.
* **Formatted Output:**: Use format strings to create detailed and informative log messages.

**Customization:**

* **Enable/Disable Logging:** Set `IsEnable` property on the Logger instance.
* **Enable/Disable Log Levels:** Set `EnableLogWarning` and `EnableLogError` properties.

**Additional Features:**

* **Contextual Logging:** Pass an object as the first argument to include its type name.
* **Formatted Output:** Use format strings for detailed logs.

**Requirements:**
* Unity 2021.3.22f1 or Later

**Dependencies:**
* None

**Example Usage:**

For a more convenient way to use the Freyja Logger, you can create a static class like `DebugLog` to manage the Logger instance:

```csharp
// DebugLog.cs
using Freyja.Logger;

public class DebugLog 
{
    private static Logger _show;
    
    public static Logger Show 
    {
        get 
        {
            if (_show == null) 
            {
                _show = Logger.AddLog("DebugLog");
            }
            
            return _show;
        }
    }
}
```

Then, you can use the `DebugLog.Show` property to access the Logger instance directly:

```csharp
// TestDebugLog.cs 
using UnityEngine;

public class TestDebugLog : MonoBehaviour 
{
     private void Start() 
     {
         DebugLog.Show.Log(this, "Test Log"); // output: [DebugLog] [TestDebugLog] Test Log
         DebugLog.Show.LogWarning(this, "Test Log Warning"); // output: [DebugLog] [TestDebugLog] Test Log Warning
         DebugLog.Show.LogError(this, "Test Log Error"); // output: [DebugLog] [TestDebugLog] Test Log Error
     }
}
```