<img src="http://riii.nl/nidenticonlogo" width="32" height="32" alt="NIdenticon Logo"> NIdenticon
==========

> "*An Identicon is a visual representation of a hash value, usually of an IP address, that serves to identify a user of a computer system as a form of avatar while protecting the users' privacy. The original Identicon was a 9-block graphic, and the representation has been extended to other graphic forms by third parties.*"
– [Wikipedia](http://en.wikipedia.org/wiki/Identicon)

NIdenticon is a library (available as [NuGet package](https://www.nuget.org/packages/NIdenticon)) that helps creating simple Identicons but is flexible enough to allow for tweaking the output to your heart's content.

## Usage

The most basic example is as follows:
```c#
var g = new IdenticonGenerator();
var mybitmap = g.Create("foo");
````

This will create an Identicon based on the string `foo` with all other options default; another example is:
```c#
var g = new IdenticonGenerator();
var mybitmap = g.Create(HttpContext.Current.Request.UserHostAddress);
````

This creates an Identicon based on the IP-address of a remote host. The Identicon can be created with the following options:

* Dimensions (width, height **default**: 400, 400)
* Number of blocks, or "pixels" (horizontal, vertical **default**: 5, 5)
* Hash algorithm (**default**: `SHA5120`)
* Background color (**default**: `Transparent`)
* Even the default string-encoding used can be specified (**default**: UTF-8)

This library only contains one class, the `IdenticonGenerator`, with only one method, `Create()`, but which is rich in overloads. These are:
```c#
public Bitmap Create(byte[] value)
public Bitmap Create(byte[] value, int width, int height)
public Bitmap Create(byte[] value, int width, int height, Color backgroundcolor)
public Bitmap Create(byte[] value, int width, int height, Color backgroundcolor, int blockshorizontal, int blocksvertical)
public Bitmap Create(IPAddress ipaddress)
public Bitmap Create(IPAddress ipaddress, int width, int height)
public Bitmap Create(IPAddress ipaddress, int width, int height, Color backgroundcolor)
public Bitmap Create(IPAddress ipaddress, int width, int height, Color backgroundcolor, int blockshorizontal, int blocksvertical)
public Bitmap Create(string value)
public Bitmap Create(string value, int width, int height)
public Bitmap Create(string value, int width, int height, Color backgroundcolor)
public Bitmap Create(string value, int width, int height, Color backgroundcolor, int blockshorizontal, int blocksvertical)
public Bitmap Create(string value, int width, int height, Color backgroundcolor, int blockshorizontal, int blocksvertical, Encoding encoding)
````

Parameters not specified will resort to the `DefaultXXX`-properties which can be specified when instantiating an `IdenticonGenerator`; the `IdenticonGenerator`'s constructor is also rich in overloads:
```c#
public IdenticonGenerator()
public IdenticonGenerator(string algorithm)
public IdenticonGenerator(string algorithm, int defaultWidth, int defaultHeight)
public IdenticonGenerator(string algorithm, int defaultWidth, int defaultHeight, Color defaultBackgroundColor)
public IdenticonGenerator(string algorithm, int defaultWidth, int defaultHeight, Color defaultBackgroundColor, int defaultBlocksHorizontal, int defaultBlocksVertical)
public IdenticonGenerator(string algorithm, int defaultWidth, int defaultHeight, Color defaultBackgroundColor, int defaultBlocksHorizontal, int defaultBlocksVertical, Encoding encoding)
````

<sub>(Ofcourse, the `DefaultXXX` properties can be changed after instantiating an `IdenticonGenerator` as well)</sub>

This allows you to specify defaults only once (using the ctor) or for each generated Identicon (passing parameters to the `Create()` methods.

#Notes

Do note that the `Create()` method and its overloads all return a `Bitmap` object; you have to take care of storing it, sending it to the browser or whatever you need to do. Also note that you might want to `Dispose()` the returned Identicon when no longer needed.

Also note that NIdenticon will round the image-dimensions DOWN to the nearest available size when the dimensions aren't exactly divisible by the horizontal/vertical blocks. Dimensions where width/horizontalblocks and height/verticalblocks are a multiple of oneanother work best (for example: for a width of 400 px you can use 2, 4, and 5 horizontal blocks but 6 will result in an image with a width of 396).

# Example

A simple Windows Forms application and sample ASP.Net MVC website is provided for you so you can explore the options and quickly see what the result will look like.

Below are some example images:


Result | Algorithm | Dimensions | Value | Type | Background | Blocks
--- | --- | --- | --- | --- | --- | ---
![MD5 Identicon](examples/MD5_Identicon.png) | `MD5` | 50x50 | Identicon | string | White | 5x5
![SHA256 Identicon](examples/SHA256_Identicon.png) | `SHA256` | 50x50 | Identicon | string | White | 5x5
![SHA512 Identicon](examples/SHA512_Identicon.png) | `SHA512` | 50x50 | Identicon | string | White | 5x5
![MD5 RobIII](examples/MD5_RobIII.png) | `MD5` | 50x50 | RobIII | string | White | 5x5
![RipeMD160 RobIII](examples/RIPEMD160_RobIII.png) | `RipeMD160` | 50x50 | RobIII | string | White | 5x5
![SHA1 RobIII](examples/SHA1_RobIII.png) | `SHA1` | 50x50 | RobIII | string | White | 5x5
![SHA256 RobIII](examples/SHA256_RobIII.png) | `SHA256` | 50x50 | RobIII | string | White | 5x5
![SHA384 RobIII](examples/SHA384_RobIII.png) | `SHA384` | 50x50 | RobIII | string | White | 5x5
![SHA512 RobIII](examples/SHA512_RobIII.png) | `SHA512` | 50x50 | RobIII | string | White | 5x5
![SHA512 RobIII](examples/SHA512_RobIII_t.png) | `SHA512` | 50x50 | RobIII | string | Transparent | 5x5
![SHA256 192.168.1.0](examples/SHA256_192.168.1.0_ipaddress.png) | `SHA256` | 50x50 | 192.168.1.0 | IPAddress | White | 5x5
![SHA256 192.168.1.10](examples/SHA256_192.168.1.10_ipaddress.png) | `SHA256` | 50x50 | 192.168.1.10 | IPAddress | White | 5x5
![SHA256 192.168.1.0](examples/SHA256_192.168.1.0_string.png) | `SHA256` | 50x50 | 192.168.1.0 | string | Black | 5x5
![SHA256 192.168.1.10](examples/SHA256_192.168.1.10_string.png) | `SHA256` | 50x50 | 192.168.1.10 | string | Black | 5x5
![SHA1 Foobar](examples/SHA1_Foobar_l.png) | `SHA1` | 50x50 | Foobar | string | Transparent | 5x5
![SHA1 FooBar](examples/SHA1_FooBar_u.png) | `SHA1` | 50x50 | FooBar | string | Transparent | 5x5
![MD5 foo_bar](examples/MD5_foo_bar_3.png) | `MD5` | 60x60 | foo_bar | string | Transparent | 3x3
![MD5 foo_bar](examples/MD5_foo_bar_4.png) | `MD5` | 60x60 | foo_bar | string | Transparent | 4x4
![MD5 foo_bar](examples/MD5_foo_bar_6.png) | `MD5` | 60x60 | foo_bar | string | Transparent | 6x6
![MD5 foo_bar](examples/MD5_foo_bar_12.png) | `MD5` | 60x60 | foo_bar | string | Transparent | 12x12
![MD5 foo_bar](examples/MD5_foo_bar_3_6.png) | `MD5` | 60x60 | foo_bar | string | Transparent | 3x6
![MD5 foo_bar](examples/MD5_foo_bar_6_3.png) | `MD5` | 60x60 | foo_bar | string | Transparent | 6x3
