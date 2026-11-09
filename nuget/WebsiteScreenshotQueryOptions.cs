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
        /// The image format for the screenshot
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The width of the screenshot in pixels (e.g., 1920). Must be between 100 and 3840
        /// </summary>
        [JsonProperty("width")]
        public double? Width { get; set; }

        /// <summary>
        /// The height of the screenshot in pixels (e.g., 1080).  Must be between 100 and 3840
        /// </summary>
        [JsonProperty("height")]
        public double? Height { get; set; }

        /// <summary>
        /// Whether to capture the full page screenshot (true or false)
        /// </summary>
        [JsonProperty("fullpage")]
        public bool? Fullpage { get; set; }

        /// <summary>
        /// CSS selector of a single element to capture instead of the viewport (e.g., #pricing). The first match is captured; a selector that matches nothing returns 400
        /// </summary>
        [JsonProperty("selector")]
        public string Selector { get; set; }

        /// <summary>
        /// Milliseconds to wait after the page loads before capturing, for animations or late content. Between 0 and 5000
        /// </summary>
        [JsonProperty("delay")]
        public double? Delay { get; set; }

        /// <summary>
        /// When navigation counts as finished before capture: domcontentloaded (default, fastest), load (all resources), or networkidle (network quiet). A page that never settles is captured as parsed
        /// </summary>
        [JsonProperty("waituntil")]
        public string Waituntil { get; set; }

        /// <summary>
        /// Compression quality from 1 to 100. Applies only when type is jpeg or webp
        /// </summary>
        [JsonProperty("quality")]
        public double? Quality { get; set; }
    }
}
