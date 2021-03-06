using System.Collections.Generic;

namespace Abstractions.DTOs.Admin
{
    public class SageDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public List<BasicBookDto> Books { get; set; }
    }

    public class BasicSageDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string City { get; set; }
    }

    public class CreateSageDto
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public List<int> Books { get; set; }
    }

    public class UpdateSageDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        public List<int> Books { get; set; }
    }
}