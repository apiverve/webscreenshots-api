Website Screenshot API
============

Website Screenshot renders webpage screenshots from any URL into PNG, JPEG, or WebP format. It returns a signed download link with an expiration timestamp, supporting custom viewport dimensions up to 3840 pixels wide.


[![PyPI version](https://img.shields.io/pypi/v/apiverve-websitescreenshot.svg)](https://pypi.org/project/apiverve-websitescreenshot/)

This is a Python wrapper for the [Website Screenshot API](https://apiverve.com/marketplace/webscreenshots?utm_source=pypi&utm_medium=referral&utm_content=readme)

---

## Installation

Using `pip`:

```bash
pip install apiverve-websitescreenshot
```

Using `pip3`:

```bash
pip3 install apiverve-websitescreenshot
```

---

## Configuration

Before using the Website Screenshot API client, you have to setup your account and obtain your API Key.
You can get it by signing up at [https://apiverve.com](https://apiverve.com?utm_source=pypi&utm_medium=referral&utm_content=readme)

---

## Quick Start

Here's a simple example to get you started quickly:

```python
from apiverve_websitescreenshot.apiClient import WebscreenshotsAPIClient

# Initialize the client with your APIVerve API key
api = WebscreenshotsAPIClient("[YOUR_API_KEY]")

query = {
    "url": "https://ebay.com/",
    "type": "png",
    "width": 1024,
    "height": 600,
    "fullpage": false
}

try:
    # Make the API call
    result = api.execute(query)

    # Print the result
    print(result)
except Exception as e:
    print(f"Error: {e}")
```

---

## Usage

The Website Screenshot API documentation is found here: [https://docs.apiverve.com/ref/webscreenshots](https://docs.apiverve.com/ref/webscreenshots?utm_source=pypi&utm_medium=referral&utm_content=readme).
You can find parameters, example responses, and status codes documented here.

### Setup

```python
# Import the client module
from apiverve_websitescreenshot.apiClient import WebscreenshotsAPIClient

# Initialize the client with your APIVerve API key
api = WebscreenshotsAPIClient("[YOUR_API_KEY]")
```

---

## Perform Request

Using the API client, you can perform requests to the API.

###### Define Query

```python
query = {
    "url": "https://ebay.com/",
    "type": "png",
    "width": 1024,
    "height": 600,
    "fullpage": false
}
```

###### Simple Request

```python
# Make a request to the API
result = api.execute(query)

# Print the result
print(result)
```

###### Example Response

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

---

## Error Handling

The API client provides comprehensive error handling through the `WebscreenshotsAPIClientError` exception. Here are some examples:

### Basic Error Handling

```python
from apiverve_websitescreenshot.apiClient import WebscreenshotsAPIClient, WebscreenshotsAPIClientError

api = WebscreenshotsAPIClient("[YOUR_API_KEY]")

query = {
    "url": "https://ebay.com/",
    "type": "png",
    "width": 1024,
    "height": 600,
    "fullpage": false
}

try:
    result = api.execute(query)
    print("Success!")
    print(result)
except WebscreenshotsAPIClientError as e:
    print(f"API Error: {e.message}")
    if e.status_code:
        print(f"Status Code: {e.status_code}")
    if e.response:
        print(f"Response: {e.response}")
```

### Handling Specific Error Types

```python
from apiverve_websitescreenshot.apiClient import WebscreenshotsAPIClient, WebscreenshotsAPIClientError

api = WebscreenshotsAPIClient("[YOUR_API_KEY]")

query = {
    "url": "https://ebay.com/",
    "type": "png",
    "width": 1024,
    "height": 600,
    "fullpage": false
}

try:
    result = api.execute(query)

    # Check for successful response
    if result.get('status') == 'success':
        print("Request successful!")
        print(result.get('data'))
    else:
        print(f"API returned an error: {result.get('error')}")

except WebscreenshotsAPIClientError as e:
    # Handle API client errors
    if e.status_code == 401:
        print("Unauthorized: Invalid API key")
    elif e.status_code == 429:
        print("Rate limit exceeded")
    elif e.status_code >= 500:
        print("Server error - please try again later")
    else:
        print(f"API error: {e.message}")
except Exception as e:
    # Handle unexpected errors
    print(f"Unexpected error: {str(e)}")
```

### Using Context Manager (Recommended)

The client supports the context manager protocol for automatic resource cleanup:

```python
from apiverve_websitescreenshot.apiClient import WebscreenshotsAPIClient, WebscreenshotsAPIClientError

query = {
    "url": "https://ebay.com/",
    "type": "png",
    "width": 1024,
    "height": 600,
    "fullpage": false
}

# Using context manager ensures proper cleanup
with WebscreenshotsAPIClient("[YOUR_API_KEY]") as api:
    try:
        result = api.execute(query)
        print(result)
    except WebscreenshotsAPIClientError as e:
        print(f"Error: {e.message}")
# Session is automatically closed here
```

---

## Advanced Features

### Debug Mode

Enable debug logging to see detailed request and response information:

```python
from apiverve_websitescreenshot.apiClient import WebscreenshotsAPIClient

# Enable debug mode
api = WebscreenshotsAPIClient("[YOUR_API_KEY]", debug=True)

query = {
    "url": "https://ebay.com/",
    "type": "png",
    "width": 1024,
    "height": 600,
    "fullpage": false
}

# Debug information will be printed to console
result = api.execute(query)
```

### Manual Session Management

If you need to manually manage the session lifecycle:

```python
from apiverve_websitescreenshot.apiClient import WebscreenshotsAPIClient

api = WebscreenshotsAPIClient("[YOUR_API_KEY]")

query = {
    "url": "https://ebay.com/",
    "type": "png",
    "width": 1024,
    "height": 600,
    "fullpage": false
}

try:
    result = api.execute(query)
    print(result)
finally:
    # Manually close the session when done
    api.close()
```

---

## Customer Support

Need any assistance? [Get in touch with Customer Support](https://apiverve.com/contact?utm_source=pypi&utm_medium=referral&utm_content=readme).

---

## Updates
Stay up to date by following [@apiverveHQ](https://twitter.com/apiverveHQ) on Twitter.

---

## Legal

All usage of the APIVerve website, API, and services is subject to the [APIVerve Terms of Service](https://apiverve.com/terms?utm_source=pypi&utm_medium=referral&utm_content=readme) and all legal documents and agreements.

---

## License
Licensed under the MIT License (MIT)

Copyright (&copy;) 2026 APIVerve, and EvlarSoft LLC

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
