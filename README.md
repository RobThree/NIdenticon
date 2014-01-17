<img src="http://riii.nl/nidenticonlogo" width="32" height="32" alt="NIdenticon Logo"> NIdenticon
==========

> "*An Identicon is a visual representation of a hash value, usually of an IP address, that serves to identify a user of a computer system as a form of avatar while protecting the users' privacy. The original Identicon was a 9-block graphic, and the representation has been extended to other graphic forms by third parties.*"
– [Wikipedia](http://en.wikipedia.org/wiki/Identicon)

NIdenticon is a library (available as [NuGet package](https://www.nuget.org/packages/NIdenticon)) that helps creating simple Identicons but is flexible enough to allow for tweaking the output to your heart's content.

This project was inspired by:
 * [Github – Identicons!](https://github.com/blog/1586-identicons)
 * [David Hamp-Gonsalves – Generating Identicons](http://www.davidhampgonsalves.com/Identicons)
 * [Phil Haack – Identicons as Graphical Digital Fingerprints](http://haacked.com/archive/2007/01/22/Identicons_as_Visual_Fingerprints.aspx)
 * [Jeff Atwood – Identicons for .NET](http://www.codinghorror.com/blog/2007/01/identicons-for-net.html)

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

1. Do note that the `Create()` method and its overloads all return a `Bitmap` object; you have to take care of storing it, sending it to the browser or whatever you need to do. Also note that you might want to `Dispose()` the returned Identicon when no longer needed.

2. Also note that NIdenticon will round the image-dimensions DOWN to the nearest available size when the dimensions aren't exactly divisible by the horizontal/vertical blocks. Dimensions where width/horizontalblocks and height/verticalblocks are a multiple of oneanother work best (for example: for a width of 400 px you can use 2, 4, and 5 horizontal blocks but 6 will result in an image with a width of 396).

3. You might want to 'salt' your values (per Identicon (e.g. 'user' or 'account' for example) or per application, domain etc.) to make the Identicons even harder to 'reverse engineer'. A simple `myIDGenerator.Create(user.Email + user.Salt)` for example will do.

# Example

A simple Windows Forms application and sample ASP.Net MVC website is provided for you so you can explore the options and quickly see what the result will look like.

Below are some example images:

Result | Algorithm | Value | Blockgens | Background | Blocks | Brush
--- | --- | --- | --- | --- | --- | ---
![](examples/ex00.png) | `MD5` | `Identicon` | Extended | White | 6x6 | Static
![](examples/ex01.png) | `MD5` | `Identicon` | Extended | White | 6x6 | Static
![](examples/ex02.png) | `SHA256` | `Identicon` | Extended | White | 6x6 | Static
![](examples/ex03.png) | `SHA512` | `Identicon` | Extended | White | 6x6 | Static
![](examples/ex04.png) | `MD5` | `RobIII` | Extended | Transparent | 6x6 | Random
![](examples/ex05.png) | `RipeMD160` | `RobIII` | Extended | Transparent | 6x6 | Random
![](examples/ex06.png) | `SHA1` | `RobIII` | Extended | Transparent | 6x6 | Random
![](examples/ex07.png) | `SHA256` | `RobIII` | Extended | Transparent | 6x6 | Random
![](examples/ex08.png) | `SHA384` | `RobIII` | Extended | Transparent | 6x6 | Random
![](examples/ex09.png) | `SHA512` | `RobIII` | Extended | Transparent | 6x6 | Random
![](examples/ex10.png) | `SHA256` | `192.168.1.1` | Extended | Transparent | 6x6 | Static
![](examples/ex11.png) | `SHA256` | `192.168.1.2` | Extended | Transparent | 6x6 | Static
![](examples/ex12.png) | `SHA256` | `192.168.1.1` | Extended | Black | 6x6 | Static
![](examples/ex13.png) | `SHA256` | `192.168.1.2` | Extended | Black | 6x6 | Static
![](examples/ex14.png) | `SHA1` | `Foobar` | Extended | Black | 6x6 | Static
![](examples/ex15.png) | `SHA1` | `FooBar` | Extended | Black | 6x6 | Static
![](examples/ex16.png) | `MD5` | `foo_bar` | Extended | Transparent | 4x4 | Static
![](examples/ex17.png) | `MD5` | `foo_bar` | Extended | Transparent | 6x6 | Static
![](examples/ex18.png) | `MD5` | `foo_bar` | Extended | Transparent | 12x12 | Static
![](examples/ex19.png) | `MD5` | `foo_bar` | Default | Transparent | 4x6 | Static
![](examples/ex20.png) | `MD5` | `foo_bar` | Default | Transparent | 6x4 | Static
![](examples/ex21.png) | `SHA256` | `Identicon` | Extended | Transparent | 6x6 | Random
![](examples/ex22.png) | `SHA256` | `Identicon` | Extended | Transparent | 6x6 | Random
![](examples/ex23.png) | `SHA384` | `Identicon` | Custom<br>(Triangles only) | Transparent | 6x6 | Random
![](examples/ex24.png) | `SHA384` | `Identicon` | Custom<br>(Pie-slices only) | Transparent | 6x6 | Random
![](examples/ex25.png) | `SHA384` | `Identicon` | Custom<br>(Triangle + Pie in 4:1) | Transparent | 6x6 | Statics
