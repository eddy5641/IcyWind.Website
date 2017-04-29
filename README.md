# IcyWind.Website
The official website for IcyWind.

# IcyWindWebsite
This project allows users to create an account, manage basic settings and download the client.

The server will have certain features, and will be hosted on google's servers

For your password, use a strong password, that users will not be able to access, but is easy enough for you to remember.
The reset password feature will allow you to reset your password; however, it will wipe all critical stored account data
because this data is encrypted with the md5 hash of your password, and the stored password is a sha1 hash. This will make
it difficult for unauthorized users to use your accounts.

# IcyWindWebsite.API
This project is the api portion of the website. If you choose to use the IcyWindWebsite or want to have your own server
because you want to be super secure, or to allow only certain IP Addresses to be more secure, install this project onto your
server. You will need your own mySQL database as well.
