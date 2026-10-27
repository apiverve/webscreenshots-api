Pod::Spec.new do |s|
  s.name             = 'APIVerveWebsiteScreenshot'
  s.version          = '1.2.3'
  s.summary          = 'Website Screenshot renders webpage screenshots from any URL into PNG, JPEG, or WebP format.'
  s.description      = <<-'DESC'
Website Screenshot renders webpage screenshots from any URL into PNG, JPEG, or WebP format. It returns a signed download link with an expiration timestamp, supporting custom viewport dimensions up to 3840 pixels wide.

This iOS/macOS SDK provides a convenient way to access the Website Screenshot from APIVerve.
Supports both callback-based and async/await patterns.
                       DESC

  s.homepage         = 'https://apiverve.com/marketplace/webscreenshots?utm_source=cocoapods&utm_medium=referral&utm_content=homepage'
  s.license          = { :type => 'MIT', :file => 'LICENSE' }
  s.author           = { 'APIVerve' => 'hello@apiverve.com' }
  # The SDK repo holds every language; the pod lives under cocoapods/ with its own tag.
  s.source           = { :git => 'https://github.com/apiverve/webscreenshots-api.git', :tag => "cocoapods/v#{s.version}" }

  s.ios.deployment_target = '15.0'
  s.osx.deployment_target = '12.0'

  s.swift_version = '5.0'

  s.source_files = 'cocoapods/Sources/APIVerveWebsiteScreenshot/**/*.swift'

  s.frameworks = 'Foundation'

  # APIResponse, APIVerveError and the request plumbing, shared by every APIVerve pod.
  s.dependency 'APIVerveCore', '~> 1.2'
end
