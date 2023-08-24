using System;

namespace Brainz.Domain.Entities
{
    public class BuyedCourse
    {
        public Guid CourseId { get; set; }
        public float Price { get; set; }
    }
}
