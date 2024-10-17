
namespace Voting
{
    internal class Specialization
    {
        public string name { get; set; }
        public string image { get; set; }
        public int voteCount { get; set; }

        public Specialization(string name, string image)
        {
            this.name = name;
            this.image = image;
        }

        public override string ToString()
        {
            return name + " | " + voteCount;
        }
    }
}
