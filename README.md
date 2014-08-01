WellItCouldWork (Spike)
===============

Instant testing for the .net world --  a small console app that takes the path of a test file and its corresponding solution file. Whenever the test file is saved the app parses the file to find any dependencies required referenced in the file, then builds a temporary assembly and runs the NUnit test runner against this little assembly i.e.
Output

![alt tag](http://enginechris.files.wordpress.com/2010/10/capture.jpg?w=640)
