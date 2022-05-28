# MakeAPassword

This project is a password generating website to help our staff and students decide on more secure passwords, and to encourage help desk staff to use better temporary passwords that are easier to convey to users over the phone. Hopefully this project encourages better password hygene. 

This web application is designed to be reasonably cryptographically strong, to not store any information regarding what passwords were generated, and to provide a level of plausible deniability. The page generates a _lot_ of passwords, and has no way of knowing which one you've chosen, if you've chosen any at all.

## Deployment best practices

This web application is designed to run in a container. I would recommend that it be run with multiple replications, accross multiple worker nodes, and with a load balancer. This should make it much more difficult to predict the state of the random number generator being used, as it's never really clear what server the application is being run from.

This web application should be run over an SSL connection. The simplest way to do this is via a reverse-proxy that handles SSL, or via a load balancer that handles SSL.

## API endpoints

This web application provides several API endpoints that you can use in scripts. They also provide many passwords in one request, so if the request is intercepted, it's not clear which password was chosen, if any.

## Aren't random number generators considered not-secure?

This project does _not_ use the `Random` random number generator, which is not cryptographically secure. 

This project uses [System.Security.Cryptography.RandomNumberGenerator](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.randomnumbergenerator?view=net-6.0) instead, which at the time of this writing is considered cryptographically secure. 
