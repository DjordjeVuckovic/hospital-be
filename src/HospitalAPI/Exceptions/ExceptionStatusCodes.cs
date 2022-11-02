﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using HospitalLibrary.CustomException;

namespace HospitalAPI.Exceptions
{
    public static class ExceptionStatusCodes
    {
        public static Dictionary<string, string> GetExceptionDetails(Exception exception)
        {
            var properties = exception.GetType()
                .GetProperties();
            var fields = properties
                .Select(property => new
                {
                    Name = property.Name,
                    Value = property.GetValue(exception, null)
                })
                .Select(x => $"{x.Name} = {(x.Value != null ? x.Value.ToString() : string.Empty)}")
                .ToDictionary(k => k, v => v);
            return fields;
        }
    }
}