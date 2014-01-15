# NIdenticon

> "*An Identicon is a visual representation of a hash value, usually of an IP address, that serves to identify a user of a computer system as a form of avatar while protecting the users' privacy. The original Identicon was a 9-block graphic, and the representation has been extended to other graphic forms by third parties.*"
– [Wikipedia](http://en.wikipedia.org/wiki/Identicon)

NIdenticon is a library (available as NuGet package) that helps creating simple Identicons but is flexible enough to allow for tweaking the output to your heart's content.

## Usage

The most basic example is as follows:
```c#
var g = new IdenticonGenerator();
g.Create("foo");
````

This will create an Identicon based on the string `foo` with all other options default; another example is:
```c#
var g = new IdenticonGenerator();
g.Create(HttpContext.Current.Request.UserHostAddress);
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

Do note that the `Create()` method and its overloads all return a `Bitmap` object; you have to take care of storing it, sending it to the browser or whatever you need to do. Also note that you might want to `Dispose()` the returned Identicon when no longer needed.

A [test-application](NIdenticon/TestApp) is provided for you so you can explore the options and what the result will be.
