using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Four.BreadcrumbGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = string.Empty;
            text = "mysite.com/pictures/holidays.html";
            text = "www.codewars.com/users/GiacomoSorbi";
            text = "www.microsoft.com/docs/index.htm";
            text = "www.very-long-site_name-to-make-a-silly-yet-meaningful-example.com/users/giacomo-sorbi";
            text = "https://www.agcpartners.co.uk/index.html";
            text = "https://www.linkedin.com/in/giacomosorbi";
            Console.WriteLine(GenerateBC(text, " : "));
        }
        
        public static string GenerateBC(string url, string separator)
        {
            var ignoreSymbols = new[] { '#', '?' };
            var clearUrl = string.Concat(url.TakeWhile(c => !ignoreSymbols.Contains(c)));
            
            var urlParts = clearUrl
                .Split('/', StringSplitOptions.RemoveEmptyEntries)
                .Where(s => !(s.StartsWith("index.") || s.StartsWith("http")))
                .ToArray();
            
            if (urlParts.Length == 0)
                return string.Empty;

            var breadcrumbs = new Queue<string>();
            breadcrumbs.Enqueue("<a href=\"/\">HOME</a>");

            if (urlParts.Length == 1)
                return "<span class=\"active\">HOME</span>";

            for (var i = 1; i < urlParts.Length - 1; i++)
            {
                var breadcrumb = $"<a href=\"/{urlParts[i].ToLower()}/\">{GetBreadcrumbText(urlParts[i])}</a>";
                breadcrumbs.Enqueue(breadcrumb);
            }

            var lastBreadcrumbText = GetBreadcrumbText(string
                    .Concat(urlParts.Last().TakeWhile(c => c != '.')));
            
            var last = $"<span class=\"active\">{lastBreadcrumbText}</span>";
            breadcrumbs.Enqueue(last);
            
            return string.Join(separator, breadcrumbs);
        }

        private static string GetBreadcrumbText(string text)
        {
            var ignoreWords = new[]
                { "the", "of", "in", "from", "by", "with", "and", "or", "for", "to", "at", "a" };

            var split = text.Split('-');
            
            var breadcrumbTextParts = split.Length == 1
                ? split
                : split.Where(str => !ignoreWords.Contains(str));

            var breadcrumbText = text.Length <= 30
                ? string.Join(' ', breadcrumbTextParts)
                : string.Concat(breadcrumbTextParts.Select(c => c.First()));
            
            return breadcrumbText.ToUpper();
        }
    }
}