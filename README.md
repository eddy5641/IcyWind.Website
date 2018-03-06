# IcyWind.Website
The official website for IcyWind.

# IcyWindWebsite
This project allows users to create an account, manage basic settings and download the client.

The server will have certain features, and will be hosted on google's servers

For your password, use a strong password, that users will not be able to access, but is easy enough for you to remember.
The reset password feature will allow you to reset your password; however, it will wipe all critical stored account data
because this data is encrypted with the SHA256 hash of your password, and the stored password is a sha1 hash. This will make
it difficult for unauthorized users to use your accounts.

# IcyWindWebsite.API
This project is the api portion of the website. If you choose to use the IcyWindWebsite or want to have your own server
because you want to be super secure, or to allow only certain IP Addresses to be more secure, install this project onto your
server. You will need your own mySQL database as well.

# Note
If you use this project, you are only allowed to use this project for non-commercial use. In addition, your server cannot connect to any other servers, unless permission is granted.

You cannot edit the passwords of users (see their passwords). You are only able to reset and delete passwords. This cannot be modified as passwords are encrypted and decrypted clientside. The online passward management is disabled for all users as trasmitting the password over any network is unsecure.

If you want to use this on your own server box for profits, go ahead.

