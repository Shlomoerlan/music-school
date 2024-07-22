using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MusicSchool.Service
{
    static class PracticeService
    {
        public static Func<List<string>, bool> StartA = (list) => list.Any(l => l.ToLower().StartsWith("a"));

        public static Func<List<string>, bool> ContainsEmpty = (list) => list.Any(l => l.Contains(" "));

        public static Func<List<string>, bool> ContainsA = (list) => list.All(l => l.ToLower().Contains("a"));

        public static Func<List<string>, List<string>> ToUpper = (list) => list.Select(l => l.ToUpper()).ToList();

        public static Func<List<string>, List<string>> LinqToUpper = (list) => (from str  in list select str.ToUpper()).ToList();

        public static Func<List<string>, List<string>> ReturnIfGreterThan3Char = (list) => list.Where(l => l.Length > 3).ToList();

        public static Func<List<string>, List<string>> ReturnIfLinq = (list) => (from str in list where str.Length>=3 select str).ToList();

        public static Func<List<string>, string> ReturnStr = (list) => list.Aggregate("", (current, next) => current + " " + next);

        public static Func<List<string>, int> ReturnInt = (list) => list.Aggregate(0, (current, next) => current + next.Length);

        public static Func<List<string>, List<string>> ReturnIfGreater3 = (list) => list.Aggregate(new List<string>(),(current, next) => (next.Length >= 3 ?[..current , next] : [..current]));

        public static Func<List<string>, List<int>> ReturnInt1 = (list) => list.Aggregate(new List<int>(), (current, next) => [..current, next.Length]);

    }
}