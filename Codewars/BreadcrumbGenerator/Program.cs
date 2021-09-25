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
            text = "github.com/research-cauterization-the/";
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

            var previousUrl = string.Empty;

            for (var i = 1; i < urlParts.Length - 1; i++)
            {
                var breadcrumbUrl = string.IsNullOrEmpty(previousUrl)
                    ? urlParts[i]
                    : string.Join("/", new[]{previousUrl, urlParts[i]});
                
                var breadcrumb = $"<a href=\"/{breadcrumbUrl.ToLower()}/\">{GetBreadcrumbText(urlParts[i])}</a>";
                breadcrumbs.Enqueue(breadcrumb);
                previousUrl = breadcrumbUrl;
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

            string breadcrumbText;

            if (text.Length <= 30)
                breadcrumbText = string.Join(' ', split);
            else
            {
                breadcrumbText = string.Concat(split
                    .Where(str => !ignoreWords.Contains(str))
                    .Select(str => str.First()));
            }

            return breadcrumbText.ToUpper();
        }
    }
}