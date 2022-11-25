using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle            ("MVBD Client")]
[assembly: AssemblyDescription      ("")]
[assembly: AssemblyConfiguration    ("")]
[assembly: AssemblyCompany          ("Metec AG - Andreas Baumüller")]
[assembly: AssemblyProduct          ("MVBDClient")]
[assembly: AssemblyCopyright        ("Copyright ©  2021")]
[assembly: AssemblyTrademark        ("")]
[assembly: AssemblyCulture          ("")]
[assembly: ComVisible               (false)]
[assembly: Guid                     ("6b9cad8d-b453-4a70-8a68-eae75cfc7255")]
[assembly: AssemblyVersion          ("1.2.0.148")]
[assembly: AssemblyFileVersion      ("1.2.0.148")]
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

// 1.2.0.148  01.06.2021  Hotfix int the Tcp-IP communication. The header stays at 2 bytes for the length.
//                        The sending of very long data (over 65536) is not good.
//
// 1.2.0.146  25.01.2021  Removed from TUD Git. Now in metec SVN
// 1.1.0.141  04.06.2020  Debug Messages (cmd 77)
// 1.1.0.140  20.05.2020  OCR with UWP (Windows10 APIs), Spanish, Language independent speakers
// 1.1.0.135  03.07.2019  Finger can click (Touch double click)
// 1.1.0.134  21.06.2019  Automatic close the speaker warning message 'High volume can cause hearing loss'
// 1.1.0.133  06.06.2019  Finger moves the mousepointer
// 1.1.0.132  27.03.2019  ...
// 1.1.0.131  08.03.2019  Test NVDA Gestures
// 1.1.0.130  20.02.2019  Enum for ConfigurationsMask. Fingers are send with Raw positions like in the past
// 1.1.0.129  18.02.2019  DeviceShortcuts to inject BrailleKeys. Battery 0-100%
// 1.1.0.128  29.01.2019  Tactile2D is running now. Bugfix https download
// 1.1.0.127  28.01.2019  Draw Cross, changed to https links, TCP package length is 2 bytes like in past
// 1.1.0.126  06.12.2018  TactileWeb
// 1.0.0.124  14.09.2018  SetVisibitity
// 1.0.0.123  22.08.2018  New compiled
// 1.0.0.109  06.09.2017  Drawings. New command 35-40
// 1.0.0.108  28.08.2017  Bugfixing
// 1.0.0.107  23.08.2017  Change TcpRooting from outside with command