# Website Screenshot API - Ruby Gem

Website Screenshot renders webpage screenshots from any URL into PNG, JPEG, or WebP format. It returns a signed download link with an expiration timestamp, supporting custom viewport dimensions up to 3840 pixels wide.

## Installation

Add this line to your application's Gemfile:

```ruby
gem 'apiverve_webscreenshots'
```

And then execute:

```bash
$ bundle install
```

Or install it yourself as:

```bash
$ gem install apiverve_webscreenshots
```

## Getting Started

Get your API key at [APIVerve](https://apiverve.com)

### Basic Usage

```ruby
require 'apiverve_webscreenshots'

# Initialize the client
client = APIVerve::Webscreenshots::Client.new(api_key: "YOUR_API_KEY")

# Make a request
response = client.execute({
  url: "https://ebay.com/",
  type: "png",
  width: 1024,
  height: 600,
  fullpage: false
})

# Print the response
puts response
```


### Error Handling

```ruby
begin
  response = client.execute({ url: "https://ebay.com/", type: "png", width: 1024, height: 600, fullpage: false })
  puts response["data"]
rescue APIVerve::Webscreenshots::ValidationError => e
  puts "Validation error: #{e.errors.join(', ')}"
rescue APIVerve::Webscreenshots::APIError => e
  puts "API error: #{e.message}"
  puts "Status code: #{e.status_code}"
end
```

### Debug Mode

```ruby
# Enable debug logging
client = APIVerve::Webscreenshots::Client.new(
  api_key: "YOUR_API_KEY",
  debug: true
)
```

## Example Response

```json
{
  "status": "ok",
  "error": null,
  "data": {
    "width": 1024,
    "height": 600,
    "scaleFactor": 1,
    "imageName": "77072426-6af8-45c2-93dd-d7013d2c765e.png",
    "expires": 1766097105719,
    "url": "https://ebay.com/",
    "downloadURL": "https://storage.googleapis.com/apiverve-helpers.appspot.com/webscreenshots/77072426-6af8-45c2-93dd-d7013d2c765e.png?GoogleAccessId=1089020767582-compute%40developer.gserviceaccount.com&Expires=1766097105&Signature=uZKa777XpeVnlwOZG7Uhjs%2BNkPzkEuiV4Wug2%2B%2BAHcPovRZ3iVjZEX%2FZhp7gnADXI6au5q0ggPwweoOFJeMCdk9zod6aZo4hlUDe1DsJf0oao4rh3tGUl5wPeudXLp7Y%2F3zVflup9Mp255LY6%2B2JdU0auOHdPnEYLDCvf705X9C%2BflmWQZKh7QKi74gvU8pqsP6Zc7SfJJsv5kmhP8SkO7TBZKBU6pAr2mNHKpKgB5mtfCRLbyPYcxawSGlTuyIyRXffWbkfHdDl6pquPX9J%2Fp5uGYM4jTrqrrrR1MPAOfkD7d9V5juqe5A7VvWmhiAyCMGDO%2BeqUO%2BSe6t9php0vA%3D%3D"
  }
}
```

## Documentation

For more information, visit the [API Documentation](https://docs.apiverve.com/ref/webscreenshots?utm_source=rubygems&utm_medium=referral&utm_content=readme).

## Support

- Website: [https://apiverve.com/marketplace/webscreenshots?utm_source=ruby&utm_medium=referral&utm_content=readme](https://apiverve.com/marketplace/webscreenshots?utm_source=ruby&utm_medium=referral&utm_content=readme)
- Email: hello@apiverve.com

## License

This gem is available under the [MIT License](LICENSE).
