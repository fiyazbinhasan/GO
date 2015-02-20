How to use

All the connection strings are configured in GOBD project's web.config

Database context file can be found in the GOBD.DATA project

POCOs can be found in the GOBD.MODEL project

insert a new point in the database with the specified latitude and longitude
api/Location/insert?lat=<lat>&lon=<lon>

finding nearest point in the database with the specifid latitude and longitude
api/Location/find?lat=<lat>&lon=<lon>
