from setuptools import setup, find_packages

setup(
    name='apiverve_websitescreenshot',
    version='1.2.5',
    packages=find_packages(),
    include_package_data=True,
    install_requires=[
        'requests',
        'setuptools'
    ],
    description='Website Screenshot renders webpage screenshots from any URL as PNG, JPEG or WebP, with ads blocked and cookie notices dismissed. It returns a signed download link with an expiration timestamp, supporting custom viewport dimensions up to 3840 pixels wide, single-element capture by CSS selector, a capture delay, a page-load wait strategy and JPEG or WebP quality.',
    author='APIVerve',
    author_email='hello@apiverve.com',
    url='https://apiverve.com/marketplace/webscreenshots?utm_source=pypi&utm_medium=referral&utm_content=homepage',
    classifiers=[
        'Programming Language :: Python :: 3',
        'Operating System :: OS Independent',
    ],
    python_requires='>=3.6',
)
