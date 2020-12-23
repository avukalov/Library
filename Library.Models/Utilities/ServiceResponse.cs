﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Models.Utilities
{
    public class ServiceResponse<T> where T : class
    {
        public T Data { get; set; } = null;
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;
        public object Metadata { get; set; } = null;
    }
}