using System;
using System.Collections.Generic;
using System.Linq;

namespace Codewars.Four.BreadcrumbGenerator
{
    class Program
    {
        private static readonly HashSet<string> IgnoreWords = new HashSet<string>(
            new[] { "the", "of", "in", "from", "by", "with", "and", "or", "for", "to", "at", "a" });
        
        static void Main(string[] args)
        {
            var text = string.Empty;
            text = "mysite.com/pictures/holidays.html";
            text = "www.codewars.com/users/GiacomoSorbi";
            text = "www.microsoft.com/docs/index.htm";
            text = "www.very-long-site_name-to-make-a-silly-yet-meaningful-example.com/users/giacomo-sorbi";
            text = "https://www.agcpartners.co.uk/index.html";
            text = "mysite.com/pictures/holidays.html";
            Console.WriteLine(GenerateBC(text, " : "));
        }
        
        public static string GenerateBC(string url, string separator)
        {
            var urlParts = GetUrlParts(url);
            
            if (urlParts.Length == 0)
                return string.Empty;

            if (urlParts.Length == 1)
                return "<span class=\"active\">HOME</span>";

            var breadcrumbs = new Queue<string>();
            breadcrumbs.Enqueue("<a href=\"/\">HOME</a>");
            var previousUrl = string.Empty;
            string breadcrumbUrl;

            for (var i = 1; i < urlParts.Length - 1; i++, previousUrl = breadcrumbUrl)
            {
                breadcrumbUrl = string.IsNullOrEmpty(previousUrl)
                    ? urlParts[i]
                    : string.Join("/", new[]{previousUrl, urlParts[i]});

                var breadcrumb = $"<a href=\"/{breadcrumbUrl.ToLower()}/\">{GetBreadcrumbText(urlParts[i])}</a>";
                
                breadcrumbs.Enqueue(breadcrumb);
            }

            var lastBreadcrumbLetters = urlParts
                .Last()
                .TakeWhile(c => c != '.');
            
            var lastBreadcrumbText = GetBreadcrumbText(string.Concat(lastBreadcrumbLetters));
            
            var last = $"<span class=\"active\">{lastBreadcrumbText}</span>";
            breadcrumbs.Enqueue(last);
            
            return string.Join(separator, breadcrumbs);
        }

        private static string[] GetUrlParts(string url)
        {
            var ignoreSymbols = new[] { '#', '?' };
            
            var clearUrl = string.Concat(url.TakeWhile(c => !ignoreSymbols.Contains(c)));
            
            return clearUrl
                .Split('/', StringSplitOptions.RemoveEmptyEntries)
                .Where(s => !(s.StartsWith("index.") || s.StartsWith("http")))
                .ToArray();
        }

        private static string GetBreadcrumbText(string text)
        {
            var split = text.Split('-');

            string breadcrumbText;

            if (text.Length <= 30)
                breadcrumbText = string.Join(' ', split);
            else
            {
                breadcrumbText = string.Concat(split
                    .Where(str => !IgnoreWords.Contains(str))
                    .Select(str => str.First()));
            }

            return breadcrumbText.ToUpper();
        }
    }
}