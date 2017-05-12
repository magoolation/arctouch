namespace ArcTouchPOC.DTOS
{

    public class ConfigurationsDTO
    {
        public Images images { get; set; }
        public string[] change_keys { get; set; }
    }

    public class Images
    {
        public string base_url { get; set; }
        public string secure_base_url { get; set; }
        public string[] backdrop_sizes { get; set; }
        public string[] logo_sizes { get; set; }
        public string[] poster_sizes { get; set; }
        public string[] profile_sizes { get; set; }
        public string[] still_sizes { get; set; }
    }

}
