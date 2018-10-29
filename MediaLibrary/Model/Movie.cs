using System.Collections.Generic;

namespace MediaLibrary.Model
{
    public class Movie
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string OriginalName { get; set; }

        public IEnumerable<string> AlternativeNames { get; set; }

        public int ReleaseYear { get; set; }

        public object Directors { get; set; } //Todo ContributorSummary erstellen

        public object Image { get; set; } //TODO Image class erstellen

        public string FilmCollectionId { get; set; }

        public object[] Links { get; set; } //Todo Link class erstellen

        public object[] Relationships { get; set; } //Todo MemberFilmRelationship class erstellen
    }
}