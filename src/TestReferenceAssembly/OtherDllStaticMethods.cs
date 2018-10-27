﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

#pragma warning disable CA1801

using System;
using System.Linq;
using System.Text;

namespace OtherDll
{
    /// <summary>
    /// Aids with testing dataflow analysis _not_ doing interprocedural DFA.
    /// </summary>
    /// <remarks>
    /// Since Roslyn doesn't support cross-binary DFA, and this class is
    /// defined in a different binary, using this class from test source code
    /// is a way to test handling of non-interprocedural results in dataflow 
    /// analysis implementations.
    /// </remarks>
    public static class OtherDllStaticMethods
    {
        public static T ReturnsInput<T>(T input)
        {
            return input;
        }

        public static T ReturnsDefault<T>(T input)
        {
            return default(T);
        }

        public static string ReturnsRandom(string input)
        {
            Random r = new Random();
            byte[] bytes = new byte[r.Next(20) + 10];
            r.NextBytes(bytes);
            bytes = bytes.Where(b => (byte) ' ' <= b && b <= (byte) '~').ToArray();
            return Encoding.ASCII.GetString(bytes);
        }

        public static void SetsOutputToInput<T>(T input, out T output)
        {
            output = input;
        }

        public static void SetsOutputToDefault<T>(T input, out T output)
        {
            output = default(T);
        }

        public static void SetsOutputToRandom(string input, out string output)
        {
            output = ReturnsRandom(input);
        }
    }
}
