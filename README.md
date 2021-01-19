# Availiable parameters:

- [int] Take - range from 1 to 20
- [int] Skip - range from 0 to int.MaxValue
- [string] OrderBy - one of 'Email, FirstName, LastName, Address, PhoneNumber, FacebookLink, TwitterLink'
- [bool] Desc - true or false to select sorting order (false by default)
- [bool] WithFacebookLink - set to true to select only users with facebook link (false by default)

# Sample requests:

[GET] https://localhost:44307/api/users?take=11

[GET] https://localhost:44307/api/users?take=11&orderby=phoneNumber

[GET] https://localhost:44307/api/users?take=11&orderby=phoneNumber&desc=true&WithFacebookLink=true

# Configuration:

All user data stored in serialized form and loaded on application startup from JSON file.
Use configuration parameter 'AppSettings:MockDataFileName' to provide JSON file name which contains serialized Users.
