using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSchool.Configuration
{
    internal static class AppConfiguration
    {
        public static string musicSchoolPath = Path.Combine(Directory.GetCurrentDirectory(), "MusicSchool.xml");
    }
}
