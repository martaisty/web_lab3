﻿using System.Collections.Generic;
using Abstractions.Entities;

namespace Abstractions.DTOs.Admin
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<SageDto> Sages { get; set; }
    }
    
    public class CreateBookDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<int> Sages { get; set; }
    }
    
    public class UpdateBookDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<int> Sages { get; set; }
    }
}