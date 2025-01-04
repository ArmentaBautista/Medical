using Medical.Domain.Abstractions;

namespace Medical.Domain.Doctors
{
    public record Specialty
    {
        public required string Name { get; set; }

        public Specialty(string value)
        {
            Name = value;
        }

        public Specialty()
        {
            
        }
    }
}
