using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace APIVerve.API.WebsiteScreenshot
{
    /// <summary>
    /// Query options for the Website Screenshot API
    /// </summary>
    public class WebsiteScreenshotQueryOptions
    {
        /// <summary>
        /// The URL of the web page to capture the screenshot (e.g., https://example.com)
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// The type of the screenshot (png, jpeg, or webp)
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The width of the screenshot in pixels (e.g., 1920). Must be between 100 and 3840
        /// </summary>
        [JsonProperty("width")]
        public string Width { get; set; }

        /// <summary>
        /// The height of the screenshot in pixels (e.g., 1080).  Must be between 100 and 3840
        /// </summary>
        [JsonProperty("height")]
        public string Height { get; set; }

        /// <summary>
        /// Whether to capture the full page screenshot (true or false)
        /// </summary>
        [JsonProperty("fullpage")]
        public string Fullpage { get; set; }
    }
}
