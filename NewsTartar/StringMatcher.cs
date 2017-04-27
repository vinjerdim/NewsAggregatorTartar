﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
namespace NewsTartar
{
    public class StringMatcher
    {
        public static int KMPMatch(string text, string pattern)
        {
            int n = text.Length;
            int m = pattern.Length;
            string tempText = text.ToLower();
            string tempPattern = pattern.ToLower();

            int[] fail = computeFail(tempPattern);
            int i = 0;
            int j = 0;

            while (i < n)
            {
                if (tempPattern[j] == tempText[i])
                {
                    if (j == m - 1)
                        return i - m + 1; //match
                    i++;
                    j++;
                }
                else if (j > 0)
                    j = fail[j - 1];
                else
                    i++;
            }
            return -1;//no match
        }

        private static int[] computeFail(string pattern)
        {
            int[] fail = new int[pattern.Length];
            fail[0] = 0;
            int m = pattern.Length;
            int j = 0;
            int i = 1;

            while (i < m)
            {
                if (pattern[j] == pattern[i])
                { //j+1 chars match
                    fail[i] = j + 1;
                    i++;
                    j++;
                }
                else if (j > 0) // j follows matching prefix
                    j = fail[j - 1];
                else
                {
                    fail[i] = 0;
                    i++;
                }
            }
            return fail;
        }

        public static int BMMatch(string text, string pattern)
        {
            int[] last = buildLast(pattern);
            int n = text.Length;
            int m = pattern.Length;
            int i = m - 1;

            string tempText = text.ToLower();
            string tempPattern = pattern.ToLower();

            if (i > n - 1)
                return -1; //nomatch if pattern is longer than text

            int j = m - 1;
            do
            {
                if (tempPattern[j] == tempText[i])
                {
                    if (j == 0)
                        return i; //match
                    else
                    {
                        i--;
                        j--;
                    }
                }
                else
                {
                    int lo = last[tempText[i]]; //last occ
                    i = i + m - Math.Min(j, 1 + lo);
                    j = m - 1;
                }
            } while (i <= n - 1);
            return -1; //no match
        }

        private static int[] buildLast(string pattern)
        {
            int[] last = new int[128];
            for (int i = 0; i < 128; i++)
                last[i] = -1;

            for (int i = 0; i < pattern.Length; i++)
                last[pattern[i]] = i;

            return last;
        }

        public static int regexMatch(string text, string pattern)
        {
            MatchCollection mc = Regex.Matches(text, pattern);
            return (mc.Count == 0) ? -1 : mc.Count;
        }
    }
}