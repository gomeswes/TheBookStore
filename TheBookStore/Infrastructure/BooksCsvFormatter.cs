﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using TheBookStore.DataTransferObjects;

namespace TheBookStore.Infrastructure
{
    public class BooksCsvFormatter : BufferedMediaTypeFormatter
    {
        public BooksCsvFormatter()
        {
            SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/csv"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return (type == typeof(BookDto) || type == typeof(IEnumerable<BookDto>));
        }
        
        public override void WriteToStream(Type type, object value, Stream writeStream, System.Net.Http.HttpContent content)
        {
            using (var writer = new StreamWriter(writeStream))
            {
                var books = value as IEnumerable<BookDto>;
                if (books != null)
                {
                    foreach (var book in books)
                    {
                        writer.WriteLine(book.Flatten());
                    }
                }
                else
                {
                    var book = value as BookDto;
                    if (book == null)
                    {
                        throw new InvalidOperationException("Cannot deserialize type");
                    }

                    writer.WriteLine(book.Flatten());
                }
            }
            writeStream.Close();
        }

    }
}