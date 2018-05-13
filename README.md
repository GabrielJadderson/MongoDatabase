# MongoDatabase


##16.04, 17.04(not tested) 18.04


First we need to add the RSA public key to our package manager:
`$ sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv 2930ADAE8CAF5059EE73BB4B58712A2291FA4AD5`


then we need add to our package manager, the location of where to find the MongoDB binaries.
`$ echo "deb [ arch=amd64,arm64 ] https://repo.mongodb.org/apt/ubuntu xenial/mongodb-org/3.6 multiverse" | sudo tee /etc/apt/sources.list.d/mongodb-org-3.6.list`


We then need to reload our package manager.
`$ sudo apt-get update`

Then we install `mongodb-org`.
`$ sudo apt-get install -y mongodb-org`



##14.04


First we need to add the RSA public key to our package manager:
`$ sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv 2930ADAE8CAF5059EE73BB4B58712A2291FA4AD5` 


then we need add to our package manager, the location of where to find the MongoDB binaries.      
`$ echo "deb [ arch=amd64 ] https://repo.mongodb.org/apt/ubuntu trusty/mongodb-org/3.6 multiverse" | sudo tee /etc/apt/sources.list.d/mongodb-org-3.6.list`


We then need to reload our package manager.
`$ sudo apt-get update`

Then we install `mongodb-org`.
`$ sudo apt-get install -y mongodb-org`


