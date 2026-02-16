Website Screenshot API
============

Web Screenshots is a simple tool for capturing screenshots of web pages. It returns an image screenshot of the web page provided.

![Build Status](https://img.shields.io/badge/build-passing-green)
![Code Climate](https://img.shields.io/badge/maintainability-B-purple)
![Prod Ready](https://img.shields.io/badge/production-ready-blue)

This is a Python API Wrapper for the [Website Screenshot API](https://webscreenshots.apiverve.com?utm_source=pypi&utm_medium=readme)

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

Before using the webscreenshots API client, you have to setup your account and obtain your API Key.
You can get it by signing up at [https://apiverve.com](https://apiverve.com?utm_source=pypi&utm_medium=readme)

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

The Website Screenshot API documentation is found here: [https://docs.apiverve.com/ref/webscreenshots](https://docs.apiverve.com/ref/webscreenshots?utm_source=pypi&utm_medium=readme).
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
    "imageName": "78bdb087-756b-4107-83e1-82fd40171ed1.png",
    "expires": 1725356395837,
    "url": "https://ebay.com/",
    "downloadURL": "https://storage.googleapis.com/apiverve-helpers.appspot.com/webscreenshots/78bdb087-756b-4107-83e1-82fd40171ed1.png?GoogleAccessId=1089020767582-compute%40developer.gserviceaccount.com&Expires=1725356395&Signature=jqAuoBhrbsSqs61blsFdnXEU35QOanhFnL0FN2d82cDDTXAUWonuRURUjyyhmABe02dVD3sMpvQDh0V39ROFcukPFASdIhr4HdWnKl743JLx03jrW%2FJ2baK3lZCZemPkS%2F61VqcHV1YB5XsxqsDNNkQ8QL8xlzUslHUgjuVKsorDCpBL5iFPSLo0l5DO3wvZ6UudJJP11j1MAnRmWQC7%2FkUBc7AP4akQvm6N7lftFkx8z6%2FptdxBt60w1XR6Ixoy6Vl31tvd6UjyWhjmF8JbujRSRYXmh0vjTNZBp5BX7xUntQUSMXhQf%2Bj3bXq7ZcsfMAAtqonqbzC6SBZgzSu2kA%3D%3D"
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

Need any assistance? [Get in touch with Customer Support](https://apiverve.com/contact?utm_source=pypi&utm_medium=readme).

---

## Updates
Stay up to date by following [@apiverveHQ](https://twitter.com/apiverveHQ) on Twitter.

---

## Legal

All usage of the APIVerve website, API, and services is subject to the [APIVerve Terms of Service](https://apiverve.com/terms?utm_source=pypi&utm_medium=readme) and all legal documents and agreements.

---

## License
Licensed under the The MIT License (MIT)

Copyright (&copy;) 2026 APIVerve, and EvlarSoft LLC

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
