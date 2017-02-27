﻿// Copyright 2016 Google Inc. All Rights Reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Google.Cloud.Diagnostics.Common
{
    /// <summary>
    /// A managed tracer that does nothing.
    /// </summary>
    internal sealed class DoNothingTracer : IManagedTracer
    {
        public static readonly DoNothingTracer Instance = new DoNothingTracer();

        private class DoNothingDisposable : IDisposable { public void Dispose() { } }
        private static readonly DoNothingDisposable _doNothingDisposableInstnace = new DoNothingDisposable();

        private DoNothingTracer() { }
        public IDisposable StartSpan(string name, StartSpanOptions options = null) => _doNothingDisposableInstnace;
        public void EndSpan() { }
        public void RunInSpan(Action action, string name, StartSpanOptions options = null) => action();
        public T RunInSpan<T>(Func<T> func, string name, StartSpanOptions options = null) => func();
        public void AnnotateSpan(Dictionary<string, string> labels) { }
        public void SetStackTrace(StackTrace stackTrace) { }
        public string GetCurrentTraceId() => null;
        public ulong? GetCurrentSpanId() => null;
    }
}