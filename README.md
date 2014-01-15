# NIdenticon

> "*An Identicon is a visual representation of a hash value, usually of an IP address, that serves to identify a user of a computer system as a form of avatar while protecting the users' privacy. The original Identicon was a 9-block graphic, and the representation has been extended to other graphic forms by third parties.*"
– [Wikipedia](http://en.wikipedia.org/wiki/Identicon)

NIdenticon is a library (available as NuGet package) that helps creating simple Identicons but is flexible enough to allow for tweaking the output to your heart's content.

## Usage

The most basic example is as follows:
    ```c#
        var g = new IdenticonGenerator(AlgorithmBox.Text);
        g.Create("Foo");
    ````

This will create an Identicon based on the string `foo` with all other options default; another example is:

    ```c#
        var g = new IdenticonGenerator(AlgorithmBox.Text);
        g.Create(HttpContext.Current.Request.UserHostAddress);
    ````

This creates an Identicon based on the IP-address of a remote host.