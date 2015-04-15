# FontAwesomeVS
Visual Studio Class Library for FontAwesome

This is a simple Class Library for use with Visual Studio that offers some simple implementations for FontAwesome, within Visual Studio. It mainly consists of an Enum containing the charcodes of the icons, and some helper functions.

# Implementation/Installation

* Reference to FaVS.dll from your project
* Import Namespace FontAwesome
* Write some code that calls FontAwesome.FaInstaller.Install() on the first time startup of your application to deploy the FontAwesome font to the font library.

# The Enumeration

The Enum 'Fa' contains a value for each icon, obtainable by the name used by FontAwesome, converted to Camelcase.

Example:
* fa-bed = Fa.Bed
* fa-align-left = Fa.AlignLeft
* fa-arrow-circle-o-down = Fa.ArrowCircleODown (Yes, that is a cappital o)

# Support Functions

* FaFont(Size);
Creates a new Font for controls with the given size(max height in pixels).
* FaString(Fa.[Name]);
Casts a character based on Fa.[Name]

Module FaInstaller
* FaInstaller.Install();
Installs FontAwesome to the Windows Font Library, and adds a RegEntry for it.
* FaInstaller.UnInstall();
Removes the RegEntry for FontAwesome, and removes FontAwesome from the Font Library.
