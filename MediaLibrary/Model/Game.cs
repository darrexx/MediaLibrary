namespace MediaLibrary.Model
{
    public class Game
    {
        public string aliases { get; set; }
        public string api_detail_url { get; set; }
        public string date_added { get; set; }
        public string date_last_updated { get; set; }
        public string deck { get; set; }
        public string description { get; set; }
        public object expected_release_day { get; set; }
        public object expected_release_month { get; set; }
        public object expected_release_quarter { get; set; }
        public object expected_release_year { get; set; }
        public string guid { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int number_of_user_reviews { get; set; }
        public string original_release_date { get; set; }
        public string site_detail_url { get; set; }
        public string resource_type { get; set; }
    }
}