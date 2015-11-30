﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheBookStore.DataTransferObjects
{
    public class BookAuthorsDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        public override string ToString()
        {
            return FullName;
        }

    }
}