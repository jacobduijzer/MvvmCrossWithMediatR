using System;
namespace MediatrTest.Core.Interfaces
{
    public interface ISettings
    {
        string CrashReporting_iOS_Key { get; }

        string CrashReporting_Android_Key { get; }
    }
}
